using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FungiParadise.Exception
{
    class InvalidValuesException : SystemException
    {

        public InvalidValuesException()
        : base("Some values are not allowed on this method")
        {
        }

        public InvalidValuesException(string message)
        : base(message)
        {
        }

    }
}
