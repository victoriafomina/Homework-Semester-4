module BracketBalanceTests

open NUnit.Framework
open BracketBalance
open FsUnit

let testCases =
    [
        "", true
        "()", true
        "[]", true
        "{}", true
        "(]", false
        "((", false
        "(())", true
        "(([))", false
        "{()[]}", true
    ] |> List.map (fun (expression, isBalanced) -> TestCaseData(expression, isBalanced))

[<Test>]
[<TestCaseSource("testCases")>]
let ``Checks if brackets are balanced`` expression isBalanced =
    bracketsIsInBalance expression |> should equal isBalanced