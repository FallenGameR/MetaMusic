﻿(*

Чего хочу - музыкальную коллекцию со следующей структурой:

Исполнитель
    год - Альбом
        # - Имя песни.mp3
        # - Имя gtcyb.txt
        Front.jpg
        Back.jpg

Теги все обновленные и верные.
Верность определяется last.fm

-----------

Что есть - куча файлов рассортированных по разному. Теги не всегда правильные.
Сначала нужно починить все теги.
- освоить last.fm API
- освоить бибилеотеку, работающую с mp3
- вручную сверять с last.fm долго

Нет цели написать сложную F# программу. Скриптинг допустим.

-----------

01 Проверить правильность имени для Garbage.
- пройти аутентификацию на last.fm http://www.last.fm/api/desktopauth
- узнать имя исполнителя http://www.last.fm/api/show/artist.getCorrection

*)



open System.Net
open System.Xml.Linq

let apikey = "734ed2307a98ea98593e50eb1bc66294"
let secret = "7936c606d26c15548ca92863d2d1b3a3"
let lastfm = "http://ws.audioscrobbler.com/2.0/?" 
//method=auth.gettoken&api_key=b25b959554ed76058ac220b7b2e0a026"

let lastfmcall apimethod =
    let url = lastfm + "method=" + apimethod + "&api_key=" + apikey
    let client = new WebClient()
    XElement.Parse(client.DownloadString(url))

let token = (lastfmcall "auth.getToken").Value
