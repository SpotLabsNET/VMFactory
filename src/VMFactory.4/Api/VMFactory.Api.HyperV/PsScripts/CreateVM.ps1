// store current state
$currectExecPolicy = Get-ExecutionPolicy
Set-ExecutionPolicy Unrestricted

$Source = 
$Destination = 
$VMPath = 
$VMName = 'RangersVM'

echo d | xcopy $Source $Destination /s /e
Import-VM - Path $VMPath
Start-VM $VMName
Get-VM $VMName

// reset to the original state
Set-ExecutionPolicy $currectExecPolicy
