module MapForTrees

type Tree<'a> =
| Node of 'a * Tree<'a> * Tree<'a>
| Empty


let map tree = 
    if