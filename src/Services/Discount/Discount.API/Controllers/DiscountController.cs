﻿using Discount.API.Entities;
using Discount.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Discount.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountRepositories _repositories;

        public DiscountController(IDiscountRepositories repositories)
        {
            _repositories = repositories;
        }

        [HttpGet("{productName}", Name ="GetDiscount")]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Coupon>> GetDiscount(string productName)
        {
           var coupon = await _repositories.GetDiscount(productName);
            return Ok(coupon);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Coupon>> CreateDiscount([FromBody] Coupon coupon)
        {
            //bool result = await _repositories.CreateDiscount(coupon);
            //Coupon couponOnDatabase = await _repositories.GetDiscount(coupon.ProductName);
            //return CreatedAtRoute("GetDiscount", new { couponOnDatabase.Id, couponOnDatabase.ProductName, couponOnDatabase.Description, couponOnDatabase.Amout }, couponOnDatabase);

            await _repositories.CreateDiscount(coupon);
            return CreatedAtRoute("GetDiscount", new { productName = coupon.ProductName }, coupon);



            //bool result = await _repositories.CreateDiscount(coupon);
            //Coupon couponOnDatabase = await _repositories.GetDiscount(coupon.ProductName);
            //return CreatedAtRoute("GetDiscount", new { couponOnDatabase.Id, couponOnDatabase.ProductName, couponOnDatabase.Description, couponOnDatabase.Amout }, couponOnDatabase);

        }

        [HttpPut]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Coupon>> UpdateDiscount([FromBody] Coupon coupon)
        {
            return Ok(await _repositories.UpdateDiscount(coupon));
        }

        [HttpDelete("{productName}", Name = "DeleteDiscount")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> DeleteDiscount(string productName)
        {
            return Ok(await _repositories.DeleteDiscount(productName));
        }
    }
}
