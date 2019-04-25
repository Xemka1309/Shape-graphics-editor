﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace MyPaint_FabricPattern
{
         
    public abstract class Shape
    {
        public PointF[] points;
        public Color color;
        public float outline_width;

    }
    
}
