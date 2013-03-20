using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using SchemoCore;

namespace Schemo
{
    interface IVisibleElementFactory
    {
        VisibleElement newInstance(Point p);
    }

    class VisibleAnd2Factory : IVisibleElementFactory
    {
        public VisibleElement newInstance(Point p)
        {
            return new And2Visible("And2_" + IndexProvider.Instance.Index, p);
        }
    }

    class VisibleOr2Factory : IVisibleElementFactory
    {
        public VisibleElement newInstance(Point p)
        {
            return new Or2Visible("Or2_" + IndexProvider.Instance.Index, p);
        }
    }

    class VisibleNand2Factory : IVisibleElementFactory
    {
        public VisibleElement newInstance(Point p)
        {
            return new Nand2Visible("Nand2_" + IndexProvider.Instance.Index, p);
        }
    }

    class VisibleNor2Factory : IVisibleElementFactory
    {
        public VisibleElement newInstance(Point p)
        {
            return new Nor2Visible("Nor2_" + IndexProvider.Instance.Index, p);
        }
    }

    class VisibleClockFactory : IVisibleElementFactory
    {
        public VisibleElement newInstance(Point p)
        {
            return new ClockGeneratorVisible("Clock_" + IndexProvider.Instance.Index, 10, p);
        }
    }
}
