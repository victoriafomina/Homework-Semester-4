module WebPages

open System.Net
open System.IO
open System.Text.RegularExpressions

/// Downloads all the contens the link links.
let download (link : string) =
    /// Converts list of matches to list of lists.
    let makeListOfLists (matches : MatchCollection) =
        let rec makeListOfMatchesRec acc (matches : MatchCollection) list =
            if acc = matches.Count then list
            else
                makeListOfMatchesRec (acc + 1) matches (matches.[acc].Value :: list)
        makeListOfMatchesRec 0 matches [] 

    /// Finds all the links on the page.
    let findLinks page =
        let regex = new Regex("<a href=\"http[:]{1}[/]{2}(.*?)\">")
        regex.Matches(page) |> makeListOfLists
        
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
            return html
            }
    
    /// Downloads the content from the links parallel.
    (link |> fetchAsync).ToString() 
    |> findLinks 
    |> List.map fetchAsync |> Async.Parallel |> Async.RunSynchronously |> Seq.toList