
namespace Employees.App.Command
{
    using System;
    using System.Globalization;
    using System.Collections.Generic;
    using System.Text;
    using Employees.Services;
    using Employees.DtoModels;

    class SetBirthdayCommand : ICommand
    {
        private readonly EmployeeService employeeService;
        public SetBirthdayCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        // SetBirthday<employeeId> <date: "dd-MM-yyyy"> 
        public string Execute(params string[] args)
        {
            int employeeId = int.Parse(args[0]);
            DateTime birthDay = DateTime.ParseExact(args[1], "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var employeeName = employeeService.SetBirthDay(employeeId, birthDay);

            return $"{employeeName}'s birthday is set to {birthDay}";
        }
    }
}
