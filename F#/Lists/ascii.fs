module ascii
open System

let averageAscii (s: string) : float =
    if s.Length = 0 then 0.0
    else
        s |> Seq.map int |> Seq.averageBy float

let averageAsciiTriplets (s: string) : float list =
    if s.Length < 3 then []
    else
        [ for i in 0 .. s.Length - 3 do
            yield s.[i..i+2] |> averageAscii ]

let quadraticDeviation (s: string) : float =
    let avgAscii = averageAscii s
    let tripletAverages = averageAsciiTriplets s
    if tripletAverages.Length = 0 then 0.0
    else
        tripletAverages
        |> List.map (fun tripletAvg -> (tripletAvg - avgAscii) ** 2.0)
        |> List.average

let sortByQuadraticDeviation (strings: string list) : string list =
    strings |> List.sortBy quadraticDeviation


