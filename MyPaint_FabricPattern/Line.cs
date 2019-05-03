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
        public Line(float outline_width, Color color, PointF point1, PointF point2)
        {
            this.color = color;
            this.outline_width = outline_width;
            this.points = new PointF[2];
            this.points[0] = point1;
            this.points[1] = point2;
            //this.Paint();
        }
        public void Paint()
        {
            //MainForm.painter.SaveGraphicsState();
            MainForm.graphics.DrawLine(MainForm.painter.pen, this.points[0], this.points[1]);
            MainForm.painter.LastShape = this;
        }
    }
}
