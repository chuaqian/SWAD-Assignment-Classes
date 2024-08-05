using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWADAssgClasses
{
    public class DigitalWallet : Payment
    {
        public string walletId { get; set; }
        public string walletName { get; set; }
        public string walletEmail { get; set; }
    }
}