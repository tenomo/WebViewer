using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;

namespace SolidWebUI.Tests
{ 
    /// <summary>
    /// Summary description for TaskSystemUnitTest
    /// </summary>
    [TestClass]
    public class TaskSystemUnitTest
    {
        PDM_WebService.WcfServiceLibrary.ITaskSystemMonitor client;
        public TaskSystemUnitTest()
        {
           
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion


            public void InitializeClient ()
        {
            BasicHttpBinding myBinding = new BasicHttpBinding();
            EndpointAddress myEndpoint = new EndpointAddress("http://192.168.14.43:8080");
            var myChannelFactory = new ChannelFactory<PDM_WebService.WcfServiceLibrary.ITaskSystemMonitor>(myBinding, myEndpoint);
      
           
                client = myChannelFactory.CreateChannel();

           
        }

        [TestMethod]
        public void InitServiceCient_Test()
        {
            Exception exception = null;
            try
            {
                InitializeClient();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Failed initialize service client  " + ex.ToString());
            }

            Assert.IsNotNull(client);
            Assert.IsNull(exception);
        }

        #region  GetTaskData test
        [TestMethod]
        public void CountTasksData_Test ()
        {
            InitializeClient();
                 Assert.IsNotNull(client);
            ServiceLibrary.DataContracts.TaskData[] TaskskData = null;
            try
            {
                TaskskData = client.GetTasksData();
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Failed get data " + ex.ToString());
            }
            Assert.IsNotNull(TaskskData);
            System.Diagnostics.Debug.WriteLine("CountTasksData test #" + TaskskData.Length);
            Assert.AreNotEqual(TaskskData.Length, 0);
        }
        #endregion
    }
}
