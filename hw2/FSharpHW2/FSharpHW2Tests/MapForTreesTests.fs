module MapForTreesTests

open NUnit.Framework
open MapForTrees
open FsUnit

let testCases =
    [
        (Node(3, Node(1, Leaf, Leaf), Leaf)), (Node(9, Node(1, Leaf, Leaf), Leaf))
        Leaf, Leaf
        (Node(7, Node(9, Leaf, Leaf), Node(3, Leaf, Leaf))), (Node(49, Node(81, Leaf, Leaf), Node(9, Leaf, Leaf)))
    ] |> List.map (fun (tree, newTree) -> TestCaseData(tree, newTree))

[<Test>]
[<TestCaseSource("testCases")>]
let ``Test map for tree many tests`` tree newTree = 
    mapTree tree (fun x -> x * x) |> should equal newTree