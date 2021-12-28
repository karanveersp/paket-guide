// For more information see https://aka.ms/fsharp-console-apps
open Console
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

let dirPath = Environment.GetCommandLineArgs().[1]

try
    dirPath
    |> getDirectorySize
    |> sprintf "The size is: %.3f gb"
    |> Console.info
with
| :? DirectoryNotFoundException as ex -> Console.error $"{ex}{ex.StackTrace}"
