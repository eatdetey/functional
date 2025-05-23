module textAnalyze
open FParsec

type Expr =
    | Number of int
    | Add of Expr * Expr
    | Sub of Expr * Expr

let pnumber: Parser<Expr, unit> =
    pint32 |>> Number

let ws = spaces
let str_ws s = pstring s .>> ws

let exprParser: Parser<Expr, unit> =
    let opp = new OperatorPrecedenceParser<Expr, unit, unit>()
    let term = pnumber .>> ws
    opp.TermParser <- term
    opp.AddOperator(InfixOperator("+", ws, 1, Associativity.Left, fun x y -> Add(x, y)))
    opp.AddOperator(InfixOperator("-", ws, 1, Associativity.Left, fun x y -> Sub(x, y)))
    opp.ExpressionParser

let rec eval expr =
    match expr with
    | Number n -> n
    | Add (a, b) -> eval a + eval b
    | Sub (a, b) -> eval a - eval b
