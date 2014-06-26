#param(
#	[string]$vhdPath = $(throw "-vhdPath is required."),			# param 1 - vhd full path
#	[string]$driveLetter = $(throw "-driveLetter is required."), 	# param 2 - mount drive letter
#	[string]$dismPath = 'C:\Windows\System32\', 					# param 3 - dism.exe path
#	[string]$vmName = $(throw "-vmName is required."), 		# param 4 - VM name 
#	[string]$vmId = $(throw "-vmId is required."), 			# param 5 - VM ID
#	[string]$vmStatusSvcUrl = $(throw "-vmStatusSvcUrl is required."),# param 6 - vmstatus full URL
#	[string]$cfgFileName = "VMFConfig.xml" 							#param - VM configuration file 
#)

param(
	[string]$vhdPath = 'd:\_VMs\SP2013\PTMoss2k13.vhd', # param 1 - vhd full path
	[string]$driveLetter = 'x:', 						# param 2 - mount drive letter
	[string]$dismPath = 'C:\Windows\System32\', 		# param 3 - dism.exe path
	[string]$vmName = 'testVm', 						# param 4 - VM name 
	[string]$vmId = '2', 								# param 5 - VM ID
	[string]$vmStatusSvcUrl = '', 						# param 6 - vmstatus full URL
	[string]$cfgFileName = "VMFConfig.xml" 			#param - VM configuration file 
)


#
$cfgFilePath = $driveLetter + "\" + $cfgFileName



# MOUNT the VHD file
$dismExe = $dismPath + "dism.exe"
$imgParam = '/ImageFile:' + "$vhdPath"
$mountDirParam = '/MountDir:' + $driveLetter
& $dismExe '/Mount-Image' $imgParam '/Index:1' $mountDirParam


# GENERATE THE CONFIG FILE
# Set the File Name
 
# Create The Document
$XmlWriter = New-Object System.XMl.XmlTextWriter($cfgFilePath,$Null)
 
# Set The Formatting
$xmlWriter.Formatting = "Indented"
$xmlWriter.Indentation = "4"
 
# Write the XML Decleration
$xmlWriter.WriteStartDocument()
 
# Set the XSL
#$XSLPropText = "type='text/xsl' href='style.xsl'"
#$xmlWriter.WriteProcessingInstruction("xml-stylesheet", $XSLPropText)
 
# Write Root Element
$xmlWriter.WriteStartElement("Config")
 
# Write the Document
$xmlWriter.WriteElementString("VmId", $vmId)
$xmlWriter.WriteElementString("VmName",$vmName)
$xmlWriter.WriteElementString("VmStatusServiceUrl",$vmStatusSvcUrl)
 
# Write Close Tag for Root Element
$xmlWriter.WriteEndElement # <-- Closing Config
 
# End the XML Document
$xmlWriter.WriteEndDocument()
 
# Finish The Document
$xmlWriter.Finalize
$xmlWriter.Flush
$xmlWriter.Close()



# COPY THE NECESSARY FILES TO THE  MOUNTED VHD


# UNMOUNT VHD
& $dismExe '/Unmount-Image' $mountDirParam '/Commit'
