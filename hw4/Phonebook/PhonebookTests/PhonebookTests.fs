module PhonebookTests

open Microsoft.FSharp.Core.Operators
open NUnit.Framework
open PhonebookLogic
open FsUnit
open System.IO

let testCases1 =
    [
        "lol", "123"
        "abcd", "5555"
        "a", "0"
        "ajaja", "1010"
        "aoaoa", "23451"
    ] |> List.map (fun (name, number) -> TestCaseData(name, number))

let testCases2 =
    [
        "lol", "123", "..//..//Test.txt"
        "abcd", "5555", "..//..//Test.txt"
        "a", "0", "..//..//Test.txt"
    ] |> List.map (fun (name, number, filename) -> TestCaseData(name, number, filename))

[<Test>]
[<TestCaseSource("testCases1")>]
let ``Find name by number when number exists tests`` name number =
    findNameByNumber number (addNote name number :: (addNote "ololo" "777") :: []) |> should equal (Some(name))

[<Test>]
[<TestCaseSource("testCases1")>]
let ``Find name by number when number does not exist tests`` name number =
    findNameByNumber "1234567889" (addNote name number :: (addNote "ololo" "777") :: []) |> should equal None

[<Test>]
[<TestCaseSource("testCases1")>]
let ``Find number by name when name exists tests`` name number =
    findNumberByName name (addNote name number :: (addNote "ololo" "777") :: []) |> should equal (Some(number))

[<Test>]
[<TestCaseSource("testCases1")>]
let ``Find number by name when name does not exist tests`` name number =
    findNumberByName "eve" (addNote name number :: (addNote "ololo" "777") :: []) |> should equal None

[<Test>]
[<TestCaseSource("testCases1")>]
let ``Add note tests`` name number = addNote name number |> should equal [name; number]

[<Test>]
[<TestCaseSource("testCases2")>]
let ``Save to file and read from file tests 1`` name number filename =
     saveCurrentData filename ((addNote name number) :: []) 
     nameExists name (readInfoFromFile filename) |> should equal true

[<Test>]
[<TestCaseSource("testCases2")>]
let ``Save to file and read from file tests 2`` name number filename =
     saveCurrentData filename ((addNote name number) :: []) 
     numberExists number (readInfoFromFile filename) |> should equal true