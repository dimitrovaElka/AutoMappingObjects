﻿

namespace Employees.DtoModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class ManagerDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<EmployeeDto> ManagerEmployees { get; set; }

        public int ManagerEmployeesCount { get; set; }

        
    }
}
