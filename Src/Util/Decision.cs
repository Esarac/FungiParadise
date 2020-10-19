using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FungiParadise.Src.Util
{
    public abstract class Decision<T>
    {
        public abstract void Evaluate(T obj);
    }
}
