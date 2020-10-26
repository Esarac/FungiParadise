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

        //Properties
        public string Attribute { get { return attribute; } set { this.attribute = value; } }

        //Aux
        public bool IsLeaf(DataTable data)
        {
            //Get Classes
            List<string> classes = new List<string>(data.Rows.Count);
            foreach (DataRow row in data.Rows)
                classes.Add("" + row[data.Columns[0].ColumnName]);
            classes = classes.Distinct().ToList();
            //...

            return classes.Count == 1;
        }

        public abstract string ToString(int number);

    }
}
