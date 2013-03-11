using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Shemo
{
    sealed class ConvasController
    {
        public ConvasController(Graphics gr)
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

        public ICanvasState State { get; set; }
        Graphics m_graphics;
    }
}
