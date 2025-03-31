module readList
open System

let readListFromKeyboard n =
    let rec readListFromKeyboardInner n acc =
        match n with
        | 0 -> acc
        | k ->
            let element = Console.ReadLine() |> int
            let accInner = acc@[element]
            readListFromKeyboardInner (k-1) accInner
    readListFromKeyboardInner n []

let rec printList list =
    match list with
        | [] -> Console.ReadKey()
        | head::tail ->
            Console.WriteLine(head.ToString())
            printList tail

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