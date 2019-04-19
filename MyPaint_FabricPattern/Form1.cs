
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
        static public String nextshapeid;
        static public List<Shape> shape_list;
        //static public PictureBox canvas;
        static public GraphicsState prevgstate, nextgstate;
        static public Image prevpic, nextpic;
        static public Bitmap prevmap, nextmap;
        static public Bitmap picture;
        static public Bitmap buffpicture;
        static public Cursor cursor;
        static public Graphics buffgraphics;
        static public  Graphics graphics;
        static public  Painter painter;    
        public MainForm()
        {
            InitializeComponent();
            colorDialog.Color = Color.Black;
            


            shape_list = new List<Shape>();
            painter = new Painter();
            painter.SetWidth(3);
            painter.currentpoint = new Point(0, 0);
            picture = new Bitmap(680, 400);
            buffpicture = new Bitmap(680, 400);
            //graphics = pictureBox.CreateGraphics();
            graphics = Graphics.FromImage(picture);
            buffgraphics = Graphics.FromImage(buffpicture);
            prevgstate = nextgstate = graphics.Save();
            
        }

        public void SaveGraphicsState()
        {
          //prevmap = picture;
          //prevgstate = graphics.Save();
          if (pictureBox.Image!=null)
            prevpic = (Image)pictureBox.Image.Clone();
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
            try
            {
                //nextpic = (Image)pictureBox.Image.Clone();
                // nextgstate = graphics.Save();
                // if (prevpic != null)
                // picture = new Bitmap(prevpic);
                //pictureBox.Image = prevpic;
                //ImageFormatConverter imageFormatConverter = new ImageFormatConverter;
                //picture = (Bitmap)pictureBox.Image;

                Shape buff = shape_list.Last();
                String id_2 = painter.CurrentShapeToPaintID;
                nextshapeid = id_2;
                painter.SetColor(Color.White);
                painter.points = buff.points;
                switch (id_2)
                {
                    case "Triangle":
                        PointF p = new PointF();
                        p.X = painter.points[1].X + painter.ShapeWidth * 2;
                        p.Y = painter.points[1].Y;
                        graphics.DrawLine(painter.pen, painter.points[0], painter.points[1]);
                        graphics.DrawLine(painter.pen, painter.points[1], p);
                        graphics.DrawLine(painter.pen, p, painter.points[0]);
                        //shape_list.Add(painter.Create());
                        break;

                    case "Rectangle":
                        graphics.DrawRectangle(painter.pen, painter.points[0].X, painter.points[0].Y, painter.ShapeWidth, painter.ShapeHeight);
                       // shape_list.Add(painter.Create());
                        break;
                    case "Square":
                        graphics.DrawRectangle(painter.pen, painter.points[0].X, painter.points[0].Y, painter.ShapeWidth, painter.ShapeWidth);
                        //shape_list.Add(painter.Create());
                        break;

                    case "Line":
                        graphics.DrawLine(painter.pen, painter.points[0], painter.points[1]);
                       // shape_list.Add(painter.Create());
                        break;

                    case "Ellipse":
                        graphics.DrawEllipse(painter.pen, painter.points[0].X, painter.points[0].Y, painter.ShapeWidth, painter.ShapeHeight);
                        break;

                    case "Circuit":
                        graphics.DrawEllipse(painter.pen, painter.points[0].X, painter.points[0].Y, painter.ShapeWidth, painter.ShapeWidth);
                        break;

                    case "Quadrilateral":
                        //LastShape = new Quadrilateral(pen.Width, pen.Color, points);
                        break;
                }
                painter.SetColor(Color.Black);
                
            }
            catch
            {
                // if (nextgraphicsState != null)
                //     nextgraphicsState = buffstate;
               // MessageBox.Show("No previous state saved");
            }
            finally
            {
                //MessageBox.Show("Done");
            }
        }

        private void toolStripButtonRedo_Click(object sender, EventArgs e)
        {
            try
            {
                Shape buff = shape_list.Last();
                String id_2 = nextshapeid;
                painter.SetColor(Color.Black);
                painter.points = buff.points;
                switch (id_2)
                {
                    case "Triangle":
                        PointF p = new PointF();
                        p.X = painter.points[1].X + painter.ShapeWidth * 2;
                        p.Y = painter.points[1].Y;
                        graphics.DrawLine(painter.pen, painter.points[0], painter.points[1]);
                        graphics.DrawLine(painter.pen, painter.points[1], p);
                        graphics.DrawLine(painter.pen, p, painter.points[0]);
                        //shape_list.Add(painter.Create());
                        break;

                    case "Rectangle":
                        graphics.DrawRectangle(painter.pen, painter.points[0].X, painter.points[0].Y, painter.ShapeWidth, painter.ShapeHeight);
                        // shape_list.Add(painter.Create());
                        break;
                    case "Square":
                        graphics.DrawRectangle(painter.pen, painter.points[0].X, painter.points[0].Y, painter.ShapeWidth, painter.ShapeWidth);
                        //shape_list.Add(painter.Create());
                        break;

                    case "Line":
                        graphics.DrawLine(painter.pen, painter.points[0], painter.points[1]);
                        // shape_list.Add(painter.Create());
                        break;

                    case "Ellipse":
                        graphics.DrawEllipse(painter.pen, painter.points[0].X, painter.points[0].Y, painter.ShapeWidth, painter.ShapeHeight);
                        break;

                    case "Circuit":
                        graphics.DrawEllipse(painter.pen, painter.points[0].X, painter.points[0].Y, painter.ShapeWidth, painter.ShapeWidth);
                        break;

                    case "Quadrilateral":
                        //LastShape = new Quadrilateral(pen.Width, pen.Color, points);
                        break;
                }
                
            }
            catch
            {
                //   prevgraphicsState = buffstate;
                MessageBox.Show("No next state saved");
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                nextgstate = graphics.Save();
                graphics.Restore(prevgstate);

            }
            catch
            {
                // if (nextgraphicsState != null)
                //     nextgraphicsState = buffstate;
                MessageBox.Show("No previous state saved");
            }
            finally
            {
                //MessageBox.Show("Done");
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                prevgstate = graphics.Save();
                graphics.Restore(nextgstate);
            }
            catch
            {
                //   prevgraphicsState = buffstate;
                MessageBox.Show("No next state saved");
            }
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           // painter.points[0] = painter.GetCursor();
           
        }

        private void pictureBox1_CursorChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
          /* if (e.Button == MouseButtons.Left)
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
                    //painter.Create();
                }
           }
           */
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            Point current = e.Location;
            painter.currentpoint = current;
            graphics = Graphics.FromImage(picture);
            buffgraphics = Graphics.FromImage(buffpicture);
            if (e.Button== MouseButtons.Left)
            {
                buffgraphics.Clear(Color.White);
                painter.Paint(graphics, buffgraphics);
                buffgraphics.DrawImage(picture, 0, 0);
                pictureBox.Image = buffpicture;
            }
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            SaveGraphicsState();
            painter.prevpoint = e.Location;
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            
            graphics = Graphics.FromImage(picture);
            
            String id = painter.CurrentShapeToPaintID;
            switch (id)
            {
                case "Triangle":
                    PointF p = new PointF();
                    p.X = painter.points[1].X + painter.ShapeWidth * 2;
                    p.Y = painter.points[1].Y;
                    graphics.DrawLine(painter.pen, painter.points[0], painter.points[1]);
                    graphics.DrawLine(painter.pen, painter.points[1], p);
                    graphics.DrawLine(painter.pen, p, painter.points[0]);
                    shape_list.Add(painter.Create());
                    break;
                    
                case "Rectangle":
                    graphics.DrawRectangle(painter.pen, painter.points[0].X, painter.points[0].Y, painter.ShapeWidth, painter.ShapeHeight);
                    shape_list.Add(painter.Create());
                    break;
                case "Square":
                    graphics.DrawRectangle(painter.pen, painter.points[0].X, painter.points[0].Y, painter.ShapeWidth, painter.ShapeWidth);
                    shape_list.Add(painter.Create());
                    break;

                case "Line":
                    graphics.DrawLine(painter.pen, painter.points[0], painter.points[1]);
                    shape_list.Add(painter.Create());
                    break;

                case "Ellipse":
                   graphics.DrawEllipse(painter.pen, painter.points[0].X, painter.points[0].Y, painter.ShapeWidth, painter.ShapeHeight);
                    shape_list.Add(painter.Create());
                    break;

                case "Circuit":
                    graphics.DrawEllipse(painter.pen, painter.points[0].X, painter.points[0].Y, painter.ShapeWidth, painter.ShapeWidth);
                    shape_list.Add(painter.Create());
                    break;

                case "Quadrilateral":
                    //LastShape = new Quadrilateral(pen.Width, pen.Color, points);
                    break;
            }
        }

        private void toolStripButtonColor_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            painter.SetColor(colorDialog.Color);
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            painter.SetColor(colorDialog.Color);
        }
    }

    public class Painter
    {
       
        public Point prevpoint;
        public Point currentpoint;
        public int pointsneed;
        public int pointsset;
       // public PointF startpoint, endpoint;
        public float ShapeWidth, ShapeHeight;
        public ToolStripButton SelectedButton;
        public String CurrentShapeToPaintID;
       // public GraphicsState prevgraphicsState;
       // public GraphicsState nextgraphicsState;
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

       

       
        
        public void SelectButton(ToolStripButton button)
        {
            if (SelectedButton!=null)
                SelectedButton.BackColor = Color.White;
            SelectedButton = button;
            SelectedButton.BackColor = Color.OrangeRed;
        }
        public void Paint(Graphics g, Graphics buffg)
        {
            
            this.points[0] = prevpoint;
            this.points[1] = currentpoint;
            ShapeWidth = points[0].X - points[1].X;
            ShapeHeight = points[1].Y - points[0].Y;
            if (points[0].X > points[1].X)
            {
                //PointF buff = points[0];
                //points[0] = points[1];
                //points[1] = buff;
                ShapeWidth = points[0].X - points[1].X;
            }
            else
            {
                ShapeWidth = points[1].X - points[0].X;
            }
            
            if (points[1].Y > points[0].Y)
            {
                ShapeHeight = points[1].Y - points[0].Y;
                //float buff = points[0].Y;
                //points[0].Y = points[1].Y;
                //points[1].Y = buff;
            }
            else
            {
                ShapeHeight = points[0].X - points[1].X;
            }
            String id = CurrentShapeToPaintID;
            switch (id)
            {
                case "Triangle":
                    PointF p=new PointF();
                    p.X = points[1].X + ShapeWidth*2;
                    p.Y = points[1].Y;
                    buffg.DrawLine(pen,points[0], points[1]);
                    buffg.DrawLine(pen, points[1], p);
                    buffg.DrawLine(pen, p, points[0]);
                    break;
                case "Rectangle":     
                    buffg.DrawRectangle(pen, points[0].X,points[0].Y, ShapeWidth, ShapeHeight);
                    break;
                case "Square":
                    buffg.DrawRectangle(pen, points[0].X, points[0].Y, ShapeWidth, ShapeWidth);
                    break;
                case "Line":
                    buffg.DrawLine(pen, points[0], points[1]);
                    break;
                case "Ellipse":
                    buffg.DrawEllipse(pen,points[0].X,points[0].Y, ShapeWidth, ShapeHeight);
                    break;
                case "Circuit":
                    buffg.DrawEllipse(pen, points[0].X, points[0].Y, ShapeWidth, ShapeWidth);
                    break;
                case "Quadrilateral":
                    LastShape = new Quadrilateral(pen.Width, pen.Color, points);
                    break;
            }
            

           
            //return LastShape;
        }
        public Shape Create()
        {
            String id = CurrentShapeToPaintID;
            switch (id)
            {
                case "Triangle":
                    points[2].X = points[1].X + ShapeWidth * 2;
                    points[2].Y = points[1].Y;
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

    

