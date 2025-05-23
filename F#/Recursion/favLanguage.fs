module favLanguage

let favLanguage answer:string =
    match answer with
    | "F#" -> "Подлиза!"
    | "Prolog" -> "Подлиза!"
    | "Python" -> "Ха-ха, напиши код в парадигме ООП!"
    | "Go" -> "Филипп, делай лабы на нормальном языке, зачем ты себя мучаешь?"
    | _ -> "Прикол!"