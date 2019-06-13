using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public interface IEditable
    {
         void ChangeColor(Color color);
         void ChangeOutlineWidth(float width);
    }
}
