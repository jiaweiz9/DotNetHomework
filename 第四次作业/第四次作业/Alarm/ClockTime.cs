using System;

namespace Alarm {
	public class ClockTime
	{
		private int hour;
		public int Hour{ get => hour; set=> hour= value % 24;  }
		private int minute;
		public int Minute { get => minute; set => minute = value % 60; }
		private int second;
		public int Second { get => second; set => second = value % 60; }

		public ClockTime(int hour=0, int minute=0, int second=0)
		{
			this.hour = hour % 24;
			this.minute = minute % 60;
			this.second = second % 60;
		}
	}
}