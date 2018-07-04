import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { HomeComponent } from './Components/home.component';
import { EmployeeComponent } from './Components/employee.component';
import { PayslipComponent } from './Components/payslip.component';
import { HeaderComponent } from './Layout/header/header.component';
import { AppRoutingModule } from './app-routing.module';
import { InputNumberDirective } from './Directives/inputNumber';
import { URLService } from './url-service';
import { MyDatePickerModule } from 'mydatepicker';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    PayslipComponent,
    EmployeeComponent,
    HeaderComponent,
    InputNumberDirective
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    MyDatePickerModule
  ],
  providers: [URLService],
  bootstrap: [AppComponent]
})
export class AppModule { }
