using EmployeePayslipContracts;
using EmployeePayslipModel.Models;
using static EmployeePayslipModel.Utility.Global;

namespace EmployeePayslipBuisness
{
    public class PayslipFactory: PayslipAbstractFactory
    {
        public override IGeneratePayslip GetPaySlip(TaxMethod method)
        {
            switch (method)
            {
                case TaxMethod.Austerlia:
                default:
                   return new GeneratePayslip();
            }
        }
     }
}
