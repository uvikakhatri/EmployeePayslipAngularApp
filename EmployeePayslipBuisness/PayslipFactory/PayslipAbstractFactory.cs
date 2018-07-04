using EmployeePayslipContracts;
using EmployeePayslipModel.Models;
using static EmployeePayslipModel.Utility.Global;

namespace EmployeePayslipBuisness
{
    public abstract class PayslipAbstractFactory
    {
        public abstract IGeneratePayslip GetPaySlip(TaxMethod method);
    }
}
