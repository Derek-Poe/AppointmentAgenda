# AppointmentAgenda

A C# Windows Forms coursework application for customer records, appointment scheduling, and reports backed by MySQL. It includes appointment conflict checks, time-zone conversions, and an English/French login interface.

This is a historical desktop application, retained as a supporting portfolio project. The maintenance changes remove embedded connection credentials, signing material, and generated deployment artifacts; the login lookup now uses SQL parameters.

## Build

Use Visual Studio on Windows with the .NET desktop development workload and the .NET Framework 4.7.2 targeting pack. Open `C969_001340166.sln`, restore NuGet packages, and build the solution.

The project restores `MySql.Data` 8.1.0, matching the connector version used by the historical application. No connector DLL, ClickOnce certificate, or generated executable is committed. ClickOnce manifest signing is disabled; configure your own signing identity separately if you choose to distribute an installer.

After building Release, run `./tests/Test-DatabaseSettings.ps1` in Windows PowerShell. It compiles only the configuration parser and tests synthetic inputs without launching the application or contacting a database. GitHub Actions builds the project and runs these checks.

## Configure your own local database

The repository does not include the original database or account data. Provision a disposable MySQL database using the coursework schema (`country`, `city`, `address`, `customer`, `user`, and `appointment`) and synthetic records. The application expects that existing schema; it does not run migrations or create a database for you.

Set the connection string only in the environment of the process that launches the application. For example, with credentials for your own disposable local database:

```powershell
$env:APPOINTMENTAGENDA_CONNECTION_STRING = 'Server=localhost;Database=appointment_demo;User Id=demo_user;Password=<your-local-password>;'
# Launch the freshly built application from this same session.
& .\bin\Debug\C969_001340166.exe
```

The sample values are placeholders. Do not commit your actual connection string. Missing or malformed configuration produces an actionable message; database failures do not display the connection string or password. UI login credentials belong to a synthetic user record in your own database and are distinct from the database connection credentials.

## Historical limits

The original schema and account workflow use legacy password handling, and other data-editing queries still use interpolation. This is not a production authentication system or a fully hardened database application. Use controlled local synthetic data when evaluating it. The cleanup does not claim to have modernized every data-access path.

The application has not been connected to the original database during maintenance.

On 2026-10-18, public branch history was rewritten to exclude identified historical sensitive data. Re-clone if you have an older checkout; merging its history back can reintroduce removed data. GitHub cached views or retained references, if present, need separate cleanup; external copies are not erased.

MIT license for Derek Poe's application source. The MySQL connector is a separately restored third-party dependency governed by its own license.
