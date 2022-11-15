using CouponGenarator.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CouponGenarator.Services
{
    public class CouponService : ICouponService
    {

        public IEnumerable<string> BulkGenerateCoupon(int couponSize, int couponQuantity)
        {
            List<string> couponList = new List<string>();

            for (int i = 0; i < couponQuantity; i++)
            {
                couponList.Add(GenerateUniqueCoupon(couponSize));
            }

            return GetPage(couponList, 1, 100);
        }



        public string GenerateUniqueCoupon(int size)
        {
            string coupon;
            char[] couponChar;
            int total = 0;
            do
            {
                total = 0;
                coupon = GenerateCode(size);
                couponChar = coupon.ToCharArray();

                foreach (var letter in couponChar)
                {
                    total += Convert.ToInt32(letter);
                }
            }
            while (total != GetASCIIDecimalLimit(size) || CouponList.Contains(coupon));

            CouponList.Add(coupon);

            return coupon;
        }

        public bool VerifyCoupon(string cuopon)
        {
            int total = 0;

            foreach (var letter in cuopon)
            {
                total += Convert.ToInt32(letter);
            }

            return total == GetASCIIDecimalLimit((int)cuopon.Length) ? true : false;
        }

        private string GenerateCode(int size)
        {
            var coupon = new StringBuilder(size);
            var crypto = new RNGCryptoServiceProvider();
            var chars = ALPHABET.ToCharArray();
            var data = new byte[size];

            crypto.GetBytes(data);

            foreach (byte b in data)
            {
                coupon.Append(chars[b % (chars.Length)]);
            }

            return coupon.ToString();
        }


        private int GetASCIIDecimalLimit(int size)
        {
            var chars = ALPHABET.ToCharArray();
            int total = 0;

            foreach (var letter in chars)
            {
                total += Convert.ToInt32(letter);
            }
            var avg = (total / chars.Length) * size;

            return avg;
        }

        private IList<string> GetPage(IList<string> couponList, int pageNumber, int pageSize = 10)
        {
            return couponList.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }


        public static string ALPHABET = "ACDEFGHKLMNPRTXYZ234579";

        #region Saklama alanı
        public static HashSet<string> CouponList = new HashSet<string>();
        #endregion
    }
}
