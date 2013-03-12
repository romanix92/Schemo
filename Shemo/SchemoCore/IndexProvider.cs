using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchemoCore
{
    public class IndexProvider
    {
        public static IndexProvider Instance
        {
            get
            {
                return m_instance.Value;
            }
        }

        private readonly static Lazy<IndexProvider> m_instance
            = new Lazy<IndexProvider>(() => new IndexProvider());
        private int m_index;

        public int Index
        {
            get
            {
                m_index++;
                return m_index;
            }
        }
    }
}
