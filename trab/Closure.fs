module trab.Closure

open System
open trab.Types.CourseOrProject
open trab.Curry

let getClosure =
    let itemsRef = ref [
        { Titulo = "Exercício de academia"; CargaHoraria = 10; Categoria = "curso" }
        { Titulo = "dasdasdsa academia"; CargaHoraria = 20; Categoria = "curso" }
        { Titulo = "fdsfdsfsd academia"; CargaHoraria = 30; Categoria = "curso" }
        { Titulo = "gfdgfd academia"; CargaHoraria = 40; Categoria = "projeto" }
        { Titulo = "arte sdsa da"; CargaHoraria = 10; Categoria = "curso" }
        { Titulo = "dsasa arte dsadas"; CargaHoraria = 20; Categoria = "projeto" }
        { Titulo = "dsadsa arte dsadas"; CargaHoraria = 20; Categoria = "curso" }
        { Titulo = "dsds arte"; CargaHoraria = 30; Categoria = "projeto" }
    ]
    
    let filterItemsByTitle title =
        let temp =  filterByTitle title itemsRef.Value
        itemsRef.Value <- temp
        
    let filterByCategory category =
        let temp = filterByCategory category itemsRef.Value
        itemsRef.Value <- temp
    
    let filterByWorkload workload =
        let temp = filterByWorkload workload itemsRef.Value
        itemsRef.Value <- temp
    
    let getItems () =
        itemsRef.Value
            
    filterItemsByTitle, filterByCategory, filterByWorkload, getItems
    
    
let execClosure = 
    let filterItemsByTitle, filterByCategory, filterByWorkload, getItems = getClosure
    
    filterItemsByTitle "arte"
    filterByCategory "curso"
    filterByWorkload (Some(fun x -> x >= 10))
    
    let items = getItems ()
    
    for item in items do
        Console.WriteLine(item)
