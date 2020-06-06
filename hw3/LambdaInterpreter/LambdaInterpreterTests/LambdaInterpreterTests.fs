module LambdaInterpreterTests

open NUnit.Framework
open LambdaInterpreter
open FsUnit

let testCases =
    [
        Applic(Abstr('x', Variable('x')), Variable('y')), Variable('y')
        Variable('x'), Variable('x')
        Applic(Abstr('x', Variable('x')), Variable('y')), Variable('y')
        Applic(Variable('x'), Variable('y')), Applic(Variable('x'), Variable('y'))
        Abstr('x', Applic(Abstr('y', Variable('y')), Variable('x'))), Abstr('x', Variable('x'))
    ] |> List.map (fun (exp, res) -> TestCaseData(exp, res))

[<Test>]
[<TestCaseSource("testCases")>]
let ``Beta reduction works correctly tests`` exp res =
    betaReduction exp |> should equal res