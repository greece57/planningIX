﻿namespace planningIX
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
            this.deleteApplications = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tb_ITComplienceReport = new System.Windows.Forms.TextBox();
            this.test = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tb_ComponentVersions = new System.Windows.Forms.TextBox();
            this.deleteComponents = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tb_applicationInterfaces = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tb_ComponentUsage = new System.Windows.Forms.TextBox();
            this.DeleteComponentConnections = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tb_businessSupport = new System.Windows.Forms.TextBox();
            this.deleteBusinessCapabilities = new System.Windows.Forms.Button();
            this.DeleteUserGroups = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
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
            this.tb_ApplicationsVersions.Text = "C:\\Users\\Niko\\Downloads\\EA_Output\\EA_Output\\Application___Application_Version (1)" +
    ".xlsx";
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(24, 603);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(171, 104);
            this.start.TabIndex = 1;
            this.start.Text = "Start Import";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // resultRTB
            // 
            this.resultRTB.Location = new System.Drawing.Point(24, 403);
            this.resultRTB.Name = "resultRTB";
            this.resultRTB.Size = new System.Drawing.Size(771, 196);
            this.resultRTB.TabIndex = 2;
            this.resultRTB.Text = "";
            // 
            // deleteApplications
            // 
            this.deleteApplications.Location = new System.Drawing.Point(624, 605);
            this.deleteApplications.Name = "deleteApplications";
            this.deleteApplications.Size = new System.Drawing.Size(171, 48);
            this.deleteApplications.TabIndex = 3;
            this.deleteApplications.Text = "Delete all Applications";
            this.deleteApplications.UseVisualStyleBackColor = true;
            this.deleteApplications.Click += new System.EventHandler(this.deleteApplications_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tb_ITComplienceReport);
            this.groupBox2.Location = new System.Drawing.Point(12, 77);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(783, 59);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "IT Complience Report";
            // 
            // tb_ITComplienceReport
            // 
            this.tb_ITComplienceReport.Location = new System.Drawing.Point(6, 21);
            this.tb_ITComplienceReport.Name = "tb_ITComplienceReport";
            this.tb_ITComplienceReport.Size = new System.Drawing.Size(771, 22);
            this.tb_ITComplienceReport.TabIndex = 0;
            this.tb_ITComplienceReport.Text = "C:\\Users\\Niko\\Downloads\\EA_Output\\EA_Output\\IT_Compliance_Report.xlsx";
            // 
            // test
            // 
            this.test.Location = new System.Drawing.Point(214, 605);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(64, 48);
            this.test.TabIndex = 4;
            this.test.Text = "Test Import";
            this.test.UseVisualStyleBackColor = true;
            this.test.Click += new System.EventHandler(this.test_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tb_ComponentVersions);
            this.groupBox3.Location = new System.Drawing.Point(12, 207);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(783, 59);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Component Versions";
            // 
            // tb_ComponentVersions
            // 
            this.tb_ComponentVersions.Location = new System.Drawing.Point(6, 21);
            this.tb_ComponentVersions.Name = "tb_ComponentVersions";
            this.tb_ComponentVersions.Size = new System.Drawing.Size(771, 22);
            this.tb_ComponentVersions.TabIndex = 0;
            this.tb_ComponentVersions.Text = "C:\\Users\\Niko\\Downloads\\EA_Output\\EA_Output\\Component___Component_Version (1).xls" +
    "x";
            // 
            // deleteComponents
            // 
            this.deleteComponents.Location = new System.Drawing.Point(624, 659);
            this.deleteComponents.Name = "deleteComponents";
            this.deleteComponents.Size = new System.Drawing.Size(171, 48);
            this.deleteComponents.TabIndex = 5;
            this.deleteComponents.Text = "Delete all Components";
            this.deleteComponents.UseVisualStyleBackColor = true;
            this.deleteComponents.Click += new System.EventHandler(this.deleteComponents_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tb_applicationInterfaces);
            this.groupBox4.Location = new System.Drawing.Point(12, 142);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(783, 59);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Application Interfaces";
            // 
            // tb_applicationInterfaces
            // 
            this.tb_applicationInterfaces.Location = new System.Drawing.Point(6, 21);
            this.tb_applicationInterfaces.Name = "tb_applicationInterfaces";
            this.tb_applicationInterfaces.Size = new System.Drawing.Size(771, 22);
            this.tb_applicationInterfaces.TabIndex = 0;
            this.tb_applicationInterfaces.Text = "C:\\Users\\Niko\\Downloads\\EA_Output\\EA_Output\\Information_Flows.xlsx";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tb_ComponentUsage);
            this.groupBox5.Location = new System.Drawing.Point(12, 272);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(783, 59);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Component Usage";
            // 
            // tb_ComponentUsage
            // 
            this.tb_ComponentUsage.Location = new System.Drawing.Point(6, 21);
            this.tb_ComponentUsage.Name = "tb_ComponentUsage";
            this.tb_ComponentUsage.Size = new System.Drawing.Size(771, 22);
            this.tb_ComponentUsage.TabIndex = 0;
            this.tb_ComponentUsage.Text = "C:\\Users\\Niko\\Downloads\\EA_Output\\EA_Output\\Component_Versions___Usage.xlsx";
            // 
            // DeleteComponentConnections
            // 
            this.DeleteComponentConnections.Location = new System.Drawing.Point(447, 659);
            this.DeleteComponentConnections.Name = "DeleteComponentConnections";
            this.DeleteComponentConnections.Size = new System.Drawing.Size(171, 48);
            this.DeleteComponentConnections.TabIndex = 6;
            this.DeleteComponentConnections.Text = "Delete all Component Connections";
            this.DeleteComponentConnections.UseVisualStyleBackColor = true;
            this.DeleteComponentConnections.Click += new System.EventHandler(this.DeleteComponentConnections_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.tb_businessSupport);
            this.groupBox6.Location = new System.Drawing.Point(12, 338);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(783, 59);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "BusinessSupport";
            // 
            // tb_businessSupport
            // 
            this.tb_businessSupport.Location = new System.Drawing.Point(6, 21);
            this.tb_businessSupport.Name = "tb_businessSupport";
            this.tb_businessSupport.Size = new System.Drawing.Size(771, 22);
            this.tb_businessSupport.TabIndex = 0;
            this.tb_businessSupport.Text = "C:\\Users\\Niko\\Downloads\\EA_Output\\EA_Output\\New_Mapping_Capabilities_to_Operation" +
    "al_Business_Support (1).xlsx";
            // 
            // deleteBusinessCapabilities
            // 
            this.deleteBusinessCapabilities.Location = new System.Drawing.Point(447, 605);
            this.deleteBusinessCapabilities.Name = "deleteBusinessCapabilities";
            this.deleteBusinessCapabilities.Size = new System.Drawing.Size(171, 48);
            this.deleteBusinessCapabilities.TabIndex = 7;
            this.deleteBusinessCapabilities.Text = "Delete all Business Capabilitys";
            this.deleteBusinessCapabilities.UseVisualStyleBackColor = true;
            this.deleteBusinessCapabilities.Click += new System.EventHandler(this.deleteBusinessCapabilities_Click);
            // 
            // DeleteUserGroups
            // 
            this.DeleteUserGroups.Location = new System.Drawing.Point(270, 659);
            this.DeleteUserGroups.Name = "DeleteUserGroups";
            this.DeleteUserGroups.Size = new System.Drawing.Size(171, 48);
            this.DeleteUserGroups.TabIndex = 8;
            this.DeleteUserGroups.Text = "Delete all User Groups";
            this.DeleteUserGroups.UseVisualStyleBackColor = true;
            this.DeleteUserGroups.Click += new System.EventHandler(this.DeleteUserGroups_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 722);
            this.Controls.Add(this.DeleteUserGroups);
            this.Controls.Add(this.deleteBusinessCapabilities);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.DeleteComponentConnections);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.deleteComponents);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.test);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.deleteApplications);
            this.Controls.Add(this.resultRTB);
            this.Controls.Add(this.start);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_ApplicationsVersions;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.RichTextBox resultRTB;
        private System.Windows.Forms.Button deleteApplications;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tb_ITComplienceReport;
        private System.Windows.Forms.Button test;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tb_ComponentVersions;
        private System.Windows.Forms.Button deleteComponents;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tb_applicationInterfaces;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox tb_ComponentUsage;
        private System.Windows.Forms.Button DeleteComponentConnections;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox tb_businessSupport;
        private System.Windows.Forms.Button deleteBusinessCapabilities;
        private System.Windows.Forms.Button DeleteUserGroups;
    }
}

