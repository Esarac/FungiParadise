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

namespace FungiParadise.Gui
{
    public partial class ChartTab : UserControl
    {
        //Attributes
        private Manager manager;

        public ChartTab()
        {
            InitializeComponent();
        }

        public void InitializeChartTab(Manager manager)
        {
            this.manager = manager;

            GenerateTypeChart();
            GenerateOdorChart();
            GenerateRingNumberChart();
            GenerateBruisesChart();
            GenerateCapColorChart();
        }

        private void GenerateTypeChart()
        {
            //Config
            typeChart.Series["s"].XValueMember = "X";
            typeChart.Series["s"].YValueMembers = "Y";
            //...
            typeChart.DataSource = manager.GenerateTypeChart();
            typeChart.DataBind();
        }

        private void GenerateOdorChart()
        {
            //Config
            odorChart.Series["s"].XValueMember = "X";
            odorChart.Series["s"].YValueMembers = "Y";
            //...
            odorChart.DataSource = manager.GenerateOdorChart();
            odorChart.DataBind();
        }

        private void GenerateRingNumberChart()
        {
            //Config
            ringNumberChart.Series["s"].XValueMember = "X";
            ringNumberChart.Series["s"].YValueMembers = "Y";
            //...
            ringNumberChart.DataSource = manager.GenerateRingNumberChart();
            ringNumberChart.DataBind();
        }

        private void GenerateBruisesChart()
        {
            //Config
            bruisesChart.Series["s"].XValueMember = "X";
            bruisesChart.Series["s"].YValueMembers = "Y";
            //...
            bruisesChart.DataSource = manager.GenerateBruisesChart();
            bruisesChart.DataBind();
        }

        private void GenerateCapColorChart()
        {
            //Config
            capColorChart.Series["s"].XValueMember = "X";
            capColorChart.Series["s"].YValueMembers = "Y";
            //...
            capColorChart.DataSource = manager.GenerateCapColorChart();
            capColorChart.DataBind();
        }

    }
}
