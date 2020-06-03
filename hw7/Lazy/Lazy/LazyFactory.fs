module LazyFactory

(*
/// <summary>
/// The LazyFactory class creates objects of the class Lazy.
/// </summary>
public class LazyFactory<T>
{
    public static Lazy<T> Create(Func<T> supplier)
    {
        return new Lazy<T>(supplier);
    }

    public static LazyThreadSafe<T> CreateThreadSafe(Func<T> supplier)
    {
        return new LazyThreadSafe<T>(supplier);
    }
      
}
*)

open Lazy

type LazyFactory<'a> =
    member this.CreateSingleThreadedLazy (supplier : unit -> 'a) = new Lazy<'a>(supplier)