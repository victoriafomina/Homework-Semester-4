module CountEvenInList

/// Counts even numbers in the list using map.
let countEvenInListMap list =
    if list = [] then 0
    else List.sum <| List.map(fun x -> if x % 2 = 0 then 1 else 0) list

/// Counts even numbers in the list using filter.
let countEvenInListFilter list =
    if list = [] then 0
    else List.filter(fun x -> x % 2 = 0) list |> List.length

/// Counts even numbers in the list using fold.
let countEvenInListFold list =
   if list = [] then 0
   else List.fold(fun acc x -> if x % 2 = 0 then acc + 1 else acc) 0 list
    