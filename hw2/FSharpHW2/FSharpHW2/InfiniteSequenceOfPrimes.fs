module InfiniteSequenceOfPrimes

/// <summary>The function generates infinite sequence of primes.</summary>
let infiniteSeqOfPrimes =
    let rec isPrime n acc = 
        if n = 2 then true
        elif float acc > sqrt (float n) then true
        elif n % acc = 0 then false
        else isPrime n (acc + 1)

    let rec findNPrime acc currN = 
        if isPrime currN 2 && acc <> 1 then findNPrime (acc - 1) (currN + 1)
        elif isPrime currN 2 then currN
        else findNPrime (acc) (currN + 1)

    Seq.initInfinite(fun index ->
        let n = index + 1
        findNPrime n 2)