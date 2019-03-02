using System;
using System.Collections.Generic;
using Api.Models;
using Foundation.ObjectHydrator;

namespace Api
{
    public class Repository
    {
        public static Repository intance { get; } = new Repository();
        public IList<CustomerDTO> customers { get; set; }

        public Repository()
        {
            //Crea 5 usuarios
            Hydrator<CustomerDTO> hydrator = new Hydrator<CustomerDTO>();
            customers = hydrator.GetList(5);
            //inicializa las ordenes
            Random ram = new Random();
            Hydrator<OrdersDTO> ordersHydrator = new Hydrator<OrdersDTO>();
            foreach(var customer in customers)
            {
                customer.orders = ordersHydrator.GetList(ram.Next(1, 10));
            }

        }
    }
}
