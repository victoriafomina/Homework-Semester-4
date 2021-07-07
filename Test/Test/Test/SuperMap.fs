module SuperMap

/// [a, b, c, ...] - input list. [sin(a), cos(a), sin(b), cos(b), ...] - output list.
let superMap list =
    let rec superMapRec list acc = 
        match list with
        | [] -> acc
        | h :: t -> (superMapRec t (sin h :: (cos h :: acc)))
    superMapRec (List.rev list) []