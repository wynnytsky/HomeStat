window.onload = function () {

	$(document).ready(function () {

		paintMap();

		$.getJSON("daily/fig", function (json) {
	//	$.getJSON("https://a002-oom03.nyc.gov/homestat2/daily/fig", function (json) {
			paintNum(json);
		});

	});
}


function paintNum(json) {
	$(".SPACE_outdoor").text(json.outdoor);
	$(".SPACE_indoor").text(json.indoor);

	var paintSource = function (item) {
		$(".DIV_" + item.type.toLowerCase() + " .STAT_manhattan").text(item.count_manhattan);
		$(".DIV_" + item.type.toLowerCase() + " .STAT_citywide").text(item.count);
	}

	if (Array.isArray(json.source))
		$.each(json.source, function (i, item) {
			paintSource(item);
		});
	else
		paintSource(json.source);
	
//	$("#MAIN_homestat > section:first-of-type time").html(moment().subtract(1, 'day').format("MMMM Do, YYYY"));

	$("#MAIN_homestat > section:first-of-type span time").html(moment(json.created_date).format("MMMM Do, YYYY"));
	$("#MAIN_homestat > section:first-of-type span").toggleClass('cloaked');

	var DIV_OldData = $("#DIV_OldData");
	if (DIV_OldData.length) {

		var yesterday = moment().subtract(1, 'days').startOf('day');
		if (moment(json.created_date) < yesterday) {
			$("#DIV_OldData time").html(yesterday.format("M-D-YYYY"));
			DIV_OldData.toggle();
		}
	}
}