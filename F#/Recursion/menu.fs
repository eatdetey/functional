module menu

let factorial n=
    let rec factorial_inner acc m =
        match m with
        | 0 -> acc
        | _ -> factorial_inner (acc*m) n-1
    factorial_inner n 1

let digits_Sum_down (n:int) =
    let rec digits_Sum_inner n current_sum =
        if n = 0 then current_sum
        else
            let n1=n/10
            let digit = n%10
            let new_sum = current_sum + digit
            digits_Sum_inner n1 new_sum
    digits_Sum_inner n 0

let menu (n:bool, m:int) =
    match n with
    |true -> digits_Sum_down(m)
    |false -> factorial(m)
