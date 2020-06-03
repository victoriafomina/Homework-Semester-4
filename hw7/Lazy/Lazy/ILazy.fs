module ILazy

/// Lazy computations interface.
type ILazy<'a> =
    abstract member Get: unit -> 'a