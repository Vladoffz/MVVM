using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Model
{ [DataContract]
    public class Transport
    {
        [DataMember]
        public string Name;
        [DataMember]
        public int MaxWeight;
        [DataMember]
        public int MaxHeight;
        [DataMember]
        public int MaxWidth;
        [DataMember]
        public int Speed;
    }
}
