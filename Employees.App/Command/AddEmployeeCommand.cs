
namespace Employees.App.Command
{
    using Employees.DtoModels;
    using Employees.Services;
    using System;
    using System.Collections.Generic;
    using System.Text;
    class AddEmployeeCommand : ICommand
    {
        private readonly EmployeeService employeeService;

        public AddEmployeeCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public void Execute(params string[] args)
        {
            //AddEmployee <firstName> <lastName> <salary> 
            string firstName = args[0];
            string lastName = args[1];
            decimal salary = decimal.Parse(args[2]);
            var employeeDto = new EmployeeDto(firstName, lastName, salary);

            
        }

    }
}
