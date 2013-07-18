using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeZones
{
	using System.IO;

	class Program
	{
		static void Main(string[] args)
		{
			DateTime currentDateTime = System.DateTime.Now;
			IReadOnlyCollection<TimeZoneInfo> zones = TimeZoneInfo.GetSystemTimeZones();
			Console.Write("Started...");
			FileStream fs = new FileStream(@"c:\Temp\TimeZones.txt", FileMode.Create);
			TextWriter tmp = Console.Out;
			StreamWriter sw = new StreamWriter(fs);
			Console.SetOut(sw); 
			Console.WriteLine("Local Time Zone = " + TimeZoneInfo.Local.DisplayName);
			Console.WriteLine("Current Date/Time in Local Time Zone = " + currentDateTime.ToString());
			Console.WriteLine();
			foreach (var zone in zones)
			{
				var sb = new StringBuilder();
				sb.Append("ID = ");
				sb.AppendLine(zone.Id);
				sb.Append("StandardName = ");
				sb.AppendLine(zone.StandardName);
				sb.Append("DisplayName = ");
				sb.AppendLine(zone.DisplayName);
				sb.Append("DaylightName = ");
				sb.AppendLine(zone.DaylightName);
				sb.Append("BaseUtcOffset = ");
				sb.AppendLine(zone.BaseUtcOffset.ToString());
				sb.Append("SupportsDaylightSavingTime = ");
				sb.AppendLine(zone.SupportsDaylightSavingTime.ToString());
				sb.Append("Current Date/Time in This Time Zone = ");
				sb.AppendLine(TimeZoneInfo.ConvertTime(currentDateTime, TimeZoneInfo.Local, zone).ToString());
				Console.WriteLine(sb.ToString());
			}
			Console.SetOut(tmp);
			Console.Write("Done");
			Console.ReadLine();
		}
	}
}
