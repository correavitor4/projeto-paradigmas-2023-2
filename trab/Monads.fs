module trab.Monads

//Monads são uma forma de encapsular um valor em um contexto.
//Eles são usados para representar computações que podem falhar, ou que podem
//retornar múltiplos valores, ou que precisam de acesso a algum estado global,
//ou que são apenas complicadas de se fazer com funções normais.

open trab.Types.CourseOrProject

let filterByTitle (tit: string) (arr: Option<CourseOrProject list>) =
    match arr with
    | Some(arr) ->
        let res = List.filter (fun item -> item.Titulo.Contains(tit)) arr
        if res.Length > 0 then
            Some(res)
        else
            None
    | None ->
        None


let filterByWorkload (fcomp: (int -> bool) option) (arr: Option<CourseOrProject list>) =
    match fcomp with
    | Some(func) ->
        match arr with
        | Some(arr) ->
            let res = List.filter (fun item -> func item.CargaHoraria) arr
            if res.Length > 0 then
                Some(res)
            else
                None

        | None -> None
        
    | None -> arr

let filterByCategory (cat: string) (arr: Option<CourseOrProject list>) =
    match arr with
    | Some(arr) ->
        let res = List.filter (fun item -> item.Categoria = cat) arr
        if res.Length > 0 then
            Some(res)
        else
            None
        
    | None -> None
        
let filter1 = Some([
        { Titulo = "Exercício de academia"; CargaHoraria = 10; Categoria = "curso" }
        { Titulo = "dasdasdsa academia"; CargaHoraria = 20; Categoria = "curso" }
        { Titulo = "fdsfdsfsd academia"; CargaHoraria = 30; Categoria = "curso" }
        { Titulo = "gfdgfd academia"; CargaHoraria = 40; Categoria = "projeto" }
        { Titulo = "arte sdsa da"; CargaHoraria = 10; Categoria = "curso" }
        { Titulo = "dsasa arte dsadas"; CargaHoraria = 20; Categoria = "projeto" }
        { Titulo = "dsadsa arte dsadas"; CargaHoraria = 20; Categoria = "curso" }
        { Titulo = "dsds arte"; CargaHoraria = 30; Categoria = "projeto" }
])


    
let getFilterResults =
    (filterByTitle "academia" filter1)
    |> filterByWorkload (Some(fun x -> x > 20))
    |> filterByCategory "curso"
    
let execMonad =
    let res = getFilterResults
    match res with
    | Some(res) ->
        printfn "Resultados:"
        for item in res do
            printfn "%s" item.Titulo
    | None ->
        //Fail
        failwith "Nenhum resultado encontrado"