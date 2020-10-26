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
        private string[] questions;

        //Constructor
        public Decision(DataTable data) {
            Grow(data);
        }

        //Train
        private void Grow(DataTable data)
        {
            //Find the value
            this.attribute = BestValue(data);
            //...

            //Generate Questions and Branches
            List<string> allQuestions = new List<string>(data.Rows.Count);
            foreach (DataRow row in data.Rows)
                allQuestions.Add(""+row[attribute]);
            this.questions = allQuestions.Distinct().ToList().ToArray();

            this.childrens = new Node[this.questions.Length];
            //...

            //Create the nodes for each question
            for (int i = 0; i < questions.Length; i++)
            {
                //Sub DataTable
                DataTable subData = data.Copy();

                List<DataRow> rows = new List<DataRow>();
                foreach (DataRow row in subData.Rows)
                {
                    if (!questions[i].Equals(""+row[attribute]))
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
                    this.childrens[i] = new Decision(subData);
                }
                else
                {
                    string columnClass = data.Columns[0].ColumnName;
                    string valueClass = (string)subData.Rows[0][columnClass];
                    this.childrens[i] = new Answer(columnClass, valueClass);
                }
                    
                //...
            }
            //...
        }

        private string BestValue(DataTable data)
        {
            string[] columnNames = data.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();

            //Find columnClass
            string columnClass = data.Columns[0].ColumnName;
            //...

            //Find Min Entropy
            double minEntropy = 1;
            string bestAttribute = "";
            foreach(string attribute in columnNames)
            {
                if (!columnClass.Equals(attribute))
                {
                    double entropy = Entropy(data, attribute);
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

        private double Entropy(DataTable data, string columnName){
            //Get Classes
            List<string> classes = new List<string>(data.Rows.Count);
            foreach (DataRow row in data.Rows)
                classes.Add(""+row[data.Columns[0].ColumnName]);
            classes = classes.Distinct().ToList();
            //...

            //Get Values
            List<string> values = new List<string>(data.Rows.Count);
            foreach (DataRow row in data.Rows)
                values.Add(""+row[columnName]);
            values = values.Distinct().ToList();
            //...

            double entropy = 0;
            foreach(string value in values){

                int[] valueProportion = new int[classes.Count];
                int valueTotal = 0;
                foreach (DataRow row in data.Rows)
                {
                    //If is actual value sum to the total and sum the total of the specific class
                    if (value.Equals(""+row[columnName]))
                    {
                        for (int i = 0; i < classes.Count; i++)
                        {
                            if (classes[i].Equals((string)row[data.Columns[0].ColumnName]))
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
