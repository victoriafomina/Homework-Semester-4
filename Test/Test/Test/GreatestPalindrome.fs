module GreatestPalindrome

/// Looks for the greatest palindrome obtained by multiplying three-digit numbers.
let greatestPalindrome =
    let length x =
        let rec lengthRec x acc =
            if x <> 0 then lengthRec (x / 10) (acc + 1)
            else acc
        lengthRec x 0

    let powOfTen pow =
        let rec powOfTen pow res acc =
            if pow = 0 then 1
            elif acc < pow then powOfTen pow (10 * res) (acc + 1)
            else res
        powOfTen pow 1 0

    let numberWithoutFirstAndLast x len = (x % powOfTen (len - 1)) / 10

    let isEqualFirstAndLast x len = x < 10 || x % 10 = x / powOfTen(len - 1)

    let rec isPalindrome x len =   
        if x < 10 then true
        elif (isEqualFirstAndLast x len) then (isPalindrome (numberWithoutFirstAndLast x len) (len - 2))
        else false

    let rec greatestPalindromeRec num1 num2 acc =
        if num1 <= 999 && num2 < 999 && (isPalindrome (num1 * num2) (length(num1 * num2))) && num1 * num2 > acc then 
                greatestPalindromeRec num1 (num2 + 1) (num1 * num2)
        elif num1 <= 999 && num2 < 999 && (isPalindrome(num1 * num2) (length(num1 * num2))) then 
                greatestPalindromeRec num1 (num2 + 1) acc
        elif num1 <= 999 && num2 < 999 then greatestPalindromeRec num1 (num2 + 1) acc
        elif num1 <= 999 && num2 = 999 && (isPalindrome(num1 * num2) (length(num1 * num2))) && num1 * num2 > acc then 
                greatestPalindromeRec (num1 + 1) 100 (num1 * num2)
        elif num1 <= 999 && num2 = 999 && (isPalindrome(num1 * num2) (length(num1 * num2))) then   
                greatestPalindromeRec (num1 + 1) 100 acc
        elif num1 <= 999 && num2 = 999 then greatestPalindromeRec (num1 + 1) 100 acc
        else acc

    greatestPalindromeRec 100 100 1