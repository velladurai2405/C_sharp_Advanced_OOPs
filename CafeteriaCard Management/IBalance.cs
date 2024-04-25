using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCard_Management
{
    public interface IBalance
    {
        public int WalletBalance { get;  }

        public int WalletRecharge(int amount);
        public int DeductAmount(int amount);
    }
}