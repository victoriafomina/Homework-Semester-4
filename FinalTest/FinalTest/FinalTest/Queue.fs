module Queue

/// Type implements queue data structure.
type Queue<'a> () =
    let mutable maxSize = 100
    
    let mutable elements = Array.zeroCreate<'a> (maxSize)

    let mutable count = 0

    /// Resizes the queue.
    let resize () = 
        maxSize <- maxSize + 50
        let mutable temp = elements
        elements <- Array.zeroCreate<'a> (maxSize)

        let copy (whatCopy : 'a[]) =
            for i in 0..(maxSize - 1 - 50) do
                elements.[i] <- whatCopy.[i]

        copy temp
    
    /// Makes shift in array after dequeue.
    let shift () =
        for i in 1..(maxSize - 1) do
            elements.[i - 1] <- elements.[i]

    /// Peeks the first element in the queue.
    member this.Peek () =
        if count = 0 then failwith "The queue is empty!"
        else elements.[0]
    
    /// Enqueue an element.
    member this.Enqueue value =
        if count = maxSize then
            resize()
        else
            elements.[count] <- value
            count <- count + 1
    
    /// Dequeue the first element.
    member this.Dequeue () =
        if count = 0 then failwith "The queue is empty!"
        else   
            shift ()
            count <- count - 1