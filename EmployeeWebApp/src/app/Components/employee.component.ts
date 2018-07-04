import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder, FormControl } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { Employee } from '../Models/employee.model';
import { Payslip } from '../Models/payslip.model';
import { URLService } from '../url-service';
import { IMyDpOptions } from 'mydatepicker';
import * as moment from 'moment';

@Component({
  selector: 'employee',
  templateUrl: './employee.component.html'
})
export class EmployeeComponent implements OnInit {
  public employee: Employee;
  public payslip: Payslip;
  public viewPayslip: boolean;
  public form: FormGroup;
  private startDate: any;
  public dateOptions: IMyDpOptions = {   
    dateFormat: 'dd/mm/yyyy',
    editableDateField: false,
    inline: false
  };

  constructor(private http: HttpClient, private formBuilder: FormBuilder, private url: URLService) {
    this.viewPayslip = false;
  }
  ngOnInit() {
    this.CreateNew();
  }

  initForm() {
    this.form = this.formBuilder.group({      
      FirstName: [null],
      LastName: [null],
      AnnualSalary: [null],
      SuperRate: [null],
      StartDate: [null]
    });

  }

  validateForm() {
    this.form = this.formBuilder.group({
      FirstName: [this.employee.FirstName, Validators.required],
      LastName: [this.employee.LastName, Validators.required],
      AnnualSalary: [this.employee.AnnualSalary, [Validators.required, this.intValidater]],
      SuperRate: [this.employee.SuperRate, [Validators.required, this.rateValidator]],
      StartDate: [this.startDate, Validators.required]    
    });
  }

  intValidater(control: FormControl) {
    if (control.value) {
      var isInteger = Number.isInteger(control.value);
      if (!isInteger || control.value < 0)
        return { incorrect: true };
    }
    return null;
  }

  rateValidator(control: FormControl) {
    if (control.value < 0 || control.value > 12)
      return { incorrect: true };
    else
      return null;
  }

  generatePayslip() {
    this.validateForm();
    if (!this.form.valid)
      return;

   
    this.employee.StartDate = this.startDate && this.startDate.jsdate ? moment.utc(this.startDate.jsdate).local().format() : null;
    this.url.postMethod('payslip', JSON.stringify(this.employee)).subscribe((data: Payslip) => {
      this.payslip = data;
      this.viewPayslip = true;
    });

  }

  showEmployee() {
    this.viewPayslip = false;
  }

  CreateNew() {
    this.initForm();
    this.employee = new Employee();
    this.startDate = null;
    this.viewPayslip = false;
  }
}
