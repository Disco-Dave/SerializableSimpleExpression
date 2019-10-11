namespace SerializableSimpleExpression

open System.Reflection

type ThunkBuilder<'TClass, 'TReturn, 'TArg when 'TClass : not struct> internal (method : MethodInfo) =
    member __.SetArgument (arg : 'TArg) =
        Thunk<'TReturn>(method, Array.empty)

type ThunkBuilder<'TClass, 'TReturn, 'TArg1, 'TArg2 when 'TClass : not struct> internal (method : MethodInfo) =
    member __.SetArgument (arg1 : 'TArg1, arg2 : 'TArg2) =
        Thunk<'TReturn>(method, Array.empty)
    
type ThunkBuilder<'TClass, 'TReturn, 'TArg1, 'TArg2, 'TArg3 when 'TClass : not struct> internal (method : MethodInfo) =
    member __.SetArgument (arg1 : 'TArg1, arg2 : 'TArg2, arg3 : 'TArg3) =
        Thunk<'TReturn>(method, Array.empty)
    
type ThunkBuilder<'TClass, 'TReturn, 'TArg1, 'TArg2, 'TArg3, 'TArg4 when 'TClass : not struct> internal (method : MethodInfo) =
    member __.SetArgument (arg1 : 'TArg1, arg2 : 'TArg2, arg3 : 'TArg3, arg4 : 'TArg4) =
        Thunk<'TReturn>(method, Array.empty)
        
type ThunkBuilder<'TClass, 'TReturn, 'TArg1, 'TArg2, 'TArg3, 'TArg4, 'TArg5 when 'TClass : not struct> internal (method : MethodInfo) =
    member __.SetArgument (arg1 : 'TArg1, arg2 : 'TArg2, arg3 : 'TArg3, arg4 : 'TArg4, arg5 : 'TArg5) =
        Thunk<'TReturn>(method, Array.empty)
        
type ThunkBuilder<'TClass, 'TReturn, 'TArg1, 'TArg2, 'TArg3, 'TArg4, 'TArg5, 'TArg6 when 'TClass : not struct> internal (method : MethodInfo) =
    member __.SetArgument (arg1 : 'TArg1, arg2 : 'TArg2, arg3 : 'TArg3, arg4 : 'TArg4, arg5 : 'TArg5, arg6 : 'TArg6) =
        Thunk<'TReturn>(method, Array.empty)
        
type ThunkBuilder<'TClass, 'TReturn, 'TArg1, 'TArg2, 'TArg3, 'TArg4, 'TArg5, 'TArg6, 'TArg7 when 'TClass : not struct> internal (method : MethodInfo) =
    member __.SetArgument (arg1 : 'TArg1, arg2 : 'TArg2, arg3 : 'TArg3, arg4 : 'TArg4, arg5 : 'TArg5, arg6 : 'TArg6, arg7 : 'TArg7) =
        Thunk<'TReturn>(method, Array.empty)
        
type ThunkBuilder<'TClass, 'TReturn, 'TArg1, 'TArg2, 'TArg3, 'TArg4, 'TArg5, 'TArg6, 'TArg7, 'TArg8 when 'TClass : not struct> internal (method : MethodInfo) =
    member __.SetArgument (arg1 : 'TArg1, arg2 : 'TArg2, arg3 : 'TArg3, arg4 : 'TArg4, arg5 : 'TArg5, arg6 : 'TArg6, arg7 : 'TArg7, arg8 : 'TArg8) =
        Thunk<'TReturn>(method, Array.empty)
        
type ThunkBuilder<'TClass, 'TReturn, 'TArg1, 'TArg2, 'TArg3, 'TArg4, 'TArg5, 'TArg6, 'TArg7, 'TArg8, 'TArg9 when 'TClass : not struct> internal (method : MethodInfo) =
    member __.SetArgument (arg1 : 'TArg1, arg2 : 'TArg2, arg3 : 'TArg3, arg4 : 'TArg4, arg5 : 'TArg5, arg6 : 'TArg6, arg7 : 'TArg7, arg8 : 'TArg8, arg9 : 'TArg9) =
        Thunk<'TReturn>(method, Array.empty)
        
type ThunkBuilder<'TClass, 'TReturn, 'TArg1, 'TArg2, 'TArg3, 'TArg4, 'TArg5, 'TArg6, 'TArg7, 'TArg8, 'TArg9, 'TArg10 when 'TClass : not struct> internal (method : MethodInfo) =
    member __.SetArgument (arg1 : 'TArg1, arg2 : 'TArg2, arg3 : 'TArg3, arg4 : 'TArg4, arg5 : 'TArg5, arg6 : 'TArg6, arg7 : 'TArg7, arg8 : 'TArg8, arg9 : 'TArg9, arg10 : 'TArg10) =
        Thunk<'TReturn>(method, Array.empty)

