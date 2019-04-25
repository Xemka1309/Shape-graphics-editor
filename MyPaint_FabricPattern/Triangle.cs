using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyPaint_FabricPattern
{
    class Triangle : Shape, IShapeManipulator
    {
        public Triangle(float outline_width, Color color, PointF[] points)
        {
            this.color = color;
            this.outline_width = outline_width;
            this.points = new PointF[3];
            this.points[0] = points[0];
            this.points[1] = points[1];
            this.points[2] = points[2];
            this.Paint();
        }
        public void Paint()
        {
            //MainForm.painter.SaveGraphicsState();
            MainForm.graphics.DrawLine(MainForm.painter.pen, this.points[0], this.points[1]);
            MainForm.graphics.DrawLine(MainForm.painter.pen, this.points[1], this.points[2]);
            MainForm.graphics.DrawLine(MainForm.painter.pen, this.points[2], this.points[0]);
            MainForm.painter.LastShape = this;
        }
    }
}
