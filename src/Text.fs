namespace Berylsoft.Base

// TODO finish document
module Text =

    let inline encode (text: string) : byte [] =
        System.Text.Encoding.UTF8.GetBytes text

    let inline decode (bin: byte []) : string =
        System.Text.Encoding.UTF8.GetString bin
