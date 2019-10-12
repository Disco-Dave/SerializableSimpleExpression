module Tests

open System
open Xunit
open SerializableSimpleExpression

type ExampleClass () =
    member __.SomeMethod (a, b) = a + b

[<Fact>]
let ``My test`` () =
    let results = MethodCallParser.parse <@ (fun (ec : ExampleClass, b, a) -> ec.SomeMethod(a, b)) @>
    printf "%A" results
    Assert.True(true)
