module main

open trab.HigherOrderFunctions
open trab.Curry
open trab.Closure
open trab.Utils.Pause
open Trab.Functor
open trab.Monads

[<EntryPoint>]
let main _ =
    execHighOrderFunctions
    makePause None
    execCurry
    makePause None
    execClosure
    makePause None
    execFunctor
    makePause None
    execMonad
    0