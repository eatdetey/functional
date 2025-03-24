// Дополнительные сведения о F# см. на http://fsharp.net
// Дополнительную справку см. в проекте "Учебник по F#".

let sumCifr n = 
    let rec sumCifr1 n curSum = 
        if n = 0 then curSum
        else
            let n1 = n / 10
            let cifr = n % 10
            let newSum = curSum + n1
            sumCifr1 n1 newSum
    sumCifr1 n 0

let fact n = 
    let rec fact1 n curFact = 
        match n with 
        |0 -> curFact
        | _ -> 
                let n1 = n - 1
                let newFact = curFact * n
                fact1 n1 curFact
    if n < 0 then 0
    else fact1 n 1

let f6 = function
    true -> sumCifr
    | false -> fact

let rec f7 n f init = 
    if n = 0 then init
    else 
        let cifr = n % 10
        let n1 = n / 10
        let acc = f init cifr
        f7 n1 f acc

let rec f9 n f init predicate = 
    if n = 0 then init
    else
        let cifr = n % 10
        let n1 = n / 10
        let acc = f init cifr
        if predicate cifr then f9 n1 f acc predicate
        else f9 n1 f init predicate


[<EntryPoint>]
let main argv = 
    let countAndPrint = sumCifr >> System.Console.WriteLine
    countAndPrint (System.Convert.ToInt32(System.Console.ReadLine()))
    System.Console.WriteLine((f6 true 123, f6 false 10, f6 true -3))
    System.Console.WriteLine(f7 123 (fun x y -> x + y) 0)
    System.Console.WriteLine(f7 123 (fun x y -> x * y) 1)
    System.Console.WriteLine(f7 123 (fun x y -> if x > y then x else y) -1)
    System.Console.WriteLine(f7 123 (fun x y -> if x < y then x else y) 10)

    let z = System.Console.ReadKey() 
    0 // возвращение целочисленного кода выхода
