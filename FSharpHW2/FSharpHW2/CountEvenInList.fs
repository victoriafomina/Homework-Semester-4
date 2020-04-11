module CountEvenInList

// Реализовать три варианта функции, подсчитывающей количество 
// четных чисел в списке (с использованием стандартных функций map, filter, fold). 
// Использование рекурсии не допускается, зато нужен FsCheck для проверки функций 
// на эквивалентность

let countEvenInListFilter list =
    if list = [] then None
    else Some((List.filter(fun x -> x % 2 = 0) list).Length)

// странно работает
let countEvenInListFold list =
   if list = [] then None
   else Some(List.fold(fun acc x -> acc - x % 2 + 1) 0 list)
    