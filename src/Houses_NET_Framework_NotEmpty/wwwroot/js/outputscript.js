function updateTextInput() {
    var str = document.getElementById('rangeElement').value;
    var arr = str.split(",");
    var first = arr[0];
    var second = arr[1];
    document.getElementById('fromYear').innerHTML = first;
    document.getElementById('toYear').innerHTML = second;
}