using System;
using EmployeePayslipContracts;
using EmployeePayslipModel.Models;
using EmployeePayslipModel.Utility;

namespace  EmployeePayslipBuisness
{
    public class GeneratePayslip : IGeneratePayslip
    {
        Payslip payCheck;
        public GeneratePayslip()
        {
            payCheck = new Payslip();
        }

        public Payslip GenerateEmployeePayslip(Employee employee)
        {
            // Payslip payCheck = new Payslip();
            payCheck.FullName = string.Join(" ", employee.FirstName, employee.LastName);
            payCheck.PayPeriod = Global.GetDateRange(employee.StartDate);
            this.CalculateGrossIncome(employee.AnnualSalary);
            payCheck.IncomeTax = calculateTax(employee.AnnualSalary);
            this.CalculateNetIncome();
            this.CalculateSuperAnnuation(employee.SuperRate);
            return payCheck;
        }

      

        public void CalculateGrossIncome(int annualSalary)
        {
            payCheck.GrossIncome = annualSalary / 12.0;
            payCheck.GrossIncome = Math.Round(payCheck.GrossIncome, MidpointRounding.AwayFromZero);
        }
        
        public void CalculateNetIncome()
        {
            payCheck.NetIncome = (payCheck.GrossIncome - payCheck.IncomeTax);
            payCheck.NetIncome = Math.Round(payCheck.NetIncome, MidpointRounding.AwayFromZero);
        }


        public void CalculateSuperAnnuation(int superRate)
        {
            payCheck.SuperAnnuation = (payCheck.GrossIncome * superRate)/100.0;
            payCheck.SuperAnnuation = Math.Round(payCheck.SuperAnnuation, MidpointRounding.AwayFromZero);
        }


       
        public double calculateTax(int annualSalary)
        {
            double incomeTax=0;
            double minimumTax = 0;
            double addOnTaxPerDoller = 0;//in cents
            int minimumTaxableIncome = 0;
            bool isNotTaxble = false;

            switch (annualSalary)
            {
                case int annualSalaryAmt when (annualSalaryAmt <= 18200):
                default:
                    isNotTaxble = true;
                    break;
                case int annualSalaryAmt when (annualSalaryAmt > 18200 && annualSalaryAmt <= 37000):
                    minimumTax = 0;
                    addOnTaxPerDoller = 19;//in cents
                    minimumTaxableIncome = 18201;                    
                    break;
                case int annualSalaryAmt when (annualSalaryAmt > 37000 && annualSalaryAmt <= 87000):
                    minimumTax = 3572;
                    addOnTaxPerDoller = 32.5;
                    minimumTaxableIncome = 37000;
                    break;
                case int annualSalaryAmt when (annualSalaryAmt > 87000 && annualSalaryAmt <= 180000):
                    minimumTax = 19822;
                    addOnTaxPerDoller = 37;
                    minimumTaxableIncome = 87000;
                    break;
                case int annualSalaryAmt when (annualSalaryAmt > 180000):
                    minimumTax = 54232;
                    addOnTaxPerDoller = 45;
                    minimumTaxableIncome = 180000;
                    break;
            }

            //change cents to doller
            addOnTaxPerDoller = addOnTaxPerDoller / 100.0;
            incomeTax = isNotTaxble?0: Math.Round((minimumTax + (annualSalary - minimumTaxableIncome) * addOnTaxPerDoller) / 12.0, MidpointRounding.AwayFromZero);

            return incomeTax;
        }
    }
}
