module trab.Bag

open System

type BagItem = {
    Value: double
    Weight: float
}

let execBag = 

    let bagItems = [| { Value = 25.0; Weight = 1.5 };
                  { Value = 39.0; Weight = 2.0 };
                  { Value = 20.0; Weight = 1.2 };
                  { Value = 14.0; Weight = 0.9 };
                  { Value = 11.1; Weight = 1.45};
                  { Value = 11.0; Weight = 3.0 };
                  { Value = 20.0; Weight = 1.9 };
                  { Value = 41.7; Weight = 0.1 };
                  { Value = 11.0; Weight = 1.45}|]

    //Ordena em ordem descrecente pela razão Valor/Peso
    let sortedItems =
        Array.sortByDescending (fun item -> item.Value/item.Weight) bagItems

    let maxBadWeight = 6

    let putItemsInBag (items: BagItem[]) (maxWeight: float) =
        let mutable availableWeight = maxWeight
        Array.fold (fun (acc: float) item ->
                if item.Weight <= availableWeight then
                    availableWeight <- availableWeight - item.Weight
                    acc + item.Value
                else
                    let temp = availableWeight
                    availableWeight <- 0.0
                    acc + item.Value * temp
            ) 0.0 items
        
    let bagValue = putItemsInBag sortedItems maxBadWeight

    Console.WriteLine(bagValue)
    