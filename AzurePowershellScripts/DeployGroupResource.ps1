<#Login into azure account#>
Login-AzureRmAccount

$resourceGroupName = Read-Host -Prompt "Enter the Resource Group name"

<#Create new resource group#>
New-AzureRmResourceGroup -Name $resourceGroupName -Location "West Europe"

<#Create App Service and Database from provided template#>
$templateFile = ".\AppServiceWithDatabaseTemplate.json"
New-AzureRmResourceGroupDeployment -ResourceGroupName $resourceGroupName -TemplateFile $templateFile -Verbose

Write-Host -f Green "Finished"
Write-Host "Remember to configure Azure ADB2C for deployed application."