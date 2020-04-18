module MapForTrees

type Tree<'a> =
| Node of 'a * Tree<'a> * Tree<'a>
| Leaf

let rec mapTree tree f =
    match tree with 
    | Node(v, l, r) -> f v (mapTree l f) (mapTree r f)

let rec insert tree value =
    match tree with
    | Node(v, l, r) when value < v -> 
        let l' = insert l value
        Node(v, l', r)
    | Node(v, l, r) when value > v ->
        let r' = insert r value
        Node(v, l, r')      
    | Leaf -> Node(value, Leaf, Leaf)

let rec isInTree tree x =
    match tree with
    | Node(v, l, r) when v < x -> isInTree r x
    | Node(v, l, r) when v > x -> isInTree l x
    | Node(v, l, r) when v = x -> true
    | Leaf -> false

 // не получилось: распечатать и добавить в список
 (*  
let rec listElements(tree: Tree<int>, list: List<int>) =
    match tree with
    | Node(v, l, r) -> printf "%d" v 
        listElements(l v :: list)
        listElements r v :: list
*)
    
