using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object
{
    public class DataUCChangedEventArgs
    {
        public readonly int data;
        public DataUCChangedEventArgs(int data)
        {
            this.data = data;
        }

    }
}
