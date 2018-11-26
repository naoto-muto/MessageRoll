var result = function(a) {
    document.getElementById("result").textContent = a;
}

var changeState = function(a){
    document.getElementById("evt").textContent = a;
}

var state = true;
var recognizing = false;

var toggleStateButton = function() {
    if(state) {
        document.getElementById("state").value = "停止中";
        rec.stop();
    } else {
        document.getElementById("state").value = "録音中";
        if(!recognizing) {
            rec.start();
        }
    }
    state = !state;
}

var rec = new webkitSpeechRecognition();
rec.continuous = false;
rec.interimResults = false;
rec.lang = "ja-JP";

var xhr = new XMLHttpRequest();
xhr.onreadystatechange = function() {
    if(xhr.readyState == 4) {
        console.log("status : " + xhr.status);
    }
}

rec.onresult = function(event) {
    console.log("onresult");
    changeState("onresult");

    if(event.results.length > 0) {
        console.log("length:"+event.results.length);
        var txt = event.results[0][0].transcript;
        console.log("transcript:"+txt);

        result(txt);

        xhr.open("GET", "/post?q=" + encodeURIComponent(txt));
        xhr.send();
    }

    rec.stop();
}

rec.onstart = function() {
    console.log("onstart");
    changeState("onstart");
    recognizing = true;
};

rec.onend = function() {
    console.log("onend");
    changeState("onend(停止)");
    if(state) {
        rec.start();
    } else {
        recognizing = false;
    }
};

rec.onerror = function (event) {
    console.log("onerror");
    changeState("onerror");
    recognizing = false;
};

rec.onspeechstart = function() {
    console.log("onspeechstart");
    changeState("onspeechstart(音声入力中)");
};

rec.onspeechend = function() {
    console.log("onspeechend");
    changeState("onspeechend");
};

rec.onosundstart = function() {
    console.log("onosundstart");
    changeState("onosundstart");
};

rec.onsoundend = function() {
    console.log("onsoundend");
    changeState("onsoundend");
};

rec.onaudiostart = function() {
    console.log("onaudiostart");
    changeState("onaudiostart(準備完了)");
};

rec.onaudioend = function() {
    console.log("onaudioend");
    changeState("onaudioend");
};

rec.start();
recognizing = true;