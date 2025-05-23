module palindrome
open System

let isPalindrome (str: string) =
    let cleaned = str |> Seq.filter Char.IsUpper |> Seq.toArray
    cleaned = Array.rev cleaned