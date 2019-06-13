using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public interface IShapeDll
    {
        void SetColor(Color color);
        void SetWidth(float width);
        Shape GetShape();
    }

}

