open System
open geometricFigures

let testGeometricFigures() =
    let rect = Rectangle(3.0, 4.0) :> IPrint
    let square = Square(5.0) :> IPrint
    let circle = Circle(2.5) :> IPrint

    rect.Print()
    square.Print()
    circle.Print()

    let fig1 = RectangleD(3.0, 4.0)
    let fig2 = SquareD(5.0)
    let fig3 = CircleD(2.5)

    printfn "Площадь прямоугольника: %.2f" (area fig1)
    printfn "Площадь квадрата: %.2f" (area fig2)
    printfn "Площадь круга: %.2f" (area fig3)

testGeometricFigures()