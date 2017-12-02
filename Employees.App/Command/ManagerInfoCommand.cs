
namespace Employees.App.Command
{
    using Employees.Services;
    using System;
    using System.Collections.Generic;
    using System.Text;
    class ManagerInfoCommand : ICommand
    {
        private readonly EmployeeService employeeService;
        public ManagerInfoCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        public string Execute(params string[] args)
        {
            var managerId = int.Parse(args[0]);
            var manager = employeeService.ManagerInfo(managerId);

            var result = new StringBuilder();
            result.AppendLine($"{manager.FirstName} {manager.LastName} | Employees: {manager.ManagerEmployeesCount}");
                //$"{manager.FirstName} {manager.LastName} | Employees: {manager.ManagerEmployeesCount}" + Environment.NewLine;
            var employees = manager.ManagerEmployees;

            foreach (var e in employees)
            {
                result.AppendLine($"    - {e.FirstName} {e.LastName} - ${e.Salary:f2}");
            }

            return result.ToString().Trim();
        }
    }
}
