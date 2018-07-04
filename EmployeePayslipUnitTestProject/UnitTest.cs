using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using EmployeePayslipModel.Models;
using EmployeePaySlipWebAPI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeePayslipUnitTestProject
{
    [TestClass]
    public class UnitTest
    {

        [TestMethod]
        public void Test_GetPayslip_1()
        {
            var payslipController = new PayslipController();

            var employee = new Employee()
            {
                FirstName = "Uvika",
                LastName = "Khatri",
                AnnualSalary = 60050,
                StartDate = new DateTime(2018, 03, 01),
                SuperRate = 9
            };

           

            payslipController.Request = new HttpRequestMessage();
            payslipController.Configuration = new HttpConfiguration();

            Payslip paySlip;
            var response = payslipController.CreatePaySlip(employee);
            Assert.IsTrue(response.TryGetContentValue<Payslip>(out paySlip));
            Assert.IsNotNull(paySlip);
            Assert.AreEqual(5004, paySlip.GrossIncome);
            Assert.AreEqual(922, paySlip.IncomeTax);
            Assert.AreEqual(4082, paySlip.NetIncome);
            Assert.AreEqual(450, paySlip.SuperAnnuation);
            Assert.AreEqual("01 Mar 2018-31 Mar 2018", paySlip.PayPeriod);
        }


        [TestMethod]
        public void Test_GetPayslip_2()
        {
            var payslipController = new PayslipController();            
            payslipController.Request = new HttpRequestMessage();
            payslipController.Configuration = new HttpConfiguration();

            var employee = new Employee()
            {
                FirstName = "Uvika",
                LastName = "Khatri",
                AnnualSalary = 120000,
                StartDate = new DateTime(2018, 03, 15),
                SuperRate = 10
            };
            var response = payslipController.CreatePaySlip(employee);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            Payslip paySlip;
            Assert.IsTrue(response.TryGetContentValue<Payslip>(out paySlip));
            Assert.IsNotNull(paySlip);
            Assert.AreEqual(10000, paySlip.GrossIncome);
            Assert.AreEqual(2669, paySlip.IncomeTax);
            Assert.AreEqual(7331, paySlip.NetIncome);
            Assert.AreEqual(1000, paySlip.SuperAnnuation);
            Assert.AreEqual("01 Mar 2018-31 Mar 2018", paySlip.PayPeriod);
        }

        [TestMethod]
        public void Test_GetPayslip_3()
        {
            var payslipController = new PayslipController();
            payslipController.Request = new HttpRequestMessage();
            payslipController.Configuration = new HttpConfiguration();
            var employee = new Employee()
            {
                FirstName = "Uvika",
                LastName = "Khatri",
                AnnualSalary = 10000,
                StartDate = new DateTime(2018, 06, 30),
                SuperRate = 0
            };

            Payslip paySlip;
            var response = payslipController.CreatePaySlip(employee);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            Assert.IsTrue(response.TryGetContentValue<Payslip>(out paySlip));
            Assert.IsNotNull(paySlip);
            Assert.AreEqual(833, paySlip.GrossIncome);
            Assert.AreEqual(0, paySlip.IncomeTax);
            Assert.AreEqual(833, paySlip.NetIncome);
            Assert.AreEqual(0, paySlip.SuperAnnuation);
            Assert.AreEqual("01 Jun 2018-30 Jun 2018", paySlip.PayPeriod);
        }

        [TestMethod]
        public void Test_GetPayslip_4()
        {
            var payslipController = new PayslipController();
            payslipController.Request = new HttpRequestMessage();
            payslipController.Configuration = new HttpConfiguration();
            var employee = new Employee()
            {
                FirstName = "Uvika",
                LastName = "Khatri",
                AnnualSalary = 20000,
                StartDate = new DateTime(2018, 06, 30),
                SuperRate = 3
            };
            var response = payslipController.CreatePaySlip(employee);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            Payslip paySlip;            
            Assert.IsTrue(response.TryGetContentValue<Payslip>(out paySlip));
            Assert.IsNotNull(paySlip);
            Assert.AreEqual(1667, paySlip.GrossIncome);
            Assert.AreEqual(28, paySlip.IncomeTax);
            Assert.AreEqual(1639, paySlip.NetIncome);
            Assert.AreEqual(50, paySlip.SuperAnnuation);
            Assert.AreEqual("01 Jun 2018-30 Jun 2018", paySlip.PayPeriod);
        }

        [TestMethod]
        public void Test_GetPayslip_5()
        {
            var payslipController = new PayslipController();
            payslipController.Request = new HttpRequestMessage();
            payslipController.Configuration = new HttpConfiguration();
            var employee = new Employee()
            {
                FirstName = "Uvika",
                LastName = "Khatri",
                AnnualSalary = 200000,
                StartDate = new DateTime(2018, 06, 30),
                SuperRate = 3
            };

            Payslip paySlip;
            var response = payslipController.CreatePaySlip(employee);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            Assert.IsTrue(response.TryGetContentValue<Payslip>(out paySlip));
            Assert.IsNotNull(paySlip);
            Assert.AreEqual(16667, paySlip.GrossIncome);
            Assert.AreEqual(5269, paySlip.IncomeTax);
            Assert.AreEqual(11398, paySlip.NetIncome);
            Assert.AreEqual(500, paySlip.SuperAnnuation);
            Assert.AreEqual("01 Jun 2018-30 Jun 2018", paySlip.PayPeriod);
        }

        [TestMethod]
        public void NegativeTest_GetPayslip1()
        {
            var payslipController = new PayslipController();
            payslipController.Request = new HttpRequestMessage();
            payslipController.Configuration = new HttpConfiguration();
            var response = (payslipController.CreatePaySlip(null));

            // Assert
            Assert.AreEqual( response.StatusCode, HttpStatusCode.NotFound);
        }
        [TestMethod]
        public void NegativeTest_GetPayslip2()
        {
            var payslipController = new PayslipController();
            payslipController.Request = new HttpRequestMessage();
            payslipController.Configuration = new HttpConfiguration();
            var employee = new Employee()
            {
                FirstName = "Uvika",
                LastName = "Khatri",
                AnnualSalary = -200,
                StartDate = new DateTime(2018, 06, 30),
                SuperRate = -3
            };

            var response = (payslipController.CreatePaySlip(employee));

            // Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.BadRequest);
        }

    }
}
