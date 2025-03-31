open System
open readList

//Задание 1
Console.WriteLine("Введите элементы списка: ")
let list = readListFromKeyboard 5

//Задание 2
let testPrint () =
    printList(list)

//Задание 3
let testReduce () =
    Console.WriteLine("Минимальный элемент: ")
    Console.WriteLine(minList list)

    Console.WriteLine("Сумма четных чисел: ")
    Console.WriteLine(reduceList list (+) (fun a -> a%2=0) 0)

    Console.WriteLine("Количество нечетных элементов: ")
    Console.WriteLine(reduceList list (fun a b-> a+1) (fun a -> a%2<>0) 0)

//Задание 4