module trab.Closure

open System
open trab.Types.CourseOrProject

let filterByTitle (tit: string) (arr: CourseOrProject list) =
        List.filter (fun item -> item.Titulo.Contains(tit)) arr

let filterByWorkload (fcomp: (int -> bool) option) (arr: CourseOrProject list) =
    match fcomp with
    | Some(func) -> List.filter (fun item -> func item.CargaHoraria) arr
    | None -> arr

let filterByCategory (cat: string) (arr: CourseOrProject list) =
    List.filter (fun item -> item.Categoria = cat) arr

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
