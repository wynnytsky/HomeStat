function teamsiteCallback1() {
	alert ('callback 1')
}

window.onload = function () {

	$(document).ready(function () {

		var url = 'https://nycdoitt.cartodb.com/u/jperazzo/api/v2/viz/40297d00-d99e-11e5-b48a-0ecd1babdde5/viz.json';

		cartodb.createVis('DIV_map', url, {
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




		$.getJSON("https://a002-oom03.nyc.gov/homestat/stats", function (data) {
			paint(data);
		});

		/*
		$.getJSON("stats", function (data) {
			paint(data);
		});
		
		paint([
			{
				"type": "PUBLIC",
				"count_manhattan": 53,
				"count": 69
			},
			{
				"type": "CANVAS",
				"count_manhattan": 103,
				"count": 105
			}
		]);

			{
				"type": "PARKS",
				"count_manhattan": 3,
				"count": 33
			},
			{
				"type": "CAMP",
				"count_manhattan": 15,
				"count": 24
			}
		*/
	});
}

function paint(data) {
	var total = 0;
	$.each(data, function (i, item) {
		total += item.count;

		/*
		var id = "";
		switch (item.type) {
			case "PUBLIC": id = "public"; break;
			case "CAMP": id = "camp"; break;
			case "PARKS": id = "parks"; break;
			case "CANVAS": id = "canvasser"; break;
		}
		*/

		$("#SECTION_" + item.type.toLowerCase() + " div:nth-of-type(1) div").text(item.count_manhattan);
		$("#SECTION_" + item.type.toLowerCase() + " div:nth-of-type(2) div").text(item.count);
		$("#SECTION_" + item.type.toLowerCase() + " .cloaked").toggleClass('cloaked');
	});

	$("#SECTION_intro h1").html(total);
	$("#SECTION_intro time").html(moment().subtract(1, 'day').format("MMMM Do, YYYY"));
//	$("#SECTION_intro time").html(moment("20160317", "YYYYMMDD").subtract(1, 'day').format("MMMM Do, YYYY"));
	$("#SECTION_intro div").toggleClass('cloaked');
}