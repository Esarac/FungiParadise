namespace FungiParadise.Gui
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
            this.orientationLabel = new MetroFramework.Drawing.Html.HtmlLabel();
            this.orientationComboBox = new MetroFramework.Controls.MetroComboBox();
            this.typeLabel = new MetroFramework.Drawing.Html.HtmlLabel();
            this.typeComboBox = new MetroFramework.Controls.MetroComboBox();
            this.picPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.picTree = new System.Windows.Forms.PictureBox();
            this.styleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.successLabel = new MetroFramework.Drawing.Html.HtmlLabel();
            this.successPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.headerPanel.SuspendLayout();
            this.picPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleManager)).BeginInit();
            this.successPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.Controls.Add(this.orientationLabel);
            this.headerPanel.Controls.Add(this.orientationComboBox);
            this.headerPanel.Controls.Add(this.typeLabel);
            this.headerPanel.Controls.Add(this.typeComboBox);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(800, 40);
            this.headerPanel.TabIndex = 0;
            // 
            // orientationLabel
            // 
            this.orientationLabel.AutoScroll = true;
            this.orientationLabel.AutoScrollMinSize = new System.Drawing.Size(86, 27);
            this.orientationLabel.AutoSize = false;
            this.orientationLabel.BackColor = System.Drawing.SystemColors.Window;
            this.orientationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orientationLabel.Location = new System.Drawing.Point(0, 7);
            this.orientationLabel.Margin = new System.Windows.Forms.Padding(0, 7, 0, 3);
            this.orientationLabel.Name = "orientationLabel";
            this.orientationLabel.Size = new System.Drawing.Size(110, 40);
            this.orientationLabel.TabIndex = 3;
            this.orientationLabel.Text = "       Orientation";
            // 
            // orientationComboBox
            // 
            this.orientationComboBox.Enabled = false;
            this.orientationComboBox.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.orientationComboBox.FormattingEnabled = true;
            this.orientationComboBox.ItemHeight = 21;
            this.orientationComboBox.Location = new System.Drawing.Point(110, 7);
            this.orientationComboBox.Margin = new System.Windows.Forms.Padding(0, 7, 3, 2);
            this.orientationComboBox.Name = "orientationComboBox";
            this.orientationComboBox.Size = new System.Drawing.Size(120, 27);
            this.orientationComboBox.TabIndex = 2;
            this.orientationComboBox.UseSelectable = true;
            this.orientationComboBox.SelectedIndexChanged += new System.EventHandler(this.OrientationComboBoxSelectedIndexChanged);
            // 
            // typeLabel
            // 
            this.typeLabel.AutoScroll = true;
            this.typeLabel.AutoScrollMinSize = new System.Drawing.Size(44, 27);
            this.typeLabel.AutoSize = false;
            this.typeLabel.BackColor = System.Drawing.SystemColors.Window;
            this.typeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeLabel.Location = new System.Drawing.Point(241, 7);
            this.typeLabel.Margin = new System.Windows.Forms.Padding(8, 7, 0, 3);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(56, 40);
            this.typeLabel.TabIndex = 4;
            this.typeLabel.Text = "Type";
            // 
            // typeComboBox
            // 
            this.typeComboBox.Enabled = false;
            this.typeComboBox.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.ItemHeight = 21;
            this.typeComboBox.Location = new System.Drawing.Point(297, 7);
            this.typeComboBox.Margin = new System.Windows.Forms.Padding(0, 7, 3, 2);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(210, 27);
            this.typeComboBox.TabIndex = 5;
            this.typeComboBox.UseSelectable = true;
            // 
            // picPanel
            // 
            this.picPanel.AutoScroll = true;
            this.picPanel.Controls.Add(this.picTree);
            this.picPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picPanel.Location = new System.Drawing.Point(0, 40);
            this.picPanel.Name = "picPanel";
            this.picPanel.Size = new System.Drawing.Size(800, 560);
            this.picPanel.TabIndex = 1;
            // 
            // picTree
            // 
            this.picTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picTree.Location = new System.Drawing.Point(3, 3);
            this.picTree.Name = "picTree";
            this.picTree.Size = new System.Drawing.Size(100, 50);
            this.picTree.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picTree.TabIndex = 0;
            this.picTree.TabStop = false;
            this.picTree.Paint += new System.Windows.Forms.PaintEventHandler(this.PicTreePaint);
            this.picTree.Resize += new System.EventHandler(this.PicTreeReSize);
            // 
            // styleManager
            // 
            this.styleManager.Owner = this;
            this.styleManager.Style = MetroFramework.MetroColorStyle.Green;
            // 
            // successLabel
            // 
            this.successLabel.AutoScroll = true;
            this.successLabel.AutoScrollMinSize = new System.Drawing.Size(10, 0);
            this.successLabel.AutoSize = false;
            this.successLabel.BackColor = System.Drawing.SystemColors.Window;
            this.successLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.successLabel.Location = new System.Drawing.Point(0, 0);
            this.successLabel.Margin = new System.Windows.Forms.Padding(0);
            this.successLabel.Name = "successLabel";
            this.successLabel.Size = new System.Drawing.Size(298, 40);
            this.successLabel.TabIndex = 4;
            // 
            // successPanel
            // 
            this.successPanel.Controls.Add(this.successLabel);
            this.successPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.successPanel.Location = new System.Drawing.Point(0, 582);
            this.successPanel.Name = "successPanel";
            this.successPanel.Size = new System.Drawing.Size(800, 18);
            this.successPanel.TabIndex = 2;
            // 
            // TreeTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.successPanel);
            this.Controls.Add(this.picPanel);
            this.Controls.Add(this.headerPanel);
            this.Name = "TreeTab";
            this.Size = new System.Drawing.Size(800, 600);
            this.headerPanel.ResumeLayout(false);
            this.picPanel.ResumeLayout(false);
            this.picPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleManager)).EndInit();
            this.successPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel headerPanel;
        private System.Windows.Forms.FlowLayoutPanel picPanel;
        private System.Windows.Forms.PictureBox picTree;
        private MetroFramework.Components.MetroStyleManager styleManager;
        private MetroFramework.Controls.MetroComboBox orientationComboBox;
        private MetroFramework.Drawing.Html.HtmlLabel orientationLabel;
        private MetroFramework.Drawing.Html.HtmlLabel successLabel;
        private System.Windows.Forms.FlowLayoutPanel successPanel;
        private MetroFramework.Drawing.Html.HtmlLabel typeLabel;
        private MetroFramework.Controls.MetroComboBox typeComboBox;
    }
}
