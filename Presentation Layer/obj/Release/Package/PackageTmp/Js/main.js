$(document).ready(function () {
    var recordButton = document.getElementById("recordButton");
    var stopButton = document.getElementById("stopButton");
    var saveButton = document.getElementById("saveButton");
    var controler = new Controler();
    controler.stopRecording();
    recordButton.addEventListener("click", () => { controler.startRecording()});
    stopButton.addEventListener("click", () => { controler.stopRecording()});
    saveButton.addEventListener("click", controler.exportRec);
});

var totalSeconds = 0;
var play = false;
var myVar = null;
var duration = null;
function myTimer() {
    if (play == true) {
        totalSeconds = 0;
        play = false;
    }
    ++totalSeconds;
    document.getElementById("timer").innerHTML = pad(parseInt(totalSeconds / 60)) + ":" + pad(totalSeconds % 60);
}

function myStopFunction() {
    clearInterval(myVar);
    play = true;
}

function pad(val) {
    var valString = val + "";
    if (valString.length < 2) {
        return "0" + valString;
    } else {
        return valString;
    }
}