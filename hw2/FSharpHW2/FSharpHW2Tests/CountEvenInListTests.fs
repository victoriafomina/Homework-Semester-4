module CountEvenListTests

open NUnit.Framework
open FsCheck
open CountEvenInList

[<Test>]
let ``The results should be the same`` () = 
    Check.QuickThrowOnFailure (fun l ->
    countEvenInListFilter l = countEvenInListFold l && countEvenInListFold l = countEvenInListMap l)