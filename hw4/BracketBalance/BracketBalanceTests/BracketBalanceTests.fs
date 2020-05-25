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
        ")", false
        "))", false
        "nagibator666", true
        "meow)", false
        "o(o)i{s}", true
        "olo({ol}s)", true
        "!", true
    ] |> List.map (fun (expression, isBalanced) -> TestCaseData(expression, isBalanced))

[<Test>]
[<TestCaseSource("testCases")>]
let ``Checks if brackets are balanced`` expression isBalanced =
    bracketsAreInBalance expression |> should equal isBalanced