module PointFreeTests

open NUnit.Framework
open PointFree
open FsCheck

[<Test>]
let ``The results should be the same`` () = 
    Check.QuickThrowOnFailure (fun x l ->
    multiply1 x l = multiply2 x l && multiply2 x l = multiply3 x l && multiply3 x l = multiplyPointFree x l)
