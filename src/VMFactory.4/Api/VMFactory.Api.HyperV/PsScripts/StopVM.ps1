Param(
	[string]$VMName
)

Write-Output "[StopVM] Current Configuration:"
Write-Output "VMName: $VMName" 

$vm = Get-VM -name "$VMName" –errorvariable VMFErorVar
if ($VMFErorVar)
{
	Write-Output "ERROR Testing the VM ($VMName). [$LastExitCode]" 
	Write-Output $VMFErorVar
	Exit
}
else
{
	Write-Output "Finished Testing the VM"
}

Write-Output "Stoping VM."
Stop-VM $vm –errorvariable VMFErorVar
if ($VMFErorVar)
{
	Write-Output "ERROR Stoping the VM."
	Write-Output $VMFErorVar
	$vm
	Exit
}
else
{
	Write-Output "Finished Stoping the VM"
}
