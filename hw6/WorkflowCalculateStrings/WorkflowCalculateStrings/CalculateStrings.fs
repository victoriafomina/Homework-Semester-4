module CalculateStrings

open System

/// Implements interface letting calculate strings of integer numbers.
type CalculateBuilder() =
    member this.Bind(x : string, f) =
        match System.Int32.TryParse x with
        | (true, number) -> (f number).ToString()
        | _ -> "None"

    member this.Return(x) = x