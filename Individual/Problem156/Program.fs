open System

let baseValue = 10uL

let countSingle (baseValue: uint64) (digit: uint64) (value: uint64) =
    let rec countRec v acc =
        if v = 0uL then acc
        elif v % baseValue = digit then
            countRec (v / baseValue) (acc + 1uL)
        else
            countRec (v / baseValue) acc
    if value = 0uL && digit = 0uL then 1uL
    else countRec value 0uL


let rec count (baseValue: uint64) (digit: uint64) (value: uint64) =
    let rec findShiftMultiplier shift multiplier =
        if shift * baseValue > value then
            (shift, multiplier * (shift / baseValue))
        else
            findShiftMultiplier (shift * baseValue) (multiplier + 1uL)

    if value < baseValue then
        if value < digit then 0uL else 1uL
    else
        let shift, multiplier = findShiftMultiplier 1uL 0uL
        let first = value / shift
        let remainder = value % shift

        let result = first * multiplier
        let result = result + (count baseValue digit remainder)

        let result =
            if digit = first then
                result + remainder + 1uL
            elif digit < first && digit > 0uL then
                result + shift
            else
                result
        result


let rec findAll (baseValue: uint64) (digit: uint64) (fromValue: uint64) (toValue: uint64) =
    let center = (fromValue + toValue) / 2uL

    if fromValue = center then
        let current = count baseValue digit fromValue
        if current = fromValue then fromValue else 0uL
    else
        // Рекурсивная версия цикла для fast-path
        let rec fastSum acc current countCurrent =
            if countCurrent = current && current < toValue then
                let next = current + 1uL
                let nextCount = countCurrent + countSingle baseValue digit next
                fastSum (acc + current) next nextCount
            else
                (acc, current)

        let initialCount = count baseValue digit fromValue
        let (fastResult, newFrom) = fastSum 0uL fromValue initialCount

        if newFrom >= toValue + 1uL then
            fastResult
        else
            let newCenter = (newFrom + toValue) / 2uL
            let countCenter = count baseValue digit newCenter
            let countTo = count baseValue digit toValue

            let leftResult =
                if countCenter >= newFrom && newCenter >= initialCount && newCenter > newFrom then
                    findAll baseValue digit newFrom newCenter
                else 0uL

            let rightResult =
                if countTo >= newCenter && toValue >= countCenter && newCenter < toValue then
                    findAll baseValue digit newCenter toValue
                else 0uL

            fastResult + leftResult + rightResult


[<EntryPoint>]
let main argv =
    let baseValue = 10uL
    let limit = 1000000000000uL // 10^12

    let sum =
        [1uL .. 9uL]
        |> List.map (fun digit -> findAll baseValue digit 0uL limit)
        |> List.sum

    printfn "%d" sum
    0
