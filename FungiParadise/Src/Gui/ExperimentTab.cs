using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FungiParadise.Model;

namespace FungiParadise.Src.Gui
{
    public partial class ExperimentTab : UserControl
    {
        //Attributes
        private Manager manager;

        public ExperimentTab()
        {
            InitializeComponent();
        }

        //Initializers

        public void InitializeExperimentTab(Manager manager)
        {
            this.manager = manager;
            VisibleComponents();
        }

        public void VisibleComponents()
        {
            runButton.Visible = true;
            logConsole.Visible = true;
        }

        //Triggers
        private void OnMouseEnter(object sender, EventArgs e)
        {
            MouseEnterColor((Button)sender);
        }

        private void OnMouseLeave(object sender, EventArgs e)
        {
            MouseLeavesColor((Button)sender);
        }

        private void OnClickRunExperiment(object sender, EventArgs e)
        {
            experimentProgBar.Visible = true;
        }

        //Methods
        private void MouseEnterColor<T>(T button) where T : Button
        {
            button.BackColor = Color.FromArgb(58, 145, 84);
            button.ForeColor = Color.White;
        }

        private void MouseLeavesColor<T>(T button) where T : Button
        {
            button.BackColor = Color.White;
            button.ForeColor = Color.Black;
        }
    }
}
