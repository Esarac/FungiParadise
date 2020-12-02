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
            this.logConsole = new MetroFramework.Drawing.Html.HtmlPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.styleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.styleManager)).BeginInit();
            this.SuspendLayout();
            // 
            // experimentProgBar
            // 
            this.experimentProgBar.Location = new System.Drawing.Point(357, 3);
            this.experimentProgBar.Margin = new System.Windows.Forms.Padding(357, 3, 3, 15);
            this.experimentProgBar.Name = "experimentProgBar";
            this.experimentProgBar.Size = new System.Drawing.Size(181, 23);
            this.experimentProgBar.TabIndex = 0;
            this.experimentProgBar.Visible = false;
            // 
            // runButton
            // 
            this.runButton.BackColor = System.Drawing.Color.White;
            this.runButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.runButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.runButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runButton.Location = new System.Drawing.Point(410, 146);
            this.runButton.Margin = new System.Windows.Forms.Padding(410, 15, 3, 2);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(99, 34);
            this.runButton.TabIndex = 5;
            this.runButton.TabStop = false;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = false;
            this.runButton.Visible = false;
            this.runButton.Click += new System.EventHandler(this.OnClickRunExperiment);
            this.runButton.MouseEnter += new System.EventHandler(this.OnMouseEnter);
            this.runButton.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            // 
            // logConsole
            // 
            this.logConsole.AutoScroll = true;
            this.logConsole.AutoScrollMinSize = new System.Drawing.Size(928, 0);
            this.logConsole.BackColor = System.Drawing.SystemColors.Window;
            this.logConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logConsole.Location = new System.Drawing.Point(3, 44);
            this.logConsole.Name = "logConsole";
            this.logConsole.Size = new System.Drawing.Size(903, 84);
            this.logConsole.TabIndex = 6;
            this.logConsole.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.experimentProgBar, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.logConsole, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.runButton, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 197);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(909, 182);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // styleManager
            // 
            this.styleManager.Owner = this;
            this.styleManager.Style = MetroFramework.MetroColorStyle.Green;
            // 
            // ExperimentTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ExperimentTab";
            this.Size = new System.Drawing.Size(1252, 600);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.styleManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroProgressBar experimentProgBar;
        private System.Windows.Forms.Button runButton;
        private MetroFramework.Drawing.Html.HtmlPanel logConsole;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Components.MetroStyleManager styleManager;
    }
}
