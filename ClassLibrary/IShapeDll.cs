
using System.Drawing;

namespace ClassLibrary
{
    public interface IShapeDll
    {
        void SetColor(Color color);
        void SetWidth(float width);
        Shape GetShape();
    }

}

