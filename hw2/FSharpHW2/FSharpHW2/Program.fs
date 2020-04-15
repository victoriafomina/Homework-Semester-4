open CountEvenInList
open InfiniteSequenceOfPrimes
open MapForTrees
open System.Text.RegularExpressions

[<EntryPoint>]
let main argv =
    // printTree (insert Leaf 4) // вывело 4, всё ок
    printfn "%b" (isInTree(insert (Node (1, Leaf, Leaf)) 3) 1)

    mapTree (insert (Node (1, Leaf, Leaf)) 3) fun x -> x * x

    0
