module geometricFigures
open System

type IPrint =
    abstract member Print : unit -> unit

[<AbstractClass>]
type GeometricFigure() =
    abstract member Area : unit -> float
    override this.ToString() = "Геометрическая фигура"

type Rectangle(width: float, height: float) =
    inherit GeometricFigure()
    member this.Width = width
    member this.Height = height
    override this.Area() = this.Width * this.Height
    override this.ToString() =
        sprintf "Прямоугольник: ширина = %.2f, высота = %.2f, площадь = %.2f" this.Width this.Height (this.Area())
    interface IPrint with
        member this.Print() = 
            printfn "%s" (this.ToString())

type Square(side: float) =
    inherit Rectangle(side, side)
    override this.ToString() =
        sprintf "Квадрат: сторона = %.2f, площадь = %.2f" side (this.Area())
    interface IPrint with
        member this.Print() =
            printfn "%s" (this.ToString())

type Circle(radius: float) =
    inherit GeometricFigure()
    member this.Radius = radius
    override this.Area() = Math.PI * this.Radius * this.Radius
    override this.ToString() =
        sprintf "Круг: радиус = %.2f, площадь = %.2f" this.Radius (this.Area())
    interface IPrint with
        member this.Print() =
            printfn "%s" (this.ToString())

type GeometricFigureDiscriminated =
    | RectangleD of width: float * height: float
    | SquareD of side: float
    | CircleD of radius: float

let area figure =
    match figure with
    | RectangleD (w, h) -> w * h
    | SquareD s -> s * s
    | CircleD r -> Math.PI * r * r
