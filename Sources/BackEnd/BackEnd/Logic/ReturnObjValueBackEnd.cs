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

    }
}
