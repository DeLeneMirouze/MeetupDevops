
$rgName = $env:DEPLOY_RGNAME
$location = $env:DEPLOY_LOCATION

$parameters = @{
    webAppName = "webapp_$rgName".Replace("_", "-")
    location   = $location
}

Write-host "##[warning]Deploiement de l'AppService $($parameters.webAppName) sur $rgName ($location)" 

$paramFile = Join-Path -Path (Get-Location).Path -ChildPath "infrastructure/appservice.json"
New-AzResourceGroupDeployment `
    -ResourceGroupName $rgName `
    -TemplateFile $paramFile `
    -name appservice `
    -TemplateParameterObject $parameters