using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using SchemoCore;

namespace Shemo
{
    class VisibleInPort
    {
        public VisibleInPort(InPort p, Point pos)
        {
            port = p;
            position = pos;
        }
        public InPort port;
        public Point position;
    }

    class VisibleOutPort
    {
        public VisibleOutPort(OutPort p, Point pos)
        {
            port = p;
            position = pos;
        }
        public OutPort port;
        public Point position;
    }

    abstract class VisibleElement : IDrawable
    {
        public abstract void Draw(Graphics gr);
        public abstract bool IsMy(Point p);
        public abstract VisibleInPort IsInPort(Point p);
        public abstract VisibleOutPort IsOutPort(Point p);
        public abstract Element Element { get; }
        public abstract void Move(Point delta);
        public Point Location { get { return m_location; } }
        public bool Selected { get; set; }
        protected Point m_location;
        protected Pen defaultPen = new Pen(new SolidBrush(Color.Black));
        protected Pen selectedPen = new Pen(new SolidBrush(Color.Brown), 2);
        protected Font m_font = new Font("Arial", 12.0f);
        protected Font m_fontSmall = new Font("Arial", 8.0f);
        protected VisibleElement(Point loc)
        {
            m_location = loc;
            Selected = false;
        }
    }

    abstract class Visible2PinElement : VisibleElement
    {
        public override bool IsMy(Point p)
        {
            return m_bounding.IsVisible(p);
        }

        public override VisibleInPort IsInPort(Point p)
        {
            if (m_in1.IsVisible(p))
                return new VisibleInPort(m_element.in1, new Point(m_location.X - 10, m_location.Y + 15));
            else if (m_in2.IsVisible(p))
                return new VisibleInPort(m_element.in2, new Point(m_location.X - 10, m_location.Y + 45));
            else
                return null;
        }

        public override VisibleOutPort IsOutPort(Point p)
        {
            if (m_out.IsVisible(p))
                return new VisibleOutPort(m_element.out1, new Point(m_location.X + 50, m_location.Y + 30));
            else
                return null;
        }

        public override Element Element
        {
            get
            {
                return m_element;
            }
        }

        public override void Move(Point delta)
        {
            m_location.Offset(delta);
            m_bounding.Translate(delta.X, delta.Y);
            m_in1.Translate(delta.X, delta.Y);
            m_in2.Translate(delta.X, delta.Y);
            m_out.Translate(delta.X, delta.Y);
            foreach (Wire w in Circuit.wires)
            {
                if (w.inP == m_element.in1 || w.inP == m_element.in2)
                {
                    w.p4.Offset(delta);
                    w.p2 = new Point((w.p1.X + w.p4.X) / 2, w.p1.Y);
                    w.p3 = new Point((w.p1.X + w.p4.X) / 2, w.p4.Y);
                }
                if (w.outP == m_element.out1)
                {
                    w.p1.Offset(delta);
                    w.p2 = new Point((w.p1.X + w.p4.X) / 2, w.p1.Y);
                    w.p3 = new Point((w.p1.X + w.p4.X) / 2, w.p4.Y);
                }
            }
        }

        public override void Draw(Graphics gr)
        {
            Pen pen = (Selected) ? selectedPen : defaultPen;
            gr.DrawRectangle(pen, new Rectangle(m_location, new Size(40, 60)));
            gr.DrawLine(pen, m_location.X - 10, m_location.Y + 15, m_location.X     , m_location.Y + 15);
            gr.DrawLine(pen, m_location.X - 10, m_location.Y + 45, m_location.X     , m_location.Y + 45);
            gr.DrawLine(pen, m_location.X + 40, m_location.Y + 30, m_location.X + 50, m_location.Y + 30);
        }

        protected Visible2PinElement(Point loc)
            : base(loc)
        {
            m_bounding = new Region(new Rectangle(loc.X - 10, loc.Y, 60, 60));
            m_in1 = new Region(new Rectangle(loc.X - 10, loc.Y + 10, 10, 10));
            m_in2 = new Region(new Rectangle(loc.X - 10, loc.Y + 40, 10, 10));
            m_out = new Region(new Rectangle(loc.X + 40, loc.Y + 25, 10, 10));
        }

        protected Region m_bounding;
        protected Region m_in1;
        protected Region m_in2;
        protected Region m_out;
        protected Element2Pin m_element;
    }

    class And2Visible : Visible2PinElement
    {
        public And2Visible(String name, Point loc)
            : base(loc)
        {
            m_element = new And2(name);
            m_element.InitPorts();
        }

        public override void Draw(Graphics gr)
        {
            base.Draw(gr);
            gr.DrawString("&", m_font, defaultPen.Brush, new PointF(m_location.X + 3, m_location.Y + 3));
            gr.DrawString(this.Element.Name, m_fontSmall, defaultPen.Brush, new PointF(m_location.X - 2, m_location.Y + 62));
        }
    }

    class Or2Visible : Visible2PinElement
    {
        public Or2Visible(String name, Point loc)
            : base(loc)
        {
            m_element = new Or2(name);
            m_element.InitPorts();
        }

        public override void Draw(Graphics gr)
        {
            base.Draw(gr);
            gr.DrawString("1", m_font, defaultPen.Brush, new PointF(m_location.X + 3, m_location.Y + 3));
            gr.DrawString(this.Element.Name, m_fontSmall, defaultPen.Brush, new PointF(m_location.X - 2, m_location.Y + 62));
        }
    }

    class Nor2Visible : Visible2PinElement
    {
        public Nor2Visible(String name, Point loc)
            : base(loc)
        {
            m_element = new Nor2(name);
            m_element.InitPorts();
        }

        public override void Draw(Graphics gr)
        {
            base.Draw(gr);
            gr.DrawString("1", m_font, defaultPen.Brush, new PointF(m_location.X + 3, m_location.Y + 3));
            gr.DrawString(this.Element.Name, m_fontSmall, defaultPen.Brush, new PointF(m_location.X - 2, m_location.Y + 62));
            Pen pen = (Selected) ? selectedPen : defaultPen;
            gr.DrawEllipse(pen, new Rectangle(m_location.X + 38, m_location.Y + 28, 4, 4));
        }
    }

    class Nand2Visible : Visible2PinElement
    {
        public Nand2Visible(String name, Point loc)
            : base(loc)
        {
            m_element = new Nand2(name);
            m_element.InitPorts();
        }

        public override void Draw(Graphics gr)
        {
            base.Draw(gr);
            gr.DrawString("&", m_font, defaultPen.Brush, new PointF(m_location.X + 3, m_location.Y + 3));
            gr.DrawString(this.Element.Name, m_fontSmall, defaultPen.Brush, new PointF(m_location.X - 2, m_location.Y + 62));
            Pen pen = (Selected) ? selectedPen : defaultPen;
            gr.DrawEllipse(pen, new Rectangle(m_location.X + 38, m_location.Y + 28, 4, 4));
        }
    }
}

