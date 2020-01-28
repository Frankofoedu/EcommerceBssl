using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceBssl.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EcommerceBssl.Api
{
     public  class ValuesViewModel
    {
        public string ActualAddress { get; set; }
    }

    [Route("api/[controller]")]
    public class ValuesController : Controller
    {

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
           
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
       // [HttpGet("{id}")]
       [HttpGet("ByName")]
        public string Get([FromQuery]int id, [FromQuery] string name)
        {
            return $"Your Name is {name} and your ID is : {id}";
        }


        [HttpGet("AddressById")]
        public Address GetAddressById([FromQuery]int id)
        {
            //this is our database
            var listOfAddress = new List<Address>
            {
                new Address
                {
                    Id = 1,
                     ActualAddress="No 6 john"
                },
                new Address
                {
                    Id = 2,
                     ActualAddress="No 3 coker"
                },
            };
            

            //this is our query 
            var requestedAddress = listOfAddress.FirstOrDefault(x => x.Id == id);



            return requestedAddress;
        }



        [HttpGet("AllAddress")]
        public List<ValuesViewModel> GetAllAddress()
        {
            //this is our database
            var listOfAddress = new List<Address>
            {
                new Address
                {
                    Id = 1,
                     ActualAddress="No 6 john"
                     
                },
                new Address
                {
                    Id = 2,
                     ActualAddress="No 3 coker"
                },
            };

            var data = listOfAddress.Select(x => new ValuesViewModel { ActualAddress = x.ActualAddress }).ToList();

            //#region using forloop csharp
            //var t = new List<ValuesViewModel>();
            //foreach (var address in listOfAddress)
            //{
            //    var vv = new ValuesViewModel();
            //    vv.ActualAddress = address.ActualAddress;
            //    t.Add(vv);
            //} 
            //#endregion

            return data;
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
