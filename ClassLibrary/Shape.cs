using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;


namespace MyPaint_FabricPattern
{
    [DataContract]
   // [JsonObject]
    public abstract class Shape
    {
        
        //public PointF[] points;
        [DataMember]
        //[JsonProperty("color")]
        public Color color;
        [DataMember]
        //[JsonProperty("outline_width")]
        public float outline_width;
        public virtual void Paint(Graphics graphics) { }
        
        

    }
    
}
