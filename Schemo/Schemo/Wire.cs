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
            p1 = start;
            p4 = end;
            p2 = new Point((p1.X + p4.X) / 2, p1.Y);
            p3 = new Point((p1.X + p4.X) / 2, p4.Y);

            outP = first;
            inP = second;

            Selected = false;
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
