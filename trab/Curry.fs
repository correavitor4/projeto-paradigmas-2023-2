module trab.Curry

open trab.Types.CourseOrProject

let filterByCategory (cat: string) (arr: CourseOrProject list) =
    List.filter (fun item -> item.Categoria = cat) arr
    
let filterByWorkload (min: int) (max: int) (arr: CourseOrProject list) =
    let res = List.filter (fun item -> item.CargaHoraria >= min && item.CargaHoraria <= max) arr
    let toReturn filterString =  filterByCategory filterString res
    toReturn
    
let filterByTitle (tit: string) (arr: CourseOrProject list) =
    let res = List.filter (fun item -> item.Titulo.Contains(tit)) arr
    let toReturn min max = filterByWorkload min max res
    toReturn
    
let execCurry =
    let filter1 = [
        { Titulo = "Exercício de academia"; CargaHoraria = 10; Categoria = "curso" }
        { Titulo = "dasdasdsa academia"; CargaHoraria = 20; Categoria = "curso" }
        { Titulo = "fdsfdsfsd academia"; CargaHoraria = 30; Categoria = "curso" }
        { Titulo = "gfdgfd academia"; CargaHoraria = 40; Categoria = "projeto" }
        { Titulo = "arte sdsa da"; CargaHoraria = 10; Categoria = "curso" }
        { Titulo = "dsasa arte dsadas"; CargaHoraria = 20; Categoria = "projeto" }
        { Titulo = "dsadsa arte dsadas"; CargaHoraria = 20; Categoria = "curso" }
        { Titulo = "dsds arte"; CargaHoraria = 30; Categoria = "projeto" }
    ]


    let filteredData =
        filterByTitle "arte" filter1 10 20 "projeto"
        // filterByTitle "arte"
        // >> filterByWorkload (Some(fun ch -> ch >= 10 && ch <= 40))
        // >> filterByCategory "projeto"
        // <| filter1
        
    let printFilteredData = 
        fun filteredData ->
            printfn "Resultados da filtragem:"
            List.iter (fun item ->
                printfn "Título: %s, Carga Horária: %d, Categoria: %s"
                    item.Titulo item.CargaHoraria item.Categoria
            ) filteredData

    printFilteredData filteredData
