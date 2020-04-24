module TestTests

open NUnit.Framework
open FsUnit
open GreatestPalindrome
open SuperMap

[<Test>]
let ``Greatest palindrome should return 906609`` () =
   greatestPalindrome |> should equal 906609

[<Test>]
let ``SuperMap smoke test`` () =
    (abs(0.841 - (superMap [1.0; 2.0; 3.0]).[0]) < 0.01 |> should equal true)

