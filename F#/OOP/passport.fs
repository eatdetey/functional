module passport
open System
open System.Text.RegularExpressions

type Passport
    (
        lastName: string,
        firstName: string,
        patronymic: string,
        gender: string,
        birthDate: DateTime,
        birthPlace: string,
        series: string,
        number: string,
        issuedDate: DateTime,
        issuedBy: string,
        departmentCode: string
    ) =

    do
        if not (Regex.IsMatch(series, @"^\d{4}$")) then
            invalidArg "series" "Серия паспорта должна состоять из 4 цифр."
        if not (Regex.IsMatch(number, @"^\d{6}$")) then
            invalidArg "number" "Номер паспорта должен состоять из 6 цифр."
        if not (Regex.IsMatch(departmentCode, @"^\d{3}-\d{3}$")) then
            invalidArg "departmentCode" "Код подразделения должен быть в формате 000-000."
        if gender <> "М" && gender <> "Ж" then
            invalidArg "gender" "Пол должен быть 'М' или 'Ж'."
        if birthDate > DateTime.Now then
            invalidArg "birthDate" "Дата рождения не может быть в будущем."
        if String.IsNullOrWhiteSpace(lastName) || String.IsNullOrWhiteSpace(firstName) then
            invalidArg "ФИО" "Фамилия и имя обязательны."

    member val LastName = lastName
    member val FirstName = firstName
    member val Patronymic = patronymic
    member val Gender = gender
    member val BirthDate = birthDate
    member val BirthPlace = birthPlace
    member val Series = series
    member val Number = number
    member val IssuedDate = issuedDate
    member val IssuedBy = issuedBy
    member val DepartmentCode = departmentCode

    override this.ToString() =
        $"Паспорт:\n{this.LastName} {this.FirstName} {this.Patronymic}, пол: {this.Gender}\n" +
        $"Дата рождения: {this.BirthDate.ToShortDateString()}, место рождения: {this.BirthPlace}\n" +
        $"Серия: {this.Series}, Номер: {this.Number}\n" +
        $"Код подразделения: {this.DepartmentCode}\n" +
        $"Выдан: {this.IssuedBy} ({this.IssuedDate.ToShortDateString()})"

    override this.Equals(obj) =
        match obj with
        | :? Passport as other ->
            this.Series = other.Series && this.Number = other.Number
        | _ -> false

    override this.GetHashCode() =
        hash (this.Series, this.Number)
