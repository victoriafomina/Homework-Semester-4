module ILazy

/// Lazy computations interface.
type ILazy<'a> =
    /// Returns value of the object.
    abstract member Get: unit -> 'a