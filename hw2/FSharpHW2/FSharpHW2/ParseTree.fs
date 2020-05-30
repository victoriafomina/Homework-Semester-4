module ParseTree

type Expression =
    | Number of int
    | Add of Expression * Expression
    | Subtract of Expression * Expression
    | Multiply of Expression * Expression
    | Divide of Expression * Expression

/// Calculates an expression represented in discriminated unions.
let rec calculate exp =
    match exp with
    | Number num -> num
    | Add(op1, op2) -> calculate op1 + calculate op2
    | Subtract(op1, op2) -> calculate op1 - calculate op2
    | Multiply(op1, op2) -> calculate op1 * calculate op2
    | Divide(op1, op2) -> if op2 = Number(0) then failwith "Division by zero" else calculate op1 / calculate op2