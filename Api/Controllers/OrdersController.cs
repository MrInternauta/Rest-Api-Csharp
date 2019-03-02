using System;
using System.Linq;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    // api/customer/23/orders
    [Route("api/customer")]
    public class OrdersController: Controller
    {
        public OrdersController()
        {
        }

        [HttpGet("{customerId}/order")]
        public IActionResult getOrders(int customerId) {
            var customer = Repository.intance.customers.FirstOrDefault(c => c.id == customerId);
            if (customer == null) return NotFound();
            else return Ok(customer.orders);
            }

        [HttpGet("{customerId}/order/{orderId}", Name = "getOrder")]
        public IActionResult getOrder(int customerId, int orderId)
        {
            var customer = Repository.intance.customers.FirstOrDefault(c => c.id == customerId);
            if (customer == null) return NotFound();
            var order = customer.orders.FirstOrDefault(o => o.OrderId == orderId);
            if (order == null) return NotFound();
            else return Ok(order);
        }

        [HttpPost("{customerId}/order/")]
        public IActionResult createOrder(
        int customerId,
        [FromBody] OrdersForCreationDTO order //Desde el cuerpo de la peticion
        )
        {
            //si envia order
            if (order == null) return BadRequest();
            //compuerba si existe el usuario
            var customer = Repository.intance.customers.FirstOrDefault(c => c.id == customerId);
            if (customer == null) return NotFound();
            var maxOrderId = Repository.intance.customers
            //selecciona el maximo id
            .SelectMany(c => c.orders).Max(o => o.OrderId);
            var finalOrder = new OrdersDTO()
            {
                OrderId = maxOrderId ++,
                EmployeeId = order.EmployeeId,
                OrderDate = order.OrderDate,
                RequiredDate = order.RequiredDate,
                ShippedDate = order.ShippedDate,
                ShipVia = order.ShipVia,
                Freight = order.Freight,
                ShipName = order.ShipName,
                ShipAddress = order.ShipAddress,
                ShipCity = order.ShipCity,
                ShipRegion = order.ShipRegion,
                ShipPostalCode = order.ShipPostalCode,
                ShipCountry = order.ShipCountry
    };
            customer.orders.Add(finalOrder);
            return CreatedAtRoute("getOrder",
                new
                {
                customerId,
                orderId = finalOrder.OrderId 
                },finalOrder);
        }



    }
}
