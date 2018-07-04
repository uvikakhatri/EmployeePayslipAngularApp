import { TestBed, async, ComponentFixture } from '@angular/core/testing';
//import { BrowserModule } from '@angular/platform-browser';
//import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule, FormBuilder } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { HomeComponent } from '../Components/home.component';
import { EmployeeComponent } from '../Components/employee.component';
import { PayslipComponent } from '../Components/payslip.component';
//import { HeaderComponent } from '../Layout/header/header.component';
//import { AppRoutingModule } from '../app-routing.module';
import { InputNumberDirective } from '../Directives/inputNumber';
import { URLService } from '../url-service';
import { MyDatePickerModule } from 'mydatepicker';
import { HttpClient, HttpHeaders } from '@angular/common/http';
describe('Component: Employee', () => {

  let component: EmployeeComponent;
  let fixture: ComponentFixture<EmployeeComponent>;

  beforeEach(() => {

    // refine the test module by declaring the test component
    TestBed.configureTestingModule({
      imports: [
       
        FormsModule,
        ReactiveFormsModule,
        MyDatePickerModule],
         declarations: [
        PayslipComponent,
        EmployeeComponent,
        
        InputNumberDirective],
      providers: [{http: HttpClient,  formBuilder: FormBuilder,  url: URLService}]
    });

    // create component and test fixture
    fixture = TestBed.createComponent(EmployeeComponent);

    // get test component from the fixture
    component = fixture.componentInstance;
    component.ngOnInit();
  });

  it('form invalid when empty', () => {

    expect(component.form.valid).toBeFalsy();
  });

  it('First Name field validity', () => {
    debugger;
    let errors = {};
    let firstName = component.form.controls['FirstName'];
    expect(firstName.valid).toBeFalsy();

    // FirstName is required
    errors = firstName.errors || {};
    expect(errors['required']).toBeTruthy();

    // Set FirstName to something
    firstName.setValue("uvika");
    errors = firstName.errors || {};
    expect(errors['required']).toBeFalsy();

  });
  it('Last Name field validity', () => {
    let errors = {};
    let lastName = component.form.controls['LastName'];
    expect(lastName.valid).toBeFalsy();

    // LastName field is required
    errors = lastName.errors || {};
    expect(errors['required']).toBeTruthy();

    // Set LastName to something
    lastName.setValue("khatri");
    errors = lastName.errors || {};
    expect(errors['required']).toBeFalsy();


  });

  it('Annual Salary field validity', () => {
    let errors = {};
    let salary = component.form.controls['AnnualSalary'];
    expect(salary.valid).toBeFalsy();

    // AnnualSalary field is required
    errors = salary.errors || {};
    expect(salary['required']).toBeTruthy();

    // Set AnnualSalary to something
    salary.setValue("80000");
    errors = salary.errors || {};
    expect(errors['required']).toBeFalsy();

    salary.setValue("-2000");
    errors = salary.errors || {};
    expect(errors['incorrect']).toBeTruthy();

    salary.setValue("test");
    errors = salary.errors || {};
    expect(errors['incorrect']).toBeTruthy();
  });

  it('Super Rate field validity', () => {
    let errors = {};
    let superRate = component.form.controls['SuperRate'];
    expect(superRate.valid).toBeFalsy();

    // AnnualSalary field is required
    errors = superRate.errors || {};
    expect(superRate['required']).toBeTruthy();

    // Set AnnualSalary to something
    superRate.setValue("9");
    errors = superRate.errors || {};
    expect(errors['required']).toBeFalsy();

    superRate.setValue("-2");
    errors = superRate.errors || {};
    expect(errors['incorrect']).toBeTruthy();

    superRate.setValue("15");
    errors = superRate.errors || {};
    expect(errors['incorrect']).toBeTruthy();
  });

  it('Start Date field validity', () => {
    let errors = {};
    let startDate = component.form.controls['StartDate'];
    expect(startDate.valid).toBeFalsy();

    // LastName field is required
    errors = startDate.errors || {};
    expect(errors['required']).toBeTruthy();

    // Set LastName to something
    startDate.setValue(new Date());
    errors = startDate.errors || {};
    expect(errors['required']).toBeFalsy();


  });


});

