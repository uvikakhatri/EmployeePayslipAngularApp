using EmployeePayslipModel.Models;

namespace EmployeePayslipContracts
{
    public interface  IGeneratePayslip
    {
        Payslip GenerateEmployeePayslip(Employee employee);

    }
}
