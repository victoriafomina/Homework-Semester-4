module InfiniteSequenceOfPrimes

/// The function generates infinite sequence of primes.
let infiniteSeqOfPrimes =
    let rec isPrime n acc = 
        if n = 2 || acc * acc > n || n % acc = 0 then true
        else isPrime n (acc + 1)

    let rec findNPrime acc currN = 
        if isPrime currN 2 && acc <> 1 then findNPrime (acc - 1) (currN + 1)
        elif isPrime currN 2 then currN
        else findNPrime (acc) (currN + 1)

    Seq.initInfinite(fun index ->
        let n = index + 1
        findNPrime n 2)