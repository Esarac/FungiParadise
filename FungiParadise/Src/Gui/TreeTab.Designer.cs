namespace FungiParadise.Src.Gui
{
    partial class TreeTab
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
            this.headerPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.orientationLabel = new System.Windows.Forms.Label();
            this.picPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.picTree = new System.Windows.Forms.PictureBox();
            this.orientationComboBox = new MetroFramework.Controls.MetroComboBox();
            this.styleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.headerPanel.SuspendLayout();
            this.picPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleManager)).BeginInit();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.Controls.Add(this.orientationLabel);
            this.headerPanel.Controls.Add(this.orientationComboBox);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(800, 41);
            this.headerPanel.TabIndex = 0;
            // 
            // orientationLabel
            // 
            this.orientationLabel.AutoSize = true;
            this.orientationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orientationLabel.Location = new System.Drawing.Point(11, 11);
            this.orientationLabel.Margin = new System.Windows.Forms.Padding(11, 11, 3, 0);
            this.orientationLabel.Name = "orientationLabel";
            this.orientationLabel.Size = new System.Drawing.Size(91, 20);
            this.orientationLabel.TabIndex = 0;
            this.orientationLabel.Text = "Orientation";
            // 
            // picPanel
            // 
            this.picPanel.AutoScroll = true;
            this.picPanel.Controls.Add(this.picTree);
            this.picPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picPanel.Location = new System.Drawing.Point(0, 41);
            this.picPanel.Name = "picPanel";
            this.picPanel.Size = new System.Drawing.Size(800, 559);
            this.picPanel.TabIndex = 1;
            // 
            // picTree
            // 
            this.picTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picTree.Location = new System.Drawing.Point(3, 3);
            this.picTree.Name = "picTree";
            this.picTree.Size = new System.Drawing.Size(100, 100);
            this.picTree.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picTree.TabIndex = 1;
            this.picTree.TabStop = false;
            this.picTree.Paint += new System.Windows.Forms.PaintEventHandler(this.PicTreePaint);
            this.picTree.Resize += new System.EventHandler(this.PicTreeReSize);
            // 
            // orientationComboBox
            // 
            this.orientationComboBox.Enabled = false;
            this.orientationComboBox.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.orientationComboBox.FormattingEnabled = true;
            this.orientationComboBox.ItemHeight = 21;
            this.orientationComboBox.Location = new System.Drawing.Point(109, 7);
            this.orientationComboBox.Margin = new System.Windows.Forms.Padding(4, 7, 3, 2);
            this.orientationComboBox.Name = "orientationComboBox";
            this.orientationComboBox.Size = new System.Drawing.Size(120, 27);
            this.orientationComboBox.TabIndex = 2;
            this.orientationComboBox.UseSelectable = true;
            // 
            // styleManager
            // 
            this.styleManager.Owner = this;
            this.styleManager.Style = MetroFramework.MetroColorStyle.Green;
            // 
            // TreeTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.picPanel);
            this.Controls.Add(this.headerPanel);
            this.Name = "TreeTab";
            this.Size = new System.Drawing.Size(800, 600);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.picPanel.ResumeLayout(false);
            this.picPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel headerPanel;
        private System.Windows.Forms.Label orientationLabel;
        private System.Windows.Forms.FlowLayoutPanel picPanel;
        private System.Windows.Forms.PictureBox picTree;
        private MetroFramework.Controls.MetroComboBox orientationComboBox;
        private MetroFramework.Components.MetroStyleManager styleManager;
    }
}
