A.Instruction to run application

Step 1. Set up the Development Environment

1.1.You need to set up your development environment before you can do anything. Install Node.js  and npm if they are not already on your machine.

1..2. Verify that you are running at least Node.js version 8.x or greater and npm version 5.x or greater by running node -v and npm -v in a terminal/console window. Older versions produce 	  errors, but newer versions are fine.

1.3. Then install the Angular CLI globally. Write following command in console window 
      npm install -g @angular/cli   

1.4. Install packages.Go to the project directory and write following command in console window
      cd EmployeeWebApp          
      npm install                   

1.5. Serve the application.Go to the project directory and launch the server.
      cd EmployeeWebApp           
      ng serve --open                

The ng serve command launches the server, watches your files, and rebuilds the app as you 	  make changes to those files.

Step 2. Run WebAPI
  1.  EmployeePayslipWebAPI must be set as startup app.

    1.1. In the Solution Explorer, select the EmployeePayslipWebAPI . Right-click the node to get 	the 	context menu.

    1.2.Click on ‘Set As Startup Project’.   

  2. Restore Nuget packages.
  
    2.1. Right click solution, Click Restore Nuget packages.

    2.2. Start the project

  3. Run application.

  4. At Home page, Fill all details and click on ‘Generate Payslip’ button to see payslip.

B. Assumptions: 

  1. Application assumption

1.1.Project is developed using VS2017, Framework version 4.6.1. 

1.2.I have used WebAPI 2.0 and Angular5 to develop application.

1.3.All fields are mandatory. 

    1.3. User can enter any date of month in start date field. Output will show start and end date of 	that month . Eg: If user entered  21/06/2018 as start date then Pay period in output will show 	date as 1 Jun 2018- 30 Jun 2018.
 
  2. Code Assumptions

    2.1. Used Abstract Factory pattern that is based country or location, I used enum to store all 	posibilities.

    2.2. So based on the location, Method to generate Payslip might change, that is handled using 	PayslipFactory.

    2.3. I have not used any database as It generates payslip dynamically according to entered 	employee details.

    2.4. Angular5 is used.
  
C. Link to source code :https://github.com/uvikakhatri/EmployeePayslipAngularApp

D. Test Inputs and outputs

    1.Test Inputs and outputs are stated in Unit Test Project
