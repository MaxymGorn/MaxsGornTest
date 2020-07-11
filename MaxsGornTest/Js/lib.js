URL = window.URL || window.webkitURL;
var gumStream;
var rec;
var input;
var AudioContext = window.AudioContext || window.webkitAudioContext;
var audioContext
class Controler {
    construct() {

    }
    startRecording() {
        var constraints = {
            audio: true,
            video: false
        }
        recordButton.disabled = true;
        stopButton.disabled = false;
        navigator.mediaDevices.getUserMedia(constraints).then(function (stream) {
            audioContext = new AudioContext();
            gumStream = stream;
            input = audioContext.createMediaStreamSource(stream);
            rec = new Recorder(input, {
                numChannels: 1
            })
            rec.record();
            var myDate = new Date(1000 * Date.now());
            document.getElementById("date").innerHTML = myDate.toString().toString();
            myVar = setInterval(myTimer, 100);


        }).catch(function (err) {
            recordButton.disabled = false;
            stopButton.disabled = true;
        });
    }
    stopRecording() {
        stopButton.disabled = true;
        recordButton.disabled = false;
        myStopFunction();
        rec.stop();
        gumStream.getAudioTracks()[0].stop();
        var url = null;
        rec.exportWAV(function (blob) {
            url = URL.createObjectURL(blob);
            console.log(url);
            document.getElementById("value_url").setAttribute("name", url.toString());
        });
   
    }
    
}
