module reduce

let rec reduce num (func:int->int->int) acc: int  =
    match num with
    | 0 -> acc
    | _ -> reduce (num/10) func (func acc (num%10)) 

let sumly a b =
    a+b;;