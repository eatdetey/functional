module fibonacci

let rec fibon n =
    match n with
    | 0 -> 1
    | 1 -> 1
    | _ -> fibon(n-1) + fibon(n-2);;

let fibon_down (n:int) =
    let rec fibon_down_inner m acc n =
        match n with
        | 0 -> acc
        | _ -> fibon_down_inner acc (acc+m) (n-1)
    fibon_down_inner 0 1 n
