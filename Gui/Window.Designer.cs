namespace FungiParadise.Gui
{
    partial class window
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.styleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.panel = new System.Windows.Forms.FlowLayoutPanel();
            this.importButton = new System.Windows.Forms.Button();
            this.tabMenu = new MetroFramework.Controls.MetroTabControl();
            this.tabTable = new MetroFramework.Controls.MetroTabPage();
            this.tabCharts = new MetroFramework.Controls.MetroTabPage();
            this.tabInfo = new MetroFramework.Controls.MetroTabPage();
            this.tableTab = new FungiParadise.Gui.TableTab();
            this.chartTab = new FungiParadise.Gui.ChartTab();
            this.infoTab = new FungiParadise.Gui.InfoTab();
            ((System.ComponentModel.ISupportInitialize)(this.styleManager)).BeginInit();
            this.panel.SuspendLayout();
            this.tabMenu.SuspendLayout();
            this.tabTable.SuspendLayout();
            this.tabCharts.SuspendLayout();
            this.tabInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // styleManager
            // 
            this.styleManager.Owner = this;
            this.styleManager.Style = MetroFramework.MetroColorStyle.Green;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.importButton);
            this.panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel.Location = new System.Drawing.Point(20, 60);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1040, 47);
            this.panel.TabIndex = 0;
            // 
            // importButton
            // 
            this.importButton.BackColor = System.Drawing.Color.White;
            this.importButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.importButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.importButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importButton.Location = new System.Drawing.Point(15, 12);
            this.importButton.Margin = new System.Windows.Forms.Padding(15, 12, 0, 0);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(99, 34);
            this.importButton.TabIndex = 2;
            this.importButton.TabStop = false;
            this.importButton.Text = "Import";
            this.importButton.UseVisualStyleBackColor = false;
            this.importButton.Click += new System.EventHandler(this.ImportButtonClick);
            this.importButton.MouseLeave += new System.EventHandler(this.OnMouseLeaveImportButton);
            this.importButton.MouseHover += new System.EventHandler(this.OnMouseHoverImportButton);
            // 
            // tabMenu
            // 
            this.tabMenu.Controls.Add(this.tabTable);
            this.tabMenu.Controls.Add(this.tabCharts);
            this.tabMenu.Controls.Add(this.tabInfo);
            this.tabMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMenu.Location = new System.Drawing.Point(20, 107);
            this.tabMenu.Name = "tabMenu";
            this.tabMenu.SelectedIndex = 0;
            this.tabMenu.Size = new System.Drawing.Size(1040, 593);
            this.tabMenu.TabIndex = 1;
            this.tabMenu.UseSelectable = true;
            // 
            // tabTable
            // 
            this.tabTable.Controls.Add(this.tableTab);
            this.tabTable.HorizontalScrollbarBarColor = false;
            this.tabTable.HorizontalScrollbarHighlightOnWheel = false;
            this.tabTable.HorizontalScrollbarSize = 0;
            this.tabTable.Location = new System.Drawing.Point(4, 38);
            this.tabTable.Name = "tabTable";
            this.tabTable.Size = new System.Drawing.Size(1032, 551);
            this.tabTable.TabIndex = 0;
            this.tabTable.Text = "  Table";
            this.tabTable.VerticalScrollbarBarColor = false;
            this.tabTable.VerticalScrollbarHighlightOnWheel = false;
            this.tabTable.VerticalScrollbarSize = 0;
            // 
            // tabCharts
            // 
            this.tabCharts.Controls.Add(this.chartTab);
            this.tabCharts.HorizontalScrollbarBarColor = true;
            this.tabCharts.HorizontalScrollbarHighlightOnWheel = false;
            this.tabCharts.HorizontalScrollbarSize = 0;
            this.tabCharts.Location = new System.Drawing.Point(4, 38);
            this.tabCharts.Name = "tabCharts";
            this.tabCharts.Size = new System.Drawing.Size(1032, 551);
            this.tabCharts.TabIndex = 1;
            this.tabCharts.Text = "  Charts";
            this.tabCharts.VerticalScrollbarBarColor = true;
            this.tabCharts.VerticalScrollbarHighlightOnWheel = false;
            this.tabCharts.VerticalScrollbarSize = 0;
            // 
            // tabInfo
            // 
            this.tabInfo.Controls.Add(this.infoTab);
            this.tabInfo.HorizontalScrollbarBarColor = true;
            this.tabInfo.HorizontalScrollbarHighlightOnWheel = false;
            this.tabInfo.HorizontalScrollbarSize = 0;
            this.tabInfo.Location = new System.Drawing.Point(4, 38);
            this.tabInfo.Name = "tabInfo";
            this.tabInfo.Size = new System.Drawing.Size(1032, 551);
            this.tabInfo.TabIndex = 2;
            this.tabInfo.Text = "  Information";
            this.tabInfo.VerticalScrollbarBarColor = true;
            this.tabInfo.VerticalScrollbarHighlightOnWheel = false;
            this.tabInfo.VerticalScrollbarSize = 0;
            // 
            // tableTab
            // 
            this.tableTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableTab.Location = new System.Drawing.Point(0, 0);
            this.tableTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableTab.Name = "tableTab";
            this.tableTab.Size = new System.Drawing.Size(1032, 551);
            this.tableTab.TabIndex = 0;
            // 
            // chartTab
            // 
            this.chartTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartTab.Location = new System.Drawing.Point(0, 0);
            this.chartTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartTab.Name = "chartTab";
            this.chartTab.Size = new System.Drawing.Size(1032, 551);
            this.chartTab.TabIndex = 2;
            // 
            // infoTab
            // 
            this.infoTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoTab.Location = new System.Drawing.Point(0, 0);
            this.infoTab.Name = "infoTab";
            this.infoTab.Size = new System.Drawing.Size(1032, 551);
            this.infoTab.TabIndex = 2;
            // 
            // window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 720);
            this.Controls.Add(this.tabMenu);
            this.Controls.Add(this.panel);
            this.Name = "window";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Fungi Paradise";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.styleManager)).EndInit();
            this.panel.ResumeLayout(false);
            this.tabMenu.ResumeLayout(false);
            this.tabTable.ResumeLayout(false);
            this.tabCharts.ResumeLayout(false);
            this.tabInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager styleManager;
        private System.Windows.Forms.FlowLayoutPanel panel;
        private System.Windows.Forms.Button importButton;
        private MetroFramework.Controls.MetroTabControl tabMenu;
        private MetroFramework.Controls.MetroTabPage tabTable;
        private MetroFramework.Controls.MetroTabPage tabCharts;
        private MetroFramework.Controls.MetroTabPage tabInfo;
        private TableTab tableTab;
        private ChartTab chartTab;
        private InfoTab infoTab;
    }
}