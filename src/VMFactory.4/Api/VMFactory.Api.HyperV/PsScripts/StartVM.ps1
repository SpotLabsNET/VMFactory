Param(
	[string]$VMName
)


Write-Output "Current Configuration:"
Write-Output "VMName: $VMName" 


# store current state
#$currectExecPolicy = Get-ExecutionPolicy
#Set-ExecutionPolicy Unrestricted

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

Write-Output "Starting VM."
Start-VM $vm –errorvariable VMFErorVar
if ($VMFErorVar)
{
	Write-Output "ERROR Starting the VM."
	Write-Output $VMFErorVar
	$vm
	Exit
}
else
{
	Write-Output "Finished Starting the VM"
}


# reset to the original state
#Set-ExecutionPolicy $currectExecPolicy
