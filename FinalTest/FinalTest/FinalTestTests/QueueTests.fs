module QueueTests

open NUnit.Framework
open FsUnit
open Queue
open System

[<Test>]
let ``Enqueue and peek test 1`` () =
    let q = new Queue()
    q.Enqueu(1)
    q.Peek() |> should equal 1

[<Test>]
let ``Enqueue and peek test 2`` () =
    let q = new Queue()
    q.Enqueu(1)
    q.Enqueu(1)
    q.Peek() |> should equal 1

[<Test>]
let ``Enqueue and peek test 3`` () =
    let q = new Queue()
    q.Enqueu(1)
    q.Enqueu(2)
    q.Peek() |> should equal 1

[<Test>]
let ``Enqueue and peek test 4`` () =
    let q = new Queue()
    q.Enqueu(5)
    q.Enqueu(-7)
    q.Enqueu(0)
    q.Peek() |> should equal 5

[<Test>]
let ``Dequeue and peek test 1`` () =
    let q = new Queue()
    q.Enqueu(1)
    q.Dequeu()
    q.Enqueu(1)
    q.Peek() |> should equal 1

[<Test>]
let ``Dequeue from empty queue test 1`` () =
    let q = new Queue()
    (fun () -> q.Dequeu() |> ignore) |> should throw typeof<Exception>

[<Test>]
let ``Dequeue from empty queue test 2`` () =
    let q = new Queue()
    q.Enqueu(-9)
    q.Dequeu() |> ignore
    (fun () -> q.Dequeu() |> ignore) |> should throw typeof<Exception>

[<Test>]
let ``Peek with empty queue test 1`` () =
    let q = new Queue()
    (fun () -> q.Peek() |> ignore) |> should throw typeof<Exception>

[<Test>]
let ``Peek with empty queue test 2`` () =
    let q = new Queue()
    q.Enqueu(-9)
    q.Dequeu() |> ignore
    (fun () -> q.Peek() |> ignore) |> should throw typeof<Exception>