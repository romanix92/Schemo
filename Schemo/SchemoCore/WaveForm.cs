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

        public Signal? Get(int tick)
        {
            Signal? s = null;
            try
            {
                s = m_values[tick];
            }
            catch (System.Exception)
            {
                return null;
            }
            return s;
        }

        public void GetNext(int current, out int time, out Signal? s)
        {
            time = (from key in m_values.Keys where key > current select key).Min();
            s = m_values[time];
        }

        public int Count()
        {
            return m_values.Keys.Max();
        }

        public void Clear()
        {
            m_values.Clear();
        }
    }
}
