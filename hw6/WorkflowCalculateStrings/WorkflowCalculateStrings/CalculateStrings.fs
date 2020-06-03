module CalculateStrings

open System

/// Implements interface letting calculate strings of integer numbers.
type CalculateBuilder() =
    member this.Bind(x : string, f) =
        if Seq.length x = ((Seq.filter (fun c -> Char.IsDigit(c)) x) |> Seq.length) then (f <| Int32.Parse(x)).ToString() else "None"

    member this.Return(x) = x