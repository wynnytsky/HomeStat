window.onload = function () {

	$(document).ready(function () {

		paintMap();

	});
}


google.charts.load('current', { 'packages': ['corechart', 'bar'] });
google.charts.setOnLoadCallback(paint);

function paint() {

	/*
	var json = {

		"gen": {
			"female": "417",
			"male": "2003",
			"tran_F2M": "2",
			"tran_M2F": "10",
			"unknown": "10"
		},

		"age": {
			"u21": "7",
			"u31": "163",
			"u41": "313",
			"u51": "572",
			"u61": "835",
			"u71": "422",
			"u81": "97",
			"u91": "11",
			"unknown": "22"
		},

		"vet_pct": "56",

		"home": 
			{
				"@month": "2016-06-01",
				"serviceRequests": "1190",
				"clients": "1250",
				"contacted": "1600",
				"streetOn": "700",
				"streetOff": "129",
				"homeTemp": "41",
				"homePerm": "7"
			},

		"source": [
			{
				"type": "PUBLIC",
				"count_manhattan": "1641",
				"count": "2081"
			},
			{
				"type": "CANVAS",
				"count_manhattan": "2471",
				"count": "2513"
			},
			{
				"type": "CAMP",
				"count_manhattan": "374",
				"count": "518"
			},
			{
				"type": "PARKS",
				"count_manhattan": "3",
				"count": "3"
			}
		]
	};
	*/

	
	$.getJSON("monthly/fig", function (json) {
//	$.getJSON("https://a002-oom03.nyc.gov/homestat2/monthly/fig", function (json) {
		paintMisc(json);
		paintCharts(json);
	});
	
}

function paintMisc(json) {

	var month = moment(json.home["@month"]).format("MMMM YYYY");

	$(".HS_Month").text(month);

	$("#H1_clients").text(Number(json.home.clients).toLocaleString());
	$(".H1_serviceRequests").text(Number(json.home.serviceRequests).toLocaleString());

	$("#SECTION_vet > article > div:last-of-type").text(json.vet_pct + "%");

	$.each(json.source, function (i, item) {
		$(".DIV_" + item.type.toLowerCase() + " .STAT_manhattan").text(Number(item.count_manhattan).toLocaleString());
		$(".DIV_" +item.type.toLowerCase() + " .STAT_citywide").text(Number(item.count).toLocaleString());
	});

	$("#MAIN_homestat .cloaked").toggleClass('cloaked');

	paintHomeTiles(json.home);

}

function paintCharts(json) {
	
	paintGender(json.gen);
	paintAge(json.age);
//	paintHomeChart(json.home);

}

function paintGender(gen) {

	var data = google.visualization.arrayToDataTable([
		['Gender', 'Number'],
		['Female', Number(gen.female)],
		['Male', Number(gen.male)],
		['Transgender', Number(gen.tran_F2M) + Number(gen.tran_M2F)],
	/*	['Tran', Number(gen.tran)],
		['Transgendered Female to Male', Number(gen.tran_F2M)],
		['Transgendered Male to Female', Number(gen.tran_M2F)],*/
		['Unknown', Number(gen.unknown)],
	]);

	var options = {
		pieHole: 0.6,
		pieSliceText: 'none',
		chartArea: { width: '95%', height: '100%' },
		tooltip: { text: 'percentage' },
		colors: ['#25237a', '#00b2e8', '#024da1', /*'#e44398',*/ '#fff200'],
		legend: { position: 'right' },
		sliceVisibilityThreshold: 0
	};

	var chart = new google.visualization.PieChart(document.getElementById('DIV_genderDonut'));
	chart.draw(data, options);

}

function paintAge(age) {

	var data = google.visualization.arrayToDataTable([
		['Age', 'Range'],
		['Under 21', Number(age.u21)],
		['21 - 30', Number(age.u31)],
		['31 - 40', Number(age.u41)],
		['41 - 50', Number(age.u51)],
		['51 - 60', Number(age.u61)],
		['61 - 70', Number(age.u71)],
		['71 - 80', Number(age.u81)],
		['81 - 90', Number(age.u91)],
		['Unknown', Number(age.unknown)],
	]);

	var options = {
		pieHole: 0.6,
		pieSliceText: 'none',
		chartArea: {width: '95%', height: '100%'},
		tooltip: { text: 'percentage' },
		colors: ['#25237a', '#213d6d', '#024da1', '#00b2e8', '#c6eafb', '#e44398', '#9f2882', '#fcb414', '#fff200'],
		legend: { position: 'right' },
		sliceVisibilityThreshold: 0
	};

	var chart = new google.visualization.PieChart(document.getElementById('DIV_ageDonut'));
	chart.draw(data, options);

}


function paintHomeTiles(home) {

	$("#DIV_streetTile > h1").text(Number(home.onStreet).toLocaleString());
	$("#DIV_houseTile > h1").text(Number(home.homeTran_current).toLocaleString());
	$("#DIV_otherTile > h1").text(Number(home.clients - home.onStreet - home.homeTran_current).toLocaleString());

	$("#DIV_placedOtherTile> h1").text(Number(home.homeOther_placed).toLocaleString());
	$("#DIV_placedTranTile > h1").text(Number(home.homeTran_placed).toLocaleString());
	$("#DIV_placedPermTile > h1").text(Number(home.homePerm_placed).toLocaleString());

	/*
//	$("#SECTION_home > article > div:nth-of-type(1) > h1").text(Number(home.serviceRequests).toLocaleString());
	$("#SECTION_home > article > div:nth-of-type(2) > h1").text(Number(home.prospects).toLocaleString());
	$("#SECTION_home > article > div:nth-of-type(3) > h1").text(Number(home.onStreet).toLocaleString());
	$("#SECTION_home > article > div:nth-of-type(4) > h1").text(Number(home.homeTran_placed).toLocaleString());
	$("#SECTION_home > article > div:nth-of-type(5) > h1").text(Number(home.homeTran_current).toLocaleString());
	$("#SECTION_home > article > div:nth-of-type(6) > h1").text(Number(home.homePerm_placed).toLocaleString());
	*/
}

/*
function paintHomeChart(home) {

	var data = new google.visualization.DataTable();
	data.addColumn('string', null);
	data.addColumn('number', 'Total 311 service requests for homeless assistance');
	data.addColumn('number', 'Individuals contacted by HOME-STAT Outreach teams');
	data.addColumn('number', 'HOME-STAT clients on the street');
	data.addColumn('number', 'Clients transitioned off the street');
	data.addColumn('number', 'HOME-STAT clients currently in transitional housing');
	data.addColumn('number', 'HOME-STAT clients placed in permanent housing');

	data.addRows([
		[moment(home[0]["@month"]).format("MMM YYYY")
		, Number(home[0].serviceRequests)
		, Number(home[0].contacted)
		, Number(home[0].streetOn)
		, Number(home[0].streetOff)
		, Number(home[0].homeTemp)
		, Number(home[0].homePerm)],

		[moment(home[1]["@month"]).format("MMM YYYY")
		, Number(home[1].serviceRequests)
		, Number(home[1].contacted)
		, Number(home[1].streetOn)
		, Number(home[1].streetOff)
		, Number(home[1].homeTemp)
		, Number(home[1].homePerm)]
	]);

	var options = {
		height: 260,
		colors: ['#25237a', '#9f2882', '#e44398', '#024da1', '#213d6d', '#00b2e8'],
		legend: { position: 'none' },
	};

	new google.charts.Bar(document.getElementById('ARTICLE_homeChart')).draw(data, google.charts.Bar.convertOptions(options));

}
*/