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
            Train(data);
        }

        //Methods
        public void Train(DataTable data)
        {
            rootNode = new Decision(data);
        }

        public override string ToString()
        {
            string text = "Decision Tree:";
            text += "\n"+((Decision)rootNode).ToString(1);

            return text;
        }

    }
}
