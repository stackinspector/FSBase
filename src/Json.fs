namespace Berylsoft.Base

module Json =

    open System.Text.Json
    open System.Text.Json.Serialization

    let converter =
        JsonFSharpConverter (
            unionEncoding = (
                JsonUnionEncoding.ExternalTag
                ||| JsonUnionEncoding.UnwrapFieldlessTags
                ||| JsonUnionEncoding.UnwrapOption
                ||| JsonUnionEncoding.UnwrapSingleFieldCases
            )
        )

    let options = JsonSerializerOptions ()
    options.Converters.Add converter

    let serialize (object: 'T) : string =
        (object, options)
        |> JsonSerializer.Serialize 

    let deserialize<'T> (json: string) : 'T =
        (json, options)
        |> JsonSerializer.Deserialize<'T>
