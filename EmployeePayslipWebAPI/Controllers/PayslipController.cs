using EmployeePayslipBuisness;
using EmployeePayslipContracts;
using EmployeePayslipModel.Models;
using EmployeePayslipWebAPI.Filters;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using static EmployeePayslipModel.Utility.Global;

namespace EmployeePaySlipWebAPI.Controllers
{
    public class PayslipController : ApiController
    {

        public PayslipController()
        {

        }



        // Post api/<controller>
       
        [HttpPost]
        public HttpResponseMessage CreatePaySlip([FromBody]Employee employee)
        {
            this.Validate(employee);
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            if (employee != null)
            {
                PayslipAbstractFactory payslipFactory = new PayslipFactory();
                var payslip = payslipFactory.GetPaySlip(TaxMethod.Austerlia);
                return Request.CreateResponse(HttpStatusCode.OK, payslip.GenerateEmployeePayslip(employee), Configuration.Formatters.JsonFormatter);
            }
            else
                return Request.CreateResponse(HttpStatusCode.NotFound);



        }


    }

}