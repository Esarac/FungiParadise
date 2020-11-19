namespace FungiParadise.Gui
{
    partial class ClassifyTab
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
            this.grid = new System.Windows.Forms.TableLayoutPanel();
            this.top = new System.Windows.Forms.FlowLayoutPanel();
            this.attributeLabel = new MetroFramework.Drawing.Html.HtmlLabel();
            this.valueComboBox = new MetroFramework.Controls.MetroComboBox();
            this.bottom = new System.Windows.Forms.FlowLayoutPanel();
            this.backButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.grid.SuspendLayout();
            this.top.SuspendLayout();
            this.bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.grid.ColumnCount = 1;
            this.grid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.grid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.grid.Controls.Add(this.top, 0, 0);
            this.grid.Controls.Add(this.bottom, 0, 1);
            this.grid.Location = new System.Drawing.Point(16, 180);
            this.grid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grid.Name = "grid";
            this.grid.RowCount = 2;
            this.grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.grid.Size = new System.Drawing.Size(532, 159);
            this.grid.TabIndex = 0;
            // 
            // top
            // 
            this.top.Controls.Add(this.attributeLabel);
            this.top.Controls.Add(this.valueComboBox);
            this.top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.top.Location = new System.Drawing.Point(3, 2);
            this.top.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.top.Name = "top";
            this.top.Size = new System.Drawing.Size(526, 75);
            this.top.TabIndex = 0;
            // 
            // attributeLabel
            // 
            this.attributeLabel.AutoScroll = true;
            this.attributeLabel.AutoScrollMinSize = new System.Drawing.Size(10, 0);
            this.attributeLabel.AutoSize = false;
            this.attributeLabel.BackColor = System.Drawing.SystemColors.Window;
            this.attributeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attributeLabel.Location = new System.Drawing.Point(3, 7);
            this.attributeLabel.Margin = new System.Windows.Forms.Padding(3, 7, 3, 2);
            this.attributeLabel.Name = "attributeLabel";
            this.attributeLabel.Size = new System.Drawing.Size(255, 57);
            this.attributeLabel.TabIndex = 0;
            // 
            // valueComboBox
            // 
            this.valueComboBox.FormattingEnabled = true;
            this.valueComboBox.ItemHeight = 24;
            this.valueComboBox.Location = new System.Drawing.Point(264, 2);
            this.valueComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.valueComboBox.Name = "valueComboBox";
            this.valueComboBox.Size = new System.Drawing.Size(121, 30);
            this.valueComboBox.TabIndex = 1;
            this.valueComboBox.UseSelectable = true;
            this.valueComboBox.Visible = false;
            // 
            // bottom
            // 
            this.bottom.Controls.Add(this.backButton);
            this.bottom.Controls.Add(this.nextButton);
            this.bottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottom.Location = new System.Drawing.Point(3, 81);
            this.bottom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bottom.Name = "bottom";
            this.bottom.Size = new System.Drawing.Size(526, 76);
            this.bottom.TabIndex = 1;
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.White;
            this.backButton.Enabled = false;
            this.backButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.Location = new System.Drawing.Point(85, 6);
            this.backButton.Margin = new System.Windows.Forms.Padding(85, 6, 3, 2);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(99, 34);
            this.backButton.TabIndex = 3;
            this.backButton.TabStop = false;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Visible = false;
            this.backButton.Click += new System.EventHandler(this.OnActionBackButton);
            this.backButton.MouseEnter += new System.EventHandler(this.OnMouseEnter);
            this.backButton.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            // 
            // nextButton
            // 
            this.nextButton.BackColor = System.Drawing.Color.White;
            this.nextButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.nextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextButton.Location = new System.Drawing.Point(198, 6);
            this.nextButton.Margin = new System.Windows.Forms.Padding(11, 6, 3, 2);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(99, 34);
            this.nextButton.TabIndex = 4;
            this.nextButton.TabStop = false;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = false;
            this.nextButton.Visible = false;
            this.nextButton.Click += new System.EventHandler(this.OnActionNextButton);
            this.nextButton.MouseEnter += new System.EventHandler(this.OnMouseEnter);
            this.nextButton.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            // 
            // ClassifyTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.grid);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ClassifyTab";
            this.Size = new System.Drawing.Size(824, 534);
            this.grid.ResumeLayout(false);
            this.top.ResumeLayout(false);
            this.bottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel grid;
        private System.Windows.Forms.FlowLayoutPanel top;
        private MetroFramework.Drawing.Html.HtmlLabel attributeLabel;
        private MetroFramework.Controls.MetroComboBox valueComboBox;
        private System.Windows.Forms.FlowLayoutPanel bottom;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button nextButton;
    }
}
