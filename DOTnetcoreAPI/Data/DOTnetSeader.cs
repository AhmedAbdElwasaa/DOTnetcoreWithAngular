using DOTnetcoreAPI.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DOTnetcoreAPI.Data
{
    public class DOTnetSeader
    {
        private readonly DOTnetContext _context;
        private readonly IHostingEnvironment _hosting;

        public DOTnetSeader(DOTnetContext context,IHostingEnvironment hosting)
        {
            _context = context;
            _hosting = hosting;
        }

        public void Sead()
        {
            _context.Database.EnsureCreated();

            if(!_context.Products.Any())
            {
                //need to create sample data
                var file = Path.Combine(_hosting.ContentRootPath,"Data/art.json");
                var json = File.ReadAllText(file);
                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
                _context.Products.AddRange(products);

                var order = _context.Orders.Where(o => o.Id == 1).FirstOrDefault();
                if(order !=null)
                {

                    order.Items = new List<OrderItem>()
                    {
                       new OrderItem()
                       {
                           Product=products.First(),
                           Quantity=10,
                           UnitPrice=products.First().Price
                       }
                    };
                }

                _context.SaveChanges();
            }
        }
    }
}
