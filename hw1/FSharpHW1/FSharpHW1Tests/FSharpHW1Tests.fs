module FSharpHW1Tests

open NUnit.Framework
open FsUnit
open Functions

[<Test>]
let ``Factorial of 1 should return Some(1)`` () =
   fact 1 |> should equal (Some 1)

[<Test>]
let ``Factorial of negative number should return None`` () =
    fact -2 |> should equal None

[<Test>]
let ``Factorial of 5 should return Some(120)`` () =
    fact 5 |> should equal (Some 120)

[<Test>]
let ``Fibonacci of negative number should return None`` () =
    fibonacci -5 |> should equal None

[<Test>]
let ``Fibonacci of 1 should return Some(1)`` () =
    fibonacci 1 |> should equal (Some 1)

[<Test>]
let ``Fibonacci of 5 should return Some(8)`` () =
    fibonacci 6 |> should equal (Some 8)

[<Test>]
let ``ReverseList of [] should return []`` () =
    reverseList [] |> should equal []

[<Test>]
let ``ReverseList of [1; 2; 3; 1; 5] should return [5; 1; 3; 2; 1]`` () =
    reverseList [1; 2; 3; 1; 5] |> should equal [5; 1; 3; 2; 1]

[<Test>]
let ``ListPowers of negative m or n parameters should return None`` () =
    listPowers -2 5 |> should equal None

[<Test>]
let ``ListPowers when second parameter is lower than first should return None`` () =
    listPowers 5 3 |> should equal None

[<Test>]
let ``ListPowers of 2 and 5 should return [4; 8; 16; 32]`` () =
    listPowers 2 5 |> should equal (Some [4; 8; 16; 32])

[<Test>]
let ``FirstPos of [] should return None`` () =
    firstPos [] 1 |> should equal None

[<Test>]
let ``FirstPos of [3; 5; -1; 2; -1] and -1 should return 2`` () =
    firstPos [3; 5; -1; 2; -1] -1 |> should equal (Some 2)