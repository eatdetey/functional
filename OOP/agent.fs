module agent

type LogMessage =
    | Print of string
    | Error of string
    | Exit

type LogAgent() =
    let agent = MailboxProcessor.Start(fun inbox ->
        let rec loop () =
            async {
                let! msg = inbox.Receive()
                match msg with
                | Print text ->
                    printfn "[INFO] %s" text
                    return! loop()
                | Error err ->
                    printfn "[ERROR] %s" err
                    return! loop()
                | Exit ->
                    printfn "Агент завершает работу."
                    return ()
            }
        loop()
    )

    member _.Post(msg: LogMessage) = agent.Post(msg)
