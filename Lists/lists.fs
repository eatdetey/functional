module lists
open System

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