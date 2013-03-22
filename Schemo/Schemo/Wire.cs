using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using SchemoCore;

namespace Schemo
{
    class Wire : IDrawable
    {
        public Wire(Point start, Point end, OutPort first, InPort second)
        {
            outP = first;
            inP = second;
            FindPath(start, end);
            Selected = false;
        }

        public void FindPath(Point start, Point end)
        {
            p1 = start;
            p4 = end;
            if (start.X < end.X)
            {
                p2 = new Point((p1.X + p4.X) / 2, p1.Y);
                p3 = new Point((p1.X + p4.X) / 2, p4.Y);
            }
            else if (Math.Abs(start.Y - end.Y) > 40)
            {
                p2 = new Point(p1.X, (int)(.5f * (p1.Y + p4.Y)));
                p3 = new Point(p4.X, (int)(.5f * (p1.Y + p4.Y)));
            }
            else
            {
                p2 = new Point(p1.X, Math.Max(p1.Y, p4.Y) + 65);
                p3 = new Point(p4.X, Math.Max(p1.Y, p4.Y) + 65);
            }
        }

        public void Remove()
        {
            outP.RemoveSubscriber(inP);
        }

        public void Draw(Graphics gr)
        {
            Pen pen = (Selected) ? selectedPen : defaultPen;
            gr.DrawLine(pen, p1, p2);
            gr.DrawLine(pen, p2, p3);
            gr.DrawLine(pen, p3, p4);
        }

        public bool Selected { get; set; }

        public Point p1;
        public Point p2;
        public Point p3;
        public Point p4;

        public OutPort outP;
        public InPort  inP;

        private Pen defaultPen = new Pen(new SolidBrush(Color.Black));
        private Pen selectedPen = new Pen(new SolidBrush(Color.Brown), 2);
    }
}
