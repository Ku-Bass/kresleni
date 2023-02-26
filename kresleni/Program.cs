using System;
using System.Drawing;
using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

/*
namespace kresleni
{
    class DrawingProgram : Form
    {
        private bool isDrawing = false;
        private Point lastPoint = Point.Empty;
        private Bitmap canvas = new Bitmap(800, 600);
        private Pen currentPen = new Pen(Color.Black, 1);

        private ColorDialog colorDialog = new ColorDialog();
        private TrackBar sizeSlider = new TrackBar();
        private TrackBar opacitySlider = new TrackBar();

        public DrawingProgram()
        {
            this.ClientSize = new Size(800, 600);
            this.DoubleBuffered = true;
            this.Paint += new PaintEventHandler(DrawingProgram_Paint);
            this.MouseDown += new MouseEventHandler(DrawingProgram_MouseDown);
            this.MouseUp += new MouseEventHandler(DrawingProgram_MouseUp);
            this.MouseMove += new MouseEventHandler(DrawingProgram_MouseMove);

            // add a tool strip with color and size options
            ToolStrip toolStrip = new ToolStrip();
            toolStrip.Items.Add("Color", null, ShowColorDialog);
            toolStrip.Items.Add(new ToolStripSeparator());
            toolStrip.Items.Add("Small", null, ChangeSize);
            toolStrip.Items.Add("Medium", null, ChangeSize);
            toolStrip.Items.Add("Large", null, ChangeSize);
            toolStrip.Items.Add(new ToolStripSeparator());
            toolStrip.Items.Add("Clear", null, ClearCanvas);
            this.Controls.Add(toolStrip);

            // add the size and opacity sliders
            sizeSlider.Minimum = 1;
            sizeSlider.Maximum = 50;
            sizeSlider.Value = 1;
            sizeSlider.Width = 100;
            sizeSlider.TickFrequency = 5;
            sizeSlider.ValueChanged += new EventHandler(SizeSlider_ValueChanged);
            this.Controls.Add(sizeSlider);

            opacitySlider.Minimum = 0;
            opacitySlider.Maximum = 255;
            opacitySlider.Value = 255;
            opacitySlider.Width = 100;
            opacitySlider.TickFrequency = 5;
            opacitySlider.ValueChanged += new EventHandler(OpacitySlider_ValueChanged);
            this.Controls.Add(opacitySlider);
        }

        private void DrawingProgram_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(canvas, Point.Empty);
        }

        private void DrawingProgram_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;
            lastPoint = e.Location;
        }

        private void DrawingProgram_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
            lastPoint = Point.Empty;
        }

        private void DrawingProgram_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                using (Graphics g = Graphics.FromImage(canvas))
                {
                    currentPen.Color = colorDialog.Color;
                    currentPen.Width = sizeSlider.Value;
                    currentPen.Brush = new SolidBrush(Color.FromArgb(opacitySlider.Value, currentPen.Color));
                    g.DrawLine(currentPen, lastPoint, e.Location);
                }

                lastPoint = e.Location;
                this.Invalidate();
            }
        }

        private void ShowColorDialog(object sender, EventArgs e)
        {
            DialogResult result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                currentPen.Color = colorDialog.Color;
            }
        }

        private void ChangeSize(object sender, EventArgs e)
        {
            ToolStripButton button = (ToolStripButton)sender;
            switch (button.Text)
            {
                case "Small":
                    sizeSlider.Value = 1;
                    break;
                case "Medium":
                    sizeSlider.Value = 10;
                    break;
                case "Large":
                    sizeSlider.Value = 20;
                    break;
            }
        }

        private void ClearCanvas(object sender, EventArgs e)
        {
            using (Graphics g = Graphics.FromImage(canvas))
            {
                g.Clear(Color.White);
                this.Invalidate();
            }
        }
        private void SizeSlider_ValueChanged(object sender, EventArgs e)
        {
            currentPen.Width = sizeSlider.Value;
        }

        private void OpacitySlider_ValueChanged(object sender, EventArgs e)
        {
            currentPen.Brush = new SolidBrush(Color.FromArgb(opacitySlider.Value, currentPen.Color));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Application.Run(new DrawingProgram());
        }
    }

}*/
// brush size buttons, color changing 
namespace kresleni
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class DrawingProgram : Form
    {
        private const int CanvasWidth = 800;
        private const int CanvasHeight = 600;

        private Button clearButton;
        private PictureBox canvas;
        private Pen pen;
        private Point lastPoint;

        public DrawingProgram()
        {
            InitializeComponents();
            pen = new Pen(Color.Black, 5);
        }

        private void InitializeComponents()
        {
            this.clearButton = new Button();
            this.clearButton.Text = "Clear";
            this.clearButton.Dock = DockStyle.Top;
            this.clearButton.Click += new EventHandler(clearButton_Click);

            this.canvas = new PictureBox();
            this.canvas.Dock = DockStyle.Fill;
            this.canvas.BackColor = Color.White;
            this.canvas.MouseDown += new MouseEventHandler(canvas_MouseDown);
            this.canvas.MouseMove += new MouseEventHandler(canvas_MouseMove);
            this.canvas.MouseUp += new MouseEventHandler(canvas_MouseUp);

            this.Controls.Add(this.canvas);
            this.Controls.Add(this.clearButton);
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = e.Location;
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                using (Graphics g = Graphics.FromImage(canvas.Image))
                {
                    g.DrawLine(pen, lastPoint, e.Location);
                }
                lastPoint = e.Location;
            }
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                using (Graphics g = Graphics.FromImage(canvas.Image))
                {
                    g.DrawLine(pen, lastPoint, e.Location);
                }
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearCanvas();
        }

        private void ClearCanvas()
        {
            using (Graphics g = Graphics.FromImage(canvas.Image))
            {
                g.Clear(Color.White);
            }
        }

        public static void Main()
        {
            Application.Run(new DrawingProgram());
        }
    }
}

    
