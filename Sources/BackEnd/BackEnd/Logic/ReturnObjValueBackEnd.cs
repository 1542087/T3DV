using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Logic
{
    class ReturnObjValueBackEnd
    {
        private Boolean _succsess = false;
        private Object _data = null;
        private String _message = string.Empty;
        private String _matk = string.Empty;
        private String _magd = string.Empty;
        private decimal _sodu = 0;
        public Boolean Success {
            get { return _succsess; }
            set { _succsess = value; }
        
        }
        public Object Data
        {
            get { return _data; }
            set { _data = value; }
        }
        public String Message
        {
            get { return _message; }
            set { _message = value; }
        }

        public String MaTK
        {
            get { return _matk; }
            set { _matk = value; }
        }
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
