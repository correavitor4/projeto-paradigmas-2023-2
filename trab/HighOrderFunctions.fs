module trab.HigherOrderFunctions

open System
open trab.Types.BagItem

let maxBadWeight = 6
let execHighOrderFunctions = 

    //Cria uma lista de itens
    let bagItems = [| { Value = 25.0; Weight = 1.5 };
                  { Value = 39.0; Weight = 2.0 };
                  { Value = 20.0; Weight = 1.2 };
                  { Value = 14.0; Weight = 0.9 };
                  { Value = 11.1; Weight = 1.45};
                  { Value = 11.0; Weight = 3.0 };
                  { Value = 20.0; Weight = 1.9 };
                  { Value = 41.7; Weight = 0.1 };
                  { Value = 11.0; Weight = 1.45}|]

    //Função de ordenação (que será colocada dentro de outra funcão)
    let sortFunction item = item.Value/item.Weight 
    
    //A função Array.sortByDescending recebe uma função de ordenação como parâmetro
    //Ordena em ordem descrecente pela razão Valor/Peso
    let sortedItems =
        Array.sortByDescending sortFunction bagItems
    
    //Função que avalia se o item cabe na mochila
    let evaluateItem (acc: float) (item: BagItem) (availableWeight:float)=
        if item.Weight <= availableWeight then
            (acc + item.Value), (availableWeight - item.Weight)
        else
            (acc + item.Value * availableWeight), 0.0
            
    //Função que coloca os itens na mochila
    let putItemsInBag (items: BagItem[]) (maxWeight: float) =
        let mutable availableWeight: float  = maxWeight
        //A função Array.fold recebe uma função acumulação como parâmetro (para ser função de alta ordem)
        Array.fold (fun (acc: float) item ->
                let newAcc, newAvailableWeight = evaluateItem acc item availableWeight
                availableWeight <- newAvailableWeight
                newAcc
            ) 0.0 items
        
    let bagValue = putItemsInBag sortedItems maxBadWeight

    Console.WriteLine(bagValue)
    