module main

open trab.HigherOrderFunctions
open trab.Curry
open trab.Closure
open trab.Utils.Pause
open Trab.FunctorAndMonads

[<EntryPoint>]
let main _ =
    execHighOrderFunctions
    makePause None
    execCurry
    makePause None
    execClosure
    makePause None
    execFunctorAndMonads
    0