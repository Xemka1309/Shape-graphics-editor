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
    class Rectangle : Shape, IShapeManipulator
    {
        [DataMember]
        PointF upper_left_point;
        [DataMember]
        float width;
        [DataMember]
        float height;

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

        override public void Paint()
        {
            
            MainForm.graphics.DrawRectangle(MainForm.painter.pen, upper_left_point.X, upper_left_point.Y, width, height);
            MainForm.painter.LastShape = this;
        }
    }
}
