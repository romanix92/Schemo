using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Shemo
{
    interface IContextMenuProvider
    {
        ContextMenuStrip Menu { get; }
        VisibleElement Selected { get; set; }
        Point offset { get; set; }
    }

    class ElementContextProvider : IContextMenuProvider
    {
        private ElementContextProvider(){}
        private static readonly Lazy<ElementContextProvider> m_instance =
            new Lazy<ElementContextProvider>(() => new ElementContextProvider());

        public static ElementContextProvider Instance { get { return m_instance.Value; } }
        public ContextMenuStrip Menu { get; set; }
        public VisibleElement Selected { get; set; }
        public Point offset { get; set; }
    }
}
