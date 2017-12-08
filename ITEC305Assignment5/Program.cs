using System;
using Nancy.Hosting.Self;

namespace Noriko
{
    class Program
    {
        static void Main(string[] args)
        {
			var nancy = new NancyHost(new HostConfiguration
			{
				UrlReservations = new UrlReservations
				{
					CreateAutomatically = true
				}
			}
			, new Uri("http://localhost:9876"));
			nancy.Start();
			Console.Write("Hosting on http://localhost:9876");
			Console.ReadLine();
        }
    }
}
