package views

import (
	"log"
	"net/http"
	"os"

	"../utils"
)

// PostHandler .
func PostHandler(w http.ResponseWriter, r *http.Request) {
	log.Printf("query:%s\n", r.URL.RawQuery)

	r.ParseForm()

	log.Printf("param:%s\n", r.Form["q"][0])

	conf := utils.GetConfInstance()

	wFile, err := os.OpenFile(conf.Prof.WatchFile, os.O_WRONLY|os.O_APPEND|os.O_CREATE, 0666)
	if err != nil {
		log.Fatal(err)
	}
	defer wFile.Close()

	wFile.Write([]byte(r.Form["q"][0] + "\n"))
}
