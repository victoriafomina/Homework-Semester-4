module Queue

/// Type implements queue data structure.
type Queue () =
    let mutable maxSize = 100
    
    let mutable elements = Array.zeroCreate<'a> (maxSize)

    let mutable count = 0

    /// Resizes the queue.
    let resize () = 
        maxSize <- maxSize + 50
        let mutable temp = elements
        elements <- Array.zeroCreate<'a> (maxSize)

        let copy (whatCopy : 'a[]) =
            for i in 0.. (maxSize - 1 - 50) do
                elements.[i] <- whatCopy.[i]

        copy temp
    
    /// Makes shift in array after dequeue.
    let shift () =
        for i in 1 .. (maxSize - 1) do
            elements.[i - 1] <- elements.[i]
    
    /// Checks if the queue contains value. (Just for testing)
    member this.Contains (value : 'a) =
        let rec containsRec value acc =
            if acc = count then false
            elif elements.[acc] = value then true
            else containsRec value (acc + 1)
        containsRec value 0

    /// Peeks the first element in the queue.
    member this.Peek () =
        if count = 0 then failwith "The queue is empty!"
        else elements.[0]
    
    /// Enqueue an element.
    member this.Enqueu value =
        if count = maxSize then
            resize()
        else
            elements.[count] <- value
            count <- count + 1
    
    /// Dequeu the first element.
    member this.Dequeu () =
        if count = 0 then failwith "The queue is empty!"
        else   
            shift()
            count <- count - 1