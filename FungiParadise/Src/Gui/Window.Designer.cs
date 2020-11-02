namespace FungiParadise.Gui
{
    partial class Window
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Window));
            this.styleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.panel = new System.Windows.Forms.FlowLayoutPanel();
            this.importButton = new System.Windows.Forms.Button();
            this.tabMenu = new MetroFramework.Controls.MetroTabControl();
            this.tabTable = new MetroFramework.Controls.MetroTabPage();
            this.tableTab = new FungiParadise.Gui.TableTab();
            this.tabCharts = new MetroFramework.Controls.MetroTabPage();
            this.chartTab = new FungiParadise.Gui.ChartTab();
            this.tabTree = new MetroFramework.Controls.MetroTabPage();
            this.treeTab = new FungiParadise.Gui.TreeTab();
            this.tabClassify = new MetroFramework.Controls.MetroTabPage();
            this.classifyTab = new FungiParadise.Gui.ClassifyTab();
            this.tabInfo = new MetroFramework.Controls.MetroTabPage();
            this.infoTab = new FungiParadise.Gui.InfoTab();
            ((System.ComponentModel.ISupportInitialize)(this.styleManager)).BeginInit();
            this.panel.SuspendLayout();
            this.tabMenu.SuspendLayout();
            this.tabTable.SuspendLayout();
            this.tabCharts.SuspendLayout();
            this.tabTree.SuspendLayout();
            this.tabClassify.SuspendLayout();
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
            this.panel.Location = new System.Drawing.Point(20, 74);
            this.panel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1040, 40);
            this.panel.TabIndex = 0;
            // 
            // importButton
            // 
            this.importButton.BackColor = System.Drawing.Color.White;
            this.importButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.importButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.importButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importButton.Location = new System.Drawing.Point(15, 5);
            this.importButton.Margin = new System.Windows.Forms.Padding(15, 5, 0, 0);
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
            this.tabMenu.Controls.Add(this.tabTree);
            this.tabMenu.Controls.Add(this.tabClassify);
            this.tabMenu.Controls.Add(this.tabInfo);
            this.tabMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMenu.Location = new System.Drawing.Point(20, 114);
            this.tabMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabMenu.Name = "tabMenu";
            this.tabMenu.SelectedIndex = 0;
            this.tabMenu.Size = new System.Drawing.Size(1040, 586);
            this.tabMenu.TabIndex = 0;
            this.tabMenu.UseSelectable = true;
            // 
            // tabTable
            // 
            this.tabTable.Controls.Add(this.tableTab);
            this.tabTable.HorizontalScrollbarBarColor = false;
            this.tabTable.HorizontalScrollbarHighlightOnWheel = false;
            this.tabTable.HorizontalScrollbarSize = 0;
            this.tabTable.Location = new System.Drawing.Point(4, 38);
            this.tabTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabTable.Name = "tabTable";
            this.tabTable.Size = new System.Drawing.Size(1032, 544);
            this.tabTable.TabIndex = 0;
            this.tabTable.Text = "  Table";
            this.tabTable.VerticalScrollbarBarColor = false;
            this.tabTable.VerticalScrollbarHighlightOnWheel = false;
            this.tabTable.VerticalScrollbarSize = 0;
            // 
            // tableTab
            // 
            this.tableTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableTab.Location = new System.Drawing.Point(0, 0);
            this.tableTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableTab.Name = "tableTab";
            this.tableTab.Size = new System.Drawing.Size(1032, 544);
            this.tableTab.TabIndex = 0;
            // 
            // tabCharts
            // 
            this.tabCharts.Controls.Add(this.chartTab);
            this.tabCharts.HorizontalScrollbarBarColor = true;
            this.tabCharts.HorizontalScrollbarHighlightOnWheel = false;
            this.tabCharts.HorizontalScrollbarSize = 0;
            this.tabCharts.Location = new System.Drawing.Point(4, 38);
            this.tabCharts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabCharts.Name = "tabCharts";
            this.tabCharts.Size = new System.Drawing.Size(1032, 544);
            this.tabCharts.TabIndex = 1;
            this.tabCharts.Text = " Charts";
            this.tabCharts.VerticalScrollbarBarColor = true;
            this.tabCharts.VerticalScrollbarHighlightOnWheel = false;
            this.tabCharts.VerticalScrollbarSize = 0;
            // 
            // chartTab
            // 
            this.chartTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartTab.Location = new System.Drawing.Point(0, 0);
            this.chartTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartTab.Name = "chartTab";
            this.chartTab.Size = new System.Drawing.Size(1032, 544);
            this.chartTab.TabIndex = 2;
            // 
            // tabTree
            // 
            this.tabTree.Controls.Add(this.treeTab);
            this.tabTree.HorizontalScrollbarBarColor = true;
            this.tabTree.HorizontalScrollbarHighlightOnWheel = false;
            this.tabTree.HorizontalScrollbarSize = 0;
            this.tabTree.Location = new System.Drawing.Point(4, 38);
            this.tabTree.Name = "tabTree";
            this.tabTree.Size = new System.Drawing.Size(1032, 544);
            this.tabTree.TabIndex = 3;
            this.tabTree.Text = "  Decision Tree";
            this.tabTree.VerticalScrollbarBarColor = true;
            this.tabTree.VerticalScrollbarHighlightOnWheel = false;
            this.tabTree.VerticalScrollbarSize = 0;
            // 
            // treeTab
            // 
            this.treeTab.BackColor = System.Drawing.Color.White;
            this.treeTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeTab.Location = new System.Drawing.Point(0, 0);
            this.treeTab.Name = "treeTab";
            this.treeTab.Size = new System.Drawing.Size(1032, 544);
            this.treeTab.TabIndex = 2;
            // 
            // tabClassify
            // 
            this.tabClassify.Controls.Add(this.classifyTab);
            this.tabClassify.HorizontalScrollbarBarColor = true;
            this.tabClassify.HorizontalScrollbarHighlightOnWheel = false;
            this.tabClassify.HorizontalScrollbarSize = 0;
            this.tabClassify.Location = new System.Drawing.Point(4, 38);
            this.tabClassify.Name = "tabClassify";
            this.tabClassify.Size = new System.Drawing.Size(1032, 544);
            this.tabClassify.TabIndex = 4;
            this.tabClassify.Text = " Classify";
            this.tabClassify.VerticalScrollbarBarColor = true;
            this.tabClassify.VerticalScrollbarHighlightOnWheel = false;
            this.tabClassify.VerticalScrollbarSize = 0;
            // 
            // classifyTab
            // 
            this.classifyTab.BackColor = System.Drawing.Color.White;
            this.classifyTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.classifyTab.Location = new System.Drawing.Point(0, 0);
            this.classifyTab.Name = "classifyTab";
            this.classifyTab.Size = new System.Drawing.Size(1032, 544);
            this.classifyTab.TabIndex = 2;
            // 
            // tabInfo
            // 
            this.tabInfo.Controls.Add(this.infoTab);
            this.tabInfo.HorizontalScrollbarBarColor = true;
            this.tabInfo.HorizontalScrollbarHighlightOnWheel = false;
            this.tabInfo.HorizontalScrollbarSize = 0;
            this.tabInfo.Location = new System.Drawing.Point(4, 38);
            this.tabInfo.Name = "tabInfo";
            this.tabInfo.Size = new System.Drawing.Size(1032, 544);
            this.tabInfo.TabIndex = 5;
            this.tabInfo.Text = " Information";
            this.tabInfo.VerticalScrollbarBarColor = true;
            this.tabInfo.VerticalScrollbarHighlightOnWheel = false;
            this.tabInfo.VerticalScrollbarSize = 0;
            // 
            // infoTab
            // 
            this.infoTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoTab.Location = new System.Drawing.Point(0, 0);
            this.infoTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.infoTab.Name = "infoTab";
            this.infoTab.Size = new System.Drawing.Size(1032, 544);
            this.infoTab.TabIndex = 3;
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 720);
            this.Controls.Add(this.tabMenu);
            this.Controls.Add(this.panel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1080, 720);
            this.Name = "Window";
            this.Padding = new System.Windows.Forms.Padding(20, 74, 20, 20);
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Fungi Paradise";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.styleManager)).EndInit();
            this.panel.ResumeLayout(false);
            this.tabMenu.ResumeLayout(false);
            this.tabTable.ResumeLayout(false);
            this.tabCharts.ResumeLayout(false);
            this.tabTree.ResumeLayout(false);
            this.tabClassify.ResumeLayout(false);
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
        private TableTab tableTab;
        private ChartTab chartTab;
        private MetroFramework.Controls.MetroTabPage tabTree;
        private Gui.TreeTab treeTab;
        private MetroFramework.Controls.MetroTabPage tabClassify;
        private Gui.ClassifyTab classifyTab;
        private MetroFramework.Controls.MetroTabPage tabInfo;
        private InfoTab infoTab;
    }
}