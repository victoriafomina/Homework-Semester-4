module CalculateStringsTests

open NUnit.Framework
open CalculateStrings
open FsUnit

let testCase1 =
    [
        "1", "2", "3"
        "2", "1", "3"
        "123", "0", "123"
        "0", "753", "753"
        "ú", "2", "None"
        "b", "0", "None"
        "c", "12a", "None"
        "123r", "17", "None"
        "154", "307", "461"
    ] |> List.map (fun (op1, op2, result) -> TestCaseData(op1, op2, result))

let testCase2 =
    [
        "1", "2", "-1"
        "2", "1", "1"
        "123", "0", "123"
        "0", "753", "-753"
        "ú", "2", "None"
        "b", "0", "None"
        "c", "12a", "None"
        "123r", "17", "None"
        "154", "307", "-153"
    ] |> List.map (fun (op1, op2, result) -> TestCaseData(op1, op2, result))

let testCase3 =
    [
        "1", "2", "0"
        "2", "1", "2"
        "123", "1", "123"
        "0", "753", "0"
        "ú", "2", "None"
        "b", "0", "None"
        "c", "12a", "None"
        "123r", "17", "None"
        "150", "10", "15"
    ] |> List.map (fun (op1, op2, result) -> TestCaseData(op1, op2, result))

let testCase4 =
    [
        "1", "2", "2"
        "2", "1", "2"
        "123", "2", "246"
        "0", "753", "0"
        "ú", "2", "None"
        "b", "0", "None"
        "c", "12a", "None"
        "123r", "17", "None"
        "150", "10", "1500"
    ] |> List.map (fun (op1, op2, result) -> TestCaseData(op1, op2, result))

let calculate = new CalculateBuilder()

let calcRes f op1 op2 = calculate {
    let! x = op1
    let! y = op2
    let z = f x y
    return z
}

[<Test>]
[<TestCaseSource("testCase1")>]
let ``Tests adds correctly`` op1 op2 result =
    calcRes (+) op1 op2 |> should equal result

[<Test>]
[<TestCaseSource("testCase2")>]
let ``Tests subtracts correctly`` op1 op2 result =
    calcRes (-) op1 op2 |> should equal result

[<Test>]
[<TestCaseSource("testCase3")>]
let ``Tests divides correctly`` op1 op2 result =
    calcRes (/) op1 op2 |> should equal result

[<Test>]
[<TestCaseSource("testCase4")>]
let ``Tests mutiplies correctly`` op1 op2 result =
    calcRes (*) op1 op2 |> should equal result    
