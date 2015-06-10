using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;

namespace planningIX
{

    public partial class Form1 : Form
    {
        ImportedData importedData = new ImportedData();

        public Form1()
        {
            InitializeComponent();
        }

        private void start_Click(object sender, EventArgs e)
        {
            importApplications();
            exportData();
        }

        private void importApplications()
        {
            Excel.Application oExcel = new Excel.Application();
            Excel.Workbook applicationsWB = oExcel.Workbooks.Open(tb_ApplicationsVersions.Text);
            Excel.Worksheet applicationsWS = applicationsWB.Worksheets[WorksheetConsts.ApplicationsFile.WORKSHEET_NAME];

            Application lastApp = null;
            int index = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int row = WorksheetConsts.ApplicationsFile.FIRST_ROW; row < 2000; row++)
            {
                Excel.Range nameCell = applicationsWS.Cells[row, WorksheetConsts.ApplicationsFile.Columns.name];
                Excel.Range nrCell = applicationsWS.Cells[row, WorksheetConsts.ApplicationsFile.Columns.nr];
                if (String.IsNullOrEmpty(nameCell.Value))
                {
                    // exit for when name is empty
                    row = 2000;
                }
                else if (String.IsNullOrEmpty(nrCell.Value))
                {
                    // add new version when nr is empty
                    string newName = nameCell.Value;
                    lastApp.currentVersions.Add(newName);
                }
                else
                {
                    // import new Application
                    Application app = new Application();
                    app.name = nameCell.Value;
                    app.state = applicationsWS.Cells[row, WorksheetConsts.ApplicationsFile.Columns.state].Value;
                    app.alias = applicationsWS.Cells[row, WorksheetConsts.ApplicationsFile.Columns.alias].Value;
                    app.itServiceCenter = applicationsWS.Cells[row, WorksheetConsts.ApplicationsFile.Columns.itServiceCenter].Value;
                    app.itProductGroup = applicationsWS.Cells[row, WorksheetConsts.ApplicationsFile.Columns.itProductGroup].Value;
                    app.productSpecialist = applicationsWS.Cells[row, WorksheetConsts.ApplicationsFile.Columns.productSpecialist].Value;
                    app.startDate = applicationsWS.Cells[row, WorksheetConsts.ApplicationsFile.Columns.startDate].Value.ToString();
                    app.endDate = applicationsWS.Cells[row, WorksheetConsts.ApplicationsFile.Columns.endDate].Value.ToString();
                    app.itProductCategory = applicationsWS.Cells[row, WorksheetConsts.ApplicationsFile.Columns.itProductCategory].Value;
                    app.usage = applicationsWS.Cells[row, WorksheetConsts.ApplicationsFile.Columns.usage].Value;
                    app.standardisation = applicationsWS.Cells[row, WorksheetConsts.ApplicationsFile.Columns.standardisation].Value;
                    app.description = applicationsWS.Cells[row, WorksheetConsts.ApplicationsFile.Columns.description].Value;

                    // just for progress
                    if (!(lastApp == null))
                    {
                        index++;
                        resultRTB.Text += index.ToString() + ": " + lastApp.ToString() + Environment.NewLine;
                        resultRTB.SelectionStart = resultRTB.Text.Length;
                        resultRTB.ScrollToCaret();
                    }
                    this.Update();

                    lastApp = app;
                    importedData.applicationList.Add(app);
                }
            }

            sw.Stop();

            resultRTB.Text += Environment.NewLine + "Time needed to import Applications: " + sw.Elapsed.Hours.ToString() + "h " +
                sw.Elapsed.Minutes.ToString() + "m " + sw.Elapsed.Seconds.ToString() + "s";

            //foreach (Application app in importedData.applicationList)
            //{
            //    resultRTB.Text += app.ToString();
            //}

            oExcel.Visible = true;
         
        }

        private void exportData()
        {

        }
    }
}
