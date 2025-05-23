module Digits

let rec digits_Sum n =
    if n=0 then 0
    else (n%10) + (digits_Sum(n/10))

let digits_Sum_down (n:int) =
    let rec digits_Sum_down1 n current_sum =
        if n = 0 then current_sum
        else
            let n1=n/10
            let digit = n%10
            let new_sum = current_sum + digit
            digits_Sum_down1 n1 new_sum
    digits_Sum_down1 n 0
