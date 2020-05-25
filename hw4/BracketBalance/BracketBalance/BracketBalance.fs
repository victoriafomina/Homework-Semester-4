module BracketBalance

/// Checks the brackets balance in the expression.
let bracketsAreInBalance expression =
        let isBracket symbol = List.contains symbol ['('; ')'; '['; ']'; '{'; '}'] 

        let isOpeningBracket symbol = List.contains symbol ['('; '['; '{']

        let isClosingBracket symbol = List.contains symbol [')'; ']'; '}']

        let pairIsBalanced bracket1 bracket2 =
            if List.contains bracket1 ['('; ')'] && List.contains bracket2 ['('; ')'] then true
            elif List.contains bracket1 ['['; ']'] && List.contains bracket2 ['['; ']'] then true
            elif List.contains bracket1 ['{'; '}'] && List.contains bracket2 ['{'; '}'] then true
            else false
    
        let rec bracketsAreInBalanceRec expression brackets =
            match expression with
            | [] -> List.isEmpty brackets
            | h :: t when h |> isOpeningBracket -> bracketsAreInBalanceRec t (h :: brackets)
            | h :: _ when h |> isClosingBracket && List.isEmpty brackets -> false
            | h :: t when not (h |> isBracket) -> bracketsAreInBalanceRec t brackets
            | h :: t when isBracket (List.head brackets) && pairIsBalanced (List.head brackets) h  ->  bracketsAreInBalanceRec t (List.tail brackets)
            | _ -> false

        bracketsAreInBalanceRec (Seq.toList expression) []