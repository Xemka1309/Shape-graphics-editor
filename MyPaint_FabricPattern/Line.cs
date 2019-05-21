﻿using System;
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
    class Line : Shape, IEditable, IRepositable
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
        override public void Paint()
        {   
            MainForm.graphics.DrawLine(new Pen(this.color, this.outline_width), this.point1, this.point2);
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
        public PointF getpospoint()
        {
            return point1;
        }
    }
}
