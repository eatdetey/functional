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
        | [] -> Console.WriteLine("")
        | head::tail ->
            Console.Write(head.ToString())
            Console.Write(" ")
            printList tail
