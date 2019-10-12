namespace SerializableSimpleExpression

open Microsoft.FSharp.Quotations.DerivedPatterns
open Microsoft.FSharp.Quotations.Patterns
open System.Reflection


type internal MethodCallParseResults =
    {
        method : MethodInfo
        argOrder : int array 
    }
    
module internal MethodCallParser =
    let private reOrderParams (methodArgs : string array) (passedInArgs : string seq)  =
       passedInArgs
       |> Seq.map (fun a -> Array.findIndex ((=) a) methodArgs)
       |> Seq.toArray
    
    let parse expr =
        match expr with
        | Lambdas (param, body) ->
            match body with
            | Call(_, methodInfo, exprList) ->
                let passedInArgs =
                    List.tryHead param
                    |> Option.map (List.map (fun a -> a.ToString()) >> List.skip 1)
                    
                let methodArgs =
                    exprList
                    |> Seq.map (fun a -> a.ToString())
                    |> Seq.toArray
                    
                passedInArgs
                |> Option.map (reOrderParams methodArgs)
                |> Option.map (fun argOrder ->
                    {
                        method = methodInfo
                        argOrder = argOrder
                    })
            | _ -> None
        | _ -> None

