module InfiniteSequenceOfPrimesTests

open InfiniteSequenceOfPrimes
open FsUnit
open NUnit.Framework

[<Test>]
let ``Infinite sequence of primes should return 0`` () =
    Seq.findIndex(fun x -> x = 2) infiniteSeqOfPrimes |> should equal 0

[<Test>]
let ``Infinite sequence of primes should return 1`` () =
    Seq.findIndex(fun x -> x = 3) infiniteSeqOfPrimes |> should equal 1

[<Test>]
let ``Infinite sequence of primes should return 3`` () =
    Seq.findIndex(fun x -> x = 7) infiniteSeqOfPrimes |> should equal 3

[<Test>]
let ``Infinite sequence of primes should return 6`` () =
    Seq.findIndex(fun x -> x = 17) infiniteSeqOfPrimes |> should equal 6

[<Test>]
let ``Infinite sequence of primes should return 1128`` () =
    Seq.findIndex(fun x -> x = 9973) infiniteSeqOfPrimes |> should equal 1228