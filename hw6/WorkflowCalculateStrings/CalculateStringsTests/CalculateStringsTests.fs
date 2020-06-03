module CalculateStringsTests

open NUnit.Framework

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

[<Test>]
[<TestCaseSource("testCase1")>]
let ``Tests adds correctly`` op1 op2 result =
    
