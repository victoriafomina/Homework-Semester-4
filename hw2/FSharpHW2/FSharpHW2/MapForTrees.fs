module MapForTrees

type Tree<'a> =
| Node of 'a * Tree<'a> * Tree<'a>
| Leaf

/// Maps the result of function f to all the nodes of a tree.
let rec mapTree tree f = 
    match tree with 
    | Node(v, l, r) -> Node(f v, mapTree l f, mapTree r f)
    | Leaf -> Leaf
