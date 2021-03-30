using System;

namespace Alarm
{
    class main
    {
        static void Main(string[] args)
        {
            AlarmClock myClock = new AlarmClock(6, 59, 55);
            myClock.AlarmEvent += GetUp;
            myClock.TickEvent += TickSound;
            myClock.setAlarmTime(7, 0, 0);
            myClock.run();
        }
        static private void GetUp(object sender)
        { Console.WriteLine("铃声响了，我要起床了！"); }
        static private void TickSound(object sender)
        { Console.WriteLine(" 滴答... "); }
    }
}
