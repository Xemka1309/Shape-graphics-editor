using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    //[JsonObject]
    [DataContract]
    class Line : Shape, IRepositable,IShapeDll,IThreePointsToPaint
    {
        // [JsonProperty("point1")]
        [DataMember]
        public PointF point1;
        //[JsonProperty("point2")]
        [DataMember]
        public PointF point2;
        public Line(float outline_width, Color color, PointF point1, PointF point2)
        {
            this.color = color;
            this.outline_width = outline_width;
            this.point1 = point1;
            this.point2 = point2;
        }
        public Line()
        {

        }
        public void SetPaintArgs(string[] args)
        {
            this.point1.X = Convert.ToInt32(args[0]);
            this.point1.Y = Convert.ToInt32(args[1]);
            this.point2.X = Convert.ToInt32(args[2]);
            this.point2.Y = Convert.ToInt32(args[3]);
            //this.height = Convert.ToInt32(args[3]);
        }
        public override void SetFields(string[] args)
        {
            base.SetFields(args);
            this.point1.X = Convert.ToInt32(args[0]);
            this.point1.Y = Convert.ToInt32(args[1]);
            this.point2.X = Convert.ToInt32(args[2]);
            this.point2.Y = Convert.ToInt32(args[3]);
        }
        override public void Paint(Graphics graphics)
        {
            graphics.DrawLine(new Pen(this.color, this.outline_width), this.point1, this.point2);
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
            return point1;
        }
        public void SetWidth(float width)
        {
            this.outline_width = width;
        }
        public void SetColor(Color color)
        {
            this.color = color;
        }
        public Shape GetShape()
        {
            return new Line();
        }
    }
}
