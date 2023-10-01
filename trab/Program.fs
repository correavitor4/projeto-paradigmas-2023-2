module main

open trab.HigherOrderFunctions
open trab.Curry
open trab.Utils
open trab.Utils.Pause

[<EntryPoint>]
let main _ =
    execHighOrderFunctions
    makePause None
    execCurry
    0