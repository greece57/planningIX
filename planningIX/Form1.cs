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
        Excel.Application oExcel;

        public Form1()
        {
            InitializeComponent();

            ApiClient client = ApiClient.GetInstance();
            client.setBasePath(Constants.LeanIX.BASE_PATH);
            client.setApiKey(Constants.LeanIX.API_KEY);

        }

        private void start_Click(object sender, EventArgs e)
        {
            // init Excel
            oExcel = new Excel.Application();

            importComponents();
            importApplications();
            importComplience();

            oExcel.Visible = true;
            oExcel.Quit();

            importData();
        }

        private void deleteApplications_Click(object sender, EventArgs e)
        {
            deleteAllServices();
        }

        private void importComponents()
        {
            Excel.Workbook applicationsWB = oExcel.Workbooks.Open(tb_ComponentVersions.Text);
            Excel.Worksheet applicationsWS = applicationsWB.Worksheets[Constants.ComponentsFile.WORKSHEET_NAME];

            Component lastComponent = null;
            int index = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int row = Constants.ComponentsFile.FIRST_ROW; row < 2000; row++)
            {
                Excel.Range nameCell = applicationsWS.Cells[row, Constants.ComponentsFile.Columns.name];
                Excel.Range nrCell = applicationsWS.Cells[row, Constants.ComponentsFile.Columns.nr];
                if (String.IsNullOrEmpty(nameCell.Value))
                {
                    row = 2000;
                    // exit for when name is empty
                }
                else if (String.IsNullOrEmpty(nrCell.Value))
                {
                    // add new version when nr is empty
                    string currentVersionName = nameCell.Value;
                    lastComponent.currentVersions.Add(currentVersionName);

                    DateTime startDate = applicationsWS.Cells[row, Constants.ComponentsFile.Columns.startDate].Value ?? new DateTime(0);
                    DateTime endDate = applicationsWS.Cells[row, Constants.ComponentsFile.Columns.endDate].Value ?? new DateTime(0);

                    // set biggest & smallest StartDate
                    if (lastComponent.startDate > startDate || lastComponent.startDate.Equals(new DateTime())) lastComponent.startDate = startDate;
                    if (lastComponent.endDate < endDate || lastComponent.endDate.Equals(new DateTime())) lastComponent.endDate = endDate;
                }
                else
                {
                    // import new Application
                    Component comp = new Component();
                    comp.Name = nameCell.Value;
                    comp.state = applicationsWS.Cells[row, Constants.ComponentsFile.Columns.state].Value;
                    comp.alias = applicationsWS.Cells[row, Constants.ComponentsFile.Columns.alias].Value;
                    comp.itServiceCenter = applicationsWS.Cells[row, Constants.ComponentsFile.Columns.itServiceCenter].Value;
                    comp.itProductGroup = applicationsWS.Cells[row, Constants.ComponentsFile.Columns.itProductGroup].Value;
                    comp.productSpecialist = applicationsWS.Cells[row, Constants.ComponentsFile.Columns.productSpecialist].Value;
                    comp.domain = applicationsWS.Cells[row, Constants.ComponentsFile.Columns.domain].Value;
                    comp.standardTechnology = applicationsWS.Cells[row, Constants.ComponentsFile.Columns.standardTechnology].Value;
                    comp.decisionStatus = applicationsWS.Cells[row, Constants.ComponentsFile.Columns.decisionStatus].Value;

                    // just for progress
                    if (!(lastComponent == null))
                    {
                        index++;
                        resultRTB.Text += index.ToString() + ": " + lastComponent.ToString() + Environment.NewLine;
                        resultRTB.SelectionStart = resultRTB.Text.Length;
                        resultRTB.ScrollToCaret();
                    }
                    this.Update();

                    lastComponent = comp;
                    importedData.componentList.Add(comp);
                }
            }

            sw.Stop();

            resultRTB.Text += Environment.NewLine + "Time needed to import Components: " + sw.Elapsed.Hours.ToString() + "h " +
                sw.Elapsed.Minutes.ToString() + "m " + sw.Elapsed.Seconds.ToString() + "s";


            applicationsWB.Close(false);
        }

        private void importApplications()
        {
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
                    string currentVersionName = nameCell.Value;
                    lastApp.currentVersions.Add(currentVersionName);
                }
                else
                {
                    // import new Application
                    Application app = new Application();
                    app.Name = nameCell.Value;
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
                    app.Description = applicationsWS.Cells[row, Constants.ApplicationsFile.Columns.description].Value;

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


            applicationsWB.Close(false);

        }

        private void importComplience()
        {
            Excel.Workbook complienceWB = oExcel.Workbooks.Open(tb_ITComplienceReport.Text);
            Excel.Worksheet complienceWS = complienceWB.Worksheets[Constants.ComplienceReportFile.WORKSHEET_NAME];

            int index = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int row = Constants.ComplienceReportFile.FIRST_ROW; row < 2000; row++)
            {
                Excel.Range nameCell = complienceWS.Cells[row, Constants.ComplienceReportFile.Columns.name];
                if (String.IsNullOrEmpty(nameCell.Value))
                {
                    row = 2000;
                }
                else
                {
                    Application app = importedData.applicationList[nameCell.Value];
                    if (!(app == null))
                    {
                        app.businessContact = complienceWS.Cells[row, Constants.ComplienceReportFile.Columns.businessContact].Value;
                        app.applicationType = complienceWS.Cells[row, Constants.ComplienceReportFile.Columns.applicationType].Value;
                        app.CS_Relevance = complienceWS.Cells[row, Constants.ComplienceReportFile.Columns.csRelevance].Value;
                        app.DR_Class = complienceWS.Cells[row, Constants.ComplienceReportFile.Columns.drClass].Value;
                        app.ConfProd = complienceWS.Cells[row, Constants.ComplienceReportFile.Columns.confProd].Value;
                        app.ConfInt = complienceWS.Cells[row, Constants.ComplienceReportFile.Columns.confInt].Value;
                        app.ConfDev = complienceWS.Cells[row, Constants.ComplienceReportFile.Columns.confDev].Value;
                        app.Integrity = complienceWS.Cells[row, Constants.ComplienceReportFile.Columns.integrity].Value;
                        app.Availability = complienceWS.Cells[row, Constants.ComplienceReportFile.Columns.availability].Value;
                        app.nrOfLegalEntities = int.Parse(complienceWS.Cells[row, Constants.ComplienceReportFile.Columns.nrOfLegalEntities].Value);
                        app.nrOfBusinessProcesses = int.Parse(complienceWS.Cells[row, Constants.ComplienceReportFile.Columns.nrOfBusinessProcesses].Value);
                        app.nrOfInterfaces = int.Parse(complienceWS.Cells[row, Constants.ComplienceReportFile.Columns.nrOfInterfaces].Value);
                        
                        // just for progress
                        index++;
                        resultRTB.Text += index.ToString() + ". Update: " + app.Name + Environment.NewLine;
                        resultRTB.SelectionStart = resultRTB.Text.Length;
                        resultRTB.ScrollToCaret();
                    
                        this.Update();

                    }
                }
            }

            complienceWB.Close(false);
        }

        private void importData()
        {

            Stopwatch sw = new Stopwatch();
            resultRTB.Text += Environment.NewLine + Environment.NewLine + "Started Importing Services..." + Environment.NewLine;
            sw.Start();

            AddServices(importedData.applicationList);
            AddComponents(importedData.componentList);

            sw.Stop();
            resultRTB.Text += Environment.NewLine + "Time needed to import to LeanIX: " + sw.Elapsed.Hours.ToString() + "h " +
            sw.Elapsed.Minutes.ToString() + "m " + sw.Elapsed.Seconds.ToString() + "s";
        }

        private Application createTestApplication()
        {
            Application app = new Application();
            app.Name = "TestAppName";
            app.alias = "TestAlias";
            app.Description = "TestDescription";
            app.currentVersions.Add("TestAppName 1.0");
            app.currentVersions.Add("TestAppName 2.0");
            app.startDate = new DateTime(2007,12,11);
            app.endDate = new DateTime(2010, 1, 1);
            app.usage = "Local";
            app.ConfInt = "C3 - Confidential (INT)";
            app.Availability = "A1 - Low Availabilty";
            return app;
        }

        private void AddOneService(Application app)
        {
            ServicesApi sApi = new ServicesApi();
            FactSheetApi fsApi = new FactSheetApi();


            Service service = app.getService();

            service = sApi.createService(service);
            app.ID = service.ID;

            app.addApplicationLifecycleToService(service);

            fsApi.createFactSheetHasLifecycles(service.ID, service);

        }

        private void AddServices(ListOfFactSheets<Application> applications)
        {
            ServicesApi sApi = new ServicesApi();
            FactSheetApi fsApi = new FactSheetApi();

            // Keep Progress
            Progress prog = new Progress();
            prog.current = 1;
            prog.max = applications.Count;

            foreach (Application app in applications)
            {
                Service service = app.getService();

                service = sApi.createService(service);
                app.ID = service.ID;

                // Add Lifecycles
                app.addApplicationLifecycleToService(service);
                fsApi.createFactSheetHasLifecycles(service.ID, service);
                

                if (!(service == null))
                {
                    resultRTB.Text += prog.current.ToString() + ": " + service.name + " (" + prog.ToString() + ") " + Environment.NewLine;
                    resultRTB.SelectionStart = resultRTB.Text.Length;
                    resultRTB.ScrollToCaret();
                }
                prog.current++;
            }
        }

        private void AddComponents(ListOfFactSheets<Component> components)
        {
            ResourcesApi rApi = new ResourcesApi();
            FactSheetApi fsApi = new FactSheetApi();

            // Keep Progress
            Progress prog = new Progress();
            prog.current = 1;
            prog.max = components.Count;

            foreach (Component comp in components)
            {
                Resource resource = comp.getResource();

                resource = rApi.createResource(resource);
                comp.ID = resource.ID;

                // Add Lifecycles
                comp.addComponentLifecycleToService(resource);
                fsApi.createFactSheetHasLifecycles(resource.ID, resource);


                if (!(resource == null))
                {
                    resultRTB.Text += prog.current.ToString() + ": " + resource.name + " (" + prog.ToString() + ") " + Environment.NewLine;
                    resultRTB.SelectionStart = resultRTB.Text.Length;
                    resultRTB.ScrollToCaret();
                }
                prog.current++;
            }
        }

        private void deleteAllServices()
        {
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

        private void test_Click(object sender, EventArgs e)
        {
            Application app = createTestApplication();
            AddOneService(app);
        }

        private void deleteComponents_Click(object sender, EventArgs e)
        {
            deleteAllResources();
        }

        private void deleteAllResources()
        {
            ResourcesApi api = new ResourcesApi();
            List<Resource> resources = api.getResources(false, "");

            // Keep Progress
            Progress prog = new Progress();
            prog.current = 1;
            prog.max = resources.Count;

            // Stop time
            Stopwatch sw = new Stopwatch();
            sw.Start();

            foreach (Resource resource in resources)
            {
                api.deleteResource(resource.ID);
                resultRTB.Text += "Deleted Service \"" + resource.name + "\" (" + prog.ToString() + ")" + Environment.NewLine;
                resultRTB.SelectionStart = resultRTB.Text.Length;
                resultRTB.ScrollToCaret();
                prog.current++;
            }


            sw.Stop();

            resultRTB.Text += Environment.NewLine + "Time needed to delete " + prog.max + " Applications: " + sw.Elapsed.Hours.ToString() + "h " +
                sw.Elapsed.Minutes.ToString() + "m " + sw.Elapsed.Seconds.ToString() + "s";

        }
    }
}
