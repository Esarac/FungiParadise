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
            this.components = new System.ComponentModel.Container();
            this.experimentProgBar = new MetroFramework.Controls.MetroProgressBar();
            this.runButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.logConsole = new MetroFramework.Drawing.Html.HtmlLabel();
            this.styleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.styleManager)).BeginInit();
            this.SuspendLayout();
            // 
            // experimentProgBar
            // 
            this.experimentProgBar.Location = new System.Drawing.Point(268, 2);
            this.experimentProgBar.Margin = new System.Windows.Forms.Padding(268, 2, 2, 12);
            this.experimentProgBar.Name = "experimentProgBar";
            this.experimentProgBar.Size = new System.Drawing.Size(136, 19);
            this.experimentProgBar.TabIndex = 0;
            this.experimentProgBar.Visible = false;
            // 
            // runButton
            // 
            this.runButton.BackColor = System.Drawing.Color.White;
            this.runButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.runButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.runButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runButton.Location = new System.Drawing.Point(308, 118);
            this.runButton.Margin = new System.Windows.Forms.Padding(308, 12, 2, 2);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(74, 28);
            this.runButton.TabIndex = 5;
            this.runButton.TabStop = false;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = false;
            this.runButton.Visible = false;
            this.runButton.Click += new System.EventHandler(this.OnClickRunExperiment);
            this.runButton.MouseEnter += new System.EventHandler(this.OnMouseEnter);
            this.runButton.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.experimentProgBar, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.runButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.logConsole, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 160);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(682, 148);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // logConsole
            // 
            this.logConsole.AutoScroll = true;
            this.logConsole.AutoScrollMinSize = new System.Drawing.Size(10, 0);
            this.logConsole.AutoSize = false;
            this.logConsole.BackColor = System.Drawing.SystemColors.Window;
            this.logConsole.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.logConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logConsole.Location = new System.Drawing.Point(3, 36);
            this.logConsole.Name = "logConsole";
            this.logConsole.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.logConsole.Size = new System.Drawing.Size(676, 67);
            this.logConsole.TabIndex = 6;
            // 
            // styleManager
            // 
            this.styleManager.Owner = this;
            this.styleManager.Style = MetroFramework.MetroColorStyle.Green;
            // 
            // ExperimentTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ExperimentTab";
            this.Size = new System.Drawing.Size(939, 488);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.styleManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroProgressBar experimentProgBar;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Components.MetroStyleManager styleManager;
        private MetroFramework.Drawing.Html.HtmlLabel logConsole;
    }
}
