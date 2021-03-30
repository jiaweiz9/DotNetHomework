using System;
using System.Threading;
namespace Alarm{

	public delegate void alarmEvent(object sender);
	public class AlarmClock
	{
		public event alarmEvent TickEvent;
		public event alarmEvent AlarmEvent;
		public AlarmClock(int hour=0,int minute=0,int second=0)
		{
			clockTime.Hour = hour%24;
			clockTime.Minute = minute%60;
			clockTime.Second = second%60;
		}
	    private ClockTime clockTime=new ClockTime();
		private ClockTime alarmTime=new ClockTime();
		public void run()
        {
			while(true)
            {
				Console.WriteLine(clockTime.Hour+":"+clockTime.Minute+":"+clockTime.Second);
				TickEvent(this);
				clockTime.Second = (clockTime.Second + 1) % 60;
				if (clockTime.Second % 60 == 0) clockTime.Minute = (clockTime.Minute+1)%60;
				if (clockTime.Minute % 60 == 0&&clockTime.Second % 60 == 0)  clockTime.Hour = (clockTime.Hour + 1) % 24; 
				if (clockTime.Hour == alarmTime.Hour && clockTime.Minute == alarmTime.Minute && clockTime.Second == alarmTime.Second) AlarmEvent(this);
				Thread.Sleep(1000);
            }
        }

		public void setAlarmTime(int hour, int minute, int second)
		{
			alarmTime.Hour = hour % 24;
			alarmTime.Minute = minute % 60;
			alarmTime.Second = second % 60;
		}

	}
}
