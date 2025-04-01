module array
open System

let readArray () =
    let input = Console.ReadLine()
    input.Split(' ') |> Array.map int


let arrayIntersection (arr1: int[]) (arr2: int[]) =
    let set1 = arr1 |> Set.ofArray
    let set2 = arr2 |> Set.ofArray
    Set.intersect set1 set2 |> Set.toArray |> Array.sort
