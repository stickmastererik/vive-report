# Needs to be at least that version, or mmm can't read the archive
#Requires -Modules @{ ModuleName="Microsoft.PowerShell.Archive"; ModuleVersion="1.2.3" }
$MyInvocation.MyCommand.Path | Split-Path | Push-Location # Run from this script's directory
$Name = (ls *.csproj).BaseName
dotnet build -c Release
cp bin\Release\netstandard2.0\oscar_fpv.dll BepInEx\plugins\oscar_fpv.dll
Compress-Archive .\BepInEx\ $Name-v
rmdir .\BepInEx\ -Recurse