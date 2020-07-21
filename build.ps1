$path = (Get-Item .\PAYNLSDK\PayNLSdk.csproj).FullName
$csproj = [xml](Get-Content $path)
Write-Output "Update version to" $Env:APPVEYOR_BUILD_VERSION
$csproj.Project.PropertyGroup.Version = $Env:APPVEYOR_BUILD_VERSION
$csproj.Save($path)
