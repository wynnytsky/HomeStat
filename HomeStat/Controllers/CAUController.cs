using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace HomeStat.Controllers
{
	[EnableCors(origins: "*", headers: "*", methods: "get")]
	public class CAUController : ApiController
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

		List<object> features = new List<object>(40000);

		void AppendFeature(decimal? lat, decimal? lng, int key, DateTime created, DateTime? closed, string agency, string complaint, string descriptor, string address )
		{
			//{	
			//	'type': 'Feature',
			//	'geometry': { 'type': 'Point', 'coordinates': [{1},{0}] },
			//	'properties': { 'agency': '{2}', 'borough': '{3}', 'complaint': '{4}', 'descriptor': '{5}' }
			//}

			features.Add(
				new
				{
					type = "Feature",
					geometry = new
					{
						type = "Point",
						coordinates = new decimal?[] { lng, lat }
					},
					properties = new
					{
						key = key,
						d1 = created,
						d2 = closed,
						agen = agency,
						comp = complaint,
						desc = descriptor,
						addr = address
					}
				});
		}

		void FillData()
		{
		//	int i = 0;

		//	List<object> _features = new List<object>(40);
			foreach (var row in db.geo)
			{
				AppendFeature(row.LAT, row.LON, row.UNIQUE_KEY, row.CREATED_DATE, row.CLOSED_DATE, row.AGENCY, row.COMPLAINT_TYPE, row.DESCRIPTOR_1, row.INCIDENT_ADDRESS);

			//	if (i++ == 10)
			//		break;
				
			//	if (i++ % 100 == 0)
			//		Console.WriteLine(i);
			}
		}

		[Route("cau/geo")]
		public object GetDailyGeo()
		{
			FillData();

			return FeatureCollection;
		//	return JsonConvert.DeserializeObject(Serialize(FeatureCollection));
		}

		/*
		//using System.IO;
		//using System.Text;
		//using Newtonsoft.Json;

		string Serialize(object _)
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
		*/
	}
}