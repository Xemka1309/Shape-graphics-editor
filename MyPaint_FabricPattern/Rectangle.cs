using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyPaint_FabricPattern
{
    //[JsonObject]
    [DataContract]
    class Rectangle : Shape, IRepositable
    {
       // [JsonProperty("upper_left_point")]
        [DataMember]
        public PointF upper_left_point;
        //[JsonProperty("width")]
        [DataMember]
        public float width;
        //[JsonProperty("height")]
        [DataMember]
        public float height;

        public Rectangle(float outline_width, Color color, PointF upper_left_point, float width, float height)
        {
            this.color = color;
            this.outline_width = outline_width;
            this.upper_left_point = upper_left_point;
            this.width = width;
            this.height = height;
            //this.Paint();
        }
        // конструктор для квадрата
        public Rectangle(float outline_width, Color color, PointF upper_left_point, float width)
        {
            this.color = color;
            this.outline_width = outline_width;
            this.upper_left_point = upper_left_point;
            this.width = width;
            this.height = width;
            //this.Paint();
        }

        override public void Paint(Graphics graphics)
        {
            
            graphics.DrawRectangle(new Pen(this.color, this.outline_width), upper_left_point.X, upper_left_point.Y, width, height);
            //MainForm.painter.LastShape = this;
        }
        public void ChangeOutlineWidth(float width)
        {
            this.outline_width = width;
        }
        public void ChangeColor(Color color)
        {
            this.color = color;
        }
        public PointF getpospoint()
        {
            return upper_left_point;
        }
    }
}
