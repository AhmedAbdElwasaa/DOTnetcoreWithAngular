using DOTnetcoreAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOTnetcoreAPI.Data
{
    public class DOTnetRepository : IDOTnetRepository
    {
        private readonly DOTnetContext _context;
        private readonly ILogger<DOTnetRepository> _logger;

        public DOTnetRepository(DOTnetContext context,ILogger<DOTnetRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public List<Order> GetAllOrders()
        {
            try
            {
            _logger.LogInformation("Get all orders is Called ...");
            return _context.Orders
                    .Include(o => o.Items)
                    .ThenInclude(c => c.Product)
                    .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"failed to get all orders: {ex.Message}");
                return null;
                
            }
        }

        public List<Product> GetProducts()
        {
            try
            {
            _logger.LogInformation("Get Products is Called ....");
                return _context.Products
                               .OrderBy(c => c.Title)
                               .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all products: {ex.Message} ");
                return null;
            }
           
        }
        public List<Product> GetProductsByCategory(string category)
        {
            try
            {
                _logger.LogInformation("GetProductsByCategory is Called ...");
                return _context.Products
               .Where(p => p.Category == category)
               .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all products: {ex.Message} ");
                return null;
            }
           
        }

        public bool SaveAll()
        {
            try
            {
                _logger.LogInformation("SaveAll is Called ...");
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($" Failed to Save: {ex.Message}");
                return false;
            }
           
        }
    }
}
