
# $Source = "C:\Pro\RangersVM.Template"
# $Destination = "C:\Pro\RangersVM"
# $VMPath = ‘C:\Pro\RangersVM\Virtual Machines\82996FC1-2120-4150-8E30-05FD64EC09B2.XML’
# $VMName = 'RangersVM'


Param(
	[string]$Source,
	[string]$Destination,
	[string]$VMPath,
	[string]$VMName,
	[string]$VMBaseName
)

Write-Output "Current Configuration:"
Write-Output ""
Write-Output "     Source: $Source"
Write-Output "Destination: $Destination"
Write-Output "     VMPath: $VMPath"
Write-Output "     VMName: $VMName"
Write-Output " VMBaseName: $VMBaseName"
Write-Output ""

Write-Output "Starting copying VM"
Write-Output ""
$xcopyResult = robocopy $Source $Destination.Substring(0, $Destination.Length-1) /MIR

#if ($xcopyResult -match "ERROR :")
#{
#	Write-Output "ERROR Copying the VM."
#	Write-Output $xcopyResult
#	Exit
#}
#else
#{
#	Write-Output "Finished Copying the VM"
#}


Write-Output "Starting importing new VM"

$newVM = Import-VM –Path "$VMPath" -copy -GenerateNewId -VhdDestinationPath "$Destination\Virtual Hard Disks" -VirtualMachinePath "$Destination\Virtual Machines"
#Import-VM –Path "$VMPath" -copy -GenerateNewId -VhdDestinationPath "$Destination\Virtual Hard Disks" -VirtualMachinePath "$Destination\Virtual Machines" -SnapshotFilePath "$Destination" -SmartPagingFilePath "$Destination" –errorvariable VMFErorVar
#Import-VM –Path "$VMPath" -copy -GenerateNewId -VhdDestinationPath "$Destination" -VirtualMachinePath "$Destination" -SnapshotFilePath "$Destination" -SmartPagingFilePath "$Destination"
if ($VMFErorVar)
{
	Write-Output "ERROR Importing the VM."
	Write-Output $VMFErorVar
	Exit
}
else
{
	Write-Output "Finished importing the VM"
}
Write-Output ""


Write-Output "Renaming new VM"
$newVM | Rename-VM -NewName $VMName
if ($VMFErorVar)
{
	Write-Output "ERROR Renaming the VM."
	Write-Output $VMFErorVar
	Exit
}
else
{
	Write-Output "Finished Renaming the VM"
}
Write-Output ""

#Write-Output "Testing VM."
#Write-Output "Get-VM -name $VMName –errorvariable VMFErorVar"
#$tvm = Get-VM
#Write-Output "----------------"
#Write-Output $tvm 
#Write-Output "----------------"
#$tvm = Get-VM "MyTestVm"
#Write-Output $tvm 
#Write-Output "----------------"
#$tvm = Get-VM $VMName
#Write-Output $tvm 
#Write-Output "----------------"


$vm = Get-VM -name "$VMName" –errorvariable $VMFErorVar
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

#Write-Output "Starting VM."
#Start-VM $vm –errorvariable VMFErorVar
#if ($VMFErorVar)
#{
#	Write-Output "ERROR Starting the VM."
#	Write-Output $VMFErorVar
#	$vm
#	Exit
#}
#else
#{
#	Write-Output "Finished Starting the VM"
#}



# reset to the original state
#Set-ExecutionPolicy $currectExecPolicy
