module Lazy

/// Lazy computations interface.
type ILazy<'a> =
    abstract member Get : unit -> 'a

type Lazy<'a>(supplier : unit -> 'a) =
    let value = supplier

    interface ILazy<'a> with
        member this.Get () = value ()
