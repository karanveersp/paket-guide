#load @".paket/load/BlackFox.ColoredPrintf.fsx"

module Console =
    open BlackFox.ColoredPrintf

    let complete = colorprintfn "$magenta[%s]"
    let ok = colorprintfn "$green[%s]"
    let info = colorprintfn "$cyan[%s]"
    let warn = colorprintfn "$yellow[%s]"
    let error = colorprintfn "$red[%s]"

open System
open System.IO
open System.Linq


/// Converts bytes to gigabytes
let toGb numBytes = (float numBytes) * 1e-9

/// Returns the size of a directory in gigabytes.
let getDirectorySize dirPath =
    DirectoryInfo(dirPath)
        .EnumerateFiles("*", SearchOption.AllDirectories)
        .Sum(fun fi -> fi.Length)
    |> toGb

// arg index is updated according to seq (fsi script.fsx arg1 arg2...)
let dirPath = Environment.GetCommandLineArgs().[2]

try
    dirPath
    |> getDirectorySize
    |> sprintf "The size is: %.3f gb"
    |> Console.info
with
| :? DirectoryNotFoundException as ex -> Console.error $"{ex}{ex.StackTrace}"
