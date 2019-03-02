using System;
using System.Collections.Generic;

namespace Api.Models
{
    public class CustomerDTO
    {
        public int id { get; set; }
        public string customerId { get; set; }
        public string companyName { get; set; }
        public string contactName { get; set; }
        public string contactTitle { get; set; }
        public string adress { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public string postalCode { get; set; }
        public string country { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }
        public ICollection<OrdersDTO> orders{ get; set; }
        public CustomerDTO()
        {

        }
    }
}
