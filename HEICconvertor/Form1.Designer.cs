using System.Resources;

namespace HEICconvertor
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtInputFolder = new TextBox();
            this.txtOutputFolder = new TextBox();
            this.btnBrowseInput = new Button();
            this.btnBrowseOutput = new Button();
            this.progressBar = new ProgressBar();
            this.btnGo = new Button();
            this.lblInput = new Label();
            this.lblOutput = new Label();
            this.labelVersion = new Label();

            // 
            // txtInputFolder
            // 
            this.txtInputFolder.Location = new System.Drawing.Point(12, 32);
            this.txtInputFolder.Name = "txtInputFolder";
            this.txtInputFolder.Size = new System.Drawing.Size(400, 23);
            this.txtInputFolder.TabIndex = 0;
            this.txtInputFolder.TextChanged += new System.EventHandler(this.txtInputFolder_TextChanged);

            // 
            // txtOutputFolder
            // 
            this.txtOutputFolder.Location = new System.Drawing.Point(12, 82);
            this.txtOutputFolder.Name = "txtOutputFolder";
            this.txtOutputFolder.Size = new System.Drawing.Size(400, 23);
            this.txtOutputFolder.TabIndex = 2;
            this.txtOutputFolder.TextChanged += new System.EventHandler(this.txtOutputFolder_TextChanged);

            // 
            // btnBrowseInput
            // 
            this.btnBrowseInput.Location = new System.Drawing.Point(418, 31);
            this.btnBrowseInput.Name = "btnBrowseInput";
            this.btnBrowseInput.Size = new System.Drawing.Size(75, 25);
            this.btnBrowseInput.TabIndex = 1;
            this.btnBrowseInput.Text = "Browse...";
            this.btnBrowseInput.Click += new System.EventHandler(this.btnBrowseInput_Click);

            // 
            // btnBrowseOutput
            // 
            this.btnBrowseOutput.Location = new System.Drawing.Point(418, 81);
            this.btnBrowseOutput.Name = "btnBrowseOutput";
            this.btnBrowseOutput.Size = new System.Drawing.Size(75, 25);
            this.btnBrowseOutput.TabIndex = 3;
            this.btnBrowseOutput.Text = "Browse...";
            this.btnBrowseOutput.Click += new System.EventHandler(this.btnBrowseOutput_Click);

            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 120);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(481, 23);
            this.progressBar.TabIndex = 4;

            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(418, 158);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 25);
            this.btnGo.TabIndex = 5;
            this.btnGo.Text = "Go";
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);

            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Location = new System.Drawing.Point(12, 14);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(69, 15);
            this.lblInput.TabIndex = 6;
            this.lblInput.Text = "Input Folder:";

            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(12, 64);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(79, 15);
            this.lblOutput.TabIndex = 7;
            this.lblOutput.Text = "Output Folder:";

            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(12, 165);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(40, 15);
            this.labelVersion.TabIndex = 8;
            this.labelVersion.Text = "v1.0.0";

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 195);
            this.Controls.Add(this.lblInput);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.txtInputFolder);
            this.Controls.Add(this.txtOutputFolder);
            this.Controls.Add(this.btnBrowseInput);
            this.Controls.Add(this.btnBrowseOutput);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.labelVersion);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "HEIC to JPG Converter";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private TextBox txtInputFolder;
        private TextBox txtOutputFolder;
        private Button btnBrowseInput;
        private Button btnBrowseOutput;
        private ProgressBar progressBar;
        private Button btnGo;
        private Label lblInput;
        private Label lblOutput;
        private Label labelVersion;
    }
}