$(document).ready(function () {
    var recordButton = document.getElementById("recordButton");
    var stopButton = document.getElementById("stopButton");
    var controler = new Controler();
    recordButton.addEventListener("click", controler.startRecording);
    stopButton.addEventListener("click", controler.stopRecording);
});

var startTime = Date.now();
var play = false;
var myVar = null;

function myTimer() {
    if (play == true) {
        startTime = Date.now();
        play = false;
    }
    var elapsedTime = Date.now() - startTime;
    document.getElementById("timer").innerHTML = (elapsedTime / 1000).toFixed(3);
}

function myStopFunction() {
    clearInterval(myVar);
    play = true;
}
