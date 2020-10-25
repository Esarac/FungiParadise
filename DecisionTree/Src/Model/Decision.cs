using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Data.Common;

namespace DecisionTree.Model
{
    public class Decision : Node
    {
        //Attribute
        private Node[] childrens;
        private char[] questions;

        //Constructor
        public Decision(DataTable data, int number) {
            Grow(data, number);
        }

        //Learn
        public void Grow(DataTable data, int number)
        {
            this.attribute = BestValue(data);

            //Generate Branches
            List<char> allQuestions = new List<char>(data.Rows.Count);
            foreach (DataRow row in data.Rows)
                allQuestions.Add((char)row[attribute]);
            this.questions = allQuestions.Distinct().ToList().ToArray();

            this.childrens = new Node[this.questions.Length];
            //...

            for (int i = 0; i < questions.Length; i++)
            {
                //Sub DataTable
                DataTable subData = data.Copy();

                List<DataRow> rows = new List<DataRow>();
                foreach (DataRow row in subData.Rows)
                {
                    if ((char)row[attribute] != questions[i])
                    {
                        rows.Add(row);
                    }
                }
                foreach(DataRow row in rows)
                    subData.Rows.Remove(row);

                subData.Columns.Remove(attribute);
                //...

                //Add Decision
                if (!IsLeaf(subData))
                {
                    this.childrens[i] = new Decision(subData, number+1);
                }
                else
                {
                    List<string> classes = new List<string>(subData.Rows.Count);
                    foreach (DataRow row in subData.Rows)
                        classes.Add("" + row[FindClass(subData)]);
                    classes = classes.Distinct().ToList();
                    string singleClass = classes[0];
                    this.childrens[i] = new Answer(FindClass(subData), singleClass, number+1);
                }
                    
                //...
            }
        }

        public string BestValue(DataTable data)
        {
            string[] columnNames = data.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();

            //Find columnClass
            string columnClass = FindClass(data);
            //...

            //Find Min Entropy
            double minEntropy = 1;
            string bestAttribute = "";
            foreach(string attribute in columnNames)
            {
                if (!columnClass.Equals(attribute))
                {
                    double entropy = Entropy(data, attribute, columnClass);
                    if (entropy < minEntropy)
                    {
                        minEntropy = entropy;
                        bestAttribute = attribute;
                    }
                }
            }
            //...

            return bestAttribute;
        }

        public double Entropy(DataTable data, string columnName, string columnClass){
            //Get Classes
            List<string> classes = new List<string>(data.Rows.Count);
            foreach (DataRow row in data.Rows)
                classes.Add(""+row[columnClass]);
            classes = classes.Distinct().ToList();
            //...

            //Get Values
            List<char> values = new List<char>(data.Rows.Count);
            foreach (DataRow row in data.Rows)
                values.Add((char)row[columnName]);
            values = values.Distinct().ToList();
            //...

            double entropy = 0;
            foreach(char value in values){

                int[] valueProportion = new int[classes.Count];
                int valueTotal = 0;
                foreach (DataRow row in data.Rows)
                {
                    //If Value
                    if ((char)row[columnName] == value)
                    {
                        for (int i = 0; i < classes.Count; i++)
                        {
                            if (classes[i].Equals((string)row[columnClass]))
                            {
                                valueProportion[i] += 1;
                            }
                        }
                        valueTotal += 1;
                    }
                    //...
                }

                //Calculate Value Entropy
                double valueEntropy = 1;
                for (int i = 0; i < valueProportion.Length; i++)
                {
                    valueEntropy -= Math.Pow( ((double)valueProportion[i]) / ((double)valueTotal), 2);
                }
                entropy += valueEntropy * (1/((double)values.Count));
                //...

                
            }

            return entropy;
        }

        public override string ToString(int number)
        {
            string text = "Decision: "+attribute;
            for(int i=0; i < childrens.Length; i++)
            {
                text += "\n";
                for (int j = 0; j < number; j++)
                    text += "   ";
                text += questions[i] + ". " + childrens[i].ToString(number+1);
            }

            return text;
        }


    }
}
