using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    [DataContract]
    class Triangle : Shape, IShapeDll, IEditable
    {
        [DataMember]
        public PointF point1;
        [DataMember]
        public PointF point2;
        [DataMember]
        public PointF point3;
        public Triangle(float outline_width, Color color, PointF[] points)
        {
            this.color = color;
            this.outline_width = outline_width;
            this.point1 = points[0];
            this.point2 = points[1];
            this.point3 = points[2];
        }
        public Triangle()
        {

        }
        override public void Paint(Graphics graphics)
        {
            graphics.DrawLine(new Pen(this.color, this.outline_width), this.point1, this.point2);
            graphics.DrawLine(new Pen(this.color, this.outline_width), this.point2, this.point3);
            graphics.DrawLine(new Pen(this.color, this.outline_width), this.point3, this.point1);
            //painter.LastShape = this;
        }
        public void ChangeOutlineWidth(float width)
        {
            this.outline_width = width;
        }
        public void ChangeColor(Color color)
        {
            this.color = color;
        }
        public void SetColor(Color color)
        {
            this.color = color;
        }
        public void SetWidth(float width)
        {
            this.outline_width = width;
        }
        public Shape GetShape()
        {
            return new Triangle();
        }
    }
}
