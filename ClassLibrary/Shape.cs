using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;


namespace ClassLibrary
{
    [DataContract]
    public abstract class Shape
    {
        [DataMember]

        public Color color;
        [DataMember]
        public float outline_width;
        public virtual void Paint(Graphics graphics) { }

    }
    
}
