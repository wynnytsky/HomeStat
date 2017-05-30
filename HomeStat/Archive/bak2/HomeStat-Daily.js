window.onload = function () {

	$(document).ready(function () {

		paintMap();

		/*
		$.getJSON("https://a002-oom03.nyc.gov/homestat/stats", function (data) {
			paintStats(data);
		});
		$.getJSON("stats", function (data) {
			paintStats(data);
		});
		*/

		//PARKS
		paintStats([
			{
				"type": "PUBLIC",
				"count_manhattan": 53,
				"count": 69
			},
			{
				"type": "CANVAS",
				"count_manhattan": 103,
				"count": 105
			},
			{
				"type": "CAMP",
				"count_manhattan": 11,
				"count": 22
			}
		]);
	});
}

function paintMap() {
	var url = 'https://nycdoitt.cartodb.com/u/jperazzo/api/v2/viz/40297d00-d99e-11e5-b48a-0ecd1babdde5/viz.json';

	cartodb.createVis('SECTION_map', url, {
		search: false,
		tiles_loader: true,
		layer_selector: false,
		https: true

	}).done(function (vis, layers) {
		vis.map.set({
			minZoom: 10,
			maxZoom: 13
		});

	}).error(function (err) {
		console.log(err);

	});
}

function paintStats(data) {
	
	$.each(data, function (i, item) {
		$("#DIV_" + item.type.toLowerCase() + " > div:nth-of-type(2)").text(item.count_manhattan);
		$("#DIV_" + item.type.toLowerCase() + " > div:nth-of-type(3)").text(item.count);
		$("#DIV_" + item.type.toLowerCase() + " .cloaked").toggleClass('cloaked');
	});

	$("#MAIN_homestat > section:first-of-type time").html(moment().subtract(1, 'day').format("MMMM Do, YYYY"));
//	$("#MAIN_homestat > section:first-of-type time").html(moment("20160317", "YYYYMMDD").subtract(1, 'day').format("MMMM Do, YYYY"));
	$("#MAIN_homestat > section:first-of-type time").toggleClass('cloaked');
}