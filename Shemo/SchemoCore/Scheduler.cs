using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SchemoCore
{
    public delegate void Routine();

    public class Scheduler
    {
        public static Scheduler Instance
        {
            get
            {
                if (m_instance != null)
                    return m_instance;
                lock (m_sync)
                {
                    if (m_instance == null)
                        m_instance = new Scheduler();
                }
                return m_instance;
            }
        }

        private Scheduler()
        {
            m_tick = 0;
            m_events = new List<TimeEvent>();
        }

        class TimeEvent
        {
            public TimeEvent(Routine action, int time)
            {
                m_time = time;
                m_action = action;
            }

            public Routine Routine { get { return m_action; } }
            public int Time { get { return m_time; } }
            private int m_time;
            private Routine m_action;
        }

        public void AddEvent(Routine action, int delay)
        {
            if (delay < 0)
                throw ( new ArgumentException() );
            m_events.Add(new TimeEvent(action, m_tick + delay));
        }

        public void Execute()
        {
            IEnumerable<TimeEvent> current = from ev in m_events 
                                             where ev.Time == m_tick select ev;
            foreach (TimeEvent ev in current)
            {
                ev.Routine();
            }
            m_events.RemoveAll((TimeEvent ev) => ev.Time == m_tick);
            m_tick++;
        }

        public int Time { get { return m_tick; } }

        private static Scheduler m_instance;
        private static Object m_sync= new Object();
        private int m_tick;
        private List<TimeEvent> m_events;
    }
}
