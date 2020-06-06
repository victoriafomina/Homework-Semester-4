module Menu

open System
open PhonebookLogic

/// Implements user interface of Phonebook.
let menu =

    let rec menuRec dataFromFile dataNotSavedToFileYet =
        printfn "%s" "1 - exit"
        printfn "%s" "2 - add note (name and number)"
        printfn "%s" "3 - find number by name"
        printfn "%s" "4 - find name by number"
        printfn "%s" "5 - print the database"
        printfn "%s" "6 - save current data to the file"
        printfn "%s" "7 - read data from file\n"
        
        match Console.ReadLine() with
        | "1" -> ()
        | "2" ->
            printfn "%s" "Input name and number"
            menuRec dataFromFile ((addNote (Console.ReadLine()) (Console.ReadLine())) :: dataNotSavedToFileYet)
        | "3" ->
            if dataFromFile @ dataNotSavedToFileYet <> [] then
                printfn "%s" "Input name" 
                let name = Console.ReadLine()
                match findNumberByName name (dataFromFile @ dataNotSavedToFileYet) with
                | None -> 
                    printfn "%s" "Subscriber with that name does not exists\n"
                    menuRec dataFromFile dataNotSavedToFileYet

                | Some(number) -> 
                    printf "%A%s" name " " 
                    printfn "%A%s" number "\n"
                    menuRec dataFromFile dataNotSavedToFileYet
            else
                printfn "%s" "The database is empty"
                menuRec dataFromFile dataNotSavedToFileYet
        | "4" ->
            if not dataFromFile.IsEmpty then
                printfn "%s" "Input number"
                let number = Console.ReadLine()
                match findNameByNumber number (dataFromFile @ dataNotSavedToFileYet) with
                | None -> 
                    printfn "%s" "Subscriber with that number does not exists"
                | Some(name) -> 
                    printf "%A%s" name " "
                    printfn "%A%s" number "\n"
            else
                printfn "%s" "The database is empty"
            menuRec dataFromFile dataNotSavedToFileYet
        | "5" -> 
            printDatabase (dataFromFile @ dataNotSavedToFileYet)
            menuRec dataFromFile dataNotSavedToFileYet
        | "6" ->
            printfn "%s" "Input the name of the file"
            saveCurrentData ("..//..//..//" + Console.ReadLine()) dataNotSavedToFileYet
            printfn "%s" "\n"
            menuRec dataFromFile []
        | "7" ->
            printfn "%s" "Input the name of the file"
            menuRec (readInfoFromFile ("..//..//..//" + Console.ReadLine())) dataNotSavedToFileYet
        | _ -> 
            printfn "%s" "Incorrect input\n"
            menuRec dataFromFile dataNotSavedToFileYet
        
    menuRec [] []