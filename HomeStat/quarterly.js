window.onload = function () {

	$(document).ready(function () {

		paintStats();

		paintMap();

	});
}

function paintStats() {
	$(".HS_quarter").text(hs_data.quarter);
	$("#HS_quarterStart").text(hs_data.quarterStart);

	var total = hs_data.bronx + hs_data.brooklyn + hs_data.manhattan + hs_data.queens + hs_data.staten + hs_data.train;
	$("#HS_total").text(Number(total).toLocaleString());

	$(".HS_bronx").text(Number(hs_data.bronx).toLocaleString());
	$(".HS_brooklyn").text(Number(hs_data.brooklyn).toLocaleString());
	$(".HS_manhattan").text(Number(hs_data.manhattan).toLocaleString());
	$(".HS_queens").text(Number(hs_data.queens).toLocaleString());
	$(".HS_staten").text(Number(hs_data.staten).toLocaleString());
	$(".HS_train").text(Number(hs_data.train).toLocaleString());
}