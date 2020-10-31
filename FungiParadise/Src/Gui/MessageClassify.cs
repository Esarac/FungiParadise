using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FungiParadise.Src.Gui
{
    public partial class MessageClassify : MetroFramework.Forms.MetroForm
    {
        //Atrributes
        List<string> attributes;
        List<char> values;
        string classification;

        public MessageClassify()
        {
            InitializeComponent();
        }

        //Initializers
        public void InitializeClassifyMessage(List<string> attributes, List<char> values, string classification)
        {
            this.attributes = attributes;
            this.values = values;
            this.classification = classification;
            showMessage();
        }

        //Methods
        public void showMessage()
        {
            string message = "";

            for (int i = 0; i < values.Count; i++)
            {
                message += "<h4 style=\"color: #00b300;\">" + attributes[i] + ":</h4> \n<p>" + values[i] + "</p>";
            }

            message += "<h3 style =\"color: #004d00;\">CLASSIFICATION:</h3> " + "\n<p>" + classification + "<p>";

            messageLabel.Text = message;
        }
    }
}
