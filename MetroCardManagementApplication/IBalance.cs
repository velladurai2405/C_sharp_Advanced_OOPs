using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagementApplication
{
    public interface IBalance
    {
        //properties
        public double Balance { get;  }

        //methods
        public double WalletRecharge(double rechargeAmount);
        public double DeductBalance(double rechargeAmount);
    }
}