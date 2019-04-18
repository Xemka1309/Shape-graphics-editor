using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace MyPaint_FabricPattern
{
    public class ShapeCreator
    {
        Shape shape;
    }
    
        
    public class Shape
    {
        public PointF[] points;
        public Color color;
        public float outline_width;

    }

    public interface IShapeManipulator
    {
       // Color GetColor();
       // Color ChangeColor();
        void Paint();
       // void Remove();

    }
    // Конкретные фигуры
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
            MainForm.painter.SaveGraphicsState();
            MainForm.graphics.DrawLine(MainForm.painter.pen, this.points[0], this.points[1]);
            MainForm.graphics.DrawLine(MainForm.painter.pen, this.points[1], this.points[2]);
            MainForm.graphics.DrawLine(MainForm.painter.pen, this.points[2], this.points[0]);
            MainForm.painter.LastShape = this;
        }
    } 

    class Rectangle : Shape, IShapeManipulator
    {
        float width, height;
        
        public Rectangle(float outline_width, Color color, PointF upper_left_point, float width,float height)
        {
            this.color = color;
            this.outline_width = outline_width;
            this.points = new PointF[4];
            this.points[0] = upper_left_point;
            this.width = width;
            this.height = height;
            this.Paint();
        }
        // конструктор для квадрата
        public Rectangle(float outline_width, Color color, PointF upper_left_point, float width)
        {
            this.color = color;
            this.outline_width = outline_width;
            this.points = new PointF[4];
            this.points[0] = upper_left_point;
            this.width = width;
            this.height = width;
            this.Paint();
        }

        public void Paint()
        {
            MainForm.painter.SaveGraphicsState();
            MainForm.graphics.DrawRectangle(MainForm.painter.pen, points[0].X, points[0].Y, width, height);
            MainForm.painter.LastShape = this;
        }
    }
    class Ellipse : Shape, IShapeManipulator
    {
        float width, height;
        public Ellipse(float outline_width, Color color, PointF upper_left_point, float width, float height)
        {
            this.color = color;
            this.outline_width = outline_width;
            this.points = new PointF[4];
            this.points[0] = upper_left_point;
            this.width = width;
            this.height = height;
            this.Paint();
        }
        // конструктор для окружности
        public Ellipse(float outline_width, Color color, PointF upper_left_point, float width)
        {
            this.color = color;
            this.outline_width = outline_width;
            this.points = new PointF[4];
            this.points[0] = upper_left_point;
            this.width = width;
            this.height = width;
            this.Paint();
        }
        public void Paint()
        {
            MainForm.painter.SaveGraphicsState();
            MainForm.graphics.DrawEllipse(MainForm.painter.pen, points[0].X, points[0].Y, width, height);
            MainForm.painter.LastShape = this;
        }
    }
    class Line : Shape, IShapeManipulator
    {
        public Line(float outline_width, Color color, PointF point1, PointF point2)
        {
            this.color = color;
            this.outline_width = outline_width;
            this.points = new PointF[2];
            this.points[0] = point1;
            this.points[1] = point2;
            this.Paint();
        }
        public void Paint()
        {
            MainForm.painter.SaveGraphicsState();
            MainForm.graphics.DrawLine(MainForm.painter.pen, this.points[0], this.points[1]);
            MainForm.painter.LastShape = this;
        }
    }
    
    class Quadrilateral : Shape, IShapeManipulator
    {
        public Quadrilateral(float outline_width, Color color, PointF[] points)
        {
            this.color = color;
            this.outline_width = outline_width;
            this.points = new PointF[4];
            this.points[0] = points[0];
            this.points[1] = points[1];
            this.points[2] = points[2];
            this.points[3] = points[3];
            this.Paint();
        }
        public void Paint()
        {
            MainForm.painter.SaveGraphicsState();
            MainForm.graphics.DrawLine(MainForm.painter.pen, this.points[0], this.points[1]);
            MainForm.graphics.DrawLine(MainForm.painter.pen, this.points[1], this.points[2]);
            MainForm.graphics.DrawLine(MainForm.painter.pen, this.points[2], this.points[3]);
            MainForm.graphics.DrawLine(MainForm.painter.pen, this.points[3], this.points[0]);
            MainForm.painter.LastShape = this;
        }
    }
}
