open System

let circle_S radius =
    let pi = 3.14
    pi*radius*radius;

let add_length = fun circle length ->
    circle*length;

let cilinder_S_compose = circle_S >> add_length

let cilinder_S_carry radius length =
    add_length (circle_S radius) length

System.Console.WriteLine("Введите радиус и высоту цилиндра:")
let radius = System.Console.ReadLine() |> Int32.Parse
let length = System.Console.ReadLine() |> Int32.Parse

System.Console.Write("Площадь цилиндра (композиция): ")
System.Console.WriteLine(cilinder_S_compose radius length)
System.Console.Write("Площадь цилиндра (каррирование): ")
System.Console.WriteLine(cilinder_S_carry radius length)