open System
open Microsoft.Reporting.WinForms

[<EntryPoint>]
let main args =

    let report = new LocalReport(ReportPath = "Textbox.rdlc")
    let dpi = 203;
    let device_info =
            $"<DeviceInfo>
                <OutputFormat>PNG</OutputFormat>
                <DpiX>{dpi}</DpiX><DpiY>{dpi}</DpiY>
                <MarginTop>0in</MarginTop>
                <MarginLeft>0in</MarginLeft>
                <MarginRight>0in</MarginRight>
                <MarginBottom>0in</MarginBottom>
            </DeviceInfo>";
    let raw = report.Render("IMAGE", device_info)

    let base64chars = Array.create raw.Length '\u0000'
    Convert.ToBase64CharArray(raw, 0, raw.Length, base64chars, 0) |> ignore
    let base64 = new String(base64chars)

    printfn "%s" base64
    0
