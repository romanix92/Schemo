using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SchemoCore;

namespace Shemo
{
    static class Circuit
    {
        public static List<IDrawable> all = new List<IDrawable>();
        public static List<Wire> wires = new List<Wire>();
        public static List<VisibleElement> gates = new List<VisibleElement>();
    }
}
