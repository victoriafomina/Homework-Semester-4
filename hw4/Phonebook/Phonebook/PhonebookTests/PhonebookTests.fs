module PhonebookTests

open NUnit.Framework
open PhonebookLogic
open FsUnit

let testCases1 =
    [
        "lol", "123"
        "abcd", "5555"
        "a", "0"
    ] |> List.map (fun (name, number) -> TestCaseData(name, number))

[<Test>]
[<TestCaseSource("testCases1")>]
let ``Find name by number tests`` name number =
    findNameByNumber number (addNote name number :: (addNote "ololo" "777")) |> should equal name

[<Test>]
[<TestCaseSource("testCases1")>]
let ``Find number by name tests`` name number =
    findNumberByName name (addNote name number :: (addNote "ololo" "777")) |> should equal number