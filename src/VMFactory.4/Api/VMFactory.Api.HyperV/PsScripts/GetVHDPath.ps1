[CmdletBinding()]
Param(
	[Parameter(Mandatory=$True,Position=1)]
	[string]$VMName
)

Write-Output "[GetVHDPath] Current Configuration:"
Write-Output "VMName: $VMName" 

$vm = Get-VM -Name "$VMName"

$var = Get-VHD -VMId $vm.Id

return $var.Path
