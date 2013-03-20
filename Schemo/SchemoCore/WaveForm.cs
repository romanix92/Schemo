using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchemoCore
{
    public class WaveForm
    {
        private Dictionary<int, Signal> m_values = new Dictionary<int, Signal>();
        public void Set(Signal s)
        {
            int tick = Scheduler.Instance.Time;
            m_values[tick] = s;
        }

        public Signal Get(int tick)
        {
            int idx = tick;
            Signal? s = null;
            while (idx >= 0 && s == null)
            {
                try
                {
                    s = m_values[idx];
                }
                catch (System.Exception)
                {
                }
                idx--;
            }
            return (s == null) ? Signal.UNDEF : s.Value;
        }

        public int Count()
        {
            return 100;// m_values.Count;
        }
    }
}
