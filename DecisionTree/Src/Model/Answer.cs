using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Model
{
    public class Answer : Node
    {
        //Attribute
        private string classValue;

        //Constructor
        public Answer(string attribute, string classValue)
        {
            this.attribute = attribute;
            this.classValue = classValue;
        }

        
        public override string ToString(int number)
        {
            return "Answer: " + classValue;
        }
    }
}
