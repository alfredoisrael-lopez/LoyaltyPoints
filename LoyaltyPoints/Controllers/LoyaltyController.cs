using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoyaltyPoints.Model;
using LoyaltyPoints.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoyaltyPoints.Controllers
{
    [Route("api/[controller]")]
    public class LoyaltyController : Controller
    {
        Connector connector = new Connector();

        // GET api/loyalty/1000000001
        [HttpGet("{customerNumber}")]
        public CustomerLoyaltyPoints Get(String customerNumber)
        {
            return connector.GetPoints(customerNumber);
        }

        // GET api/loyalty/1000000001/redeem/<points>
        [HttpGet("{customerNumber}/redeem/{pointsToRedeem}")]
        public void RedeemPoints(String customerNumber, int pointsToRedeem)
        {
            connector.redeemPoint(customerNumber, pointsToRedeem);
        }

        // POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        // PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
