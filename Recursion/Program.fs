open fibonacci
open menu
open reduce
open digit
open favLanguage
open coprimeTraverse
open workWithNums

//Пара
let testFibonacci () =
    System.Console.WriteLine(fibon(19))
    System.Console.WriteLine(fibon_down(19))

//Задание 6
let testMenu () =
    System.Console.WriteLine(menu(true, 5))

//Задание 7, 8
let testReduce () =

    System.Console.WriteLine(reduce 5 sumly 1)
    let testNumT7 = 12345

    let sumOfDigits = reduce testNumT7 (fun acc d -> acc + d) 0
    let productOfDigits = reduce testNumT7 (fun acc d -> acc * d) 1

    let minDigit = reduce testNumT7 (fun acc d -> 
        match acc, d with
        | a, b -> if a < b then a else b) 9

    let maxDigit = reduce testNumT7 (fun acc d -> 
        match acc, d with
        | a, b -> if a > b then a else b) 0

    System.Console.WriteLine(sumOfDigits)
    System.Console.WriteLine(productOfDigits)
    System.Console.WriteLine(minDigit)
    System.Console.WriteLine(maxDigit)

//Задание 9, 10
let testDigitTraverse () =
    let testNumT9 = 123456

    let sumEvenDigits = conditionalReduce testNumT9 (fun acc d -> acc + d) 0 (fun d -> d % 2 = 0)
    System.Console.WriteLine("Сумма четных цифр: " + sumEvenDigits.ToString())

    let productGreaterThanThree = conditionalReduce testNumT9 (fun acc d -> acc * d) 1 (fun d -> d > 3)
    System.Console.WriteLine("Произведение цифр больше 3: " + productGreaterThanThree.ToString())

    let maxOddDigit = conditionalReduce testNumT9 (fun acc d -> if acc > d then acc else d) -1 (fun d -> d % 2 <> 0)
    System.Console.WriteLine("Максимальная нечетная цифра: " + maxOddDigit.ToString())

//Задание 11, 12 
//(суперпозиция)
let testFavLanguage() =
    let languageMainSup = (fun () -> System.Console.ReadLine()) >> favLanguage >> System.Console.WriteLine
    System.Console.WriteLine("Какой твой любимый язык программирования?")
    languageMainSup ()

    //(каррирование)
    let languageMainCar input output = 
        output (favLanguage input)

    System.Console.WriteLine("Какой твой любимый язык программирования?")
    let getInput = languageMainCar (System.Console.ReadLine())
    getInput System.Console.WriteLine

//Задание 13, 14
let testCoprimeTraversal () =
    let number = 15
    
    System.Console.WriteLine("Сумма взаимнопростых чисел с числом {0}", number)
    let sum = coprimeTraversal number (+) 0
    System.Console.WriteLine(sum)

    System.Console.WriteLine("Произведение взаимнопростых чисел с числом {0}", number)
    let mult = coprimeTraversal number (*) 1
    System.Console.WriteLine(mult)

    System.Console.WriteLine("Количество взаимнопростых чисел с числом {0}", number)
    let count = coprimeTraversal number (fun x y -> x + 1) 0
    System.Console.WriteLine(count)

    System.Console.WriteLine("Минимум из взаимнопростых чисел с числом {0}", number)
    let min = coprimeTraversal number (fun x y -> if x < y then x else y) number
    System.Console.WriteLine(min)

    System.Console.WriteLine("Максимум из взаимнопростых чисел с числом {0}", number)
    let max = coprimeTraversal number (fun x y -> if x > y then x else y) 0
    System.Console.WriteLine(max)

let testEulerFunction () =
    let number = 15
    System.Console.WriteLine("Функция Эйлера от {0}", number)
    System.Console.WriteLine(eulerFunction number)

//Задание 15
let testCoprimeTraversalPredicate () =
    let number = 15

    System.Console.WriteLine("Сумма четных взаимнопростых чисел с числом {0}", number)
    let sum = coprimeTraversalPredicate number (+) (fun x -> (x%2)=0) 0
    System.Console.WriteLine(sum)

//Задание 16-19
let testWorkWithNums () =
    let number = 52

    System.Console.WriteLine("Сумма простых делителей числа: {0}", arg0=number)
    System.Console.WriteLine(sumOfPrimeDivisors number)

    System.Console.WriteLine("Количество нечетных цифр числа, больших 3, для числа {0}", arg0=number)
    System.Console.WriteLine(countOddDigitsGreaterThanThree number)

    System.Console.WriteLine("Прозведение таких делителей числа, сумма цифр которых меньше, чем сумма цифр исходного числа {0}", arg0=number)
    System.Console.WriteLine(productOfDivisorsWithSmallerDigitSum number)

//testReduce()
// testDigitTraverse()
// testFavLanguage()
// testCoprimeTraversal()
// testCoprimeTraversalPredicate()
// testEulerFunction()
//testWorkWithNums()

let run () =
    printfn "Введите номер функции (от 1 до 3):"
    let n = System.Int32.Parse(System.Console.ReadLine())
    
    System.Console.WriteLine("Введите число для обработки:")
    let m = System.Int32.Parse(System.Console.ReadLine())

    printfn "\nВыполнение через каррирование:"
    main_curried (n, m)

    printfn "\nВыполнение через суперпозицию:"
    main_composed n m

run ()
