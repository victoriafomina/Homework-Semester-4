module Lazy

open ILazy

/// Implements ILazy interface. Lets make single-thread late initialization.
type Lazy<'a>(supplier : unit -> 'a) =
    let supp = supplier 
    let mutable isCalculated =  false

    [<DefaultValue>]
    val mutable value : 'a    

    interface ILazy<'a> with
        /// Returns value of the object.
        member this.Get () =
            if not isCalculated then 
                value <- supp ()
                isCalculated <- true
            value