Param(
	[string]$VMName
)

Write-Output "[RemoveVM] Current Configuration:"
Write-Output "VMName: $VMName" 

$vm = Get-VM -name "$VMName" –errorvariable VMFErorVar
if ($VMFErorVar)
{
	Write-Output "ERROR Removing the VM ($VMName). [$LastExitCode]" 
	Write-Output $VMFErorVar
	Exit
}
else
{
	Write-Output "Finished Removing the VM"
}

Write-Output "Removing VM."
Remove-VM -Force -Name $VMName –errorvariable VMFErorVar
if ($VMFErorVar)
{
	Write-Output "ERROR Removing the VM."
	Write-Output $VMFErorVar
	$vm
	Exit
}
else
{
	Write-Output "Finished Removing the VM"
}
