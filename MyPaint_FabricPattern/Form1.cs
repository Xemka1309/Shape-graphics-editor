
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
        static public Bitmap nullmap;

        static public Bitmap[] prevmaps;
        static public Bitmap[] nextmaps;

        static public LinkedList<Bitmap> states;
        static public LinkedList<List<Shape>> shapestates;

        static public int redoind;
        static public int buff;

        static public Bitmap picture;
        static public Bitmap buffpicture;

        static public Boolean editflag;
        static public Boolean changeflag;
        static public Boolean posflag;
        static public Cursor cursor;
        static public Graphics buffgraphics;
        static public Graphics graphics;
        static public Painter painter;
        public MainForm()
        {
            InitializeComponent();
            colorDialog.Color = Color.Black;


            shapestates = new LinkedList<List<Shape>>();
            shape_list = new List<Shape>();
            Line nullshape = new Line(0, Color.Navy, new PointF(), new PointF());
            //shape_list.Add(nullshape);

            painter = new Painter();
            painter.SetWidth(3);
            painter.currentpoint = new Point(0, 0);

            picture = new Bitmap(680, 400);
            buffpicture = new Bitmap(680, 400);
            nullmap = new Bitmap(100, 100);
            states = new LinkedList<Bitmap>();
            //prevgstate = graphics.Save();
            prevmap = new Bitmap(680, 400);
            Graphics.FromImage(prevmap).DrawImage(picture, 0, 0);
            states.AddFirst(nullmap);
            states.AddFirst(prevmap);
            changeflag = false;
            posflag = false;
            prevmaps = new Bitmap[20];
            nextmaps = new Bitmap[20];
            redoind = 50;
            Serializator.getInstance().Serialize(shape_list, "BUFF/" + Convert.ToString(redoind) + ".json");
            redoind++;


            Serializator s = Serializator.getInstance();


            //graphics = pictureBox.CreateGraphics();
            graphics = Graphics.FromImage(picture);
            buffgraphics = Graphics.FromImage(buffpicture);
            // graphics.Clear(Color.White);
            //prevgstate = nextgstate = graphics.Save();

        }

        public void SetPictureBoxImage(Bitmap pic)
        {
            pictureBox.Image = pic;
        }

        public void SaveNextGraphicsState()
        {
            Bitmap nextmap = new Bitmap(680, 400);
            Graphics.FromImage(nextmap).DrawImage(picture, 0, 0);
            states.AddLast(nextmap);
            shapestates.AddLast(shape_list);
        }

        public void SavePrevGraphicsState()
        {

            prevgstate = graphics.Save();
            prevmap = new Bitmap(680, 400);
            Graphics.FromImage(prevmap).DrawImage(picture, 0, 0);
            //добавляем в начало
            states.AddFirst(prevmap);
            shapestates.AddFirst(shape_list);

        }
        private void Serundo()
        {
            Serializator.getInstance().Serialize(shape_list, "BUFF/" + Convert.ToString(redoind)+".json");
            shape_list = Serializator.getInstance().Desirialize_err("BUFF/" + Convert.ToString(redoind - 1) + ".json");
            redoind--;
            painter.DrawShapeList(shape_list);
            PaintShapeList();
            Refresh();
        }
        private void Serredo()
        {
            Serializator.getInstance().Serialize(shape_list, "BUFF/" + Convert.ToString(redoind) + ".json");
            shape_list = Serializator.getInstance().Desirialize_err("BUFF/" + Convert.ToString(redoind + 1) + ".json");
            redoind++;
            painter.DrawShapeList(shape_list);
            PaintShapeList();
            Refresh();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public void PaintShapeList()
        {
            listViewshapes.Clear();
            for (int i = 0; i < shape_list.Count; i++)
            {
                Shape shape = shape_list.ElementAt(i);
                String id = Serializator.getInstance().GetStringType(shape.GetType());
                switch (id)
                {
                    case "Triangle":

                        listViewshapes.Items.Add("Triangle", 4);
                        break;

                    case "Rectangle":

                        listViewshapes.Items.Add("Rectangle", 3);
                        break;
                    case "Square":

                        listViewshapes.Items.Add("Square", 5);
                        break;

                    case "Line":

                        listViewshapes.Items.Add("Line", 2);
                        break;

                    case "Ellipse":

                        listViewshapes.Items.Add("Ellipse", 1);

                        break;

                    case "Circuit":

                        listViewshapes.Items.Add("Circuit", 0);
                        break;


                }
            }

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
            editflag = true;
            try
            {
                Serundo();
            }
            catch
            {

                MessageBox.Show("No previous state saved");
            }
            finally
            {
                editflag = false;
            }
            /*
            if (states.First() != nullmap)
            {
                editflag = true;
                try
                {
                    shape_list = shapestates.First();
                    prevmap = states.First();
                    SaveNextGraphicsState();
                    states.RemoveFirst();

                    Graphics bgraphics = Graphics.FromImage(buffpicture);
                    picture = new Bitmap(680, 400);
                    Graphics graphics = Graphics.FromImage(picture);

                    graphics.DrawImage(prevmap, 0, 0);

                    graphics.DrawImage(prevmap, 0, 0);
                    graphics.Restore(prevgstate);

                    bgraphics.DrawImage(prevmap, 0, 0);

                    pictureBox.Image = picture;
                    editflag = false;

                }
                catch
                {

                    MessageBox.Show("No previous state saved");
                }
                finally
                {
                    //MessageBox.Show("Done");
                }
            }*/

        }

        private void toolStripButtonRedo_Click(object sender, EventArgs e)
        {
            /*if (states.Last() != nullmap)
            {
                editflag = true;
                try
                {
                    shape_list = shapestates.Last();
                    nextmap = states.Last();
                    SavePrevGraphicsState();
                    states.RemoveLast();

                    Graphics bgraphics = Graphics.FromImage(buffpicture);
                    picture = new Bitmap(680, 400);
                    Graphics graphics = Graphics.FromImage(picture);

                    graphics.DrawImage(nextmap, 0, 0);

                    graphics.DrawImage(nextmap, 0, 0);
                    graphics.Restore(prevgstate);

                    bgraphics.DrawImage(nextmap, 0, 0);

                    pictureBox.Image = picture;
                    editflag = false;

                }
                catch
                {

                    MessageBox.Show("No previous state saved");
                }
                finally
                {
                    //MessageBox.Show("Done");
                }
            }
            */
            editflag = true;
            try
            {
                Serredo();
            }
            catch
            {

                MessageBox.Show("No previous state saved");
            }
            finally
            {
                editflag = false;
            }

        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editflag = true;
            try
            {
                Serundo();
            }
            catch
            {

                MessageBox.Show("No previous state saved");
            }
            finally
            {
                editflag = false;
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editflag = true;
            try
            {
                Serredo();
               
            }
            catch
            {

                MessageBox.Show("No previous state saved");
            }
            finally
            {
                editflag = false;
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
            if (!editflag && !changeflag)
            {

                Point current = e.Location;
                painter.currentpoint = current;
                graphics = Graphics.FromImage(picture);
                buffgraphics = Graphics.FromImage(buffpicture);
                if (e.Button == MouseButtons.Left)
                {
                    buffgraphics.Clear(Color.White);
                    painter.Paint(graphics, buffgraphics);
                    buffgraphics.DrawImage(picture, 0, 0);
                    pictureBox.Image = buffpicture;

                }
            }
            if (!editflag && changeflag)
            {
                painter.DrawShapeList(shape_list);
                //Refresh();
                Point current = e.Location;
                painter.currentpoint = current;
                graphics = Graphics.FromImage(picture);
                buffgraphics = Graphics.FromImage(buffpicture);
                if (e.Button == MouseButtons.Left)
                {
                    buffgraphics.Clear(Color.White);
                    painter.Paint(graphics, buffgraphics);
                    buffgraphics.DrawImage(picture, 0, 0);
                    pictureBox.Image = buffpicture;

                }
            }

        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            SavePrevGraphicsState();
            if (!editflag && !changeflag)
            {
                painter.prevpoint = e.Location;
            }
        }



        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Serializator.getInstance().SerializeDynamic(shape_list);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SavePrevGraphicsState();
            //shape_list = Serializator.getInstance().Deserialize();
            openFileDialog1.ShowDialog();
            shape_list = Serializator.getInstance().Desirialize_err(openFileDialog1.FileName);
            painter.DrawShapeList(shape_list);
            pictureBox.Image = picture;
            states.AddLast(nullmap);
            SaveNextGraphicsState();
            PaintShapeList();
            painter.shape_was_select = false;
            //MessageBox.Show(shape_list.Last().ToString());
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            Serializator.getInstance().Serialize(shape_list, saveFileDialog1.FileName);

        }
        public void Refresh()
        {
            this.pictureBox.Image = picture;
        }


        private void pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void listViewshapes_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            painter.DrawShapeList(shape_list);
            painter.selected_shape = shape_list.ElementAt(e.ItemIndex);
            painter.SelectShape();
            pictureBox.Image = picture;
            textBoxstatwidth.Text = Convert.ToString(painter.selected_shape.outline_width);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBoxstatwidth_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonstatchangewidth_Click(object sender, EventArgs e)
        {
            if (!painter.shape_was_select)
            {
                MessageBox.Show("No selected shape");
                return;
            }
            IEditable shape = painter.selected_shape as IEditable;
            if (shape == null)
            {
                MessageBox.Show("This shape cant be edite");
                return;
            }

        }

        private void buttonstatchangeoutlinewidth_Click(object sender, EventArgs e)
        {
            if (!painter.shape_was_select)
            {
                MessageBox.Show("No selected shape");
                return;
            }
            IEditable shape = painter.selected_shape as IEditable;
            if (shape == null)
            {
                MessageBox.Show("This shape cant be edite");
                return;
            }
            

            try
            {
                shape.ChangeOutlineWidth(Convert.ToInt32(textBoxstatwidth.Text));
                //MessageBox.Show(painter.selected_shape.outline_width.ToString());
                
                painter.DrawShapeList(shape_list);
                painter.SelectShape();
                Refresh();
               // MainForm.
            }
            catch
            {
                MessageBox.Show("invalid value");
            }

        }

        private void buttonstatchangecolor_Click(object sender, EventArgs e)
        {
            if (!painter.shape_was_select)
            {
                MessageBox.Show("No selected shape");
                return;
            }
            IEditable shape = painter.selected_shape as IEditable;
            if (shape == null)
            {
                MessageBox.Show("This shape cant be edite");
                return;
            }
            colorDialog.ShowDialog();
            shape.ChangeColor(colorDialog.Color);
            painter.DrawShapeList(shape_list);
            painter.SelectShape();
            Refresh();
        }

        private void listViewshapes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            painter.shape_was_select = false;
            painter.selected_shape = null;
            painter.DrawShapeList(shape_list);
            textBoxstatsize.Text = "noshape";
            textBoxstatwidth.Text = "noshape";
            PaintShapeList();
            Refresh();
        }

        private void buttonchangesizeposition_Click(object sender, EventArgs e)
        {
            if (!painter.shape_was_select)
            {
                MessageBox.Show("No selected shape");
                return;
            }
            IRepositable shape = painter.selected_shape as IRepositable;
            if (shape == null)
            {
                MessageBox.Show("This shape cant be moved");
                return;
            }
            painter.CurrentShapeToPaintID = Serializator.getInstance().GetStringType(painter.selected_shape.GetType());
            changeflag = true;
            editflag = false;
            
            painter.prevpoint = new PointF(shape.getpospoint().X, shape.getpospoint().Y);
            painter.pen.Color = painter.selected_shape.color;
            painter.pen.Width = painter.selected_shape.outline_width;
            buff = shape_list.IndexOf(painter.selected_shape);
            
            shape_list.Remove(painter.selected_shape);
        }

        private void buttondeleteshape_Click(object sender, EventArgs e)
        {
            if (!painter.shape_was_select)
            {
                MessageBox.Show("No selected shape");
                return;
            }
            Serializator.getInstance().Serialize(shape_list, "BUFF/" + Convert.ToString(redoind) + ".json");
            redoind++;
            shape_list.Remove(painter.selected_shape);
            painter.selected_shape = null;
            painter.shape_was_select = false;
            painter.DrawShapeList(shape_list);
            PaintShapeList();
            Refresh();


        }

        private void buttonchangepos_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            
            
            if (!editflag && !changeflag)
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
                        listViewshapes.Items.Add("Triangle",4);
                        break;

                    case "Rectangle":
                        graphics.DrawRectangle(painter.pen, painter.points[0].X, painter.points[0].Y, painter.ShapeWidth, painter.ShapeHeight);
                        shape_list.Add(painter.Create());
                        listViewshapes.Items.Add("Rectangle",3);
                        break;
                    case "Square":
                        graphics.DrawRectangle(painter.pen, painter.points[0].X, painter.points[0].Y, painter.ShapeWidth, painter.ShapeWidth);
                        shape_list.Add(painter.Create());
                        listViewshapes.Items.Add("Square",5);
                        break;

                    case "Line":
                        graphics.DrawLine(painter.pen, painter.points[0], painter.points[1]);
                        shape_list.Add(painter.Create());
                        listViewshapes.Items.Add("Line",2);
                        break;

                    case "Ellipse":
                        graphics.DrawEllipse(painter.pen, painter.points[0].X, painter.points[0].Y, painter.ShapeWidth, painter.ShapeHeight);
                        shape_list.Add(painter.Create());
                        listViewshapes.Items.Add("Ellipse", 1);
                        //listViewshapes.Items.
                        break;

                    case "Circuit":
                        graphics.DrawEllipse(painter.pen, painter.points[0].X, painter.points[0].Y, painter.ShapeWidth, painter.ShapeWidth);
                        shape_list.Add(painter.Create());
                        listViewshapes.Items.Add("Circuit",0);
                        break;

                    case "Quadrilateral":
                        //LastShape = new Quadrilateral(pen.Width, pen.Color, points);
                        break;
                }
                states.AddLast(nullmap);
                SaveNextGraphicsState();
            }
            
            
                if (!editflag && changeflag)
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
                            shape_list.Insert(buff, painter.Create());
                            // listViewshapes.Items.Add("Triangle", 4);
                            break;

                        case "Rectangle":
                            graphics.DrawRectangle(painter.pen, painter.points[0].X, painter.points[0].Y, painter.ShapeWidth, painter.ShapeHeight);
                            shape_list.Insert(buff, painter.Create());
                            // listViewshapes.Items.Add("Rectangle", 3);
                            break;
                        case "Square":
                            graphics.DrawRectangle(painter.pen, painter.points[0].X, painter.points[0].Y, painter.ShapeWidth, painter.ShapeWidth);
                            shape_list.Insert(buff, painter.Create());
                            // listViewshapes.Items.Add("Square", 5);
                            break;

                        case "Line":
                            graphics.DrawLine(painter.pen, painter.points[0], painter.points[1]);
                            shape_list.Insert(buff, painter.Create());
                            // listViewshapes.Items.Add("Line", 2);
                            break;

                        case "Ellipse":
                            graphics.DrawEllipse(painter.pen, painter.points[0].X, painter.points[0].Y, painter.ShapeWidth, painter.ShapeHeight);
                            shape_list.Insert(buff, painter.Create());
                            listViewshapes.Items.Add("Ellipse", 1);
                            //listViewshapes.Items.
                            break;

                        case "Circuit":
                            graphics.DrawEllipse(painter.pen, painter.points[0].X, painter.points[0].Y, painter.ShapeWidth, painter.ShapeWidth);
                            shape_list.Insert(buff, painter.Create());
                            //listViewshapes.Items.Add("Circuit", 0);
                            break;

                        case "Quadrilateral":
                            //LastShape = new Quadrilateral(pen.Width, pen.Color, points);
                            break;
                    }
                    //states.AddLast(nullmap);
                    //SaveNextGraphicsState();
                    changeflag = false;
                    PaintShapeList();
                    Refresh();
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
        public Shape selected_shape;
        public Boolean shape_was_select;
        public PointF prevpoint;
        public PointF currentpoint;
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
            shape_was_select = false;



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
        public void SelectShape()
        {
            float width, height;
            PointF upperleftpoint;
            Pen penbuff = new Pen(Color.Red,3);
            String id = Serializator.getInstance().GetStringType(selected_shape.GetType());
            switch (id)
            {
                case "Triangle":
                Triangle triangle = selected_shape as Triangle;
                upperleftpoint = new PointF(triangle.point2.X-20, triangle.point1.Y-20);
                width = triangle.point3.X - triangle.point2.X + 40;
                height = triangle.point2.Y - triangle.point1.Y + 40;
                MainForm.graphics = Graphics.FromImage(MainForm.picture);
                MainForm.graphics.DrawRectangle(penbuff, upperleftpoint.X,upperleftpoint.Y, width, height);
                
                
                break;

                case "Rectangle":
                    Rectangle rectangle = selected_shape as Rectangle;
                    upperleftpoint = new PointF();
                    upperleftpoint.X = rectangle.upper_left_point.X - 20;
                    upperleftpoint.Y = rectangle.upper_left_point.Y - 20;
                    width = rectangle.width + 40;
                    height = rectangle.height + 40;
                    MainForm.graphics.DrawRectangle(penbuff, upperleftpoint.X, upperleftpoint.Y, width, height);
                    //MainForm.graphics.DrawLine(penbuff,0, 0, 20, 20);
                    break;
                case "Square":
                    Rectangle square = selected_shape as Rectangle;
                    upperleftpoint = new PointF();
                    upperleftpoint.X = square.upper_left_point.X - 20;
                    upperleftpoint.Y = square.upper_left_point.Y - 20;
                    width = square.width + 40;
                    height = square.height + 40;
                    MainForm.graphics.DrawRectangle(penbuff, upperleftpoint.X, upperleftpoint.Y, width, height);

                    break;

                case "Line":
                    Line line = selected_shape as Line;
                    upperleftpoint = new PointF();
                    upperleftpoint.X = line.point1.X - 20;
                    upperleftpoint.Y = line.point1.Y - 20;
                    width = line.point2.X-line.point1.X+40;
                    height = line.point2.Y-line.point1.Y + 40;
                    MainForm.graphics.DrawRectangle(penbuff, upperleftpoint.X, upperleftpoint.Y, width, height);


                    break;

                case "Ellipse":
                    Ellipse ellipse= selected_shape as Ellipse;
                    upperleftpoint = new PointF();
                    upperleftpoint.X = ellipse.upper_left_point.X - 20;
                    upperleftpoint.Y = ellipse.upper_left_point.Y - 20;
                    width = ellipse.width + 40;
                    height = ellipse.height + 40;
                    MainForm.graphics.DrawRectangle(penbuff, upperleftpoint.X, upperleftpoint.Y, width, height);

                    break;

                case "Circuit":
                    Ellipse circuit = selected_shape as Ellipse;
                    upperleftpoint = new PointF();
                    upperleftpoint.X = circuit.upper_left_point.X - 20;
                    upperleftpoint.Y = circuit.upper_left_point.Y - 20;
                    width = circuit.width + 40;
                    height = circuit.height + 40;
                    MainForm.graphics.DrawRectangle(penbuff, upperleftpoint.X, upperleftpoint.Y, width, height);

                    break;

                
             }
            shape_was_select = true;
            
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
                    //LastShape = new Quadrilateral(pen.Width, pen.Color, points);
                    break;
            }
            

           
            //return LastShape;
        }
        public Shape Create()
        {
            Serializator.getInstance().Serialize(MainForm.shape_list, "BUFF/" + Convert.ToString(MainForm.redoind) + ".json");
            MainForm.redoind++;
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
                    //LastShape = new Quadrilateral(pen.Width, pen.Color, points);
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
        
        public void DrawShapeList(List<Shape> shape_list)
        {
            MainForm.picture = new Bitmap(680,400);
            Graphics bgraphics = Graphics.FromImage(MainForm.buffpicture);
            //MainForm.picture = new Bitmap(680, 400);
            MainForm.graphics = Graphics.FromImage(MainForm.picture);

            //MainForm.graphics = Graphics.FromImage(MainForm.picture);
            int count = 0;
            while (count != shape_list.Count)
            {
                Shape shape = shape_list.ElementAt(count);
                shape.Paint(MainForm.graphics);
                
                count++;
            }
            
            //MainForm.PaintShapeList();

           // graphics.DrawImage(MainForm.prevmap, 0, 0);

            //graphics.DrawImage(MainForm.prevmap, 0, 0);
            //graphics.Restore(MainForm.prevgstate);

            //bgraphics.DrawImage(MainForm.prevmap, 0, 0);

            //MainForm.SetPictureBoxImage(MainForm.picture);
            //MainForm.editflag = false;
            //MainForm.picture = new Bitmap(680, 400);


        }

    }
}

    

