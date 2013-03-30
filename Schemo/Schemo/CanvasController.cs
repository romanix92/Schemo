using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Schemo
{
    sealed class CanvasController
    {
        public CanvasController(Graphics gr)
        {
            m_graphics = gr;
            State = AddingState.Instance;
        }

        public Graphics Graphics
        {
            get { return m_graphics; }
            set { m_graphics = value; }
        }

        public void MouseClick(MouseEventArgs e)
        {
            State.MouseClick(this, e);
        }

        public void MouseDouble(MouseEventArgs e)
        {
            State.MouseDouble(this, e);
        }

        public void MouseMove(MouseEventArgs e)
        {
            State.MouseMove(this, e);
        }

        public void MouseDown(MouseEventArgs e)
        {
            State.MouseDown(this, e);
        }

        public void MouseUp(MouseEventArgs e)
        {
            State.MouseUp(this, e);
        }

        public void Update()
        {
            State.UpdateCanvas(this);
        }

        public void DeleteElement()
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
            Circuit.all.RemoveAll((IDrawable dr) => ((dr as Wire != null) ?
                (bool)(el.Element.IsMyPort((dr as Wire).inP) || el.Element.IsMyPort((dr as Wire).outP))
                : false));
        }

        public void ElementProperties()
        {

        }

        public ICanvasState State { get; set; }
        Graphics m_graphics;
    }
}
