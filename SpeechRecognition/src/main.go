// 実行前にchromedriverのパスを通すように

package main

import (
	"log"
	"net"
	"net/http"
	"os"
	"os/exec"
	"strconv"

	"./utils"
	"./views"
)

func postHandler(w http.ResponseWriter, r *http.Request) {
	log.Printf("query:%s\n", r.URL.RawQuery)

	r.ParseForm()

	log.Printf("param:%s\n", r.Form["q"][0])
}

func main() {

	log.SetOutput(os.Stdout)
	log.SetFlags(0)

	log.Println("start")

	v := utils.GetConfInstance()

	chromePath := v.Prof.Chrome

	listener, err := net.Listen("tcp", ":0")

	if err != nil {
		log.Fatal(err)
	}

	http.Handle("/script/", http.FileServer(http.Dir("./contents/resources/")))

	http.HandleFunc("/post", views.PostHandler)
	http.HandleFunc("/start", views.StartHandler)
	http.HandleFunc("/", views.HomeHandler)

	port := listener.Addr().(*net.TCPAddr).Port

	log.Printf("open port:%d\n", port)

	// TODO
	messages := make(chan string)
	go func() {
		err = http.Serve(listener, nil)

		if err != nil {
			log.Println(err)
			messages <- "err"
			return
		}
		messages <- "end"
	}()

	cmd := exec.Command(chromePath, "--disable-extensions", "--incognito", "http://localhost:"+strconv.Itoa(port)+"/")
	cmd.Start()
	log.Println("running")
	cmd.Wait()

	msg := <-messages
	log.Println(msg)
}
