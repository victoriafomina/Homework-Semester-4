module LazyFactory

open Lazy
open LazyMultiThreadedCalculatesOnce
open LazyMultiThreadedCalculatesNotOnce

/// The LazyFactory class creates objects of the class Lazy.
type LazyFactory<'a>() =
    /// Creates single-threaded lazy.
    member this.CreateSingleThreadedLazy (supplier : unit -> 'a) = new Lazy<'a>(supplier)

    /// Creates multi-threaded lazy. Calculation is done only once.
    member this.CreateMultiThreadedLazyCalculateOnce (supplier : unit -> 'a) = 
        new LazyMultiThreadedCalculatesOnce<'a>(supplier)
    
    /// Creates multi-threaded lazy. Calculation may be done not only once.
    member this.CreateMultiThreadedLazyCalculateNotOnce (supplier : unit -> 'a) =
        new LazyMultiThreadedCalculatesNotOnce<'a>(supplier)