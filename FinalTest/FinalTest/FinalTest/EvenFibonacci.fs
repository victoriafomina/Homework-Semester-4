module EvenFibonacci

/// Sum of even fibonacci numbers that are lower than a million.
let evenFibonacci () =
    let rec fibonacci prev cur acc =
        if cur < 1000000 && cur % 2 = 0 then fibonacci cur (prev + cur) (acc + cur)
        elif cur < 1000000 then fibonacci cur (prev + cur) acc
        else acc
    fibonacci 1 1 0