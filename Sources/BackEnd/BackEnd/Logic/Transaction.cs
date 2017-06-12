using System;
namespace BackEnd.Logic
{
    class Transaction
    {
        private String _magd = string.Empty;
        private decimal _sodu = 0;

        public String MaGD
        {
            get { return _magd; }
            set { _magd = value; }
        }
        public decimal SoDuConLai
        {
            get { return _sodu; }
            set { _sodu = value; }
        }
    }
}
