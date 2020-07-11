URL = window.URL || window.webkitURL;
var gumStream;
var rec;
var input;
var myDate;
var AudioContext = window.AudioContext || window.webkitAudioContext;
var audioContext
class Controler {
    construct() {
        $('.microphone').attr("src", "https://fileswaw.blob.core.windows.net/webappstoragedotnet-imagecontainer/ezgif.com-resize.png");
    }
    startRecording() {
        var constraints = {
            audio: true,
            video: false
        }
        $('.microphone').attr("src", "https://fileswaw.blob.core.windows.net/webappstoragedotnet-imagecontainer/microphone (1) (2).gif");
        navigator.mediaDevices.getUserMedia(constraints).then(function (stream) {
            audioContext = new AudioContext();
            gumStream = stream;
            input = audioContext.createMediaStreamSource(stream);
            rec = new Recorder(input, {
                numChannels: 1
            })
            rec.record();
            myDate = new Date();
            var options = { weekday: 'long', year: 'numeric', month: 'long', day: 'numeric' };
            options.timeZone = 'UTC';
            options.timeZoneName = 'short';
            document.getElementById("date").innerHTML = myDate.toLocaleDateString('en-US', options);
            myStopFunction();
            myVar = setInterval(myTimer, 1000);
        }).catch(function (err) {
            alert(err);
        });
    }
            
    stopRecording() {
        try {
            $('.microphone').attr("src", "https://fileswaw.blob.core.windows.net/webappstoragedotnet-imagecontainer/ezgif.com-resize.png");
            rec.stop();
            stopButton.disabled = true;
            recordButton.disabled = false;
            myStopFunction();
            gumStream.getAudioTracks()[0].stop();
        }
        catch (e) {
           
        }
    }

    async exportRec() {
        rec.exportWAV(function (blob) {
            var formData = new FormData();
            var fileName = "blobtest" + ".wav";
            var encodeData = new Blob([blob], { type: 'audio/wav"' });
            formData.append("blob", encodeData, fileName);
            formData.append("dateStart", myDate.toString());
            formData.append("duration", totalSeconds.toString());
            console.log("Start ajax!");
            $.ajax({
                type: "POST",
                url: "/Home/Upload",
                data: formData,
                processData: false,
                contentType: false,
                success: function (result, status, xhr) {
                   
                },
                error: function (xhr, status, error) {
                    alert("Save in Db and Azure Storage!");
                }
            });
        });
    }
}
