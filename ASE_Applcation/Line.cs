using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Applcation
{
    /// <summary>
    /// Class for line that implements shape
    /// </summary>
    internal class Line : Shape
    {
        protected int startX, startY, endX, endY;

        /// <summary>
        /// Constructor for a new line
        /// </summary>
        /// <param name="colour">Colour to draw the line</param>
        /// <param name="startX">the x coordinate for the start of the line</param>
        /// <param name="startY">the y coordinate for the start of the line</param>
        /// <param name="penWidth">the width of the line</param>
        /// <param name="fillState">not used for this shape since it's a lined</param>
        /// <param name="endX">the x coordintae for the end of the line</param>
        /// <param name="endY">the y coordintae for the end of the line</param>
        public Line(Color colour, int startX, int startY, float penWidth, bool fillState, int endX, int endY)
            : base(colour, penWidth, fillState)
        {
            this.startX = startX;
            this.startY = startY;
            this.endX = endX;
            this.endY = endY;
        }

        /// <summary>
        /// Function to paint the line onto something
        /// </summary>
        /// <param name="graphics">Graphics object to paint onto</param>
        public override void Paint(Graphics graphics)
        {
            graphics.DrawLine(pen, startX, startY, endX, endY);
        }

        public (int, int) GetStartPoint()
        {
            return (startX, startY);
        }

        public void SetStartPoint(int x, int y)
        {
            startX = x;
            startY = y;
        }

        public (int, int) GetEndPoint()
        {
            return (endX, endY);
        }

        public void SetEndPoint(int x, int y)
        {
            endX = x;
            endY = y;
        }

        public ((int, int), (int, int)) GetPoints()
        {
            return ((startX, startY), (endX, endY));
        }

        public void SetPoints((int, int) start, (int, int) end)
        {
            startX = start.Item1;
            startY = start.Item2;
            endX = end.Item1;
            endY = end.Item2;
        }

        public void SetPoints(int startX, int startY, int endX, int endY)
        {
            this.startX = startX;
            this.startY = startY;
            this.endX = endX;
            this.endY = endY;

        }
    }
}

