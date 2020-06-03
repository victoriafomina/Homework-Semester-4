module WorkflowRoundTests

open NUnit.Framework
open Rounding
open FsUnit

let testCaseData1 =
    [
        2.0, 12.0, 3.5, 3, 0.048
        2.0, 12.0, 3.5, 2, 0.05
        1.0, 1.0, 1.0, 1, 1.0
        1.0, 3.0, 1.0, 1, 0.3
        1.0, 3.0, 1.0, 2, 0.33
    ] |> List.map (fun (op1, op2, op3, roundTo, result) -> TestCaseData(op1, op2, op3, roundTo, result))

let rounding roundTo = new RoundBuilder(roundTo)

let calcRound op1 op2 op3 round =
    rounding round {
        let! a = op1 / op2
        let! b = op3
        return a / b
    }

[<Test>]
[<TestCaseSource("testCaseData1")>]
let ``Rounding works correctly tests`` op1 op2 op3 roundTo result =
    calcRound op1 op2 op3 roundTo |> should equal result
    