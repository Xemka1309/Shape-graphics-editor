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
    class Line : Shape, IShapeManipulator
    {
        [DataMember]
        PointF point1;
        [DataMember]
        PointF point2;
        public Line(float outline_width, Color color, PointF point1, PointF point2)
        {
            this.color = color;
            this.outline_width = outline_width;
            this.point1 = point1;
            this.point2 = point2;
        }
        override public void Paint()
        {   
            MainForm.graphics.DrawLine(MainForm.painter.pen, this.point1, this.point2);
            MainForm.painter.LastShape = this;
        }
    }
}
