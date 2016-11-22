function updateTextInput() {
    var str = document.getElementById('rangeElement').value;
    var arr = str.split(",");
    var first = Math.floor(minYear + (maxYear - minYear) * (arr[0] / 100));
    var second = Math.floor(minYear + (maxYear - minYear) * (arr[1] / 100));
    currentFromYear = first;
    currentToYear = second;
    document.getElementById('fromYear').innerHTML = first;
    document.getElementById('toYear').innerHTML = second;
}

function onClick() {
    for (var i = 0, l = markerArray.length; i < l; i++)
    {
        var marker = markerArray[i];
        marker.setMap(null);
    }
    markerArray = [];

    for (var index = 0; index < lats.length; ++index) {
        if (currentFromYear < years[index] && years[index] < currentToYear) {
            var myLatLng = { lat: lats[index], lng: lngs[index] };
            var marker = new google.maps.Marker({
                icon: {
                    path: google.maps.SymbolPath.CIRCLE,
                    fillOpacity: 0.5,
                    fillColor: getColor(years[index]),
                    strokeOpacity: 0.5,
                    strokeColor: '#000000',
                    strokeWeight: 1.0,
                    scale: 4
                },
                position: myLatLng,
                map: map
            });
            markerArray.push(marker);
        }
    }
}