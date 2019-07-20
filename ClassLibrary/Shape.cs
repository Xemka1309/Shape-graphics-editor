using System;
using System.Drawing;
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
        public virtual void SetFields(String[] args) { }
    }
    
}
