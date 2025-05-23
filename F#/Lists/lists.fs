module lists
open System

let rec reduceList list (f: int -> int -> int) (p: int -> bool) acc =
    match list with
        | [] -> acc
        | head::tail ->
            let accInner = if p head then f acc head else acc
            reduceList tail f p accInner

let minList list =
    match list with
    | [] -> 0
    | head::tail -> reduceList list (fun a b -> if a<b then a else b) (fun a -> true) head

let mostFrequentElement lst =
    lst
    |> List.countBy id
    |> List.sortByDescending snd
    |> List.head
    |> fst

let countSquareElements list =
    let setList = list |> Set.ofList
    list |> List.filter (fun x -> Set.contains (x * x) setList) |> List.length

let sumOfDigits n =
    n.ToString().ToCharArray() |> Array.sumBy (fun c -> int c - int '0')

let countDivisors n =
    [1..n] |> List.filter (fun x -> n % x = 0) |> List.length

let createTupleList listA listB listC =
    let sortedA = List.sortDescending listA
    let sortedB = List.sortBy (fun x -> (sumOfDigits x, -x)) listB
    let sortedC = List.sortByDescending (fun x -> (countDivisors x, x)) listC
    List.zip3 sortedA sortedB sortedC

let sortStringsByLength strings =
    List.sortBy String.length strings

let readStrings () =
    let rec readStringsInner acc =
        let line = Console.ReadLine()
        if String.IsNullOrEmpty(line) then List.rev acc
        else readStringsInner (line :: acc)
    readStringsInner []

let shiftRight2List lst =
    let n = List.length lst
    if n < 2 then lst
    else let shift = n - 2 in List.skip shift lst @ List.take shift lst

let swapMinMaxList lst =
    match lst with
    | [] -> []
    | _ ->
        let minVal, maxVal = List.min lst, List.max lst
        List.map (fun x -> if x = minVal then maxVal elif x = maxVal then minVal else x) lst

let shiftLeft1List lst =
    match lst with
    | [] -> []
    | h :: t -> t @ [h]

let findIndicesList lst =
    lst
    |> List.mapi (fun i x -> if i > 0 && x < List.item (i - 1) lst then Some i else None)
    |> List.choose id

let divisorsList lst =
    let getDivisors n = [1 .. n] |> List.filter (fun x -> n % x = 0)
    lst |> List.collect getDivisors |> List.distinct

let countElementsList lst =
    let _, count = List.fold (fun (sum, acc) x -> if x > sum then (sum + x, acc + 1) else (sum + x, acc)) (0, 0) lst
    count

let sortByP lst =
    let evenIndexElements = lst |> List.mapi (fun i x -> if i % 2 = 0 then Some x else None) |> List.choose id
    let mean = (List.sum lst) / (List.length lst)
    let divisorsOfEvenIndices = divisorsList evenIndexElements
    let validDivisors = divisorsOfEvenIndices |> List.filter (fun d -> not (lst |> List.exists (fun x -> x < mean && x % d = 0)))
    let p a = validDivisors |> List.filter (fun d -> a % d = 0) |> List.sum
    lst |> List.sortBy p