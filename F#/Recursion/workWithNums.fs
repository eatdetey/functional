module workWithNums
open reduce
open coprimeTraverse

let isPrime n =
    let rec check d =
        d * d > n || (n % d <> 0 && check (d + 1))
    n > 1 && check 2

let sumOfPrimeDivisors number =
    let rec sumDivisors d acc =
        match d > number with
        | true -> acc
        | false ->
            match number % d, isPrime d with
            | 0, true -> sumDivisors (d + 1) (acc + d) // d - делитель и простое число
            | _, _ -> sumDivisors (d + 1) acc
    sumDivisors 1 0


let countOddDigitsGreaterThanThree number =
    reduce number (fun acc d -> 
        match d % 2, d > 3 with
        | 1, true -> acc + 1
        | _, _ -> acc
    ) 0

let productOfDivisorsWithSmallerDigitSum number =
    let totalSum = reduce number (fun acc d -> acc + d) 0
    let rec findProduct d acc =
        match d > number with
        | true -> acc
        | false -> 
            match number % d, reduce d (fun acc x -> acc + x) 0 < totalSum with
            | 0, true -> findProduct (d + 1) (acc * d)
            | _, _ -> findProduct (d + 1) acc
    findProduct 1 1

let selectFunction = function
    | 1 -> sumOfPrimeDivisors
    | 2 -> countOddDigitsGreaterThanThree
    | 3 -> productOfDivisorsWithSmallerDigitSum
    | _ -> failwith "Ошибка: номер функции должен быть от 1 до 3"

let main_curried (n, m) =
    let func = selectFunction n
    let result = func m
    printfn "Результат: %d" result

let main_composed = selectFunction >> (fun f -> f >> printfn "Результат: %d")

