namespace SerializableSimpleExpression

open System.Reflection

exception InvalidReturnType

type Thunk<'TReturn> internal (method : MethodInfo, args : obj seq) =
    do
        if typeof<'TReturn>.IsAssignableFrom(method.ReturnType) then
            raise InvalidReturnType
        
    member __.Execute (serviceLocator : IServiceLocator) =
        let classInstance = serviceLocator.Get(method.DeclaringType)
        let returnValue =
            if Seq.isEmpty args then
                method.Invoke (classInstance, null)
            else
                let methodArgs = args |> Seq.toArray
                method.Invoke (classInstance, methodArgs)
                
        returnValue :?> 'TReturn

