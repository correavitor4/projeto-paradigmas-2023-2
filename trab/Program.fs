// For more information see https://aka.ms/fsharp-console-apps
let applyOperation opFunction x y = opFunction x y

let sum x y = x + y
let multiply x y = x * y


let sumResult = applyOperation sum 5 7
let multiplyResult = applyOperation multiply 5 6

printfn $"Resultado da soma: %d{sumResult}"
printfn $"Resultado da multiplicação: %d{multiplyResult}"