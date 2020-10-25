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
        private Node rootNode;

        //Constructor
        public DecisionTree(DataTable data){
            GenerateDecisionTree(data);
        }

        //Methods
        public void GenerateDecisionTree(DataTable data)
        {
            rootNode = new Decision(data, 1);
        }

        public override string ToString()
        {
            string text = "Decision Tree:";
            text += "\n"+((Decision)rootNode).ToString(1);

            return text;
        }

    }
}
