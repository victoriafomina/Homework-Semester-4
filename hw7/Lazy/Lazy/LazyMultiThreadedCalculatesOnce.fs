module LazyMultiThreadedCalculatesOnce

open System.Threading
open ILazy

/// Implements ILazy interface. Lets make thread-safe late initialization. Expression is calculated only once.
type LazyMultiThreadedCalculatesOnce<'a> (supplier : unit -> 'a) =
    let supp = supplier 
    let mutable isCalculated = false

    [<DefaultValue>]
    val mutable value : 'a

    interface ILazy<'a> with
        /// Returns value of the object.
        member this.Get () = 
            if not (Volatile.Read(ref isCalculated)) then 
                Monitor.Enter(isCalculated)
                value <- supp ()
                Volatile.Write(ref isCalculated, true)
                Monitor.Exit(isCalculated)
            value