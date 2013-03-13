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
            m_values.Add(tick, s);
        }

        public Signal Get(int tick)
        {
            return m_values[tick];
        }
    }
}
