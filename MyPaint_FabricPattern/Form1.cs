
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPaint_FabricPattern
{
    public partial class MainForm : Form
    {
        static public Cursor cursor;
        static public  Graphics graphics;
        static public  Painter painter;    
        public MainForm()
        {
            InitializeComponent();
            painter = new Painter();
            graphics = GB_canvas.CreateGraphics();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Button_test_Click(object sender, EventArgs e)
        {
            //painter.SaveGraphicsState();
            PointF[] points = new PointF[10];
            points[0].X = 22;
            points[2].X = 44;
            points[1].X = 66;
            points[0].Y = 45;
            points[1].Y = 67;
            points[2].Y = 99;
            points[3].X = 200;
            points[3].Y = 100;
            points[4].X = 400;
            points[4].Y = 200;
            //Triangle triangle = new Triangle(5,Color.Aquamarine, points);
            //Rectangle rectangle = new Rectangle(10, Color.Bisque, points[2], 300, 200);
            //Ellipse ellipse= new Ellipse(10, Color.Bisque, points[2], 300, 200);
            //Line line = new Line(100, Color.DarkOliveGreen, points[3], points[4]);
            Quadrilateral quadrilateral = new Quadrilateral(100, Color.DarkOrange, points);
           
        }

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
               painter.SetWidth(Convert.ToSingle(toolStripTextBoxWidth.Text));
               
            }
            catch
            {
                MessageBox.Show("Invalid value");
            }
        }

        private void toolStripTextBox1_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                painter.SetWidth(Convert.ToSingle(toolStripTextBox1.Text));
            }
            catch
            {
                MessageBox.Show("Invalid value");
            }
        }

        private void toolStripButtonUndo_Click(object sender, EventArgs e)
        {
           painter.Undo();
        }

        private void toolStripButtonRedo_Click(object sender, EventArgs e)
        {
            painter.Redo();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            painter.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            painter.Redo();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            painter.CurrentShapeToPaintID = "Square";
            painter.SelectButton(this.toolStripButtonSquare);
            painter.pointsneed = 2;
            painter.pointsset = 0;

        }

        private void toolStripButtonRectangle_Click(object sender, EventArgs e)
        {
            painter.CurrentShapeToPaintID = "Rectangle";
            painter.SelectButton(this.toolStripButtonRectangle);
        }

        private void toolStripButtonEllipse_Click(object sender, EventArgs e)
        {
            painter.CurrentShapeToPaintID = "Ellipse";
            painter.SelectButton(this.toolStripButtonEllipse);
            painter.pointsneed = 2;
            painter.pointsset = 0;
        }

        private void toolStripButtonCircuit_Click(object sender, EventArgs e)
        {
            painter.CurrentShapeToPaintID = "Circuit";
            painter.SelectButton(this.toolStripButtonCircuit);
        }

        private void toolStripButtonLine_Click(object sender, EventArgs e)
        {
            painter.CurrentShapeToPaintID = "Line";
            painter.SelectButton(this.toolStripButtonLine);
            painter.pointsneed = 2;
            painter.pointsset = 0;
        }

        private void rectangleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            painter.CurrentShapeToPaintID = "Rectangle";
            painter.SelectButton(this.toolStripButtonRectangle);
        }

        private void toolStripButtonTriangle_Click(object sender, EventArgs e)
        {
            painter.CurrentShapeToPaintID = "Triangle";
            painter.SelectButton(this.toolStripButtonTriangle);
            painter.pointsneed = 3;
            painter.pointsset = 0;
        }

        private void toolStripButtonQuadrilateral_Click(object sender, EventArgs e)
        {
            painter.CurrentShapeToPaintID = "Quadrilateral";
            painter.SelectButton(this.toolStripButtonQuadrilateral);
        }

        private void GB_canvas_DragDrop(object sender, DragEventArgs e)
        {
           
        }

        private void GB_canvas_LocationChanged(object sender, EventArgs e)
        {
            
        }

        private void GB_canvas_CursorChanged(object sender, EventArgs e)
        {
            
        }

        private void GB_canvas_Enter(object sender, EventArgs e)
        {
            //MessageBox.Show("slava hohlam");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           // painter.points[0] = painter.GetCursor();
           
        }

        private void pictureBox1_CursorChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
           if (e.Button == MouseButtons.Left)
           {
                painter.points[painter.pointsset] = e.Location;
                painter.pointsset++;
                if (painter.pointsset >= 2)
                {
                    painter.ShapeWidth = painter.points[0].X - painter.points[1].X;
                    if (painter.ShapeWidth < 0)
                    {
                        painter.ShapeWidth *= -1;
                       // painter.points[0].
                    }
                        
                }
                if (painter.pointsneed == painter.pointsset)
                {
                    painter.Create();
                }
           }
           
        }
    }

    public class Painter
    {
        public int pointsneed;
        public int pointsset;
        public PointF startpoint, endpoint;
        public float ShapeWidth, ShapeHeight;
        public ToolStripButton SelectedButton;
        public String CurrentShapeToPaintID;
        public GraphicsState prevgraphicsState;
        public GraphicsState nextgraphicsState;
        public Shape LastShape;
        public PointF[] points;
        public Pen pen;
        public Painter()
        {
            pen = new Pen(Color.Black);
            points = new PointF[5];
            
        }
        public void SetColor(Color color)
        {
            this.pen.Color = color;
        }

        public void SetWidth(float width)
        {
            this.pen.Width = width;
        }

        public void SaveGraphicsState()
        {
            prevgraphicsState = MainForm.graphics.Save();
        }

        public void Redo()
        {
            //GraphicsState buffstate = prevgraphicsState;
            try
            {
                prevgraphicsState = MainForm.graphics.Save();
                MainForm.graphics.Restore(nextgraphicsState);
            }
            catch
            {
             //   prevgraphicsState = buffstate;
                MessageBox.Show("No next state saved");
            }
        }
        public void Undo()
        {
           // GraphicsState buffstate;
           // if (nextgraphicsState!=null)
           //     buffstate = nextgraphicsState;
            try
            {
               nextgraphicsState = MainForm.graphics.Save();
               MainForm.graphics.Restore(prevgraphicsState);
               
            }
            catch
            {
               // if (nextgraphicsState != null)
               //     nextgraphicsState = buffstate;
                MessageBox.Show("No previous state saved");
            }
            finally
            {
                MessageBox.Show("Done");
            }
        }
        
        public void SelectButton(ToolStripButton button)
        {
            if (SelectedButton!=null)
                SelectedButton.BackColor = Color.White;
            SelectedButton = button;
            SelectedButton.BackColor = Color.OrangeRed;
        }
        public Shape Create()
        {
            String id = CurrentShapeToPaintID;
            switch (id)
            {
                case "Triangle":
                    LastShape = new Triangle(pen.Width, pen.Color, points);
                    break;
                case "Rectangle":
                    LastShape = new Rectangle(pen.Width, pen.Color, points[0], ShapeWidth, ShapeHeight);
                    break;
                case "Square":
                    LastShape = new Rectangle(pen.Width, pen.Color, points[0], ShapeWidth);
                    break;
                case "Line":
                    LastShape = new Line(pen.Width, pen.Color, points[0], points[1]);
                    break;
                case "Ellipse":
                    LastShape = new Ellipse(pen.Width, pen.Color, points[0], ShapeWidth, ShapeHeight);
                    break;
                case "Circuit":
                    LastShape = new Ellipse(pen.Width, pen.Color, points[0], ShapeWidth);
                    break;
                case "Quadrilateral":
                    LastShape = new Quadrilateral(pen.Width, pen.Color, points);
                    break;
            }
            return LastShape;
        }
        // считывает положение курсора и возвращает координату
        public PointF GetCursor()
        {
            PointF point=new PointF();
            point.X = Cursor.Current.HotSpot.X;
            point.Y = Cursor.Current.HotSpot.Y;
            return point;
        }

    }
}

    

