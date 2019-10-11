namespace SerializableSimpleExpression

open FSharpPlus
open Microsoft.FSharp.Quotations.DerivedPatterns
open Microsoft.FSharp.Quotations.Patterns
open System.Reflection


type internal MethodCallParseResults =
    {
        method : MethodInfo
        args : obj array 
    }
    
module internal MethodCallParser =
    let x (xs : int list) = monad {
        let! h = tryHead xs
        return h
    }
    
    let parse expr =
        match expr with
        | Lambdas (param, body) ->
            match body with
            | Call(exprOpt, methodInfo, exprList) ->
                Some 1
            | _ -> None
        | _ -> None

