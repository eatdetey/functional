module church

//Списки Черча
let rec reverse lst acc =
    match lst with
    | [] -> acc
    | h :: t -> reverse t (h :: acc)
let rev lst = reverse lst []

let rec min lst currentMin =
    match lst with
    | [] -> currentMin
    | h :: t -> min t (if h < currentMin then h else currentMin)
let minValue lst =
    match lst with
    | [] -> failwith "Empty list"
    | h :: t -> min t h

let rec max lst currentMax =
    match lst with
    | [] -> currentMax
    | h :: t -> max t (if h > currentMax then h else currentMax)

let maxValue lst =
    match lst with
    | [] -> failwith "Empty list"
    | h :: t -> max t h

let shiftRight2 lst =
    let rec shiftRight2Inner lst acc = 
        match lst with
        | [] -> []
        | x :: y :: [] -> x::y::rev acc
        | head::tail -> shiftRight2Inner tail (head::acc)
    shiftRight2Inner lst []

let rec swapMinMax lst =
    let rec swap lst minVal maxVal =
        match lst with
        | [] -> []
        | h :: t when h = minVal -> maxVal :: swap t minVal maxVal
        | h :: t when h = maxVal -> minVal :: swap t minVal maxVal
        | h :: t -> h :: swap t minVal maxVal
    match lst with
    | [] -> []
    | _ -> let minVal, maxVal = minValue lst, maxValue lst in swap lst minVal maxVal

let rec shiftLeft1 lst =
    match lst with
    | [] -> []
    | h :: t -> t @ [h]

let rec indicesSmallerThanLeft lst index acc =
    match lst with
    | x1 :: x2 :: t when x2 < x1 -> indicesSmallerThanLeft (x2 :: t) (index + 1) (index :: acc)
    | _ :: t -> indicesSmallerThanLeft t (index + 1) acc
    | [] -> rev acc
let findIndices lst = indicesSmallerThanLeft lst 1 []

let rec getDivisors n d acc =
    if d > n then acc
    else getDivisors n (d + 1) (if n % d = 0 then d :: acc else acc)
let rec divisors lst acc =
    match lst with
    | [] -> rev acc
    | h :: t -> divisors t (List.fold (fun acc x -> if List.contains x acc then acc else x :: acc) acc (getDivisors h 1 []))

let rec countGreaterThanSum lst sum acc =
    match lst with
    | [] -> acc
    | h :: t when h > sum -> countGreaterThanSum t (sum + h) (acc + 1)
    | h :: t -> countGreaterThanSum t (sum + h) acc
let countElements lst = countGreaterThanSum lst 0 0

