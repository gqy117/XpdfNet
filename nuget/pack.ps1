$root = (split-path -parent $MyInvocation.MyCommand.Definition) + '\..'
$projectName = "XpdfNet"
$csproj = [xml] (Get-Content $root\src\$projectName\$projectName.csproj)
$versionStr = $csproj.Project.PropertyGroup.Version

Write-Host "Setting .nuspec version tag to $versionStr"

$content = (Get-Content $root\nuget\$projectName.nuspec) 
$content = $content -replace '\$version\$',$versionStr

$content | Out-File $root\nuget\$projectName.compiled.nuspec

& nuget pack $root\nuget\$projectName.compiled.nuspec