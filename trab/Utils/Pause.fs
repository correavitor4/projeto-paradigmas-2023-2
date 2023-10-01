module trab.Utils.Pause

open System

let makePause (optionalText) =
    let text = match optionalText with
                   | Some t -> t
                   | None -> "Press any key to continue..."
                   
    Console.WriteLine(text)
    Console.ReadKey() |> ignore