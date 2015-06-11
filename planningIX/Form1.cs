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
using LeanIX.Api;
using LeanIX.Api.Models;
using LeanIX.Api.Common;
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
            //importApplications();
            importData();
        }

        private void deleteApplications_Click(object sender, EventArgs e)
        {
            deleteAllServices();
        }

        private void importApplications()
        {
            Excel.Application oExcel = new Excel.Application();
            Excel.Workbook applicationsWB = oExcel.Workbooks.Open(tb_ApplicationsVersions.Text);
            Excel.Worksheet applicationsWS = applicationsWB.Worksheets[Constants.ApplicationsFile.WORKSHEET_NAME];

            Application lastApp = null;
            int index = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int row = Constants.ApplicationsFile.FIRST_ROW; row < 2000; row++)
            {
                Excel.Range nameCell = applicationsWS.Cells[row, Constants.ApplicationsFile.Columns.name];
                Excel.Range nrCell = applicationsWS.Cells[row, Constants.ApplicationsFile.Columns.nr];
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
                    app.state = applicationsWS.Cells[row, Constants.ApplicationsFile.Columns.state].Value;
                    app.alias = applicationsWS.Cells[row, Constants.ApplicationsFile.Columns.alias].Value;
                    app.itServiceCenter = applicationsWS.Cells[row, Constants.ApplicationsFile.Columns.itServiceCenter].Value;
                    app.itProductGroup = applicationsWS.Cells[row, Constants.ApplicationsFile.Columns.itProductGroup].Value;
                    app.productSpecialist = applicationsWS.Cells[row, Constants.ApplicationsFile.Columns.productSpecialist].Value;
                    app.startDate = applicationsWS.Cells[row, Constants.ApplicationsFile.Columns.startDate].Value;
                    app.endDate = applicationsWS.Cells[row, Constants.ApplicationsFile.Columns.endDate].Value;
                    app.itProductCategory = applicationsWS.Cells[row, Constants.ApplicationsFile.Columns.itProductCategory].Value;
                    app.usage = applicationsWS.Cells[row, Constants.ApplicationsFile.Columns.usage].Value;
                    app.standardisation = applicationsWS.Cells[row, Constants.ApplicationsFile.Columns.standardisation].Value;
                    app.description = applicationsWS.Cells[row, Constants.ApplicationsFile.Columns.description].Value;

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

        private void importData()
        {

            Stopwatch sw = new Stopwatch();
            resultRTB.Text += Environment.NewLine + Environment.NewLine + "Started Importing Services..." + Environment.NewLine;
            sw.Start();

            Application app = createTestApplication();
            AddOneService(app);
            //AddServices(importedData.applicationList);

            sw.Stop();
            resultRTB.Text += Environment.NewLine + "Time needed to import to LeanIX: " + sw.Elapsed.Hours.ToString() + "h " +
            sw.Elapsed.Minutes.ToString() + "m " + sw.Elapsed.Seconds.ToString() + "s";
        }

        private Application createTestApplication()
        {
            Application app = new Application();
            app.name = "TestAppName";
            app.alias = "TestAlias";
            app.description = "TestDescription";
            app.currentVersions.Add("TestAppName 1.0");
            app.currentVersions.Add("TestAppName 2.0");
            app.startDate = new DateTime(2007,12,11);
            app.endDate = new DateTime(2010, 1, 1);
            return app;
        }

        private void AddOneService(Application app)
        {
            ApiClient client = ApiClient.GetInstance();
            client.setBasePath(Constants.LeanIX.BASE_PATH);
            client.setApiKey(Constants.LeanIX.API_KEY);

            ServicesApi api = new ServicesApi();

            Service service = new Service();
            service.name = app.name;
            service.alias = app.alias;
            service.description = app.descriptionWithVersions;
            service.release = app.release;

            service = api.createService(service);
            app.ID = service.ID;

            app.addApplicationLifecycleToService(service);
            foreach (FactsheetHasLifecycle lifecycle in service.factSheetHasLifecycle)
            {
                api.createfactSheetHasLifecycle(service.ID, lifecycle);
            }

        }

        private void AddServices(List<Application> applications)
        {
            ApiClient client = ApiClient.GetInstance();
            client.setBasePath(Constants.LeanIX.BASE_PATH);
            client.setApiKey(Constants.LeanIX.API_KEY);

            ServicesApi api = new ServicesApi();

            int index = 1;
            foreach (Application app in applications)
            {
                Service service = new Service();
                service.name = app.name;
                service.alias = app.alias;
                service.description = app.descriptionWithVersions;
                service.release = app.release;
                service = api.createService(service);
                app.ID = service.ID;

                // Add Lifecycles
                app.addApplicationLifecycleToService(service);
                foreach (FactsheetHasLifecycle lifecycle in service.factSheetHasLifecycle)
                {
                    api.createfactSheetHasLifecycle(service.ID, lifecycle);
                }
                

                if (!(service == null))
                {
                    resultRTB.Text += index.ToString() + ": " + service.name + Environment.NewLine;
                    resultRTB.SelectionStart = resultRTB.Text.Length;
                    resultRTB.ScrollToCaret();
                }
                index++;
            }
        }

        private void deleteAllServices()
        {
            ApiClient client = ApiClient.GetInstance();
            client.setBasePath(Constants.LeanIX.BASE_PATH);
            client.setApiKey(Constants.LeanIX.API_KEY);

            ServicesApi api = new ServicesApi();
            List<Service> services = api.getServices(false, "");

            // Keep Progress
            Progress prog = new Progress();
            prog.current = 1;
            prog.max = services.Count;

            // Stop time
            Stopwatch sw = new Stopwatch();
            sw.Start();

            foreach (Service service in services)
            {
                api.deleteService(service.ID);
                resultRTB.Text += "Deleted Service \"" + service.name + "\" (" + prog.ToString() + ")" + Environment.NewLine;
                resultRTB.SelectionStart = resultRTB.Text.Length;
                resultRTB.ScrollToCaret();
                prog.current++;
            }


            sw.Stop();

            resultRTB.Text += Environment.NewLine + "Time needed to delete " + prog.max +  " Applications: " + sw.Elapsed.Hours.ToString() + "h " +
                sw.Elapsed.Minutes.ToString() + "m " + sw.Elapsed.Seconds.ToString() + "s";


        }
    }
}
