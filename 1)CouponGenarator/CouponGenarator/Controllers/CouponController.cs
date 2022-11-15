using CouponGenarator.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CouponGenarator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CouponController : ControllerBase
    {
        private readonly ICouponService _couponService;
        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }


        /// <summary>
        /// GET: /BulkGenerateCoupon
        /// </summary>
        /// <param> </param>
        /// <returns></returns>
        [HttpGet]
        [Route("BulkGenerateCoupon")]
        [Description("Toplu Kupon Üret")]
        public IActionResult BulkGenerateCoupon(int couponSize, int couponQuantity)
        {
          return Ok(_couponService.BulkGenerateCoupon(couponSize, couponQuantity));
        }


        /// <summary>
        /// GET: /GenerateUniqueCoupon/8
        /// </summary>
        /// <param name="couponSize"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GenerateUniqueCoupon")]
        [Description("Kupon Üret")]
        public IActionResult GenerateUniqueCoupon(int couponSize)
        {
            return Ok(_couponService.GenerateUniqueCoupon(couponSize));
        }

        /// <summary>
        /// GET: /VerifyCoupon/XT2AC3NK
        /// </summary>
        /// <param name="coupon"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("VerifyCoupon")]
        [Description("Kupon Kodu Doğrulamat")]
        public IActionResult VerifyCoupon(string coupon)
        {
            return Ok(_couponService.VerifyCoupon(coupon));
        }

    }
}
