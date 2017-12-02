
namespace Employees.App.Command
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Employees.Services;
    using System.Linq;

    class SetAddressCommand : ICommand
    {
        private readonly EmployeeService employeeService;
        public SetAddressCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        // SetAddress <employeeId> <address> 
        public string Execute(params string[] args)
        {
            int employeeId = int.Parse(args[0]);
            string address = String.Join(" ", args.Skip(1));
            var employeeName = employeeService.SetAddress(employeeId, address);
            return $"{employeeName}'s address is set to {address}";
        }
    }
}
