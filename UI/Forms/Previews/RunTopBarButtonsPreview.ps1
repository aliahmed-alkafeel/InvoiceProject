[CmdletBinding()]
param(
    [ValidateSet("Debug", "Release")]
    [string]$Configuration = "Debug"
)

$ErrorActionPreference = "Stop"

# The preview lives in the UI project but is not part of the application's startup path.
# This script loads the already-built UI assembly and shows only the preview form.
$previewDirectory = Split-Path -Parent $MyInvocation.MyCommand.Path
$binDirectory = [System.IO.Path]::GetFullPath(
    (Join-Path $previewDirectory ("..\..\bin\" + $Configuration)))
$uiAssembly = Join-Path $binDirectory "UI.exe"

if (-not (Test-Path $uiAssembly))
{
    throw "Build the UI project first. Expected assembly not found: $uiAssembly"
}

if ([System.Threading.Thread]::CurrentThread.GetApartmentState() -ne
    [System.Threading.ApartmentState]::STA)
{
    $arguments = @(
        "-NoProfile",
        "-STA",
        "-ExecutionPolicy", "Bypass",
        "-File", ("`"{0}`"" -f $MyInvocation.MyCommand.Path),
        "-Configuration", $Configuration
    )

    Start-Process -FilePath "powershell.exe" -ArgumentList $arguments
    return
}

Add-Type -AssemblyName System.Windows.Forms
[System.Windows.Forms.Application]::EnableVisualStyles()
[System.Windows.Forms.Application]::SetCompatibleTextRenderingDefault($false)

Push-Location $binDirectory
try
{
    [void][System.Reflection.Assembly]::LoadFrom($uiAssembly)

    $form = New-Object UI.Forms.Previews.TopBarButtonsPreviewForm
    [System.Windows.Forms.Application]::Run($form)
}
finally
{
    Pop-Location
}
