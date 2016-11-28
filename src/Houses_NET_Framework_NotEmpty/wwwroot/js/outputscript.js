function updateTextInput() {
    var str = document.getElementById('rangeElement').value;
    var arr = str.split(",");
    var first = Math.floor(minYear + (maxYear - minYear) * (arr[0] / 100));
    var second = Math.floor(minYear + (maxYear - minYear) * (arr[1] / 100));

    previousFromYear = currentFromYear;
    previousToYear = currentToYear;

    currentFromYear = first;
    currentToYear = second;

    document.getElementById('fromYear').innerHTML = first;
    document.getElementById('toYear').innerHTML = second;
}

function onClick() {
    for (var year = previousFromYear; year < previousToYear; ++year) {
        yearIndex = year - minYear;
        for (var i = 0, l = markerArray[yearIndex].length; i < l; ++i) {
            var marker = markerArray[yearIndex][i];
            marker.setVisible(false);
        }
    }

    for (var year = currentFromYear; year <= currentToYear; ++year) {
        yearIndex = year - minYear;
        for (var i = 0, l = markerArray[yearIndex].length; i < l; ++i) {
            var marker = markerArray[yearIndex][i];
            marker.setVisible(true);
        }
    }
}