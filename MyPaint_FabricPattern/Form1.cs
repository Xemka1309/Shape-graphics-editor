using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
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

        static public List<Type> types;
        static private List<IShapeDll> dlls;

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
            NullShape nullshape = new NullShape();

            painter = new Painter();
            painter.SetWidth(3);
            painter.currentpoint = new Point(0, 0);

            picture = new Bitmap(680, 400);
            buffpicture = new Bitmap(680, 400);
            nullmap = new Bitmap(100, 100);
            states = new LinkedList<Bitmap>();
            prevmap = new Bitmap(680, 400);
            Graphics.FromImage(prevmap).DrawImage(picture, 0, 0);
            states.AddFirst(nullmap);
            states.AddFirst(prevmap);
            changeflag = false;
            posflag = false;
            prevmaps = new Bitmap[20];
            nextmaps = new Bitmap[20];
            redoind = 50;
            LoadDlls();
            Serializator.getInstance().Serialize(shape_list, "BUFF/" + Convert.ToString(redoind) + ".json");
            redoind++;

            Serializator s = Serializator.getInstance();

            graphics = Graphics.FromImage(picture);
            buffgraphics = Graphics.FromImage(buffpicture);

        }
        public void toolstripitemclick(object sender, ToolStripItemClickedEventArgs e)
        {
            painter.CurrentShapeToPaintID = e.ClickedItem.Text;
        }
        public void LoadDlls()
        {
            types = new List<Type>();
            DllManager dllManager = new DllManager("DLLS");
            dlls = dllManager.LoadAll(types);
            toolStrip1.Items.Clear();
            for (int i = 0; i < dlls.Count; i++)
            {
                switch (types.ElementAt(i).Name)
                {
                    case "Line":
                        toolStrip1.Items.Add("Line", Image.FromFile("Resources//l.png"));
                        toolStrip1.ItemClicked += new ToolStripItemClickedEventHandler(toolstripitemclick);
                        break;
                    case "Triangle":
                        toolStrip1.Items.Add("Triangle",Image.FromFile("Resources//t.png"));
                        break;
                    case "Rectangle":
                        toolStrip1.Items.Add("Rectangle", Image.FromFile("Resources//r.png"));
                        toolStrip1.Items.Add("Square", Image.FromFile("Resources//s.png"));
                        break;
                    case "Ellipse":
                        toolStrip1.Items.Add("Ellipse", Image.FromFile("Resources//e.png"));
                        toolStrip1.Items.Add("Circuit", Image.FromFile("Resources//c.png"));
                        break;
                    default:
                        toolStrip1.Items.Add(types.ElementAt(i).Name);
                        break;
                }
                
            }
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
                String id = shape.GetType().Name;
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
           

        }

        private void toolStripButtonRedo_Click(object sender, EventArgs e)
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

        }

        private void pictureBox1_CursorChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            
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
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            openFileDialog1.ShowDialog();
            shape_list = Serializator.getInstance().Desirialize_err(openFileDialog1.FileName);
            painter.DrawShapeList(shape_list);
            pictureBox.Image = picture;
            states.AddLast(nullmap);
            SaveNextGraphicsState();
            PaintShapeList();
            painter.shape_was_select = false;
            
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
                painter.DrawShapeList(shape_list);
                painter.SelectShape();
                Refresh();
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
                PointF p = new PointF();
                p.X = painter.points[1].X + painter.ShapeWidth * 2;
                p.Y = painter.points[1].Y;
                switch (id)
                {
                    case "Triangle":
                        graphics.DrawLine(painter.pen, painter.points[0], painter.points[1]);
                        graphics.DrawLine(painter.pen, painter.points[1], p);
                        graphics.DrawLine(painter.pen, p, painter.points[0]);
                        shape_list.Add(painter.Create(dlls,types));
                        listViewshapes.Items.Add("Triangle",4);
                        break;

                    case "Rectangle":
                        graphics.DrawRectangle(painter.pen, painter.points[0].X, painter.points[0].Y, painter.ShapeWidth, painter.ShapeHeight);
                        shape_list.Add(painter.Create(dlls, types));
                        listViewshapes.Items.Add("Rectangle",3);
                        break;
                    case "Square":
                        graphics.DrawRectangle(painter.pen, painter.points[0].X, painter.points[0].Y, painter.ShapeWidth, painter.ShapeWidth);
                        shape_list.Add(painter.Create(dlls, types));
                        listViewshapes.Items.Add("Square",5);
                        break;

                    case "Line":
                        graphics.DrawLine(painter.pen, painter.points[0], painter.points[1]);
                        shape_list.Add(painter.Create(dlls, types));
                        listViewshapes.Items.Add("Line",2);
                        break;

                    case "Ellipse":
                        graphics.DrawEllipse(painter.pen, painter.points[0].X, painter.points[0].Y, painter.ShapeWidth, painter.ShapeHeight);
                        shape_list.Add(painter.Create(dlls, types));
                        listViewshapes.Items.Add("Ellipse", 1);
                        break;

                    case "Circuit":
                        graphics.DrawEllipse(painter.pen, painter.points[0].X, painter.points[0].Y, painter.ShapeWidth, painter.ShapeWidth);
                        shape_list.Add(painter.Create(dlls, types));
                        listViewshapes.Items.Add("Circuit",0);
                        break;

                    case "Quadrilateral":
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
                            shape_list.Insert(buff, painter.Create(dlls, types));
                            break;

                        case "Rectangle":
                            graphics.DrawRectangle(painter.pen, painter.points[0].X, painter.points[0].Y, painter.ShapeWidth, painter.ShapeHeight);
                            shape_list.Insert(buff, painter.Create(dlls, types));
                            break;
                        case "Square":
                            graphics.DrawRectangle(painter.pen, painter.points[0].X, painter.points[0].Y, painter.ShapeWidth, painter.ShapeWidth);
                            shape_list.Insert(buff, painter.Create(dlls, types));
                            break;

                        case "Line":
                            graphics.DrawLine(painter.pen, painter.points[0], painter.points[1]);
                            shape_list.Insert(buff, painter.Create(dlls, types));
                            break;

                        case "Ellipse":
                            graphics.DrawEllipse(painter.pen, painter.points[0].X, painter.points[0].Y, painter.ShapeWidth, painter.ShapeHeight);
                            shape_list.Insert(buff, painter.Create(dlls, types));
                            listViewshapes.Items.Add("Ellipse", 1);
                            break;

                        case "Circuit":
                            graphics.DrawEllipse(painter.pen, painter.points[0].X, painter.points[0].Y, painter.ShapeWidth, painter.ShapeWidth);
                            shape_list.Insert(buff, painter.Create(dlls, types));
                            break;
                    }
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
    class NullShape : Shape
    {
        public NullShape()
        {

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
        public float ShapeWidth, ShapeHeight;
        public ToolStripButton SelectedButton;
        public String CurrentShapeToPaintID;
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
            String id = selected_shape.GetType().Name;
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
                
                ShapeWidth = points[0].X - points[1].X;
            }
            else
            {
                ShapeWidth = points[1].X - points[0].X;
            }
            
            if (points[1].Y > points[0].Y)
            {
                ShapeHeight = points[1].Y - points[0].Y;
                
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
        public Shape Create(List<IShapeDll> dlls, List<Type> types)
        {
            Serializator.getInstance().Serialize(MainForm.shape_list, "BUFF/" + Convert.ToString(MainForm.redoind) + ".json");
            MainForm.redoind++;
            String id = CurrentShapeToPaintID;
            if (id == "Circuit")
                id = "Ellipse";
            if (id == "Square")
                id = "Rectangle";
            String[] args = new String[6];
            for (int i = 0; i < types.Count; i++)
            {
                if (types.ElementAt(i).Name.Contains(id))
                {
                    LastShape = dlls[i].GetShape();
                    var buff = LastShape as IShapeDll;
                    if (buff == null)
                        return new NullShape();
                    else
                    {
                        buff.SetColor(pen.Color);
                        buff.SetWidth(pen.Width);
                    }
                    var shapebuff = LastShape as ITwoPointsToPaint;
                    if (shapebuff == null)
                    {
                        var shapebuff3p = LastShape as IThreePointsToPaint;
                        if (shapebuff3p == null)
                        {
                            return new NullShape();
                        }
                        else
                        {
                            points[2].X = points[1].X + ShapeWidth * 2;
                            points[2].Y = points[1].Y;
                            args[0] = Convert.ToString(points[0].X);
                            args[1] = Convert.ToString(points[0].Y);
                            args[2] = Convert.ToString(points[1].X);
                            args[3] = Convert.ToString(points[1].Y);
                            args[4] = Convert.ToString(points[2].X);
                            args[5] = Convert.ToString(points[2].Y);
                            shapebuff3p.SetPaintArgs(args);
                        }
                    }
                    else
                    {
                        int x = (int)points[0].X;
                        int y = (int)points[0].Y;
                        args[0] = Convert.ToString(x);
                        args[1] = Convert.ToString(y);
                        args[2] = Convert.ToString(ShapeWidth);
                        args[3] = Convert.ToString(ShapeHeight);
                        shapebuff.SetPaintArgs(args);
                    }
                    break;
                    
                }

            }
            if (LastShape!= null)
                LastShape.Paint(MainForm.graphics);
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
                if (shape!=null)
                    shape.Paint(MainForm.graphics);
                
                count++;
            }
            

        }

    }
}

    

