module InfiniteSequenceOfPrimesTests

open InfiniteSequenceOfPrimes
open FsUnit
open NUnit.Framework

[<Test>]
let ``Infinite sequence of primes should return 5`` () =
    Seq.item 0 infiniteSeqOfPrimes |> should equal 2

[<Test>]
let ``Infinite sequence of primes should return 3`` () =
    Seq.item 1 infiniteSeqOfPrimes |> should equal 3

[<Test>]
let ``Infinite sequence of primes should return 7`` () =
    Seq.item 3 infiniteSeqOfPrimes |> should equal 7

[<Test>]
let ``Infinite sequence of primes should return 17`` () =
    Seq.item 6 infiniteSeqOfPrimes |> should equal 17

[<Test>]
let ``Infinite sequence of primes should return 9973`` () =
    Seq.item 1228 infiniteSeqOfPrimes |> should equal 9973