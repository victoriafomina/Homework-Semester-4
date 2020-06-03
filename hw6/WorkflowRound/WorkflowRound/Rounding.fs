module Rounding

open System

/// Rounds float numbers result.
type RoundBuilder(roundTo : int) =
    let round = roundTo
    member this.Bind(x : float, f) =
        f <| Math.Round(x, round)
    member this.Return(x : float) = Math.Round(x, round)