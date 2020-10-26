using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Model
{
    public class Answer : Node
    {
        //Attribute
        private string classValue;

        //Property
        public string ClassValue { get { return classValue; } set { this.classValue = value; } }

        //Constructor
        public Answer(string attribute, string classValue)
        {
            this.attribute = attribute;
            this.classValue = classValue;
        }

        //Method
        public override string ToString(int number)
        {
            return "Answer: " + classValue;
        }
    }
}
