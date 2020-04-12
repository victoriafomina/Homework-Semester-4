module CountEvenInList

// Реализовать три варианта функции, подсчитывающей количество 
// четных чисел в списке (с использованием стандартных функций map, filter, fold). 
// Использование рекурсии не допускается, зато нужен FsCheck для проверки функций 
// на эквивалентность

/// <summary>Counts even numbers in the list using map.</summary>
//let countEvenInListMap list =
//    if list = [] then None
//    else Some(List.sum(List.map(fun x -> if x % 2 = 0 then 0 else 1)))

/// <summary>Counts even numbers in the list using filter.</summary>
let countEvenInListFilter list =
    if list = [] then None
    else Some((List.filter(fun x -> x % 2 = 0) list).Length)

/// <summary>Counts even numbers in the list using fold.</summary>
let countEvenInListFold list =
   if list = [] then None
   else Some(List.fold(fun acc x -> if x % 2 = 0 then acc + 1 else acc) 0 list)
    