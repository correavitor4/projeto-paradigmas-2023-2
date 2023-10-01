module trab.Curry

open trab.Types.CourseOrProject

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

    let filterByTitle (tit: string) (arr: CourseOrProject list) =
        List.filter (fun item -> item.Titulo.Contains(tit)) arr

    let filterByWorkload (fcomp: (int -> bool) option) (arr: CourseOrProject list) =
        match fcomp with
        | Some(func) -> List.filter (fun item -> func item.CargaHoraria) arr
        | None -> arr

    let filterByCategory (cat: string) (arr: CourseOrProject list) =
        List.filter (fun item -> item.Categoria = cat) arr

    let filteredByTitle = filterByTitle "academia"
    let filteredByWorkload = filterByWorkload (Some(fun ch -> ch >= 10 && ch <= 40))
    let filteredByCategory = filterByCategory "projeto"

    let filteredData =
        filteredByTitle >> filteredByWorkload >> filteredByCategory <| filter1
    let printFilteredData = 
        fun filteredData ->
            printfn "Resultados da filtragem:"
            List.iter (fun item ->
                printfn "Título: %s, Carga Horária: %d, Categoria: %s"
                    item.Titulo item.CargaHoraria item.Categoria
            ) filteredData

    printFilteredData filteredData
