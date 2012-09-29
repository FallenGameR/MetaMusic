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

let test = lastfmcall [ ("method","artist.getcorrection"); ("artist","Yoko Kanno")]

//---------------------
// Исправить метаданные
// Исправить структуру файлов
// Дополнить лирикой и текстами
//-----------------------------


// Берем директорию с музыкальными файлами
// Перечисляем все mp3
// Из тегов достаем альбом, артиста, имя песни
// Через last fm убеждаемся, что верны: имя песни, альбома, артиста, номер дорожки, год, жанр, Затереть: (номер диска, имя исполнителя) в комментарий ссылка на last fm
// Альбом внутри папки должен быть один, если нет ошибка
// Пишем в Id3 тег, затираем все остальные.


// track.getCorrection исправляет песню (и артиста)
// album.getTags/album.getTopTags жанр для альбома (и артиста)
// album.getInfo получить треки из альбома
// album.search ищет альбом по имени





//let test2 = lastfmcall2 "artist.getcorrection", "artist", "Yoko Kanno"
(*
let original = ["artist.getcorrection"; "artist"; "Yoko Kanno"]
let result = 
    "method" :: original
    |> List.mapi (fun i x -> (i, x))
    |> List.fold (fun agg item -> agg + "&" + snd item) ""

//fold : ('State -> 'T -> 'State) -> 'State -> 'T list -> 'State
//needed : ('State -> 'T -> 'State) -> 'T list -> 'State

partition + zip

//d:\Music\Flesh Field\2004 - Strain\01 Uprising.mp3

*)