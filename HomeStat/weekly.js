window.onload = function () {

	$(document).ready(function () {

		paintMap();
		paintNum();

	});
}

function paintNum() {
	var sql = new cartodb.SQL({ user: 'jperazzo' });

	/*
	var _sql = `
 SELECT sum(case ny_boroughs.boroname when 'Manhattan' then 1 else 0 end) as manhattan,
        count(*) as citywide, max(created) as created
 FROM   jperazzo.table_6enbb7qew6asblzr3qdhkw, ny_boroughs
 WHERE  ST_INTERSECTS(jperazzo.table_6enbb7qew6asblzr3qdhkw.the_geom, ny_boroughs.the_geom)`;

	var _sql = `
select * from hs_weekly_stats2`;
	*/

	var _sql = `
 SELECT count(*) as manhattan,
        count(*) as citywide,
		max(created) as created
 FROM   jperazzo.table_6enbb7qew6asblzr3qdhkw`;

	sql.execute(_sql)
		.done(function (data) {
		//	console.log(data.rows);
			var row = data.rows[0];

			$(".STAT_manhattan_").text(row.manhattan);
			$(".STAT_citywide_").text(row.citywide);

			$("#MAIN_homestat > section:first-of-type span time").html(moment(row.created).format("dddd, MMMM Do, YYYY"));
			$("#MAIN_homestat > section:first-of-type span").toggleClass('cloaked');
		})
		.error(function (errors) {
			console.log(errors);
		});
}

/*
function paintNum() {
//	var sql = "select * from jperazzo.untitled_table_19";

	var sql = `
 SELECT sum(case ny_boroughs.boroname when 'Manhattan' then 1 else 0 end) as manhattan,
 count(*) as citywide,
 max(created) as created
 FROM jperazzo.table_28pqwcbgo8jphjqjfazoua,
 ny_boroughs
 WHERE ST_INTERSECTS(jperazzo.table_28pqwcbgo8jphjqjfazoua.the_geom, ny_boroughs.the_geom)`;

	var url = 'https://jperazzo.carto.com/api/v2/sql?q=' + sql + '&api_key=776dd82e4fe0c99893cb56c35053556211c9d29a';

	$.getJSON(url, function (data) {
		$.each(data.rows, function (key, val) {
			console.log(val);

			$(".STAT_manhattan").text(val.manhattan);
			$(".STAT_citywide").text(val.citywide);

			$("#MAIN_homestat > section:first-of-type span time").html(moment(val.created).format("dddd, MMMM Do, YYYY"));
			$("#MAIN_homestat > section:first-of-type span").toggleClass('cloaked');
		});
	});
}
*/