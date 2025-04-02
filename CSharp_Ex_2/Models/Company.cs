using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharp_Ex.Services.Interfaces;

namespace CSharp_Ex_2.Models
{
    public class Company : IRepository<Employee>
    {
        private List<Employee> Employees {get; set;} = [];

        public void Add(Employee entity)
        {
            Employees.Add(entity);
        }

        public void Delete(int id)
        {
            var item = Employees.First(_ => _.Id == id);
            if (item is not null) {
                Employees.Remove(item);
                System.Console.WriteLine($"Remove item id={id}");
                return;
            }

            System.Console.WriteLine($"Not found item id={id}");
        }

        public void DeleteMany(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAll()
        {
            return Employees;
        }

        public Employee? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}