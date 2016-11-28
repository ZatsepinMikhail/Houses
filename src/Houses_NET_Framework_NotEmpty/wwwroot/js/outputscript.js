function updateTextInput() {
    var str = document.getElementById('rangeElement').value;
    var arr = str.split(",");
    var first = Math.floor(minYear + (maxYear - minYear) * (arr[0] / 100));
    var second = Math.floor(minYear + (maxYear - minYear) * (arr[1] / 100));

    newFromYear = first;
    newToYear = second;

    document.getElementById('fromYear').innerHTML = first;
    document.getElementById('toYear').innerHTML = second;
}
