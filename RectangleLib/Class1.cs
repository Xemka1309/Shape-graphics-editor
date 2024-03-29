﻿using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace ClassLibrary
{
    [DataContract]
    class Rectangle : Shape, IRepositable, IShapeDll,ITwoPointsToPaint, IEditable
    {
        [DataMember]
        public PointF upper_left_point;
        [DataMember]
        public float width;
        [DataMember]
        public float height;

        public Rectangle(float outline_width, Color color, PointF upper_left_point, float width, float height)
        {
            this.color = color;
            this.outline_width = outline_width;
            this.upper_left_point = upper_left_point;
            this.width = width;
            this.height = height;
        }
        public void SetPaintArgs(string[] args)
        {
            this.upper_left_point.X = Convert.ToInt32(args[0]);
            this.upper_left_point.Y = Convert.ToInt32(args[1]);
            this.width = Convert.ToInt32(args[2]);
            this.height = Convert.ToInt32(args[3]);
        }
        // конструктор для квадрата
        public Rectangle(float outline_width, Color color, PointF upper_left_point, float width)
        {
            this.color = color;
            this.outline_width = outline_width;
            this.upper_left_point = upper_left_point;
            this.width = width;
            this.height = width;
        }
        public Rectangle()
        {

        }
        public override void SetFields(string[] args)
        {
            base.SetFields(args);
            this.upper_left_point.X = Convert.ToInt32(args[0]);
            this.upper_left_point.Y = Convert.ToInt32(args[1]);
            this.width = Convert.ToInt32(args[2]);
            this.height = Convert.ToInt32(args[3]);
        }
        override public void Paint(Graphics graphics)
        {
            graphics.DrawRectangle(new Pen(this.color, this.outline_width), upper_left_point.X, upper_left_point.Y, width, height);
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
            return new Rectangle();
        }
    }
}
