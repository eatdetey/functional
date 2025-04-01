open System
open readList
open frequency
open binaryTree
open lists
open array

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

//Задание 7, 8
let testList () =
    let inputList = [1; 2; 2; 3; 3; 3; 4; 4; 4; 4; 5; 9]
    Console.WriteLine("Наиболее часто встречающийся элемент в списке:")
    Console.WriteLine(mostFrequentElement inputList)

    Console.WriteLine(sprintf "Количество элементов, являющихся квадратом другого элемента:")
    Console.WriteLine(countSquareElements inputList)

//Задание 9
let testTuples () =
    let listA = [3; 1; 4; 2]
    let listB = [14; 32; 23; 42]
    let listC = [12; 18; 24; 30]
    let tuples = createTupleList listA listB listC
    Console.WriteLine("Список кортежей:")
    tuples |> List.iter (fun (a, b, c) -> Console.WriteLine(sprintf "(%d, %d, %d)" a b c))


//Задание 10
let testReadStrings () =
    Console.WriteLine("Введите строки (пустая строка для остановки ввода):")
    let stringList = readStrings()
    Console.WriteLine(sortStringsByLength stringList)

//Задание 11-16
let testListProccessin () =
    Console.WriteLine("\nОбработка списков:")
    let testList = [3; 8; 2; 7; 5; 1]

    let shiftedRight2 = shiftRight2List testList
    Console.WriteLine("Циклический сдвиг вправо на 2 позиции:")
    Console.WriteLine(printList shiftedRight2)

    let swappedMinMax = swapMinMaxList testList
    Console.WriteLine("Поменяли местами мин. и макс. элементы:")
    Console.WriteLine(printList swappedMinMax)

    let shiftedLeft1 = shiftLeft1List testList
    Console.WriteLine("Циклический сдвиг влево на 1 позицию:")
    Console.WriteLine(printList shiftedLeft1)

    let smallerIndices = findIndicesList testList
    Console.WriteLine("Индексы элементов, которые меньше левого соседа:")
    Console.WriteLine(printList smallerIndices)
    
    let allDivisors = divisorsList testList
    Console.WriteLine("Все положительные делители списка без повторений:")
    Console.WriteLine(printList allDivisors)

    let countGreater = countElementsList testList
    Console.WriteLine("Количество элементов, больших суммы всех предыдущих:")
    Console.WriteLine(countGreater)

let testChurchProccessing () =
    Console.WriteLine("\nОбработка списков Черча:")
    let testList = [3; 8; 2; 7; 5; 1]

    let shiftedRight2 = shiftRight2 testList
    Console.WriteLine("Циклический сдвиг вправо на 2 позиции:")
    Console.WriteLine(printList shiftedRight2)

    let swappedMinMax = swapMinMax testList
    Console.WriteLine("Поменяли местами мин. и макс. элементы:")
    Console.WriteLine(printList swappedMinMax)

    let shiftedLeft1 = shiftLeft1 testList
    Console.WriteLine("Циклический сдвиг влево на 1 позицию:")
    Console.WriteLine(printList shiftedLeft1)

    let smallerIndices = findIndices testList
    Console.WriteLine("Индексы элементов, которые меньше левого соседа:")
    Console.WriteLine(printList smallerIndices)
    
    let allDivisors = divisors testList []
    Console.WriteLine("Все положительные делители списка без повторений:")
    Console.WriteLine(printList allDivisors)

    let countGreater = countElements testList
    Console.WriteLine("Количество элементов, больших суммы всех предыдущих:")
    Console.WriteLine(countGreater)


testListProccessin()
testChurchProccessing()