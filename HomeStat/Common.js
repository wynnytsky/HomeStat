function paintMap() {

	var urlSrc = 'https://nycdoitt.cartodb.com/u/jperazzo/viz/' + hs_cartoId + '/embed_map';
	var urlVis = 'https://nycdoitt.cartodb.com/u/jperazzo/api/v2/viz/' + hs_cartoId + '/viz.json';

	if (typeof (cartodb) == 'undefined') {
		$("#MAIN_homestat iframe").toggle(true);
		$("iframe").attr("src", urlSrc);
	}

	else
		cartodb.createVis('SECTION_map', urlVis, {
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