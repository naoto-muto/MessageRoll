package utils

import (
	"io/ioutil"
	"log"

	yaml "gopkg.in/yaml.v2"
)

// Conf .
type Conf struct {
	Prof Profile `yaml:"profile"`
}

// Profile .
type Profile struct {
	Chrome    string `yaml:"chrome"`
	WatchFile string `yaml:"watchfile"`
}

var confInstance = newConf()

func newConf() *Conf {
	buf, err := ioutil.ReadFile("./conf/conf.yaml")
	if err != nil {
		log.Fatal(err)
	}

	var v Conf
	err = yaml.Unmarshal(buf, &v)
	if err != nil {
		log.Fatal(err)
	}

	return &v
}

// GetConfInstance .
func GetConfInstance() *Conf {
	return confInstance
}
