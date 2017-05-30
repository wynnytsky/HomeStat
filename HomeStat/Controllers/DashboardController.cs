using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

using Newtonsoft.Json;

using HomeStat.Models;

namespace HomeStat.Controllers
{
	[EnableCors(origins: "*", headers: "*", methods: "get")]
	public class DashboardController : ApiController
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

		[Route("daily/fig")]
		public object GetDailyFigures()
		{
		//	return db.vw_daily_fig.Single().xml;

			// uglier, but removes the root XML node
			string json = JsonConvert.SerializeXNode(db.vw_daily_fig.Single().xml, Newtonsoft.Json.Formatting.None, true);
			return JsonConvert.DeserializeObject(json);
		}

		[Route("daily/geo")]
		public FeatureCollection GetDailyGeo()
		{
			FeatureCollection col = new FeatureCollection();
			foreach (var row in db.daily_geo.Where(_ => _.lat.HasValue && _.lon.HasValue ))
				col.addFeature(row.lat, row.lon,row.type);
			return col;
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
		public FeatureCollection GetMonthlyGeo()
		{
			DateTime lastDay = db.monthly_geo.Max(_ => _.created_date).Date;
			DateTime lastMonth = lastDay.AddDays(1 - lastDay.Day);

			FeatureCollection col = new FeatureCollection();
			foreach (var row in db.monthly_geo.Where(_ => _.lat.HasValue && _.lon.HasValue && _.created_date >= lastMonth && _.type != "PARKS"))
				col.addFeature(row.lat, row.lon, row.type);
			return col;
		}
		
		/*
		[Route("test")]
		public HomeStat.Models.FeatureCollection GetTest()
		{
			HomeStat.Models.FeatureCollection col = new HomeStat.Models.FeatureCollection();
			col.addFeature(1.2m, 2.3m, "abc");
			col.addFeature(3.4m, 4.5m, "def");
			return col;
		}
		*/
	}
}