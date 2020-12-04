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
using System.Threading;

namespace FungiParadise.Src.Gui
{
    public partial class ExperimentTab : UserControl
    {
        //Attributes
        private Manager manager;
        private delegate void ProgressBarValueDelegate(int value);
        private delegate void LogConsoleTextDelegate(string text);
        private delegate void EnableButtonDelegate(bool enable);

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

        private void VisibleComponents()
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
            experimentProgBar.Maximum = manager.TotalLoadedData;
            logConsole.Text = "";
            runButton.Enabled = false;

            Thread thrExperiment = new Thread(() => { manager.GenerateExperiments(); });
            thrExperiment.IsBackground = true;
            thrExperiment.Start();

            Thread thrProgressBar = new Thread(ProgressBar);
            thrProgressBar.IsBackground = true;
            thrProgressBar.Start();
        }

        //Methods
        private void ProgressBar()
        {
            int loadedData = manager.LoadedData;
            int totalLoadedData = manager.TotalLoadedData;

            while(loadedData < totalLoadedData)
            {
                string text = manager.ActualLine;

                experimentProgBar.Invoke(new ProgressBarValueDelegate(ProgressBarValue), manager.LoadedData);
                logConsole.Invoke(new LogConsoleTextDelegate(LogConsoleText), text);

                loadedData = manager.LoadedData;
                totalLoadedData = manager.TotalLoadedData;
            }

            experimentProgBar.Invoke(new ProgressBarValueDelegate(ProgressBarValue), manager.TotalLoadedData);
            logConsole.Invoke(new LogConsoleTextDelegate(LogConsoleText), "Done!");

            manager.LoadedData = 0;
            runButton.Invoke(new EnableButtonDelegate(EnableButton), true);
        }

        private void ProgressBarValue(int value)
        {
            experimentProgBar.Value = value;
        }

        private void LogConsoleText(string text)
        {
            logConsole.Text = text;
        }

        private void EnableButton(bool enable)
        {
            runButton.Enabled = enable;
        }

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
