namespace FungiParadise.Src.Gui
{
    partial class ExperimentTab
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
            this.experimentProgBar = new MetroFramework.Controls.MetroProgressBar();
            this.runButton = new System.Windows.Forms.Button();
            this.logText = new MetroFramework.Drawing.Html.HtmlPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // experimentProgBar
            // 
            this.experimentProgBar.Location = new System.Drawing.Point(80, 3);
            this.experimentProgBar.Margin = new System.Windows.Forms.Padding(80, 3, 3, 7);
            this.experimentProgBar.Name = "experimentProgBar";
            this.experimentProgBar.Size = new System.Drawing.Size(181, 23);
            this.experimentProgBar.TabIndex = 0;
            // 
            // runButton
            // 
            this.runButton.BackColor = System.Drawing.Color.White;
            this.runButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.runButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.runButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runButton.Location = new System.Drawing.Point(130, 146);
            this.runButton.Margin = new System.Windows.Forms.Padding(130, 7, 3, 2);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(99, 34);
            this.runButton.TabIndex = 5;
            this.runButton.TabStop = false;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = false;
            // 
            // logText
            // 
            this.logText.AutoScroll = true;
            this.logText.AutoScrollMinSize = new System.Drawing.Size(359, 0);
            this.logText.BackColor = System.Drawing.SystemColors.Window;
            this.logText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logText.Location = new System.Drawing.Point(3, 36);
            this.logText.Name = "logText";
            this.logText.Size = new System.Drawing.Size(359, 100);
            this.logText.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.experimentProgBar, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.runButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.logText, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(94, 146);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(365, 182);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // ExperimentTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ExperimentTab";
            this.Size = new System.Drawing.Size(800, 600);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroProgressBar experimentProgBar;
        private System.Windows.Forms.Button runButton;
        private MetroFramework.Drawing.Html.HtmlPanel logText;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
