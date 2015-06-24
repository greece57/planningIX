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

            importApplications();
            //importComplience();
            //importInterfaces();
            importComponents();
            importComponentApplicationMatching();
            //importBusinessSuppport();

            oExcel.Visible = true;
            oExcel.Quit();

            importData();
        }

        private void importBusinessSuppport()
        {
            Excel.Workbook businessSupportWB = oExcel.Workbooks.Open(tb_businessSupport.Text);
            Excel.Worksheet businessSupportWS = businessSupportWB.Worksheets[Constants.BusinessSupportFile.WORKSHEET_NAME];
            Excel.Range usedRange = businessSupportWS.UsedRange;


            int index = 0;
            BusinessProcessLvl1 currentBusinessProcess = null;
            Application currentApplication = null;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int row = Constants.BusinessSupportFile.FIRST_ROW; row < 7000; row++)
            {
                string nr = usedRange[row, Constants.BusinessSupportFile.Columns.nr].Value;
                string businessProcessName = usedRange[row, Constants.BusinessSupportFile.Columns.businessProcessLvl1].Value;
                string applicationName = usedRange[row, Constants.BusinessSupportFile.Columns.applicationName].Value;
                if (String.IsNullOrEmpty(nr))
                {
                    //exit because finished
                    row = 7000;
                }
                else if (String.IsNullOrEmpty(businessProcessName))
                {
                    // do nothing
                }else if (String.IsNullOrEmpty(applicationName))
                {
                    // do nothing
                }
                else
                {
                    currentBusinessProcess = (BusinessProcessLvl1)importedData.lvl1BusinessProcessList[businessProcessName];
                    if (currentBusinessProcess == null)
                    {
                        BusinessProcessLvl1 newProcess = new BusinessProcessLvl1();
                        newProcess.name = businessProcessName;
                        currentApplication = (Application)importedData.applicationList[applicationName];
                        if (currentApplication != null) newProcess.applicationList.Add(currentApplication);
                        importedData.lvl1BusinessProcessList.Add(newProcess);
                        currentBusinessProcess = newProcess;
                    }
                    else
                    {
                        if (currentApplication == null)
                        {
                            // do nothing - same row!
                        }
                        else if (currentApplication.Name.Equals(applicationName))
                        {
                            // do nothing
                        }
                        else
                        {
                            currentApplication = (Application)importedData.applicationList[applicationName];
                            if (currentApplication != null)  currentBusinessProcess.applicationList.Add(currentApplication);
                        }
                    }


                    // just for progress
                    index++;
                    resultRTB.Text += index.ToString() + ": " + currentBusinessProcess.name + Environment.NewLine;
                    resultRTB.SelectionStart = resultRTB.Text.Length;
                    resultRTB.ScrollToCaret();
                    this.Update();

                }
            }

        }

        private void importComponentApplicationMatching()
        {
            Excel.Workbook componentWB = oExcel.Workbooks.Open(tb_ComponentUsage.Text);
            Excel.Worksheet componentWS = componentWB.Worksheets[Constants.ComponentsUsageFile.WORKSHEET_NAME];


            int index = 0;
            Component currentComponent = null;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int row = Constants.ComponentsUsageFile.FIRST_ROW; row < 3000; row++)
            {
                Excel.Range componentName = componentWS.Cells[row, Constants.ComponentsUsageFile.Columns.componentVersion];
                if (String.IsNullOrEmpty(componentName.Value))
                {
                    // nothing
                    string applicationName = componentWS.Cells[row, Constants.ComponentsUsageFile.Columns.usedInName].Value;
                    if (String.IsNullOrEmpty(applicationName))
                    {
                        //exit because finished
                        row = 3000;
                    }
                    Application currentApp = (Application)importedData.applicationList.getByCurrentVersion(applicationName);
                    if (currentApp != null)
                    {
                        currentApp.productSpecialistEmail = componentWS.Cells[row, Constants.ComponentsUsageFile.Columns.usedProductSpecialistEmail].Value;
                        currentComponent.applicationList.Add(currentApp);
                    } 
                }
                else
                {
                    // find component
                    currentComponent = (Component)importedData.componentList[componentName.Value];
                    
                    // just for progress
                    index++;
                    resultRTB.Text += index.ToString() + ": " + currentComponent.ToString() + Environment.NewLine;
                    resultRTB.SelectionStart = resultRTB.Text.Length;
                    resultRTB.ScrollToCaret();
                    this.Update();

                }
            }

        }

        private void importInterfaces()
        {
            Excel.Workbook interfacesWB = oExcel.Workbooks.Open(tb_applicationInterfaces.Text);
            Excel.Worksheet interfacesWS = interfacesWB.Worksheets[Constants.ComponentsFile.WORKSHEET_NAME];
            

            int index = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int row = Constants.InterfacesFile.FIRST_ROW; row < 2000; row++)
            {
                Excel.Range fromCell = interfacesWS.Cells[row, Constants.InterfacesFile.Columns.from];
                if (String.IsNullOrEmpty(fromCell.Value))
                {
                    row = 2000;
                    // exit for when name is empty
                }
                
                else
                {
                    // import new Application
                    Interface intface = new Interface();
                    intface.from = fromCell.Value;
                    intface.to = interfacesWS.Cells[row, Constants.InterfacesFile.Columns.to].Value;
                    intface.state = interfacesWS.Cells[row, Constants.InterfacesFile.Columns.state].Value;
                    intface.startDate = interfacesWS.Cells[row, Constants.InterfacesFile.Columns.start].Value;
                    intface.endDate = interfacesWS.Cells[row, Constants.InterfacesFile.Columns.end].Value;
                    intface.description = interfacesWS.Cells[row, Constants.InterfacesFile.Columns.description].Value;
                    intface.connectionType = interfacesWS.Cells[row, Constants.InterfacesFile.Columns.connectionType].Value;
                    intface.connectionMethod = interfacesWS.Cells[row, Constants.InterfacesFile.Columns.connectionMethod].Value;
                    intface.connectionFrequency = interfacesWS.Cells[row, Constants.InterfacesFile.Columns.connectionFrequency].Value;
                    intface.dataFormat = interfacesWS.Cells[row, Constants.InterfacesFile.Columns.connectionDataFormat].Value;
                    intface.personalData = interfacesWS.Cells[row, Constants.InterfacesFile.Columns.personalData].Value;
                    intface.transferredBuisnessObjects = interfacesWS.Cells[row, Constants.InterfacesFile.Columns.transferredBusinessObjects].Value;

                    Application fromApp = importedData.applicationList.getByCurrentVersion(intface.from);
                    Application toApp = importedData.applicationList.getByCurrentVersion(intface.to);

                    if (fromApp == null || toApp == null)
                    {
                        resultRTB.Text += "Minderwertig: " + intface.from + " or " + intface.to + Environment.NewLine;
                    }
                    else
                    {
                        fromApp.interfaces.Add(intface);
                        intface.toApp = toApp;
                    }

                    // just for progress
                    index++;
                    resultRTB.Text += index.ToString() + ": " + intface.ToString() + Environment.NewLine;
                    resultRTB.SelectionStart = resultRTB.Text.Length;
                    resultRTB.ScrollToCaret();
                    this.Update();

                }
            }

        }

        private void deleteApplications_Click(object sender, EventArgs e)
        {
            deleteAllServices();
        }

        private void importComponents()
        {
            Excel.Workbook applicationsWB = oExcel.Workbooks.Open(tb_ComponentVersions.Text);
            Excel.Worksheet applicationsWS = applicationsWB.Worksheets[Constants.ComponentsFile.WORKSHEET_NAME];
            Excel.Range usedRange = applicationsWS.UsedRange;

            Component baseComponent = null;
            int index = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int row = Constants.ComponentsFile.FIRST_ROW; row < 2000; row++)
            {
                Excel.Range nameCell = usedRange[row, Constants.ComponentsFile.Columns.name];
                Excel.Range nrCell = usedRange[row, Constants.ComponentsFile.Columns.nr];
                if (String.IsNullOrEmpty(nameCell.Value))
                {
                    row = 2000;
                    // exit for when name is empty
                }
                else if (String.IsNullOrEmpty(nrCell.Value))
                {
                    // add new version when nr is empty
                    string currentVersionName = nameCell.Value;

                    DateTime startDate = usedRange[row, Constants.ComponentsFile.Columns.startDate].Value ?? new DateTime(0);
                    DateTime endDate = usedRange[row, Constants.ComponentsFile.Columns.endDate].Value ?? new DateTime(0);

                    Component comp = new Component(baseComponent);
                    comp.Name = currentVersionName;
                    comp.startDate = startDate;
                    comp.endDate = endDate;

                    // just for progress
                    if (!(baseComponent == null))
                    {
                        index++;
                        resultRTB.Text += index.ToString() + ": " + baseComponent.ToString() + Environment.NewLine;
                        resultRTB.SelectionStart = resultRTB.Text.Length;
                        resultRTB.ScrollToCaret();
                    }
                    this.Update();

                    importedData.componentList.Add(comp);

                }
                else
                {
                    // import new Component
                    Component comp = new Component();
                    comp.baseName = nameCell.Value;
                    comp.state = usedRange[row, Constants.ComponentsFile.Columns.state].Value;
                    comp.alias = usedRange[row, Constants.ComponentsFile.Columns.alias].Value;
                    comp.itServiceCenter = usedRange[row, Constants.ComponentsFile.Columns.itServiceCenter].Value;
                    comp.itProductGroup = usedRange[row, Constants.ComponentsFile.Columns.itProductGroup].Value;
                    comp.productSpecialist = usedRange[row, Constants.ComponentsFile.Columns.productSpecialist].Value;
                    comp.domain = usedRange[row, Constants.ComponentsFile.Columns.domain].Value;
                    comp.standardTechnology = usedRange[row, Constants.ComponentsFile.Columns.standardTechnology].Value;
                    comp.decisionStatus = usedRange[row, Constants.ComponentsFile.Columns.decisionStatus].Value;


                    baseComponent = comp;
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
            Excel.Range usedRange = applicationsWS.UsedRange;

            Application lastApp = null;
            int index = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int row = Constants.ApplicationsFile.FIRST_ROW; row < 2000; row++)
            {
                Excel.Range nameCell = usedRange[row, Constants.ApplicationsFile.Columns.name];
                Excel.Range nrCell = usedRange[row, Constants.ApplicationsFile.Columns.nr];
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
                    app.state = usedRange[row, Constants.ApplicationsFile.Columns.state].Value;
                    app.alias = usedRange[row, Constants.ApplicationsFile.Columns.alias].Value;
                    app.itServiceCenter = usedRange[row, Constants.ApplicationsFile.Columns.itServiceCenter].Value;
                    app.itProductGroup = usedRange[row, Constants.ApplicationsFile.Columns.itProductGroup].Value;
                    app.productSpecialist = usedRange[row, Constants.ApplicationsFile.Columns.productSpecialist].Value;
                    app.startDate = usedRange[row, Constants.ApplicationsFile.Columns.startDate].Value;
                    app.endDate = usedRange[row, Constants.ApplicationsFile.Columns.endDate].Value;
                    app.itProductCategory = usedRange[row, Constants.ApplicationsFile.Columns.itProductCategory].Value;
                    app.usage = usedRange[row, Constants.ApplicationsFile.Columns.usage].Value;
                    app.standardisation = usedRange[row, Constants.ApplicationsFile.Columns.standardisation].Value;
                    app.Description = usedRange[row, Constants.ApplicationsFile.Columns.description].Value;

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

            //AddServices(importedData.applicationList);
            MatchServices();
            //AddInterfaces(importedData.applicationList);
            AddComponents(importedData.componentList);
            //MatchComponents();
            AddServicesToComponents();
            //ImportBusinessCapability();

            sw.Stop();
            resultRTB.Text += Environment.NewLine + "Time needed to import to LeanIX: " + sw.Elapsed.Hours.ToString() + "h " +
            sw.Elapsed.Minutes.ToString() + "m " + sw.Elapsed.Seconds.ToString() + "s";
        }

        private void ImportBusinessCapability()
        {
            BusinessCapabilitiesApi bcApi = new BusinessCapabilitiesApi();

            Progress prog = new Progress();
            prog.current = 1;
            prog.max = importedData.componentList.Count;
            foreach (BusinessProcessLvl1 processLvl1 in importedData.lvl1BusinessProcessList)
            {
                BusinessCapability businessCapability = new BusinessCapability();
                businessCapability.serviceHasBusinessCapabilities = new List<ServiceHasBusinessCapability>();
                businessCapability.name = processLvl1.name;

                businessCapability = bcApi.createBusinessCapability(businessCapability);
                processLvl1.ID = businessCapability.ID;

                foreach (Application app in processLvl1.applicationList)
                {
                    ServiceHasBusinessCapability businessCapabilityService = new ServiceHasBusinessCapability();
                    businessCapabilityService.serviceID = app.ID;
                    businessCapabilityService.businessCapabilityID = businessCapability.ID;
                    businessCapabilityService.isLeading = false;
                    businessCapabilityService = bcApi.createServiceHasBusinessCapability(businessCapability.ID, businessCapabilityService);
                }
                prog.current++;

                resultRTB.Text += prog.current.ToString() + ": " + processLvl1.name + " (" + prog.ToString() + ") " + Environment.NewLine;
                resultRTB.SelectionStart = resultRTB.Text.Length;
                resultRTB.ScrollToCaret();
            }

        }

        private void AddServicesToComponents()
        {
            ServicesApi sApi = new ServicesApi();

            Progress prog = new Progress();
            prog.current = 1;
            prog.max = importedData.componentList.Count;
            foreach (Component comp in importedData.componentList)
            {
                if (!(comp == null))
                {
                    resultRTB.Text += prog.current.ToString() + ": " + comp.Name + " -> " + comp.applicationList.Count.ToString() + " (" + prog.ToString() + ") " + Environment.NewLine;
                    resultRTB.SelectionStart = resultRTB.Text.Length;
                    resultRTB.ScrollToCaret();
                }

                foreach (Application app in comp.applicationList)
                {
                    ServiceHasResource resourceService = new ServiceHasResource();
                    resourceService.serviceID = app.ID;
                    resourceService.resourceID = comp.ID;
                    sApi.createServiceHasResourceSvc(app.ID, resourceService);
                }
                prog.current++;
            }
        }

        private void MatchComponents()
        {
            ResourcesApi rApi = new ResourcesApi();

            List<Resource> resourceList = rApi.getResources(false, "");

            foreach (Resource resource in resourceList)
            {
                ((Component)importedData.componentList[resource.name]).ID = resource.ID;
            }
        }

        private void MatchServices()
        {
            ServicesApi sApi = new ServicesApi();

            List<Service> serviceList = sApi.getServices(false, "");

            foreach (Service service in serviceList)
            {
                ((Application)importedData.applicationList[service.name]).ID = service.ID;
            }
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

        private void AddInterfaces(ListOfFactSheets<Application> applications)
        {
            ServicesApi sApi = new ServicesApi();

            // Keep Progress
            Progress prog = new Progress();
            prog.current = 1;
            prog.max = applications.Count;

            foreach (Application app in applications)
            {

                foreach (Interface intface in app.interfaces)
                {
                    ServiceHasInterface serviceInterface = new ServiceHasInterface();
                    serviceInterface.name = intface.Description;
                    serviceInterface.serviceID = app.ID;
                    serviceInterface.serviceRefID = intface.toApp.ID;
                    if (!(String.IsNullOrEmpty(serviceInterface.serviceID) || String.IsNullOrEmpty(serviceInterface.serviceRefID)
                        || serviceInterface.serviceID == serviceInterface.serviceRefID))
                    {
                        serviceInterface.interfaceDirectionID = "2";
                        serviceInterface.interfaceFrequencyID = intface.Frequency;
                        serviceInterface.interfaceTypeID = intface.InterfaceType;
                        serviceInterface.visibilityID = intface.State;

                        serviceInterface = sApi.createServiceHasInterface(app.ID, serviceInterface);
                    }
                }


                if (!(app == null))
                {
                    resultRTB.Text += prog.current.ToString() + ": " + app.Name + " -> " + app.interfaces.Count.ToString() + " (" + prog.ToString() + ") " + Environment.NewLine;
                    resultRTB.SelectionStart = resultRTB.Text.Length;
                    resultRTB.ScrollToCaret();
                }
                prog.current++;
            }
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

        private void DeleteComponentConnections_Click(object sender, EventArgs e)
        {
            DeleteAllResourceConnections();
        }

        private void DeleteAllResourceConnections()
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
                if (service.serviceHasResources != null)
                {
                    foreach (ServiceHasResource serviceHasResource in service.serviceHasResources)
                    {
                        try
                        {
                            api.deleteServiceHasResourceSvc(serviceHasResource.serviceID, serviceHasResource.ID);
                        }
                        catch { }
                    }
                }
                resultRTB.Text += "Deleted Connections from Service \"" + service.name + "\" (" + prog.ToString() + ")" + Environment.NewLine;
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
