open System
open System.Windows.Forms
open System.Drawing

[<EntryPoint>]
[<STAThread>]
let main _ =
    let form = new Form(Text = "Калькулятор на F#", Width = 450, Height = 350, 
                       Font = new Font("Arial", 12.0f),
                       StartPosition = FormStartPosition.CenterScreen)

    let lblNum1 = new Label(Text = "Число 1:", Top = 30, Left = 30, Width = 100)
    let txtNum1 = new TextBox(Top = 30, Left = 140, Width = 200)

    let lblNum2 = new Label(Text = "Число 2:", Top = 80, Left = 30, Width = 100)
    let txtNum2 = new TextBox(Top = 80, Left = 140, Width = 200)

    let lblResult = new Label(Text = "Результат:", Top = 180, Left = 30, Width = 100)
    let txtResult = new TextBox(Top = 180, Left = 140, Width = 200, ReadOnly = true)

    let btnAdd = new Button(Text = "+", Top = 130, Left = 140, Width = 45, Height = 30)
    let btnSub = new Button(Text = "-", Top = 130, Left = 190, Width = 45, Height = 30)
    let btnMul = new Button(Text = "*", Top = 130, Left = 240, Width = 45, Height = 30)
    let btnDiv = new Button(Text = "/", Top = 130, Left = 290, Width = 45, Height = 30)

    let tryParseDouble (text: string) =
        match Double.TryParse(text, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture) with
        | true, num -> Some num
        | false, _ -> None

    let compute op num1 num2 =
        match op with
        | "divide" -> 
            if num2 = 0.0 then 
                MessageBox.Show("Ошибка: деление на ноль!", "Ошибка", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error) |> ignore
                "∞"
            else
                (num1 / num2).ToString("G6")
        | "add" -> (num1 + num2).ToString("G6")
        | "subtract" -> (num1 - num2).ToString("G6")
        | "multiply" -> (num1 * num2).ToString("G6")
        | _ -> "Неизвестная операция"

    let handleOperation op =
        let num1Opt = tryParseDouble txtNum1.Text
        let num2Opt = tryParseDouble txtNum2.Text

        match num1Opt, num2Opt with
        | Some num1, Some num2 ->
            txtResult.Text <- compute op num1 num2
        | None, _ -> 
            MessageBox.Show("Некорректное число 1!", "Ошибка ввода",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning) |> ignore
        | _, None -> 
            MessageBox.Show("Некорректное число 2!", "Ошибка ввода",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning) |> ignore

    btnAdd.Click.Add(fun _ -> handleOperation "add")
    btnSub.Click.Add(fun _ -> handleOperation "subtract")
    btnMul.Click.Add(fun _ -> handleOperation "multiply")
    btnDiv.Click.Add(fun _ -> handleOperation "divide")

    form.Controls.AddRange [|
        lblNum1 :> Control; txtNum1 :> Control;
        lblNum2 :> Control; txtNum2 :> Control;
        lblResult :> Control; txtResult :> Control;
        btnAdd :> Control; btnSub :> Control; 
        btnMul :> Control; btnDiv :> Control
    |]

    Application.Run(form)
    0