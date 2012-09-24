(*

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
open System.Web
open System.Xml.Linq

let apikey = "734ed2307a98ea98593e50eb1bc66294"
let secret = "7936c606d26c15548ca92863d2d1b3a3"


let lastfm = "http://ws.audioscrobbler.com/2.0/?" 

let concatUrl x = 
    x 
    |> List.map (fun pair -> fst pair + "=" + snd pair) 
    |> List.map HttpUtility.HtmlEncode
    |> List.reduce (fun agg item -> agg + "&" + item)
    
let lastfmcall args =
    let args = ("api_key", apikey) :: args
    let url = lastfm + concatUrl args
    let client = new WebClient()
    XElement.Parse(client.DownloadString(url))

let test = lastfmcall [("method","artist.getcorrection"); ("artist","Yoko Kanno")]
