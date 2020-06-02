module PhonebookLogic

open System.IO
open Microsoft.FSharp.Core.Operators

(*
Написать программу - телефонный справочник. Она должна уметь хранить имена и номера 
телефонов, в интерактивном режиме осуществлять следующие операции:
1. выйти
2. добавить запись (имя и телефон)
3. найти телефон по имени
4. найти имя по телефону
5. вывести всё текущее содержимое базы
6. сохранить текущие данные в файл
7. считать данные из файла
*)

/// Reads the notes from file.
let readInfoFromFile (fileName : string) =
    let spaceIndex = Seq.findIndex(fun x -> x = ' ')
    
    let splitIntoListOfStrings (str : string) = [str.[..spaceIndex str]; str.[((spaceIndex str) + 1)..]]

    let parse arrStr =
        let rec parseRec arrStr store =
            match arrStr with
            | [] -> store
            | h :: t -> parseRec t (splitIntoListOfStrings h :: store)
        parseRec arrStr []

    try
        fileName |> File.ReadAllLines |> Array.toList |> parse
    with | _ -> failwith "File was not opened or was not handled!"

/// Saves the current data to the file.
let saveCurrentData (fileName : string) data =
    let parse listListStr = 
        let rec parseRec listListStr listStr =
            match listListStr with
            | [] -> listStr
            | h :: t -> parseRec t ((List.head h + " " + List.last h) :: listStr)
        parseRec listListStr []
                
    try
        File.AppendAllLines(fileName, parse data)
    with | _ -> failwith "File was not opened or was not handled!"

/// Add note (name and number).
let addNote name number = [name; number]

/// Prints the database.
let printDatabase store =
    let printList x =
        printf "%s%s" (List.head x) ""  
        printfn "%s" (List.last x)

    List.iter (fun x -> printList x) store

/// Checks if the name exists.
let nameExists name store =
    List.exists (fun x -> List.head x = name) store

/// Checks if the number exists.
let numberExists number store =
    List.exists (fun x -> List.last x = number) store

/// Finds a number by the name.
let findNumberByName name store =
    if nameExists name store then Some(List.find (fun x -> List.head x = name) store |> List.head)
    else None

/// Finds a name by the number.
let findNameByNumber number store =
    if numberExists number store then Some(List.find (fun x -> List.last x = number) store |> List.last)
    else None