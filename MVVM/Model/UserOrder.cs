using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Model
{ [DataContract]
   public  class UserOrder
    {
        [DataMember]
        public Transport Transport;
        [DataMember]
        public Destination Destination;
        [DataMember]
        public Good Good;
        [DataMember]
        public DateTime Date;
    }
}
