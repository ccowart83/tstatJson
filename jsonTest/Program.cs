using System;
using System.Net;
using System.Web;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
//using tstatJson;
using Newtonsoft.Json;

namespace jsonTest
{
	class MainClass
	{
		public static void Main (string[] args)
		{

			Console.WriteLine ("Hello World!");
			consumeJSON ();
		}
		static void consumeJSON()
		{

			var request = HttpWebRequest.Create (string.Format (@"http://192.168.0.132/tstat"));
			request.ContentType = "application/json";
			request.Method = "GET";
			try {
			
				using (var Response = request.GetResponse() as HttpWebResponse) {
					if (Response.StatusCode != HttpStatusCode.OK)
						Console.Out.WriteLine ("Error");
					else
						using (var ResponseStreamReader = new StreamReader(Response.GetResponseStream()))
					{
						//get XML Result
						string output = ResponseStreamReader.ReadToEnd();
						Console.Out.WriteLine("Output: {0}", output);

						Tstat tstat = JsonConvert.DeserializeObject<Tstat>(output);

						string date = tstat.time.hour + ":" + tstat.time.minute;
						Console.Out.WriteLine(date);

						Console.Out.WriteLine(tstat.temp);


					}

			
				}
			} catch (WebException e) {
				Console.Out.WriteLine ("Error Connecting: {0}", e);
			}
		}

		static void postJSON()
		{
		

			var request = HttpWebRequest.Create (string.Format (@"http://192.168.0.132/tstat"));
			request.ContentType = "application/json";
			request.Method = "POST";

		

		}

	public class Time
	{
		public int day { get; set; }
		public int hour { get; set; }
		public int minute { get; set; }
	}

	public class Tstat
	{
		public double temp { get; set; }
		public int tmode { get; set; }
		public int fmode { get; set; }
		public int @override { get; set; }
		public int hold { get; set; }
		public double t_cool { get; set; }
		public int tstate { get; set; }
		public int fstate { get; set; }
		public Time time { get; set; }
		public int t_type_post { get; set; }
	}
	}
}
