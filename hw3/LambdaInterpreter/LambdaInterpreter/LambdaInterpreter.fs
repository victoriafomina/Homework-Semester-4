module LambdaInterpreter

// Реализовать интерпретатор лямбда-выражений, выполняющий бета-редукцию по нормальной стратегии. 
// Лямбда-выражения задаются через размеченные объединения. Должна поддерживаться альфа-конверсия для 
// избежания захвата свободных переменных. Примечание: если не извращаться и делать всё по определению, задача простая.

/// Defines lambda term type.
type LambdaTerm =
    | Variable of char
    | Abstr of char * LambdaTerm
    | Applic of LambdaTerm * LambdaTerm


/// Beta reduction. Normal strategy.
let rec betaReduction expression =

    /// Checks if variable is free.
    let rec isFreeVar expression var = 
        match expression with 
        | Variable x -> x = var
        | Abstr(vr, term) -> vr <> var && (isFreeVar term var) 
        | Applic(l, r) -> isFreeVar l var || isFreeVar r var

    /// Conversion.
    let findVarToConverse expression =
        List.find (fun x -> not (isFreeVar expression x)) ['a'..'z']

    /// Makes substitution.
    let rec substitute expression insteadOf value =
        match expression with
        | Variable x when x = insteadOf -> value
        | Variable -> expression
        | Abstr(var, lmd) when var = insteadOf -> expression
        | Abstr(var, lmd) when not (isFreeVar value var) -> Abstr(var, substitute lmd insteadOf value)
        | Abstr(var, lmd) -> 
            let right = substitute (substitute lmd var (Variable (findVarToConverse expression))) insteadOf value
            Abstr(findVarToConverse(value), right)
        | Applic(l, r) -> Applic(substitute l insteadOf value, substitute r insteadOf value)
        | _ -> expression

    /// Reduce with left outer term (normal strategy).
    let rec reduceLeftOuter expression =
        match expression with
        | Applic(l, r) -> match reduceLeftOuter l with 
                          | Abstr(var, lmd) -> substitute lmd var r 
                          | var -> Applic(var, r)
        | _ -> expression

    match expression with
    | Variable -> expression
    | Applic(l, r) -> match reduceLeftOuter l with 
                        | Abstr(var, lmd) -> betaReduction (substitute lmd var r)
                        | var -> Applic(betaReduction var, betaReduction r)
    | Abstr(var, lmd) -> Abstr(var, betaReduction lmd)
    