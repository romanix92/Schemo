using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing;

namespace Schemo
{
    interface ICanvasState
    {
        void MouseClick(CanvasController sender, MouseEventArgs e);
        void MouseDouble(CanvasController sender, MouseEventArgs e);
        void MouseMove(CanvasController sender, MouseEventArgs e);
        void MouseDown(CanvasController sender, MouseEventArgs e);
        void MouseUp(CanvasController sender, MouseEventArgs e);
        void UpdateCanvas(CanvasController arg);
    }

    class AddingState : ICanvasState
    {
        public static AddingState Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = new AddingState();
                return m_instance;
            }
        }
        public IVisibleElementFactory selected = new VisibleAnd2Factory();

        public void MouseClick(CanvasController sender, MouseEventArgs e)
        {
            VisibleElement el = selected.newInstance(e.Location);
            Circuit.all.Add(el);
            Circuit.gates.Add(el);
            UpdateCanvas(sender);
        }

        public void MouseDouble(CanvasController sender, MouseEventArgs e) { }
        public void MouseMove(CanvasController sender, MouseEventArgs e) { }
        public void MouseDown(CanvasController sender, MouseEventArgs e) { }
        public void MouseUp(CanvasController sender, MouseEventArgs e) { }

        public void UpdateCanvas(CanvasController arg)
        {
            Graphics buf_gr = Graphics.FromImage(m_buffer);
            buf_gr.Clear(Color.White);
            foreach (IDrawable dr in Circuit.all)
                dr.Draw(buf_gr);
            arg.Graphics.DrawImage(m_buffer, new Point(0, 0));
        }

        private Bitmap m_buffer = new Bitmap(1920, 1080);
        private static AddingState m_instance;
        private AddingState() { }
    }

    class SelectState : ICanvasState
    {
        public static SelectState Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = new SelectState();
                return m_instance;
            }
        }
        public Type selected = typeof(Nor2Visible);

        public void MouseClick(CanvasController sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                foreach (VisibleElement el in Circuit.gates)
                {
                    if (el.IsMy(e.Location))
                    {
                        el.Selected = true;
                    }
                    else
                        el.Selected = false;
                }
                UpdateCanvas(sender);
            }
            else if (e.Button == MouseButtons.Right)
            {
                foreach (VisibleElement el in Circuit.gates)
                {
                    if (el.Selected)
                    {
                        ContextMenuStrip context = ElementContextProvider.Instance.Menu;
                        ElementContextProvider.Instance.Selected = el;
                        Point offset = ElementContextProvider.Instance.offset;
                        context.Show(offset.X + e.X, offset.Y + e.Y);
                        break;
                    }
                }
            }
        }

        public void MouseDouble(CanvasController sender, MouseEventArgs e) { }

        public void MouseMove(CanvasController sender, MouseEventArgs e)
        {
            if (m_mouse_down)
            {
                if (m_prev_loc != default(Point))
                {
                    Point offset = Point.Subtract(e.Location, new Size(m_prev_loc));
                    foreach (VisibleElement el in Circuit.gates)
                        if (el.Selected)
                            el.Move(offset);
                    UpdateCanvas(sender);
                }
                m_prev_loc = e.Location;
            }
        }
        public void MouseDown(CanvasController sender, MouseEventArgs e)
        {
            m_mouse_down = true;
        }
        public void MouseUp(CanvasController sender, MouseEventArgs e)
        {
            m_prev_loc = default(Point);
            m_mouse_down = false;
        }

        public void UpdateCanvas(CanvasController arg)
        {
            Graphics buf_gr = Graphics.FromImage(m_buffer);
            buf_gr.Clear(Color.White);
            foreach (IDrawable dr in Circuit.all)
                dr.Draw(buf_gr);
            arg.Graphics.DrawImage(m_buffer, new Point(0, 0));
        }

        private Point m_prev_loc;
        private bool m_mouse_down;
        private Bitmap m_buffer = new Bitmap(1920, 1080);
        private static SelectState m_instance;
        private SelectState() { }
    }

    class ConnectingState : ICanvasState
    {
        public static ConnectingState Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = new ConnectingState();
                return m_instance;
            }
        }
        public Type selected = typeof(Nor2Visible);

        public void MouseClick(CanvasController sender, MouseEventArgs e)
        {
            if (m_firstPort == null)
            {
                foreach (VisibleElement el in Circuit.gates)
                {
                    m_firstPort = el.IsOutPort(e.Location);
                    if (m_firstPort != null)
                        break;
                }
            }
            else
            {
                VisibleInPort second = null;
                foreach (VisibleElement el in Circuit.gates)
                {
                    second = el.IsInPort(e.Location);
                    if (second != null)
                    {
                        Wire w = new Wire(m_firstPort.position, second.position,
                            m_firstPort.port, second.port);
                        Circuit.wires.Add(w);
                        Circuit.all.Add(w);
                        m_firstPort.port.AddSubscriber(second.port);
                        break;
                    }
                }
                m_firstPort = null;
                UpdateCanvas(sender);
            }
        }

        public void MouseDouble(CanvasController sender, MouseEventArgs e) { }
        public void MouseMove(CanvasController sender, MouseEventArgs e) { }
        public void MouseDown(CanvasController sender, MouseEventArgs e) { }
        public void MouseUp(CanvasController sender, MouseEventArgs e) { }

        public void UpdateCanvas(CanvasController arg)
        {
            Graphics buf_gr = Graphics.FromImage(m_buffer);
            buf_gr.Clear(Color.White);
            foreach (IDrawable dr in Circuit.all)
                dr.Draw(buf_gr);
            arg.Graphics.DrawImage(m_buffer, new Point(0, 0));
        }

        private VisibleOutPort m_firstPort = null;
        private Bitmap m_buffer = new Bitmap(1920, 1080);
        private static ConnectingState m_instance;
        private ConnectingState() { }
    }
}
