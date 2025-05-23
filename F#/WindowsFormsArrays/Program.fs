open System
open System.Windows.Forms
open System.Drawing

[<EntryPoint>]
[<STAThread>]
let main _ =
    let form = new Form(Text = "Объединение массивов", 
                       Width = 600, 
                       Height = 450,
                       Font = new Font("Segoe UI", 10.0f),
                       StartPosition = FormStartPosition.CenterScreen,
                       FormBorderStyle = FormBorderStyle.FixedDialog,
                       MaximizeBox = false)

    let mainPanel = new Panel(Dock = DockStyle.Fill, Padding = Padding(20))
    
    let groupBox1 = new GroupBox(Text = "Первый массив чисел",
                                Height = 100,
                                Dock = DockStyle.Top,
                                Padding = Padding(10))
    let lblArray1 = new Label(Text = "Вводите числа через запятую", 
                             Dock = DockStyle.Top,
                             Margin = Padding(0, 0, 0, 5))
    let txtArray1 = new TextBox(Dock = DockStyle.Top)
    groupBox1.Controls.AddRange([| lblArray1; txtArray1 |])

    let groupBox2 = new GroupBox(Text = "Второй массив чисел",
                                Height = 100,
                                Dock = DockStyle.Top,
                                Padding = Padding(10),
                                Top = groupBox1.Bottom + 10)
    let lblArray2 = new Label(Text = "Вводите числа через запятую", 
                             Dock = DockStyle.Top,
                             Margin = Padding(0, 0, 0, 5))
    let txtArray2 = new TextBox(Dock = DockStyle.Top)
    groupBox2.Controls.AddRange([| lblArray2; txtArray2 |])

    let btnMerge = new Button(Text = "Объединить массивы",
                             Height = 40,
                             Dock = DockStyle.Top,
                             Top = groupBox2.Bottom + 20,
                             BackColor = Color.LightSteelBlue,
                             FlatStyle = FlatStyle.Flat)
    btnMerge.FlatAppearance.BorderSize <- 0

    let groupBoxResult = new GroupBox(Text = "Результат объединения",
                                     Dock = DockStyle.Fill,
                                     Top = btnMerge.Bottom + 10,
                                     Padding = Padding(10))
    let txtResult = new TextBox(Multiline = true,
                               Dock = DockStyle.Fill,
                               ScrollBars = ScrollBars.Vertical,
                               Font = new Font("Consolas", 10.0f),
                               ReadOnly = true)
    groupBoxResult.Controls.Add(txtResult)

    let parseArray (input: string) =
        try
            input.Split([|','; ' '|], StringSplitOptions.RemoveEmptyEntries)
            |> Array.map (fun s -> s.Trim())
            |> Array.map Double.Parse
            |> Some
        with _ -> None

    btnMerge.Click.Add(fun _ ->
        match parseArray txtArray1.Text, parseArray txtArray2.Text with
        | Some arr1, Some arr2 ->
            let merged = Array.append arr1 arr2
            txtResult.Text <- sprintf "Объединенный массив (%d элементов):\r\n[%s]" 
                                      merged.Length 
                                      (String.Join("; ", merged))
        | None, _ -> 
            MessageBox.Show("Некорректный формат первого массива!\nПример правильного ввода: 1, 2, 3.5", 
                          "Ошибка ввода", 
                          MessageBoxButtons.OK, 
                          MessageBoxIcon.Error) |> ignore
        | _, None ->
            MessageBox.Show("Некорректный формат второго массива!\nПример правильного ввода: 4, 5.2, 6", 
                          "Ошибка ввода", 
                          MessageBoxButtons.OK, 
                          MessageBoxIcon.Error) |> ignore
    )

    mainPanel.Controls.AddRange([|
        groupBoxResult :> Control
        btnMerge :> Control
        groupBox2 :> Control
        groupBox1 :> Control
    |])

    form.Controls.Add(mainPanel)
    Application.Run(form)
    0