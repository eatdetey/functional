open System
open readList
open frequency
open binaryTree
open lists

//Задание 1
let list = [1; 2; 3; 4; 5; 6]

let testRead () =
    Console.WriteLine("Введите элементы списка: ")
    //let testlist = readListFromKeyboard 10


//Задание 2
let testPrint () =
    printList(list)

//Задание 3, 4
let testReduce () =
    Console.WriteLine("Минимальный элемент: ")
    Console.WriteLine(minList list)

    Console.WriteLine("Сумма четных чисел: ")
    Console.WriteLine(reduceList list (+) (fun a -> a%2=0) 0)

    Console.WriteLine("Количество нечетных элементов: ")
    Console.WriteLine(reduceList list (fun a b-> a+1) (fun a -> a%2<>0) 0)

//Задание 5
let testFrequency () =
    Console.WriteLine("Наиболее часто встречающийся элемент:")
    Console.WriteLine(f7 list)

//Задание 6
let testBinaryTree () =
    let initialWords = ["hello"; "worlde"; "F#"; "functional"]
    let treeFromList = List.fold (fun acc word -> insert word acc) Empty initialWords

    Console.WriteLine(inorder treeFromList)

//Задание 7
let testList () =
    let inputList = [1; 2; 2; 3; 3; 3; 4; 4; 4; 4; 5; 9]
    Console.WriteLine("Наиболее часто встречающийся элемент в списке:")
    Console.WriteLine(mostFrequentElement inputList)

    Console.WriteLine(sprintf "Количество элементов, являющихся квадратом другого элемента:")
    Console.WriteLine(countSquareElements inputList)

testList()