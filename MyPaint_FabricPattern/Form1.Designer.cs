namespace MyPaint_FabricPattern
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.GB_canvas = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Button_test = new System.Windows.Forms.Button();
            this.label_canvas = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rectangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rectangleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.squareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quadrilateralToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.triangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ellipseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ellipseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.penToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outlinewidthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSquare = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonRectangle = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonEllipse = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonCircuit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonLine = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonTriangle = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonQuadrilateral = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonColor = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBoxWidth = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonRedo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.GB_canvas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GB_canvas
            // 
            this.GB_canvas.Controls.Add(this.pictureBox1);
            this.GB_canvas.Controls.Add(this.Button_test);
            this.GB_canvas.Location = new System.Drawing.Point(14, 51);
            this.GB_canvas.Name = "GB_canvas";
            this.GB_canvas.Size = new System.Drawing.Size(782, 362);
            this.GB_canvas.TabIndex = 0;
            this.GB_canvas.TabStop = false;
            this.GB_canvas.CursorChanged += new System.EventHandler(this.GB_canvas_CursorChanged);
            this.GB_canvas.LocationChanged += new System.EventHandler(this.GB_canvas_LocationChanged);
            this.GB_canvas.DragDrop += new System.Windows.Forms.DragEventHandler(this.GB_canvas_DragDrop);
            this.GB_canvas.Enter += new System.EventHandler(this.GB_canvas_Enter);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(-6, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(782, 347);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.CursorChanged += new System.EventHandler(this.pictureBox1_CursorChanged);
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // Button_test
            // 
            this.Button_test.Location = new System.Drawing.Point(515, 74);
            this.Button_test.Name = "Button_test";
            this.Button_test.Size = new System.Drawing.Size(75, 23);
            this.Button_test.TabIndex = 1;
            this.Button_test.Text = "button1";
            this.Button_test.UseVisualStyleBackColor = true;
            this.Button_test.Click += new System.EventHandler(this.Button_test_Click);
            // 
            // label_canvas
            // 
            this.label_canvas.AutoSize = true;
            this.label_canvas.Location = new System.Drawing.Point(351, 35);
            this.label_canvas.Name = "label_canvas";
            this.label_canvas.Size = new System.Drawing.Size(37, 13);
            this.label_canvas.TabIndex = 2;
            this.label_canvas.Text = "Холст";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.drawToolStripMenuItem,
            this.editToolStripMenuItem,
            this.penToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // drawToolStripMenuItem
            // 
            this.drawToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rectangleToolStripMenuItem,
            this.triangleToolStripMenuItem,
            this.lineToolStripMenuItem,
            this.ellipseToolStripMenuItem});
            this.drawToolStripMenuItem.Name = "drawToolStripMenuItem";
            this.drawToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.drawToolStripMenuItem.Text = "Draw";
            // 
            // rectangleToolStripMenuItem
            // 
            this.rectangleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rectangleToolStripMenuItem1,
            this.squareToolStripMenuItem,
            this.quadrilateralToolStripMenuItem});
            this.rectangleToolStripMenuItem.Name = "rectangleToolStripMenuItem";
            this.rectangleToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.rectangleToolStripMenuItem.Text = "Quadrilateral";
            this.rectangleToolStripMenuItem.Click += new System.EventHandler(this.rectangleToolStripMenuItem_Click);
            // 
            // rectangleToolStripMenuItem1
            // 
            this.rectangleToolStripMenuItem1.Name = "rectangleToolStripMenuItem1";
            this.rectangleToolStripMenuItem1.Size = new System.Drawing.Size(142, 22);
            this.rectangleToolStripMenuItem1.Text = "Rectangle";
            this.rectangleToolStripMenuItem1.Click += new System.EventHandler(this.rectangleToolStripMenuItem1_Click);
            // 
            // squareToolStripMenuItem
            // 
            this.squareToolStripMenuItem.Name = "squareToolStripMenuItem";
            this.squareToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.squareToolStripMenuItem.Text = "Square";
            this.squareToolStripMenuItem.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // quadrilateralToolStripMenuItem
            // 
            this.quadrilateralToolStripMenuItem.Name = "quadrilateralToolStripMenuItem";
            this.quadrilateralToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.quadrilateralToolStripMenuItem.Text = "Quadrilateral";
            this.quadrilateralToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonQuadrilateral_Click);
            // 
            // triangleToolStripMenuItem
            // 
            this.triangleToolStripMenuItem.Name = "triangleToolStripMenuItem";
            this.triangleToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.triangleToolStripMenuItem.Text = "Triangle";
            this.triangleToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonTriangle_Click);
            // 
            // lineToolStripMenuItem
            // 
            this.lineToolStripMenuItem.Name = "lineToolStripMenuItem";
            this.lineToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.lineToolStripMenuItem.Text = "Line";
            this.lineToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonLine_Click);
            // 
            // ellipseToolStripMenuItem
            // 
            this.ellipseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ellipseToolStripMenuItem1,
            this.cuToolStripMenuItem});
            this.ellipseToolStripMenuItem.Name = "ellipseToolStripMenuItem";
            this.ellipseToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.ellipseToolStripMenuItem.Text = "Ellipse";
            // 
            // ellipseToolStripMenuItem1
            // 
            this.ellipseToolStripMenuItem1.Name = "ellipseToolStripMenuItem1";
            this.ellipseToolStripMenuItem1.Size = new System.Drawing.Size(109, 22);
            this.ellipseToolStripMenuItem1.Text = "Ellipse";
            this.ellipseToolStripMenuItem1.Click += new System.EventHandler(this.toolStripButtonEllipse_Click);
            // 
            // cuToolStripMenuItem
            // 
            this.cuToolStripMenuItem.Name = "cuToolStripMenuItem";
            this.cuToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.cuToolStripMenuItem.Text = "Circuit";
            this.cuToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonCircuit_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // penToolStripMenuItem
            // 
            this.penToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorToolStripMenuItem,
            this.outlinewidthToolStripMenuItem});
            this.penToolStripMenuItem.Name = "penToolStripMenuItem";
            this.penToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.penToolStripMenuItem.Text = "Pen";
            // 
            // colorToolStripMenuItem
            // 
            this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            this.colorToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.colorToolStripMenuItem.Text = "Color";
            // 
            // outlinewidthToolStripMenuItem
            // 
            this.outlinewidthToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1});
            this.outlinewidthToolStripMenuItem.Name = "outlinewidthToolStripMenuItem";
            this.outlinewidthToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.outlinewidthToolStripMenuItem.Text = "Outline_width";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox1.TextChanged += new System.EventHandler(this.toolStripTextBox1_TextChanged_1);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSquare,
            this.toolStripSeparator5,
            this.toolStripButtonRectangle,
            this.toolStripSeparator6,
            this.toolStripButtonEllipse,
            this.toolStripSeparator7,
            this.toolStripButtonCircuit,
            this.toolStripSeparator8,
            this.toolStripButtonLine,
            this.toolStripSeparator1,
            this.toolStripButtonTriangle,
            this.toolStripSeparator10,
            this.toolStripButtonQuadrilateral,
            this.toolStripSeparator11,
            this.toolStripButtonColor,
            this.toolStripSeparator2,
            this.toolStripLabel1,
            this.toolStripTextBoxWidth,
            this.toolStripSeparator3,
            this.toolStripButtonUndo,
            this.toolStripSeparator4,
            this.toolStripButtonRedo,
            this.toolStripSeparator9});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 39);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonSquare
            // 
            this.toolStripButtonSquare.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSquare.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSquare.Image")));
            this.toolStripButtonSquare.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSquare.Name = "toolStripButtonSquare";
            this.toolStripButtonSquare.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonSquare.Text = "Square";
            this.toolStripButtonSquare.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButtonRectangle
            // 
            this.toolStripButtonRectangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRectangle.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRectangle.Image")));
            this.toolStripButtonRectangle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRectangle.Name = "toolStripButtonRectangle";
            this.toolStripButtonRectangle.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonRectangle.Text = "Rectangle";
            this.toolStripButtonRectangle.Click += new System.EventHandler(this.toolStripButtonRectangle_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButtonEllipse
            // 
            this.toolStripButtonEllipse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEllipse.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonEllipse.Image")));
            this.toolStripButtonEllipse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEllipse.Name = "toolStripButtonEllipse";
            this.toolStripButtonEllipse.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonEllipse.Text = "Ellipse";
            this.toolStripButtonEllipse.Click += new System.EventHandler(this.toolStripButtonEllipse_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButtonCircuit
            // 
            this.toolStripButtonCircuit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCircuit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCircuit.Image")));
            this.toolStripButtonCircuit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCircuit.Name = "toolStripButtonCircuit";
            this.toolStripButtonCircuit.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonCircuit.Text = "Circuit";
            this.toolStripButtonCircuit.Click += new System.EventHandler(this.toolStripButtonCircuit_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButtonLine
            // 
            this.toolStripButtonLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonLine.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLine.Image")));
            this.toolStripButtonLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLine.Name = "toolStripButtonLine";
            this.toolStripButtonLine.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonLine.Text = "Line";
            this.toolStripButtonLine.Click += new System.EventHandler(this.toolStripButtonLine_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButtonTriangle
            // 
            this.toolStripButtonTriangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonTriangle.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonTriangle.Image")));
            this.toolStripButtonTriangle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTriangle.Name = "toolStripButtonTriangle";
            this.toolStripButtonTriangle.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonTriangle.Text = "toolStripButton1";
            this.toolStripButtonTriangle.Click += new System.EventHandler(this.toolStripButtonTriangle_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButtonQuadrilateral
            // 
            this.toolStripButtonQuadrilateral.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonQuadrilateral.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonQuadrilateral.Image")));
            this.toolStripButtonQuadrilateral.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonQuadrilateral.Name = "toolStripButtonQuadrilateral";
            this.toolStripButtonQuadrilateral.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonQuadrilateral.Text = "toolStripButton2";
            this.toolStripButtonQuadrilateral.Click += new System.EventHandler(this.toolStripButtonQuadrilateral_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButtonColor
            // 
            this.toolStripButtonColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonColor.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonColor.Image")));
            this.toolStripButtonColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonColor.Name = "toolStripButtonColor";
            this.toolStripButtonColor.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonColor.Text = "Change color";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(39, 36);
            this.toolStripLabel1.Text = "Width";
            // 
            // toolStripTextBoxWidth
            // 
            this.toolStripTextBoxWidth.Name = "toolStripTextBoxWidth";
            this.toolStripTextBoxWidth.Size = new System.Drawing.Size(50, 39);
            this.toolStripTextBoxWidth.TextChanged += new System.EventHandler(this.toolStripTextBox1_TextChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButtonUndo
            // 
            this.toolStripButtonUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonUndo.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonUndo.Image")));
            this.toolStripButtonUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonUndo.Name = "toolStripButtonUndo";
            this.toolStripButtonUndo.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonUndo.Text = "Undo";
            this.toolStripButtonUndo.Click += new System.EventHandler(this.toolStripButtonUndo_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButtonRedo
            // 
            this.toolStripButtonRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRedo.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRedo.Image")));
            this.toolStripButtonRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRedo.Name = "toolStripButtonRedo";
            this.toolStripButtonRedo.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonRedo.Text = "Redo";
            this.toolStripButtonRedo.Click += new System.EventHandler(this.toolStripButtonRedo_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 39);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label_canvas);
            this.Controls.Add(this.GB_canvas);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MyPaint";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.GB_canvas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GB_canvas;
        private System.Windows.Forms.Button Button_test;
        private System.Windows.Forms.Label label_canvas;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rectangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rectangleToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem squareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem triangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ellipseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ellipseToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quadrilateralToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem penToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outlinewidthToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonSquare;
        private System.Windows.Forms.ToolStripButton toolStripButtonRectangle;
        private System.Windows.Forms.ToolStripButton toolStripButtonEllipse;
        private System.Windows.Forms.ToolStripButton toolStripButtonCircuit;
        private System.Windows.Forms.ToolStripButton toolStripButtonLine;
        private System.Windows.Forms.ToolStripButton toolStripButtonColor;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxWidth;
        private System.Windows.Forms.ToolStripButton toolStripButtonUndo;
        private System.Windows.Forms.ToolStripButton toolStripButtonRedo;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton toolStripButtonTriangle;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton toolStripButtonQuadrilateral;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

