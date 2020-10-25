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
        public string FindClass(DataTable data)
        {
            //Find columnClass
            string columnClass = "";
            bool run = true;
            for (int i = 0; (i < data.Columns.Count) && run; i++)
            {
                if (data.Columns[i].DataType == typeof(string))
                {
                    columnClass = data.Columns[i].ColumnName;
                    run = false;
                }
            }
            //...

            return columnClass;
        }

        public bool IsLeaf(DataTable data)
        {
            string columnClass = FindClass(data);

            //Get Classes
            List<string> classes = new List<string>(data.Rows.Count);
            foreach (DataRow row in data.Rows)
                classes.Add("" + row[columnClass]);
            classes = classes.Distinct().ToList();
            //...

            return classes.Count == 1;
        }

        public abstract string ToString(int number);

    }
}
