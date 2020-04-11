
/// <summary>Calculates factorial.</summary>
let fact n =
    let rec factRec n acc =
        if n < 0 then None
        elif n = 0 then Some(acc)
        else factRec (n - 1) (acc * n)
    factRec n 1

/// <summary>Finds nth number in a sequence of fibonacci numbers.</summary>
let fibonacci n =
    let rec fibonacciRec n prev prevPrev count =
        if n < 0 then None
        elif n = 1 || n = 2 then Some(1)
        elif n = count then Some(prev + prevPrev)
        else fibonacciRec n (prev + prevPrev) prev (count + 1)
    fibonacciRec n 1 1 3

/// <summary>Reverses a list.</summary>
let reverseList list =
    let rec reverseRec list acc =
        if list = [] then acc
        else reverseRec list.Tail (list.Head :: acc)
    reverseRec list []

/// <summary>The function uses parameters n, m to create the list 
/// [2^n; 2^(n + 1); ...; 2^(n + m)].</summary>
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

/// <returns>The first posions of the element in the list.</returns>
let firstPos list num =
    if list = [] then None
    else Some(List.findIndex(fun x -> x = num) list)