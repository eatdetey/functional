module digit

let rec conditionalReduce num (func: int -> int -> int) acc (predicate: int -> bool) : int =
    match num with
    | 0 -> acc
    | _ -> 
        let digit = num % 10
        let newAcc = if predicate digit then func acc digit else acc
        conditionalReduce (num / 10) func newAcc predicate

