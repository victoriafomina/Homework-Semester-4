module ParseTreeTests

open NUnit.Framework
open FsUnit
open ParseTree
open System

[<Test>] 
let ``Smoke test`` () =
    calculate(Add(Number(1), Number(2))) |> should equal 3

[<Test>]
let ``Calculate 1 + 2 * 3 should return 7`` () =
    calculate(Add(Number(1), Multiply(Number(2), Number(3)))) |> should equal 7

[<Test>]
let ``2 / (0 - 1) + 7 should return 5`` () =
    calculate(Add(Divide(Number(2), Subtract(Number(0), Number(1))), Number(7))) |> should equal 5

[<Test>]
let ``Calculate 5 / 0 should throw an exception`` () =
    (fun() -> calculate(Divide(Number(5), Number(0))) |> ignore) |> should throw typeof<Exception>