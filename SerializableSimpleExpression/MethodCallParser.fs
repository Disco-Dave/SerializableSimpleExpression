namespace SerializableSimpleExpression

open Microsoft.FSharp.Quotations
open Microsoft.FSharp.Quotations.DerivedPatterns
open Microsoft.FSharp.Quotations.Patterns
open System.Linq.Expressions



module internal MethodCallParser =
    let parse expr =
        match expr with
        | Lambda (param, body) ->
            match body with
            | Call(exprOpt, methodInfo, exprList) ->
                ()
            | _ -> ()
        | _ -> ()

