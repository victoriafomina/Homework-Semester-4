module BracketBalance

/// Checks the brackets balance in the expression.
let bracketsIsInBalance expression =
    let isOpeningBracket symbol =
        symbol = "(" || symbol = "{" || symbol = "["

    let pairIsBalanced bracket1 bracket2 =
        bracket1 = "(" && bracket2 = ")" || bracket1 = "{" && bracket1 = "}" || bracket1 = "[" && bracket1 = "]"
    
    let rec bracketsIsInBalanceRec expression brackets =
        match expression with
        | [] -> List.isEmpty brackets
        | h :: t when brackets.[List.length brackets - 1] |> isOpeningBracket -> bracketsIsInBalanceRec t (h :: brackets)
        | h :: t when pairIsBalanced brackets.[List.length brackets - 1] h -> bracketsIsInBalanceRec t (List.tail brackets)
        | _ -> false

    bracketsIsInBalanceRec expression []