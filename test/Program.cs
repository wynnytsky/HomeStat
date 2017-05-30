using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

//D:\NYCMO\HomeStat\packages\Newtonsoft.Json.8.0.2\lib\net45\Newtonsoft.Json.dll
using Newtonsoft.Json;
using System.IO;

namespace test
{
	class Program
	{
		HomeStatDataContext _db = null;
		HomeStatDataContext db
		{
			get
			{
				if (_db == null)
					_db = new HomeStatDataContext();
				return _db;
			}
		}


		object FeatureCollection
		{
			get
			{
			//	{ 'type': 'FeatureCollection', 'features': [{0}] }
				return new
				{
					type = "FeatureCollection",
					features = features.ToArray()
				};
			}
		}

		public string FeatureCollectionJson
		{
			get
			{
				return Serialize(FeatureCollection);
			}
		}

		List<object> features = new List<object>(40000);

        void AppendFeature( decimal? lat, decimal? lng, string agency, string borough, string complaint, string descriptor )
		{
			/*
			{	
				'type': 'Feature',
				'geometry': { 'type': 'Point', 'coordinates': [{1},{0}] },
				'properties': { 'agency': '{2}', 'borough': '{3}', 'complaint': '{4}', 'descriptor': '{5}' }
			}
			*/
			features.Add(
				new
				{
					type = "Feature",
					geometry = new
					{
						type = "Point",
						coordinates = new decimal?[] { lat, lng }
					},
					properties = new
					{
						agency = agency,
						borough = borough,
						complaint = complaint,
						descriptor = descriptor
					}
				});
		}

		public void FillDummy()
		{
			AppendFeature(123, 456, "My Agency", "My' Borough", "My Complaint", "My Descriptor");
		}
        public void FillData()
		{
		//	int i = 0;

			List<object> _features = new List<object>(40);
			foreach (var row in db.geo) {
				AppendFeature(row.LAT, row.LON, row.AGENCY, row.BOROUGH, row.COMPLAINT_TYPE, row.DESCRIPTOR_1);

				/*
				if (i++ == 1)
					break;
				if (i++ % 100 == 0)
					Console.WriteLine(i);
				*/
			}
        }

		/*
		static string Serialize(object _)
		{
			string json = JsonConvert.SerializeObject(_);

			json = Regex.Replace(json, @"\\\\|\\(""|')|(""|')", match => {
					if (match.Groups[1].Value == "\"") return "\""; // Unescape \"
					if (match.Groups[2].Value == "\"") return "'";  // Replace " with '
					if (match.Groups[2].Value == "'") return "\\'"; // Escape '
					return match.Value;                             // Leave \\ and \' unchanged
				});

			return json;
		}
		*/

		static string Serialize(object _)
		{
			StringBuilder sb = new StringBuilder();
			using (StringWriter sw = new StringWriter(sb))
				using (JsonTextWriter writer = new JsonTextWriter(sw))
				{
					writer.QuoteChar = '\'';

					JsonSerializer ser = new JsonSerializer();
					ser.Serialize(writer, _);
				}

			return sb.ToString();
		}
		static void go()
		{
			Program me = new Program();
			Stopwatch t = new Stopwatch();

			t.Start();
				me.FillData();
			//	me.FillDummy();
			t.Stop();
			Console.WriteLine(t.Elapsed.TotalSeconds);
			t.Reset();

			t.Start();
				string json = me.FeatureCollectionJson;
			t.Stop();
			Console.WriteLine(t.Elapsed.TotalSeconds);
			t.Reset();

		//	Console.WriteLine(json);
		}

		static void Main(string[] args)
		{
			go();
		}
	}
}
