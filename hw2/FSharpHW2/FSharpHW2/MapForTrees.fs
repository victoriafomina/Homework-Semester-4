module MapForTrees

type Tree<'a> =
| Node of 'a * Tree<'a> * Tree<'a>
| Leaf

/// <summary>Maps the result of function f to all the nodes of a tree.<\summary>
let rec mapTree tree f = 
    match tree with 
    | Node(v, l, r) -> Node(f v, mapTree l f, mapTree r f)
    | Leaf -> Leaf
