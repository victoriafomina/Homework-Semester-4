module EvenFibonacciTests

open EvenFibonacci
open FsUnit
open NUnit.Framework

let checkSumEvenFibonacci () =
    let fibonacci n =
        let rec fibonacciRec n prev prevPrev count =
            if n = 1 || n = 2 then 1
            elif n = count then prev + prevPrev
            else fibonacciRec n (prev + prevPrev) prev (count + 1)
        fibonacciRec n 1 1 3 

    let mutable i = 1
    let mutable sum = 0

    while (fibonacci i) < 1000000 do  
        if (fibonacci i) % 2 = 0 then
            sum <- sum + fibonacci i
        i <- i + 1
    sum

[<Test>]
let ``Sum of even fibonacci lower than 1 000 000 test`` () =
    evenFibonacci () |> should equal (checkSumEvenFibonacci ())

