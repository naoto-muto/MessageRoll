package views

import (
	"net/http"
	"text/template"
)

// StartHandler .
func StartHandler(w http.ResponseWriter, r *http.Request) {
	tmpl, err := template.ParseFiles("contents/template/start.html")
	if err != nil {
		panic(err)
	}

	err = tmpl.Execute(w, nil)
	if err != nil {
		panic(err)
	}
}
