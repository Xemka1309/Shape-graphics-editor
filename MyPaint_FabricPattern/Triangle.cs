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
    class Triangle : Shape, IEditable
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
        override public void Paint()
        {
            MainForm.graphics.DrawLine(new Pen(this.color, this.outline_width), this.point1, this.point2);
            MainForm.graphics.DrawLine(new Pen(this.color, this.outline_width), this.point2, this.point3);
            MainForm.graphics.DrawLine(new Pen(this.color, this.outline_width), this.point3, this.point1);
            MainForm.painter.LastShape = this;
        }
        public void ChangeOutlineWidth(float width)
        {
            this.outline_width = width;
        }
        public void ChangeColor(Color color)
        {
            this.color = color;
        }
    }
}
