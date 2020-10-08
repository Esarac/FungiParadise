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
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.importButton = new System.Windows.Forms.Button();
            this.tabMenu = new MetroFramework.Controls.MetroTabControl();
            this.tableTab = new MetroFramework.Controls.MetroTabPage();
            this.chartsTab = new MetroFramework.Controls.MetroTabPage();
            this.infoTab = new MetroFramework.Controls.MetroTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            this.metroStyleManager1.Style = MetroFramework.MetroColorStyle.Green;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.importButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(10, 60);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1060, 35);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // importButton
            // 
            this.importButton.BackColor = System.Drawing.Color.White;
            this.importButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.importButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.importButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importButton.Location = new System.Drawing.Point(15, 2);
            this.importButton.Margin = new System.Windows.Forms.Padding(15, 2, 3, 2);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(88, 31);
            this.importButton.TabIndex = 2;
            this.importButton.TabStop = false;
            this.importButton.Text = "Import";
            this.importButton.UseVisualStyleBackColor = false;
            this.importButton.MouseLeave += new System.EventHandler(this.OnMouseLeaveImportButton);
            this.importButton.MouseHover += new System.EventHandler(this.OnMouseHoverImportButton);
            // 
            // tabMenu
            // 
            this.tabMenu.Controls.Add(this.tableTab);
            this.tabMenu.Controls.Add(this.chartsTab);
            this.tabMenu.Controls.Add(this.infoTab);
            this.tabMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMenu.Location = new System.Drawing.Point(10, 95);
            this.tabMenu.Margin = new System.Windows.Forms.Padding(2);
            this.tabMenu.Name = "tabMenu";
            this.tabMenu.SelectedIndex = 2;
            this.tabMenu.Size = new System.Drawing.Size(1060, 616);
            this.tabMenu.TabIndex = 1;
            this.tabMenu.UseSelectable = true;
            // 
            // tableTab
            // 
            this.tableTab.HorizontalScrollbarBarColor = true;
            this.tableTab.HorizontalScrollbarHighlightOnWheel = false;
            this.tableTab.HorizontalScrollbarSize = 130;
            this.tableTab.Location = new System.Drawing.Point(4, 38);
            this.tableTab.Margin = new System.Windows.Forms.Padding(2);
            this.tableTab.Name = "tableTab";
            this.tableTab.Size = new System.Drawing.Size(1052, 574);
            this.tableTab.TabIndex = 0;
            this.tableTab.Text = "  Table";
            this.tableTab.VerticalScrollbarBarColor = true;
            this.tableTab.VerticalScrollbarHighlightOnWheel = false;
            this.tableTab.VerticalScrollbarSize = 80;
            // 
            // chartsTab
            // 
            this.chartsTab.HorizontalScrollbarBarColor = true;
            this.chartsTab.HorizontalScrollbarHighlightOnWheel = false;
            this.chartsTab.HorizontalScrollbarSize = 130;
            this.chartsTab.Location = new System.Drawing.Point(4, 38);
            this.chartsTab.Margin = new System.Windows.Forms.Padding(2);
            this.chartsTab.Name = "chartsTab";
            this.chartsTab.Size = new System.Drawing.Size(1052, 574);
            this.chartsTab.TabIndex = 1;
            this.chartsTab.Text = "  Charts";
            this.chartsTab.VerticalScrollbarBarColor = true;
            this.chartsTab.VerticalScrollbarHighlightOnWheel = false;
            this.chartsTab.VerticalScrollbarSize = 80;
            // 
            // infoTab
            // 
            this.infoTab.HorizontalScrollbarBarColor = true;
            this.infoTab.HorizontalScrollbarHighlightOnWheel = false;
            this.infoTab.HorizontalScrollbarSize = 130;
            this.infoTab.Location = new System.Drawing.Point(4, 38);
            this.infoTab.Margin = new System.Windows.Forms.Padding(2);
            this.infoTab.Name = "infoTab";
            this.infoTab.Size = new System.Drawing.Size(1052, 574);
            this.infoTab.TabIndex = 2;
            this.infoTab.Text = "  Information";
            this.infoTab.VerticalScrollbarBarColor = true;
            this.infoTab.VerticalScrollbarHighlightOnWheel = false;
            this.infoTab.VerticalScrollbarSize = 80;
            // 
            // window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(4F, 7F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 720);
            this.Controls.Add(this.tabMenu);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "window";
            this.Padding = new System.Windows.Forms.Padding(10, 60, 10, 9);
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Fungi Paradise";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tabMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroTabControl tabMenu;
        private MetroFramework.Controls.MetroTabPage tableTab;
        private MetroFramework.Controls.MetroTabPage chartsTab;
        private MetroFramework.Controls.MetroTabPage infoTab;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button importButton;
    }
}

