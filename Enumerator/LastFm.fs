module LastFm

open System.Net
open System.Web
open System.Xml
open System.Xml.Linq

let lastfmcall args =
    let lastfm = "http://ws.audioscrobbler.com/2.0/?" 
    let apikey = "734ed2307a98ea98593e50eb1bc66294"
    let concatUrl = 
        List.map (fun pair -> fst pair + "=" + snd pair) >> 
        List.map HttpUtility.HtmlEncode >> 
        List.reduce (fun agg item -> agg + "&" + item)
    let args = ("api_key", apikey) :: args
    let url = lastfm + concatUrl args
    let client = new WebClient()
    XElement.Parse(client.DownloadString(url))

let trackCorrection title artist = lastfmcall [ ("method","track.getCorrection"); ("artist",artist); ("track",title) ]
let albumInfo album artist = lastfmcall [ ("method","album.getInfo"); ("artist",artist); ("album",album) ]
let albumSearch album = lastfmcall [ ("method","album.search"); ("album",album) ]
let albumTopTags album artist = lastfmcall [ ("method","album.getTopTags"); ("artist",artist); ("album",album) ] 
let artistCorrection artist = lastfmcall [ ("method","artist.getcorrection"); ("artist",artist)]
let artistGetTopTags artist = lastfmcall [ ("method","artist.getTopTags"); ("artist",artist)]


