open CountEvenInList
open InfiniteSequenceOfPrimes
open MapForTrees
open System.Text.RegularExpressions

[<EntryPoint>]
let main argv =
    // printTree (insert Leaf 4) // вывело 4, всё ок
    //printfn "%b" (isInTree(insert (Node (1, Leaf, Leaf)) 3) 1)

    // let myTree = Node(5, Node(2, Leaf, Leaf), Leaf)
    // let sq x = x * x

    // mapTree myTree sq

    printfn "%A" infiniteSeqOfPrimes

    0
