using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            m_canvas = new Canvas(panelCanvas.CreateGraphics());
        }

        Canvas m_canvas;

        private void canvasMouseClick(object sender, MouseEventArgs e)
        {
            m_canvas.MouseClick((MouseEventArgs)e);
        }
        private void canvasMouseDown(object sender, MouseEventArgs e)
        {
            m_canvas.MouseDown(e);
        }

        private void canvasMouseUp(object sender, MouseEventArgs e)
        {
            m_canvas.MouseUp(e);
        }

        private void canvasMouseMove(object sender, MouseEventArgs e)
        {
            m_canvas.MouseMove(e);
        }

        private void toolStripButtonSelect_Click(object sender, EventArgs e)
        {
            m_canvas.State = SelectState.Instance;
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            m_canvas.State = AddingState.Instance;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            m_canvas.State = ConnectingState.Instance;
        }
    }
}
