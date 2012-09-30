(*

Что хочу - получить музыкальную коллекцию со следующей структурой:

Исполнитель
    год - Альбом
        No# - Имя песни.mp3
        No# - Имя песни.txt
        Front.jpg
        Back.jpg
        missing.txt

Теги все обновленные и верные.
Верность определяется по last.fm.

-----------

На высоком уровне:
- Исправить метаданные
- Исправить структуру файлов
- Дополнить лирикой и текстами

--------------

FSI initialization:
#I @"d:\Archive\Projects\MetaMusic\Libraries\taglib-sharp-2.1.0.0-windows\Libraries\"
#I @"d:\Archive\Projects\MetaMusic\Enumerator\"
#r "taglib-sharp.dll"
#r "policy.2.0.taglib-sharp.dll"
#r "system.xml.linq.dll"
#load "Mp3.fs"
#load "LastFm.fs"

*)



let track = @"d:\Music\Garbage\2005 - Bleed Like Me\01 - Bad Boyfriend .mp3"

printfn "Track: %s" track
printfn "-------------------------"
printfn "-=[Mp3]=-"
printfn "Track - %d" (Mp3.track track)
printfn "Title - %s" (Mp3.title track)
printfn "Artist - %A" (Mp3.albumArtists track)
printfn "Album - %s" (Mp3.album track)
printfn "Year - %d" (Mp3.year track)
printfn "Genre - %A" (Mp3.genres track)
printfn "-------------------------"
printfn "-=[Last.fm]=-"

let test = LastFm.trackCorrection (Mp3.title track) ((Mp3.albumArtists track).[0])


//-----------------------------
// Берем директорию с музыкальными файлами
// Перечисляем все mp3
// Из тегов достаем альбом, артиста, имя песни
// Через last fm убеждаемся, что верны: имя песни, альбома, артиста, номер дорожки, год, жанр, Затереть: (номер диска, имя исполнителя) в комментарий ссылка на last fm
// Альбом внутри папки должен быть один, если нет ошибка
// Пишем в Id3 тег, затираем все остальные.
//let files = Directory.EnumerateFiles(folder, "*.mp3")

(*
trackCorrection
---------------

Если коррекции нет правильны, возвращается:

<lfm status="ok">
  <corrections></corrections>
</lfm>

Иначе:

<lfm status="ok">
  <corrections>
    <correction index="0" artistcorrected="1" trackcorrected="0">
      <track>
        <name>Bleed Like Me</name>
        <mbid>0c6bb349-4bb9-4764-9008-caa6f03f2224</mbid>
        <url>www.last.fm/music/Garbage/_/Bleed+Like+Me</url>
        <artist>
          <name>Garbage</name>
          <mbid>ccc700c7-a178-4692-a912-dd581bf54d11</mbid>
          <url>http://www.last.fm/music/Garbage</url>
        </artist>
      </track>
    </correction>
  </corrections>
</lfm>

*)