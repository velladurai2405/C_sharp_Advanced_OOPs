using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineFoodDeliveryApplication
{
    public interface IBalance
    {
        public double  WalletBalance { get;  }

        public double  WalletRecharge(double rechargeAmount);
        public double DeductBalance(double deductAmount);
    }
}