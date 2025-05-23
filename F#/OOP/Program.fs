open System
open geometricFigures
open maybe
open textAnalyze
open FParsec
open agent
open passport

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

//testGeometricFigures()

let testFunctorMonad() =
    let m = Just 10
    let nothing = Nothing
    let f = (+) 1
    let g = (*) 2

    printfn "Функтор – идентичность: %b" (functor_identity_test m)
    printfn "Функтор – композиция: %b" (functor_composition_test m f g)

    printfn "Аппликатив – идентичность: %b" (applicative_identity_test m)
    printfn "Аппликатив – гомоморфизм: %b" (applicative_homomorphism_test f 3)
    printfn "Аппликатив – интерчейндж: %b" (applicative_interchange_test (Just f) 3)

    let fM x = Just (x + 1)
    let gM x = Just (x * 2)

    printfn "Монада – left identity: %b" (monad_left_identity_test 5 fM)
    printfn "Монада – right identity: %b" (monad_right_identity_test m)
    printfn "Монада – ассоциативность: %b" (monad_associativity_test m fM gM)

//testFunctorMonad()

let testTextAnalyze () =
    let input = "5 + 3 - 2"
    match run exprParser input with
    | Success(result, _, _) ->
        printfn "Результат разбора: %A" result
        printfn "Вычисление: %d" (eval result)
    | Failure(msg, _, _) ->
        printfn "Ошибка парсинга: %s" msg

//testTextAnalyze()

let testAgent () =
    let logger = LogAgent()

    logger.Post(Print "Привет, мир!")
    logger.Post(Error "Что-то пошло не так.")
    logger.Post(Print "Работаем дальше...")
    logger.Post(Exit)

    System.Threading.Thread.Sleep(1000)

//testAgent()

let testPassport () =
    let passport = Passport(
        lastName = "Иванов",
        firstName = "Иван",
        patronymic = "Иванович",
        gender = "М",
        birthDate = DateTime(1990, 1, 15),
        birthPlace = "г. Москва",
        series = "1234",
        number = "567890",
        issuedDate = DateTime(2010, 5, 20),
        issuedBy = "ОВД г. Москвы",
        departmentCode = "770-001"
    )

    printfn "%s\n" (passport.ToString())

testPassport()