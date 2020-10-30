using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Model
{
    public abstract class Node
    {
        //Attribute
        protected string attribute;

        //Property
        public string Attribute { get { return attribute; } set { this.attribute = value; } }

        //Aux
        protected bool IsLeaf(DataTable data)
        {
            //Get Classes
            List<string> classes = new List<string>(data.Rows.Count);
            foreach (DataRow row in data.Rows)
                classes.Add("" + row[0]);
            classes = classes.Distinct().ToList();
            //...

            return classes.Count == 1;
        }

        //ToString
        public abstract string ToString(int number);

    }
}
