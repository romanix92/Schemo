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
            (new GatePicker()).Show();
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
            VisibleElement el = ElementContextProvider.Instance.Selected;
            IEnumerable<Wire> removedWires = from Wire w in Circuit.wires 
                                             where (el.Element.IsMyPort(w.inP) || el.Element.IsMyPort(w.outP)) 
                                             select w;
            foreach (Wire w in removedWires)
            {
                w.outP.RemoveSubscriber(w.inP);
            }
            Circuit.all.Remove(el);
            Circuit.gates.Remove(el);
            Circuit.wires.RemoveAll((Wire w) => (el.Element.IsMyPort(w.inP) || el.Element.IsMyPort(w.outP)));
        }
    }
}
