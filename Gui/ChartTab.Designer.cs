namespace FungiParadise.Gui
{
    partial class ChartTab
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabMenu = new MetroFramework.Controls.MetroTabControl();
            this.tabTypeChart = new MetroFramework.Controls.MetroTabPage();
            this.tabOdorChart = new MetroFramework.Controls.MetroTabPage();
            this.tabRingNumberChart = new MetroFramework.Controls.MetroTabPage();
            this.tabBruisesChart = new MetroFramework.Controls.MetroTabPage();
            this.tabCapColorChart = new MetroFramework.Controls.MetroTabPage();
            this.styleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.tabMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.styleManager)).BeginInit();
            this.SuspendLayout();
            // 
            // tabMenu
            // 
            this.tabMenu.Controls.Add(this.tabTypeChart);
            this.tabMenu.Controls.Add(this.tabOdorChart);
            this.tabMenu.Controls.Add(this.tabRingNumberChart);
            this.tabMenu.Controls.Add(this.tabBruisesChart);
            this.tabMenu.Controls.Add(this.tabCapColorChart);
            this.tabMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMenu.Location = new System.Drawing.Point(0, 0);
            this.tabMenu.Name = "tabMenu";
            this.tabMenu.SelectedIndex = 0;
            this.tabMenu.Size = new System.Drawing.Size(800, 600);
            this.tabMenu.TabIndex = 0;
            this.tabMenu.UseSelectable = true;
            // 
            // tabTypeChart
            // 
            this.tabTypeChart.HorizontalScrollbarBarColor = true;
            this.tabTypeChart.HorizontalScrollbarHighlightOnWheel = false;
            this.tabTypeChart.HorizontalScrollbarSize = 0;
            this.tabTypeChart.Location = new System.Drawing.Point(4, 38);
            this.tabTypeChart.Name = "tabTypeChart";
            this.tabTypeChart.Size = new System.Drawing.Size(792, 558);
            this.tabTypeChart.TabIndex = 0;
            this.tabTypeChart.Text = "  Type";
            this.tabTypeChart.VerticalScrollbarBarColor = true;
            this.tabTypeChart.VerticalScrollbarHighlightOnWheel = false;
            this.tabTypeChart.VerticalScrollbarSize = 0;
            // 
            // tabOdorChart
            // 
            this.tabOdorChart.HorizontalScrollbarBarColor = true;
            this.tabOdorChart.HorizontalScrollbarHighlightOnWheel = false;
            this.tabOdorChart.HorizontalScrollbarSize = 0;
            this.tabOdorChart.Location = new System.Drawing.Point(4, 38);
            this.tabOdorChart.Name = "tabOdorChart";
            this.tabOdorChart.Size = new System.Drawing.Size(792, 558);
            this.tabOdorChart.TabIndex = 1;
            this.tabOdorChart.Text = "  Odor";
            this.tabOdorChart.VerticalScrollbarBarColor = true;
            this.tabOdorChart.VerticalScrollbarHighlightOnWheel = false;
            this.tabOdorChart.VerticalScrollbarSize = 0;
            // 
            // tabRingNumberChart
            // 
            this.tabRingNumberChart.HorizontalScrollbarBarColor = true;
            this.tabRingNumberChart.HorizontalScrollbarHighlightOnWheel = false;
            this.tabRingNumberChart.HorizontalScrollbarSize = 0;
            this.tabRingNumberChart.Location = new System.Drawing.Point(4, 38);
            this.tabRingNumberChart.Name = "tabRingNumberChart";
            this.tabRingNumberChart.Size = new System.Drawing.Size(792, 558);
            this.tabRingNumberChart.TabIndex = 2;
            this.tabRingNumberChart.Text = "  Ring number";
            this.tabRingNumberChart.VerticalScrollbarBarColor = true;
            this.tabRingNumberChart.VerticalScrollbarHighlightOnWheel = false;
            this.tabRingNumberChart.VerticalScrollbarSize = 0;
            // 
            // tabBruisesChart
            // 
            this.tabBruisesChart.HorizontalScrollbarBarColor = true;
            this.tabBruisesChart.HorizontalScrollbarHighlightOnWheel = false;
            this.tabBruisesChart.HorizontalScrollbarSize = 0;
            this.tabBruisesChart.Location = new System.Drawing.Point(4, 38);
            this.tabBruisesChart.Name = "tabBruisesChart";
            this.tabBruisesChart.Size = new System.Drawing.Size(792, 558);
            this.tabBruisesChart.TabIndex = 3;
            this.tabBruisesChart.Text = "  Bruises";
            this.tabBruisesChart.VerticalScrollbarBarColor = true;
            this.tabBruisesChart.VerticalScrollbarHighlightOnWheel = false;
            this.tabBruisesChart.VerticalScrollbarSize = 0;
            // 
            // tabCapColorChart
            // 
            this.tabCapColorChart.HorizontalScrollbarBarColor = true;
            this.tabCapColorChart.HorizontalScrollbarHighlightOnWheel = false;
            this.tabCapColorChart.HorizontalScrollbarSize = 0;
            this.tabCapColorChart.Location = new System.Drawing.Point(4, 38);
            this.tabCapColorChart.Name = "tabCapColorChart";
            this.tabCapColorChart.Size = new System.Drawing.Size(792, 558);
            this.tabCapColorChart.TabIndex = 4;
            this.tabCapColorChart.Text = "  Cap color";
            this.tabCapColorChart.VerticalScrollbarBarColor = true;
            this.tabCapColorChart.VerticalScrollbarHighlightOnWheel = false;
            this.tabCapColorChart.VerticalScrollbarSize = 0;
            // 
            // styleManager
            // 
            this.styleManager.Owner = this;
            this.styleManager.Style = MetroFramework.MetroColorStyle.Green;
            // 
            // ChartTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabMenu);
            this.Name = "ChartTab";
            this.Size = new System.Drawing.Size(800, 600);
            this.tabMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.styleManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl tabMenu;
        private MetroFramework.Controls.MetroTabPage tabTypeChart;
        private MetroFramework.Controls.MetroTabPage tabOdorChart;
        private MetroFramework.Controls.MetroTabPage tabRingNumberChart;
        private MetroFramework.Controls.MetroTabPage tabBruisesChart;
        private MetroFramework.Controls.MetroTabPage tabCapColorChart;
        private MetroFramework.Components.MetroStyleManager styleManager;
    }
}
