namespace Employees.Services
{
    using System;

    using Employees.Data;
    using Employees.DtoModels;
    using Employees.Models;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Collections.Generic;

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

        public string SetBirthDay(int employeeId, DateTime date)
        {
            var employee = context.Employees.Find(employeeId);

            employee.BirthDay = date;
            context.SaveChanges();

            return $"{employee.FirstName} {employee.LastName}";
        }

        public string SetAddress(int employeeId, string address)
        {
            var employee = context.Employees.Find(employeeId);

            employee.Address = address;
            context.SaveChanges();

            return $"{employee.FirstName} {employee.LastName}";
        }

        public EmployeeDto ById(int employeeId)
        {
            var employee = context.Employees.Find(employeeId);

            var employeeDto = Mapper.Map<EmployeeDto>(employee);

            return employeeDto;
        }

        public EmployeePersonalDto EmployeePersonalInfo(int employeeId)
        {
            var employee = context.Employees.Find(employeeId);

            var employeePersonalDto = Mapper.Map<EmployeePersonalDto>(employee);

            return employeePersonalDto;
        }

        public EmployeePersonalDto SetManager(int employeeId, int managerId)
        {
            var employee = context.Employees.Find(employeeId);

            var manager = context.Employees.Find(managerId);

            employee.Manager = manager;
            context.SaveChanges();

            var employeePersonalDto = Mapper.Map<EmployeePersonalDto>(employee);

            return employeePersonalDto;
        }

        public ManagerDto ManagerInfo(int managerId)
        {
            var employee = context.Employees
                .Include(m => m.ManagerEmployees)
                .SingleOrDefault(m => m.Id == managerId);

            var managerDto = Mapper.Map<ManagerDto>(employee);

            return managerDto;
        }

        public List<EmployeeManagerDto> ListEmployeesOlderThan(int age)
        {
            var employees = context.Employees
                .Where(e => e.BirthDay != null && Math.Floor((DateTime.Now - e.BirthDay.Value).TotalDays / 365) > age)
                .Include(e => e.Manager)
                .ProjectTo<EmployeeManagerDto>()
                .ToList();

            return employees;
        }
    }
}
