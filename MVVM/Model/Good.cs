using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Model
{
    [DataContract]
    public class Good
    {
        [DataMember]
        public string Name;
        [DataMember]
        public int Weight;
        [DataMember]
        public int Height;
        [DataMember]
        public int Width;

        public Good() { }
    }
}
