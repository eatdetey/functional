open System
open System.Windows
open System.Windows.Controls
open System.Windows.Media

[<EntryPoint>]
[<STAThread>]
let main _ =
    let app = new Application()
    
    let window = Window(
        Title = "Калькулятор на F#",
        Width = 350.0,
        Height = 350.0,
        WindowStartupLocation = WindowStartupLocation.CenterScreen,
        FontSize = 16.0
    )

    // Основная сетка
    let grid = Grid(Margin = Thickness(15.0))
    
    // Определяем строки
    grid.RowDefinitions.Add(RowDefinition(Height = GridLength.Auto))
    grid.RowDefinitions.Add(RowDefinition(Height = GridLength.Auto))
    grid.RowDefinitions.Add(RowDefinition(Height = GridLength.Auto))
    grid.RowDefinitions.Add(RowDefinition(Height = GridLength.Auto))
    grid.RowDefinitions.Add(RowDefinition(Height = GridLength.Auto))
    grid.RowDefinitions.Add(RowDefinition(Height = GridLength.Auto))

    // Создаем элементы с подписями
    let lblNum1 = Label(Content = "Число 1:", Margin = Thickness(5.0))
    let txtNum1 = TextBox(Margin = Thickness(5.0))

    let lblNum2 = Label(Content = "Число 2:", Margin = Thickness(5.0))
    let txtNum2 = TextBox(Margin = Thickness(5.0))

    let lblResult = Label(Content = "Результат:", Margin = Thickness(5.0))
    let txtResult = TextBox(Margin = Thickness(5.0), IsReadOnly = true)

    // Кнопки операций
    let btnAdd = Button(Content = "+", Width = 50.0, Margin = Thickness(5.0))
    let btnSub = Button(Content = "-", Width = 50.0, Margin = Thickness(5.0))
    let btnMul = Button(Content = "×", Width = 50.0, Margin = Thickness(5.0))
    let btnDiv = Button(Content = "÷", Width = 50.0, Margin = Thickness(5.0))

    // Панель для кнопок
    let buttonPanel = StackPanel(
        Orientation = Orientation.Horizontal,
        HorizontalAlignment = HorizontalAlignment.Center,
        Margin = Thickness(0.0, 10.0, 0.0, 10.0)
    )
    buttonPanel.Children.Add(btnAdd) |> ignore
    buttonPanel.Children.Add(btnSub) |> ignore
    buttonPanel.Children.Add(btnMul) |> ignore
    buttonPanel.Children.Add(btnDiv) |> ignore

    // Размещаем элементы в сетке
    Grid.SetRow(lblNum1, 0)
    Grid.SetColumn(lblNum1, 0)
    Grid.SetRow(txtNum1, 1)
    Grid.SetColumn(txtNum1, 0)

    Grid.SetRow(lblNum2, 2)
    Grid.SetColumn(lblNum2, 0)
    Grid.SetRow(txtNum2, 3)
    Grid.SetColumn(txtNum2, 0)

    Grid.SetRow(buttonPanel, 4)
    Grid.SetColumn(buttonPanel, 0)

    Grid.SetRow(lblResult, 5)
    Grid.SetColumn(lblResult, 0)
    Grid.SetRow(txtResult, 6)
    Grid.SetColumn(txtResult, 0)

    // Добавляем элементы в сетку
    grid.Children.Add(lblNum1) |> ignore
    grid.Children.Add(txtNum1) |> ignore
    grid.Children.Add(lblNum2) |> ignore
    grid.Children.Add(txtNum2) |> ignore
    grid.Children.Add(buttonPanel) |> ignore
    grid.Children.Add(lblResult) |> ignore
    grid.Children.Add(txtResult) |> ignore

    // Функция безопасного парсинга
    let tryParseDouble (text: string) =
        match Double.TryParse(text) with
        | true, num -> Some num
        | false, _ -> None

    // Вычисление с проверкой деления на ноль
    let compute num1 num2 op =
        match op with
        | "add" -> num1 + num2
        | "subtract" -> num1 - num2
        | "multiply" -> num1 * num2
        | "divide" -> 
            if num2 = 0.0 then 
                MessageBox.Show("Ошибка: деление на ноль!", "Ошибка", 
                              MessageBoxButton.OK, MessageBoxImage.Error) |> ignore
                Double.PositiveInfinity
            else num1 / num2
        | _ -> Double.NaN

    // Обработчик операций
    let handleOperation op =
        match tryParseDouble txtNum1.Text, tryParseDouble txtNum2.Text with
        | Some num1, Some num2 ->
            let result = compute num1 num2 op
            txtResult.Text <-
                if Double.IsInfinity(result) then "∞"
                elif Double.IsNaN(result) then "Ошибка"
                else result.ToString("G6")
        | None, _ ->
            MessageBox.Show("Введите корректное первое число!", "Ошибка", 
                          MessageBoxButton.OK, MessageBoxImage.Warning) |> ignore
        | _, None ->
            MessageBox.Show("Введите корректное второе число!", "Ошибка", 
                          MessageBoxButton.OK, MessageBoxImage.Warning) |> ignore

    // Назначение обработчиков
    btnAdd.Click.Add(fun _ -> handleOperation "add")
    btnSub.Click.Add(fun _ -> handleOperation "subtract")
    btnMul.Click.Add(fun _ -> handleOperation "multiply")
    btnDiv.Click.Add(fun _ -> handleOperation "divide")

    window.Content <- grid
    app.Run(window)