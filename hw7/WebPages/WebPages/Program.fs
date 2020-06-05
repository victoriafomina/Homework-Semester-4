open WebPages

[<EntryPoint>]
let main argv =

    
    let lists = download "https://www.linkedin.com/"

    for list in lists do
        printfn "%A" list

    0 // return an integer exit code
