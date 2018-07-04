import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Payslip } from '../Models/payslip.model'

@Component({
  selector: 'pay-slip',
  templateUrl: './payslip.component.html'
})
export class PayslipComponent implements OnInit {
  @Input() public payslip: Payslip;
  @Output() showEmployee = new EventEmitter();

  Back() {
    this.showEmployee.emit();
  }
  constructor(private http: HttpClient) { }
 
  ngOnInit() {
   
  }
}
