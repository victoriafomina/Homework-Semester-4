module Menu

open System
open PhonebookLogic

let menu =
    let name = Console.ReadLine()

    let number = Console.ReadLine()

    let rec menuRec store currentData =
        printfn "%s" "1 - exit"
        printfn "%s" "2 - add note (name and number)"
        printfn "%s" "3 - find number by name"
        printfn "%s" "4 - find name by number"
        printfn "%s" "5 - print the database"
        printfn "%s" "6 - save current data to the file"
        printfn "%s" "7 - read data from file"
        
        match Console.ReadLine() with
        | "1" -> 0
        | "2" ->
            printfn "%s" "Input name"
            printfn "%s" "Input number"
            menuRec store (addNote name number :: currentData)
        | "3" -> 
            printfn "%s" "Input name"

            if store <> [] then
                printfn "%s" "Input name"
                match findNumberByName name store :: currentData with
                | None -> printfn "%s" "Subscriber with that name does not exists"
                | Some(number) -> printf "%s" name printfn "%s" number
            else
        
        
    menuRec true