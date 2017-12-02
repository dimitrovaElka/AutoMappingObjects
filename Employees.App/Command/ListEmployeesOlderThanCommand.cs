namespace Employees.App.Command
{
    using Employees.DtoModels;
    using Employees.Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class ListEmployeesOlderThanCommand : ICommand
    {
        private readonly EmployeeService employeeService;
        public ListEmployeesOlderThanCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        public string Execute(params string[] args)
        {
            int age = int.Parse(args[0]);

            List<EmployeeManagerDto> employees = employeeService.ListEmployeesOlderThan(age);

            if (employees == null)
            {
                throw new ArgumentException($"No employees older than {age} age.");
            }

            var result = new StringBuilder();

            var orderedEmployees = employees.OrderByDescending(e => e.Salary);

            foreach (var e in orderedEmployees)
            {
                result.Append($"{e.FirstName} {e.LastName} - ${e.Salary:f2} - Manager: ");
                if (e.Manager == null)
                {
                    result.AppendLine("[no manager]");
                }
                else
                {
                    result.AppendLine(e.Manager.LastName);
                }
            }
            return result.ToString().TrimEnd();
        }
    }
}
