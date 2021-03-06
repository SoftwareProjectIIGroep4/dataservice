﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindModel
{
    public static class DataAccess
    {
        public static NorthwindEntities context = new NorthwindEntities(new Uri("http://services.odata.org/V3/Northwind/Northwind.svc"));
        private static Dictionary<int, Employee> Employees = null;

        public async static Task<Dictionary<int, Employee>> GetEmployees()
        {
            await refreshIfEmployeesEmpty();            
            return Employees;
        }

        public async static Task<Dictionary<int, Employee>> GetEmployeesByReportsTo(int id)
        {
            await refreshIfEmployeesEmpty();
            return Employees.Where(x => x.Value.ReportsTo == id).ToDictionary(p => p.Key, p => p.Value);
        }

        public async static Task<Employee> GetEmployeeByID(int id)
        {
            await refreshIfEmployeesEmpty();
            return Employees.Where(x => x.Key == id).FirstOrDefault().Value;
        }

        public async static Task refreshEmployees()
        {
            Employees = new Dictionary<int, Employee>();
            IEnumerable<Employee> test = await context.Employees.AddQueryOption("$select", "EmployeeID, LastName, FirstName, Title, TitleOfCourtesy, ReportsTo").ExecuteAsync();
            foreach (Employee emp in test)
            {                
                Employees[emp.EmployeeID] = emp;
            }
        }

        private async static Task refreshIfEmployeesEmpty ()
        {
            if (Employees == null)
            {
                await refreshEmployees();
            }
        }
    }
}
