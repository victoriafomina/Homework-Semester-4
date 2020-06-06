module QueueTests

open NUnit.Framework
open FsUnit
open Queue
open System

[<Test>]
let ``Enqueue and peek test 1`` () =
    let q = new Queue<int>()
    q.Enqueue(1)
    q.Peek () |> should equal 1

[<Test>]
let ``Enqueue and peek test 2`` () =
    let q = new Queue<int>()
    q.Enqueue(1)
    q.Enqueue(1)
    q.Peek () |> should equal 1

[<Test>]
let ``Enqueue and peek test 3`` () =
    let q = new Queue<int>()
    q.Enqueue(1)
    q.Enqueue(2)
    q.Peek () |> should equal 1

[<Test>]
let ``Enqueue and peek test 4`` () =
    let q = new Queue<int>()
    q.Enqueue(5)
    q.Enqueue(-7)
    q.Enqueue(0)
    q.Peek() |> should equal 5

[<Test>]
let ``Dequeue and peek test 1`` () =
    let q = new Queue<int>()
    q.Enqueue(1)
    q.Dequeue ()
    q.Enqueue(1)
    q.Peek () |> should equal 1

[<Test>]
let ``Dequeue from empty queue test 1`` () =
    let q = new Queue<int>()
    (fun () -> q.Dequeue () |> ignore) |> should throw typeof<Exception>

[<Test>]
let ``Dequeue from empty queue test 2`` () =
    let q = new Queue<int>()
    q.Enqueue(-9)
    q.Dequeue () |> ignore
    (fun () -> q.Dequeue () |> ignore) |> should throw typeof<Exception>

[<Test>]
let ``Peek with empty queue test 1`` () =
    let q = new Queue<int>()
    (fun () -> q.Peek () |> ignore) |> should throw typeof<Exception>

[<Test>]
let ``Peek with empty queue test 2`` () =
    let q = new Queue<int>()
    q.Enqueue(-9)
    q.Dequeue () |> ignore
    (fun () -> q.Peek() |> ignore) |> should throw typeof<Exception>