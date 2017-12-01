namespace Employees.Services
{
    using System;

    using Employees.Data;
    using Employees.DtoModels;
    using AutoMapper;
    using Employees.Models;

    public class EmployeeService
    {
        private readonly EmployeesContext context;
        public EmployeeService(EmployeesContext context)
        {
            this.context = context;
        }

        public void AddEmployee(EmployeeDto dto)
        {
            var employee = Mapper.Map<Employee>(dto);
            context.Employees.Add(employee);
            context.SaveChanges();
        }

        public EmployeeDto ById(int employeeId)
        {
            var employee = context.Employees.Find(employeeId);

            var employeeDto = Mapper.Map<EmployeeDto>(employee);

            return employeeDto;
        }
    }
}
