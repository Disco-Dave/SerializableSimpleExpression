namespace SerializableSimpleExpression

open System
open System.Runtime.CompilerServices

type IServiceLocator =
    abstract member Get<'T> : unit -> 'T

[<Extension>]
type IServiceLocatorExtensions internal () =
    [<Extension>]
    static member inline internal Get(serviceLocator : IServiceLocator, ``type`` : Type) =
        typeof<IServiceLocator>
            .GetMethod("Get")
            .MakeGenericMethod(``type``)
            .Invoke(serviceLocator, null)
    

