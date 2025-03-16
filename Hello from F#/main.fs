open Quadratic
open Sphere
open Digits
open System

[<EntryPoint>]
//Задание №1
printfn "Hello from F#"

//Задание №2
System.Console.Write("Введите коэффициенты квадратного уравнения через пробел: ")
let coeffs = System.Console.ReadLine().Split() |> Array.map Int32.Parse
let a,b,c = coeffs.[0], coeffs.[1], coeffs.[2]

System.Console.Write("Корень квадратного уравнения: ")
System.Console.WriteLine(solve(a,b,c))

//Заданте №3
System.Console.WriteLine("Введите радиус и высоту цилиндра (с новой строки):")
let radius = System.Console.ReadLine() |> Int32.Parse
let length = System.Console.ReadLine() |> Int32.Parse

System.Console.Write("Площадь цилиндра (композиция): ")
System.Console.WriteLine(cilinder_S_compose radius length)
System.Console.Write("Площадь цилиндра (каррирование): ")
System.Console.WriteLine(cilinder_S_carry radius length)

//Задание №4 и №5
System.Console.Write("Введите число для получения суммы его цифр: ")
let value = System.Console.ReadLine() |> Int32.Parse

System.Console.Write("Сумма цифр числа (рекурсия вниз): ")
System.Console.WriteLine(digits_Sum(value))
System.Console.Write("Сумма цифр числа (рекурсия вверх): ")
System.Console.WriteLine(digits_Sum_down(value))