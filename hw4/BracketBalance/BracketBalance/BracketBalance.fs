module BracketBalance

/// Checks the brackets balance in the expression.
let bracketsIsInBalance expression =
    let isBracket symbol = List.contains symbol ['('; ')'; '['; ']'; '{'; '}'] 

    let isOpeningBracket symbol = List.contains symbol ['('; '['; '{']

    let pairIsBalanced bracket1 bracket2 =
        if List.contains bracket1 ['('; ')'] && List.contains bracket2 ['('; ')'] then true
        elif List.contains bracket1 ['['; ']'] && List.contains bracket2 ['['; ']'] then true
        elif List.contains bracket1 ['{'; '}'] && List.contains bracket2 ['{'; '}'] then true
        else false
    
    let rec bracketsIsInBalanceRec expression brackets =
        match expression with
        | [] -> List.isEmpty brackets
        | h :: t when h |> isOpeningBracket -> bracketsIsInBalanceRec t (h :: brackets)
        | h :: t when isBracket (List.head brackets) && pairIsBalanced (List.head brackets) h  ->  bracketsIsInBalanceRec t (List.tail brackets)
        | h :: t when isBracket (List.head brackets) && not (pairIsBalanced (List.head brackets) h) -> false
        | h :: t -> bracketsIsInBalanceRec t brackets

    bracketsIsInBalanceRec (Seq.toList expression) []