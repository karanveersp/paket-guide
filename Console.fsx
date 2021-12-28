#load @".paket/load/BlackFox.ColoredPrintf.fsx"

module Console =
    open BlackFox.ColoredPrintf

    let complete = colorprintfn "$magenta[%s]"
    let ok = colorprintfn "$green[%s]"
    let info = colorprintfn "$cyan[%s]"
    let warn = colorprintfn "$yellow[%s]"
    let error = colorprintfn "$red[%s]"
