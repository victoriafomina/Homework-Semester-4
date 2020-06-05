module WebPagesLinks

open System.Net
open System.IO
open System.Threading
open System
open System.Text.RegularExpressions

(*
let sites = ["http://se.math.spbu.ru"; "http://spisok.math.spbu.ru"]
let fetchAsync url =
    async {
        do printfn "Creating request for %s..." url
        let request = WebRequest.Create(url)
        use! response = request.AsyncGetResponse()
        do printfn "Getting response stream for %s..." url
        use stream = response.GetResponseStream()
        do printfn "Reading response for %s..." url
        use reader = new StreamReader(stream)
        let html = reader.ReadToEnd()
        do printfn "Read %d characters for %s..." html.Length url
    }
    sites |> List.map (fun site -> site |> fetchAsync |> Async.Start) |> ignore
 *)

let download (link : string) =
    /// Finds all the links on the page.
    let findsLinks page =
        let regex = new Regex("<a href=\"http[:]{1}[/]{2}(.*?)\">")
        regex.Matches(page) |> Seq.toList
        
    /// Downloads info from the url asynchonously.
    let fetchAsync (url : string) =        
        async {                             
            let request = WebRequest.Create(url)
            use! response = request.AsyncGetResponse();
            use stream = response.GetResponseStream()
            use reader = new StreamReader(stream)
            let html = reader.ReadToEnd()
            printfn "Downloaded from: %s" url
            printfn "Number of symbols: %d" html.Length 
            }

    async {
        
        let regex = new Regex("<a href=\"http[:]{1}[/]{2}(.*?)\">")
        let matches = regex.Matches(html)
        let makeListOfMatches (matches : MatchCollection) =
            let rec makeListOfMatchesRec acc (matches : MatchCollection) list =
                if acc = matches.Count then list
                else
                    makeListOfMatchesRec (acc + 1) matches (matches.[acc].Value :: list)
            makeListOfMatchesRec 0 matches [] 


        makeListOfMatches matches
        |> List.map fetchUrlAsync  // make a list of async tasks
        |> Async.Parallel          // set up the tasks to run in parallel
        |> Async.RunSynchronously
            
            
            (*
            // a list of sites to fetch
            let sites = ["http://www.bing.com";
                         "http://www.google.com";
                         "http://www.microsoft.com";
                         "http://www.amazon.com";
                         "http://www.yahoo.com"]
            
            #time                      // turn interactive timer on
            sites 
            |> List.map fetchUrlAsync  // make a list of async tasks
            |> Async.Parallel          // set up the tasks to run in parallel
            |> Async.RunSynchronously  // start them off
            #time 
            *)
    }