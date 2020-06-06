module EvenFibonacci

/// Sum of even fibonacci numbers that are lower than a million.
let evenFibonacci =
    let rec fibonacci prev cur acc =
        if cur < 1000000 then fibonacci cur (prev + cur) (acc + cur)
        else acc
    fibonacci 1 1 1