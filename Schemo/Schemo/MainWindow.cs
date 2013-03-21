using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Schemo
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            m_canvas = new ConvasController(panelCanvas.CreateGraphics());
            ElementContextProvider.Instance.Menu = this.contextElement;
        }

        ConvasController m_canvas;

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

        private void toolStripButtonWire_Click(object sender, EventArgs e)
        {
            m_canvas.State = ConnectingState.Instance;
        }

        private void toolStripButtonPickGate_Click(object sender, EventArgs e)
        {
            (new GatePicker()).ShowDialog();
        }

        private void MainWindow_Resize(object sender, EventArgs e)
        {
            m_canvas.Graphics = panelCanvas.CreateGraphics();
            m_canvas.Update();
        }

        private void panelCanvas_Validated(object sender, EventArgs e)
        {
            ElementContextProvider.Instance.offset = this.Location;
        }

        private void panelCanvas_Layout(object sender, LayoutEventArgs e)
        {
            ElementContextProvider.Instance.offset = this.Location;
        }

        private void MainWindow_Move(object sender, EventArgs e)
        {
            ElementContextProvider.Instance.offset = this.Location;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_canvas.DeleteElement();
            m_canvas.Update();
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new ElProp()).ShowDialog();
        }

        private void toolStripStart_Click(object sender, EventArgs e)
        {
            Simulator.Instance.Reset();
            Simulator.Instance.Simulate(100);
            (new WaveFormsWindow()).Show();
        }
    }
}
