using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using CSharp_Ex.Common.Enums;
using CSharp_Ex.Services.Interfaces;
using Models;

namespace CSharp_Ex.Models
{
    public class PostOffice : BaseModel, IRepository<Postage>
    {
        public PostOffice(int id): base(id) {}

        private List<Postage> Postages {get; set;} = [];

        public void AddData()
        {
            var customer1 = new Customer(1, "Nguyen Van A", "A");
            var customer2 = new Customer(2, "Tran Thi C", "C");
            var customer3 = new Customer(3, "Nguyen Thi Hoai F", "E");
            var customer4 = new Customer(4, "Nguyen Truong K", "Q");

            Postages.Add(new Letter(3,  "Hue", "A", customer1, FeeType.Fast));
            Postages.Add(new Letter(4,  "England", "Manchester", customer2, FeeType.Manual));
            Postages.Add(new Letter(5,  "US", "VA", customer3, FeeType.Fast));

            Postages.Add(new Package(6,  "Singapore", "Singapore", (float)10.1 ,customer1));
            Postages.Add(new Package(7,  "Thailand", "Bangkok", (float)7.1 ,customer1));
        }

        public void Add(Postage entity)
        {
            Postages.Add(entity);
        }

        public void Delete(int id)
        {
            var item = Postages.First(_ => _.Id == id);
            if (item is not null) {
                Postages.Remove(item);
                System.Console.WriteLine($"Remove item id={id}");
                return;
            }

            System.Console.WriteLine($"Not found item id={id}");
        }

        public IEnumerable<Postage> GetAll()
        {
            return Postages;
        }

        public Postage? GetById(int id)
        {
            return Postages.First(_ => _.Id == id);
        }


        public void Update(Postage entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Postage> GetEnumerator()
        {
            foreach (var postage in Postages)
            {
                yield return postage;
            }
        }

        public void DeleteMany(List<int> ids)
        {
            if (ids.Count > 0) {
                Postages.RemoveAll(p => ids.Contains(p.Id));
            }
        }
    }

}