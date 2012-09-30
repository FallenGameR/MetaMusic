module Mp3

open System.IO

let year (track: string) = TagLib.File.Create(track).Tag.Year
let albumArtists (track: string) = TagLib.File.Create(track).Tag.AlbumArtists
let album (track: string) = TagLib.File.Create(track).Tag.Album
let track (track: string) = TagLib.File.Create(track).Tag.Track
let genres (track: string) = TagLib.File.Create(track).Tag.Genres
let title (track: string) = TagLib.File.Create(track).Tag.Title


