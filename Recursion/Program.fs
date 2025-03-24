open fibonacci
open menu
open reduce
open digit
open favLanguage

//Пара
System.Console.WriteLine(fibon(19))
System.Console.WriteLine(fibon_down(19))

//Задание 6
System.Console.WriteLine(menu(true, 5))

//Задание 7
System.Console.WriteLine(reduce 5 sumly 1)

//Задание 8
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
let testNumT9 = 123456

let sumEvenDigits = conditionalReduce testNumT9 (fun acc d -> acc + d) 0 (fun d -> d % 2 = 0)
System.Console.WriteLine("Сумма четных цифр: " + sumEvenDigits.ToString())

let productGreaterThanThree = conditionalReduce testNumT9 (fun acc d -> acc * d) 1 (fun d -> d > 3)
System.Console.WriteLine("Произведение цифр больше 3: " + productGreaterThanThree.ToString())

let maxOddDigit = conditionalReduce testNumT9 (fun acc d -> if acc > d then acc else d) -1 (fun d -> d % 2 <> 0)
System.Console.WriteLine("Максимальная нечетная цифра: " + maxOddDigit.ToString())

//Задание 11
System.Console.WriteLine("Введите название своего любимого языка программирования: ")

let answer = System.Console.ReadLine()

System.Console.WriteLine(favLanguage answer)