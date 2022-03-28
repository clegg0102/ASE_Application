using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASE_Applcation
{
    public partial class Window : Form
    {

        CommandParser parser;
        DrawingClass drawer;
        Thread changeColourThread;
        Boolean flag = true;

        public Window()
        {
            InitializeComponent();
            drawer = new DrawingClass(DrawingArea);
            parser = new CommandParser(drawer);
            DrawingArea.BackColor = Color.White;
            DrawingArea.Paint += new System.Windows.Forms.PaintEventHandler(drawer.Graphics_Paint);
            
        }
        override protected void OnFormClosing(System.Windows.Forms.FormClosingEventArgs e)
        {
            flag = false;
        }

        private void execute_script(object sender, EventArgs e)
        {
            parser.executeScript(ScriptBox.Text);
        }

        private void execute(object sender, EventArgs e)
        {
            if (CommandLine.Text.ToLower() == "reset")
            {
                drawer.Clear();
                parser = new CommandParser(drawer);
                drawer.Update();
            }
            else
            {
                parser.executeLineHandler(CommandLine.Text, ScriptBox.Text);
            }
        }

        private void input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (CommandLine.Text.ToLower() == "reset")
                {
                    drawer.Clear();
                    parser = new CommandParser(drawer);
                    drawer.Update();
                }
                else
                {
                    parser.executeLineHandler(CommandLine.Text, ScriptBox.Text);
                }
            }
        }

    }
}
