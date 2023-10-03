module Trab.FunctorAndMonads

open System
open trab.Types.BagItem


let maxBadWeight = 6

type BagItemFunctor(item: BagItem) =
    member this.Map(f) =
        { item with Value = f item.Value }

let execFunctorAndMonads =
    let bagItems = [
        { Value = 25.0; Weight = 1.5 };
        { Value = 39.0; Weight = 2.0 };
        { Value = 20.0; Weight = 1.2 };
        { Value = 14.0; Weight = 0.9 };
        { Value = 11.1; Weight = 1.45 };
        { Value = 11.0; Weight = 3.0 };
        { Value = 20.0; Weight = 1.9 };
        { Value = 41.7; Weight = 0.1 };
        { Value = 11.0; Weight = 1.45 }
    ]

    let sortFunction item = item.Value / item.Weight
    

    let sortedItems =
        bagItems
        |> List.sortByDescending (fun item -> sortFunction item)



    let evaluateItem (acc, availableWeight) item =
        if item.Weight <= availableWeight then
            (acc + item.Value, availableWeight - item.Weight)
        else
            (acc + item.Value * availableWeight, 0.0)

    let putItemsInBag items maxWeight =
        let rec putItems acc availableWeight = function
            | [] -> (acc, availableWeight)
            | item :: rest ->
                let newAcc, newAvailableWeight = evaluateItem (acc, availableWeight) item
                if newAvailableWeight > 0.0 then
                    putItems newAcc newAvailableWeight rest
                else
                    (newAcc, newAvailableWeight)

        let result, _ = putItems 0.0 maxWeight items
        result

    let bagValue = putItemsInBag sortedItems maxBadWeight

    let mapBagItems f bagItems =
        bagItems
        |> List.map (fun item -> { item with Value = f item.Value })


    printfn "%f" bagValue

    Console.WriteLine(mapBagItems (fun x -> x * 2.0) bagItems)

    