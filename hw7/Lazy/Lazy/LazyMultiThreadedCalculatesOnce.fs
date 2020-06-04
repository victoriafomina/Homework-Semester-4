module LazyMultiThreadedCalculatesOnce

open System.Threading
open ILazy

/// Implements ILazy interface. Lets make thread-safe late initialization. Expression is calculated only once.
type LazyMultiThreadedCalculatesOnce<'a> (supplier : unit -> 'a) =
    let supp = supplier 
    let mutable isCalculated = false
    let mutable value = None
    let locker = new obj()

    interface ILazy<'a> with
        /// Returns value of the object.
        member this.Get () =
            if not (Volatile.Read(ref isCalculated)) then 
                lock (locker) <| ignore
                value <- Some(supp ())
                isCalculated <- true
            value.Value