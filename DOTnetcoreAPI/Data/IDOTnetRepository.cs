using System.Collections.Generic;
using DOTnetcoreAPI.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DOTnetcoreAPI.Data
{
    public interface IDOTnetRepository
    {
        List<Product> GetProducts();
        List<Product> GetProductsByCategory(string category);

        List<Order> GetAllOrders(bool includeItems);
        Order GetOrderById(int id);
        void AddEntity(object model);

        bool SaveAll();
    }
}