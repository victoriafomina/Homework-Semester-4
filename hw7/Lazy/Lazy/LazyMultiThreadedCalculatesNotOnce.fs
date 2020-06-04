module LazyMultiThreadedCalculatesNotOnce

open ILazy
open System.Threading

/// Lazy computations interface.
type ILazy<'a> =
    /// Returns value of the object.
    abstract member Get: unit -> 'a

/// Implements ILazy interface. Lets make thread-safe late initialization. Expression can be calculated more than once.
type LazyMultiThreadedCalculatesNotOnce<'a>(supplier : unit -> 'a) =
    let supp = supplier
    let mutable isCalculated = 0
    let mutable value = None

    interface ILazy<'a> with
    /// Returns value of the object.
    member this.Get () =
        while 0 = Interlocked.Exchange(ref isCalculated, 1) do
            value <- Some(supp ())
            Interlocked.Exchange(ref isCalculated, 1)
        value.Value
