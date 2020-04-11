
// Посчитать факториал
let fact n =
    let rec factRec n acc =
        if n < 0 then None
        elif n = 0 then Some(acc)
        else factRec (n - 1) (acc * n)
    factRec n 1

// Посчитать числа Фибоначчи (за линейное время)
let fibonacci n =
    let rec fibonacciRec n prev prevPrev count =
        if n < 0 then None
        elif n = 1 || n = 2 then Some(1)
        elif n = count then Some(prev + prevPrev)
        else fibonacciRec n (prev + prevPrev) prev (count + 1)
    fibonacciRec n 1 1 3

// Реализовать функцию обращения списка (за линейное время)
let reverseList list =
    let rec reverseRec list acc =
        if list = [] then acc
        else reverseRec list.Tail (list.Head :: acc)
    reverseRec list []

// Реализовать функцию, которая принимает на вход n и m и возвращает список из элементов 
// [2^n; 2^(n + 1); ...; 2^(n + m)]
let listPowers n m =
    let rec twoPowered n acc =
        if n = 0 then acc
        else twoPowered (n - 1) (acc * 2)

    if n < 0 || n > m then None
    else
    let rec returnsListRec pow acc list =
        if pow = 0 then Some(list)
        else returnsListRec (pow - 1) (acc / 2) (acc :: list)
    returnsListRec (m - n + 1) (twoPowered m 1) []

// Реализовать функцию, которая выдает первую позицию вхождения заданного числа в список
let firstPos list num =
    if list = [] then None
    else Some(List.findIndex(fun x -> x = num) list)


[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    printfn "%A" (firstPos [-5; 2; 3; 4] 3)
    printfn "%A" (listPowers 2 5)
    printfn "%A" (reverseList [1; 2; 3; 4])
    0