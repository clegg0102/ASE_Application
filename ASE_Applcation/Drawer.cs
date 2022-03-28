using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Applcation
{
    /// <summary>
    /// Interface for class to store and draw shapes
    /// </summary>
    public interface Drawer
    {
        void Clear();
        void AddShape(Shape shape);
        void Update();
    }

    /// <summary>
    /// 
    /// </summary>
    public class DrawingClass : Drawer
    {
        protected List<Shape> shapes;
        protected System.Windows.Forms.PictureBox DrawingArea;

        public DrawingClass(System.Windows.Forms.PictureBox DrawingArea)
        {
            this.DrawingArea = DrawingArea;
            shapes = new List<Shape>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="pe"></param>
        public void Graphics_Paint(object sender, System.Windows.Forms.PaintEventArgs pe)
        {
            System.Drawing.Graphics g = pe.Graphics;
            foreach (Shape shape in shapes)
            {
                shape.Paint(g);
            }
        }

        public void Clear()
        {
            shapes.Clear();
        }


        public void Update()
        {
            DrawingArea.Refresh();
        }

        public void AddShape(Shape shape)
        {
            shapes.Add(shape);
        }
        /// <summary>
        /// Method for exporting drawing to image
        /// </summary>
        /// <param name="x">Width of bitmap</param>
        /// <param name="y">Lenght of bitmap</param>
        /// <returns>A bitmap image of the drawing</returns>
        public Bitmap generateBitmap(int x, int y)
        {
            Bitmap bitmap = new Bitmap(x, y);
            Graphics graphics = Graphics.FromImage(bitmap);
            foreach (Shape shape in shapes)
            {
                shape.Paint(graphics);
            }
            return bitmap;
        }
        }
}

