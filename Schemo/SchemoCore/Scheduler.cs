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
                return m_instance.Value;
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
            IEnumerable<TimeEvent> currentTmp = from ev in m_events 
                                             where ev.Time == m_tick select ev;
            List<TimeEvent> current = new List<TimeEvent>();
            foreach (TimeEvent ev in currentTmp)
                current.Add(new TimeEvent(ev.Routine, ev.Time));
            foreach (TimeEvent ev in current)
            {
                ev.Routine();
            }
            m_events.RemoveAll((TimeEvent ev) => ev.Time == m_tick);
            m_tick++;
        }

        public void Reset()
        {
            m_events.Clear();
            m_tick = 0;
        }

        public int Time { get { return m_tick; } }

        private static Lazy<Scheduler> m_instance = new Lazy<Scheduler>(() => (new Scheduler()));
        private int m_tick;
        private List<TimeEvent> m_events;
    }
}
