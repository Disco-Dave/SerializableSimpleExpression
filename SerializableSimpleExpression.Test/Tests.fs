module Tests

open System
open Xunit
open SerializableSimpleExpression

type ExampleClass () =
    member __.SomeMethod (a, b) = a + b

[<Fact>]
let ``My test`` () =
    MethodCallParser.parse <@ (fun (ec : ExampleClass, a, b) -> ec.SomeMethod(a, b)) @> |> ignore
    Assert.True(true)
