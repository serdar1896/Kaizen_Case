using System.Collections.Generic;
using System.Threading.Tasks;

namespace CouponGenarator.Core.Services
{
    public interface ICouponService
    {
        IEnumerable<string> BulkGenerateCoupon(int couponSize, int couponQuantity);

        string GenerateUniqueCoupon(int size);

        bool VerifyCoupon(string cuopon);
    }
}
