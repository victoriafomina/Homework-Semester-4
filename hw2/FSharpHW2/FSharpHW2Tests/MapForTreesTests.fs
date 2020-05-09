module MapForTreesTests

open NUnit.Framework
open MapForTrees
open FsUnit

[<Test>]
let ``Test the leaf should return a leaf`` () =
    mapTree Leaf (fun x -> x * x) |> should equal Leaf

[<Test>]
let ``Test one Node should return a Node`` () =
    mapTree (Node(1, Leaf, Leaf)) (fun x -> x * x) |> should equal (Node(1, Leaf, Leaf))

[<Test>]
let ``Test tree should return a tree`` () =
    mapTree (Node(-1, Node(2, Node(-5, Leaf, Leaf), Node(-7, Leaf, Leaf)), Leaf)) (fun x -> abs(x)) |> should equal (Node(1, Node(2, Node(5, Leaf, Leaf), Node(7, Leaf, Leaf)), Leaf))