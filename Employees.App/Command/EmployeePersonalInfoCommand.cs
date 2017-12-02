
namespace Employees.App.Command
{
    using Employees.Services;
    using System;
    using System.Collections.Generic;
    using System.Text;
    class EmployeePersonalInfoCommand : ICommand
    {
        private readonly EmployeeService employeeService;
        public EmployeePersonalInfoCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        // EmployeePersonalInfo<employeeId>
        public string Execute(params string[] args)
        {
            int employeeId = int.Parse(args[0]);
            var employee = employeeService.EmployeePersonalInfo(employeeId);

            string birthday = "[no burtday specified]";
            if (employee.BirthDay != null)
            {
                birthday = employee.BirthDay.Value.ToString("dd-MM-yyyy");
            }

            string address = employee.Address??"[no address specified]";

            string result = $"ID: {employeeId} - {employee.FirstName} {employee.LastName} - ${employee.Salary:f2}"
                + Environment.NewLine + $"Birthday: {birthday}"
                + Environment.NewLine + $"Address: {address}";
            
            return result;
        }
    }
}
