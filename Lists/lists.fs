module lists

let mostFrequentElement lst =
    lst
    |> List.countBy id
    |> List.sortByDescending snd
    |> List.head
    |> fst

let countSquareElements list =
    let setList = list |> Set.ofList
    list |> List.filter (fun x -> Set.contains (x * x) setList) |> List.length
