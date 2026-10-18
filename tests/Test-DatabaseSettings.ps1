param([string]$ConnectorPath = (Join-Path $PSScriptRoot '..\bin\Release\MySql.Data.dll'))
$ErrorActionPreference = 'Stop'
$root = Split-Path $PSScriptRoot -Parent
if (-not (Test-Path -LiteralPath $ConnectorPath)) { throw 'Build the project first, or supply the restored MySql.Data.dll with -ConnectorPath.' }
# Only the new configuration parser is compiled. The application is never launched.
[Reflection.Assembly]::LoadFrom((Resolve-Path -LiteralPath $ConnectorPath).Path) | Out-Null
Add-Type -Path (Join-Path $root 'DatabaseSettings.cs') -ReferencedAssemblies @('System.Data.dll', (Resolve-Path -LiteralPath $ConnectorPath).Path)
$checks = 0
foreach ($value in @(
    $null, '', ' ', 'not a connection string',
    'Server=localhost;Database=demo;User Id=demo;',
    'Server=localhost;Database=demo;Password=synthetic;',
    'Server=localhost;User Id=demo;Password=synthetic;',
    'Server=localhost;Database=demo;User Id=demo;Password=synthetic;Port=not-a-port;',
    'Server=localhost;Database=demo;User Id=demo;Password=synthetic;Port=999999999999999;'
)) {
    $rejected = $false
    try { [C969_001340166.DatabaseSettings]::Validate($value) | Out-Null }
    catch {
        $errorObject = $_.Exception
        while ($errorObject.InnerException) { $errorObject = $errorObject.InnerException }
        if ($errorObject -isnot [InvalidOperationException]) { throw 'Invalid configuration must produce a safe configuration error.' }
        if ($errorObject.Message -match 'synthetic|not-a-port|999999999999999') { throw 'Error exposed supplied connection details.' }
        $rejected = $true
    }
    if (-not $rejected) { throw 'Invalid configuration was accepted.' }
    $checks++
}
$valid = 'Server=localhost;Database=appointment_demo;User Id=demo;Password=synthetic;'
$parsed = [C969_001340166.DatabaseSettings]::Validate($valid)
if ($parsed -notmatch 'appointment_demo') { throw 'Valid configuration was lost.' }
$checks++
$previous = [Environment]::GetEnvironmentVariable('APPOINTMENTAGENDA_CONNECTION_STRING')
try {
    [Environment]::SetEnvironmentVariable('APPOINTMENTAGENDA_CONNECTION_STRING', $valid)
    if ([C969_001340166.DatabaseSettings]::ReadConnectionString() -ne $parsed) { throw 'Environment configuration was not read.' }
    $checks++
} finally { [Environment]::SetEnvironmentVariable('APPOINTMENTAGENDA_CONNECTION_STRING', $previous) }
Write-Output "PASS: $checks offline configuration checks; no application or database connection was opened."
