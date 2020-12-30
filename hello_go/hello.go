package main

import (
	"fmt"
	"math/rand"
	"time"
	"net/http"
	"io/ioutil"
)

func main() {
	rand.Seed(time.Now().UnixNano())

	randomCharacterId := getRandomCharacterId()
	sendRequest(randomCharacterId)
}

func sendRequest(characterId int) {
	url := fmt.Sprintf("https://swapi.dev/api/people/%d/", characterId)
	resp, _ := http.Get(url)
	defer resp.Body.Close()

	body, _ := ioutil.ReadAll(resp.Body)
	fmt.Println("Your random Star Wars character:")
	fmt.Println(string(body))
}

func getRandomCharacterId() int {
	return rand.Intn(84) + 1
}
