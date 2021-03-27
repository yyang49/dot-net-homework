using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Alarm
{
    public class AlarmEventArgs
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }
    }
    public class TickEventArgs
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }
    }
    class Clock
    {
        public event Action<object, AlarmEventArgs> AlarmEvent;
        public event Action<object, TickEventArgs> TickEvent;
        private int alarmHour;
        private int alarmMinute;
        private int alarmSecond;
        public void SetAlarm(int alarmHour, int alarmMinute, int alarmSecond)
        {
            this.alarmHour = alarmHour;
            this.alarmMinute = alarmMinute;
            this.alarmSecond = alarmSecond;
        }
        public void Start()
        {
            while (true)
            {
                int hour = DateTime.Now.Hour;
                int minute = DateTime.Now.Minute;
                int second = DateTime.Now.Second;
                Tick(hour, minute, second);
                if (hour == this.alarmHour && minute == this.alarmMinute && second == this.alarmSecond)
                {
                    Alarm(hour, minute, second);
                }
                Thread.Sleep(1000);
            }
        }
        public void Alarm(int hour, int minute, int second)
        {
            AlarmEventArgs args = new AlarmEventArgs() { Hour = hour, Minute = minute, Second = second };
            AlarmEvent(this, args);
        }
        public void Tick(int hour, int minute, int second)
        {
            TickEventArgs args = new TickEventArgs() { Hour = hour, Minute = minute, Second = second };
            TickEvent(this, args);
        }
    }
    class Alarm
    {
        public Clock clock = new Clock();
        public Alarm()
        {
            clock.AlarmEvent += ClockAlarm;
            clock.TickEvent += ClockTick;
        }
        void ClockAlarm(object sender, AlarmEventArgs args)
        {
            Console.WriteLine($"Alarm {args.Hour}:{args.Minute}:{args.Second}");
        }
        void ClockTick(object sender, TickEventArgs args)
        {
            Console.WriteLine($"{args.Hour}:{args.Minute}:{args.Second}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Alarm alarm = new Alarm();
            alarm.clock.SetAlarm(12, 0, 0);
            alarm.clock.Start();
        }
    }
}
