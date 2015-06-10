namespace planningIX
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_ApplicationsVersions = new System.Windows.Forms.TextBox();
            this.start = new System.Windows.Forms.Button();
            this.resultRTB = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_ApplicationsVersions);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(783, 59);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Application Versions";
            // 
            // tb_ApplicationsVersions
            // 
            this.tb_ApplicationsVersions.Location = new System.Drawing.Point(6, 21);
            this.tb_ApplicationsVersions.Name = "tb_ApplicationsVersions";
            this.tb_ApplicationsVersions.Size = new System.Drawing.Size(771, 22);
            this.tb_ApplicationsVersions.TabIndex = 0;
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(316, 375);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(171, 104);
            this.start.TabIndex = 1;
            this.start.Text = "Start Import";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // resultRTB
            // 
            this.resultRTB.Location = new System.Drawing.Point(18, 77);
            this.resultRTB.Name = "resultRTB";
            this.resultRTB.Size = new System.Drawing.Size(771, 292);
            this.resultRTB.TabIndex = 2;
            this.resultRTB.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 507);
            this.Controls.Add(this.resultRTB);
            this.Controls.Add(this.start);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_ApplicationsVersions;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.RichTextBox resultRTB;
    }
}

