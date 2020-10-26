using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Model
{
    public class DecisionTree
    {
        //Attribute
        private Decision rootNode;

        //Constructor
        public DecisionTree(DataTable data){
            Train(data);
        }

        //Method
        public void Train(DataTable data)
        {
            rootNode = new Decision(data);
        }

        public string[] Classify(DataTable data)
        {
            string[] dataClass = new string[data.Rows.Count];

            //Classify each row
            for (int i = 0; i < data.Rows.Count; i++)
            {
                dataClass[i] = rootNode.Classify(data.Rows[i]);
            }
            //...

            return dataClass;
        }

        public double Test(DataTable data)
        {
            string[] dataClass = Classify(data);

            double test = 0;
            for(int i = 0; i < data.Rows.Count; i++)
            {
                if (dataClass[i].Equals(""+data.Rows[i][0]))
                {
                    test += 1;
                }
            }
            test /= (double)dataClass.Length;

            return test;
        }

        //ToString
        public override string ToString()
        {
            string text = "Decision Tree:";
            text += "\n"+((Decision)rootNode).ToString(1);

            return text;
        }

    }
}
