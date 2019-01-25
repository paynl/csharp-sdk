$path = (Get-Item .\PAYNLSDK\PayNLSdk.csproj).FullName
$csproj = [xml](Get-Content $path)
$csproj.Project.PropertyGroup.Version = $Env:APPVEYOR_BUILD_VERSION
$csproj.Save($path)