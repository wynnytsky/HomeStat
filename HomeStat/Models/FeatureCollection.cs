using System.Collections.Generic;

namespace HomeStat.Models
{
	public class Feature
	{
		public Feature(decimal? lat, decimal? lng, string type)
		{
			this.geometry = new { type = "Point", coordinates = new decimal?[] { lng, lat } };
			this.properties = new { type = type };
		}

		public const string type = "Feature";
		public object geometry;
		public object properties;
	}

	public class FeatureCollection
	{
		public string type = "FeatureCollection";

		public Feature[] features
		{
			get
			{
				return _features.ToArray();
			}
		}

		private List<Feature> _features = new List<Feature>();

		public void addFeature(decimal? lat, decimal? lng, string type )
		{
			_features.Add(new Feature(lat, lng, type));
		}
	}
}