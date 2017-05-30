using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

using Newtonsoft.Json;

namespace HomeStat.Controllers
{
	[EnableCors(origins: "*", headers: "*", methods: "get")]
	public class DashboardController : ApiController
    {
		readonly string featureCollectionTemplate = @"{
				'type': 'FeatureCollection',
					'features': [{0}]
				}";

		readonly string featureTemplate = "{'type': 'Feature', 'geometry': { 'type': 'Point', 'coordinates': [{1},{0}] }, 'properties': { 'type': '{2}' }}";

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
		/*
		object GetGeo(DateTime from, DateTime to)
		{
			//	return new { abc = 123 };
			//	db.geo.ToList().ForEach(_ => { featureList += featureList.Length > 0 ? "," : "" + string.Format(featureTemplate, _.lat, _.lng, _.type); });
			
				string json
				= @"{
						'type': 'FeatureCollection',
						'features': [{'type': 'Feature', 'geometry': { 'type': 'Point', 'coordinates': [-73.9329713,40.5880033] }, 'properties': { 'Name': 'ANONYMOUS' }}
									,{'type': 'Feature', 'geometry': { 'type': 'Point', 'coordinates': [-74.0086456,40.7073410] }, 'properties': { 'Name': 'ANONYMOUS' }}
									,{'type': 'Feature', 'geometry': { 'type': 'Point', 'coordinates': [-73.9874864,40.7343161] }, 'properties': { 'Name': 'ANONYMOUS' }}]
					}";
				return JsonConvert.DeserializeObject(json);
			
		}
		*/

		//	[Route("stats")]
		[Route("daily/fig")]
		public object GetDailyFigures()
		{
		//	return db.vw_daily_fig.Single().xml;

			// uglier, but removes the root XML node
			string json = JsonConvert.SerializeXNode(db.vw_daily_fig.Single().xml, Newtonsoft.Json.Formatting.None, true);
			return JsonConvert.DeserializeObject(json);
		}

	//	[Route("geo")]
		[Route("daily/geo")]
		public object GetDailyGeo()
		{
		//	DateTime to = DateTime.Now.Date;
		//	DateTime from = to.AddDays(-1);

			string json = "";
			foreach (var row in db.daily_geo.Where(_ => _.lat.HasValue && _.lon.HasValue /*&& _.created_date >= from && _.created_date < to*/ /*&& _.type != "CAMP"*/)) //Homeless Encampment
			{
				if (json.Length > 0)
					json += "\r\n,";

				json += featureTemplate
					.Replace("{0}", row.lat.ToString())
					.Replace("{1}", row.lon.ToString())
					.Replace("{2}", row.type.ToString());
			}

			json = featureCollectionTemplate.Replace("{0}", json);
			return JsonConvert.DeserializeObject(json);
		}

		[Route("monthly/fig")]
		public object GetMonthlyFigures()
		{
		//	return db.vw_monthly_fig.Single().xml;

			// uglier, but removes the root XML node
			string json = JsonConvert.SerializeXNode(db.vw_monthly_fig.Single().xml, Newtonsoft.Json.Formatting.None, true);
			return JsonConvert.DeserializeObject(json);
		}

		[Route("monthly/geo")]
		public object GetMonthlyGeo()
		{
			DateTime lastDay = db.monthly_geo.Max(_ => _.created_date).Date;
			DateTime lastMonth = lastDay.AddDays(1 - lastDay.Day);

			//DateTime firstOfMonth = DateTime.Now.Date;
			//firstOfMonth = firstOfMonth.AddDays(1 - firstOfMonth.Day);

			//DateTime from = firstOfMonth.AddMonths(-1);
			//DateTime to = firstOfMonth;
			//&& _.created_date < to 

			string json = "";
			foreach (var row in db.monthly_geo.Where(_ => _.lat.HasValue && _.lon.HasValue && _.created_date >= lastMonth && _.type != "PARKS"))
			{
				if (json.Length > 0)
					json += "\r\n,";

				json += featureTemplate
					.Replace("{0}", row.lat.ToString())
					.Replace("{1}", row.lon.ToString())
					.Replace("{2}", row.type.ToString());
			}

			json = featureCollectionTemplate.Replace("{0}", json);
			return JsonConvert.DeserializeObject(json);
		}
	}
}