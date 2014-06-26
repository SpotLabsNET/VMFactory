

param(
	[string]$cfgFilePath = 'W:\Projects\ALMRangers\VisualStudio.ALM\vsarVmFactory\dev\code\VMFactory.4\Powershell',  #param - VM configuration file path
	[string]$cfgFileName = "Update-VMRequestStatus.xml", #param - VM configuration file 
	[string]$currentState = 'Packaging', #param - VM current state
	[string]$additionalLogInfo = 'Add this log info'
)

# Open the document
$XmlReader = New-Object System.XMl.XmlTextReader($cfgFilePath + "\" + $cfgFileName)
$XmlDocument = New-Object System.Xml.XmlDocument
$XmlDocument.Load($XmlReader)
$XmlNamespaceManager = New-Object System.Xml.XmlNamespaceManager($XmlDocument.NameTable);


# Read the document content

$vmIdNode = $XmlDocument.SelectSingleNode("/Config/VmId", $XmlNamespaceManager)
if ( $vmIdNode -eq $null ) 
{ 
	$XmlReader.Close()
	$exception = New-Object System.Exception("Cannot find virtual machine id in configuration file")
	Throw $exception
}

$VmId = $vmIdNode.InnerText

$VmStatusServiceUrlNode = $XmlDocument.SelectSingleNode("/Config/VmStatusServiceUrl", $XmlNamespaceManager)
if ( $VmStatusServiceUrlNode -eq $null ) 
{ 
	$XmlReader.Close()
	$exception = New-Object System.Exception("Cannot find status service url id in configuration file")
	Throw $exception
}

$VmStatusServiceUrl = $VmStatusServiceUrlNode.InnerText

# Close the document
$XmlReader.Close()

$parameters = '<?xml version="1.0" encoding="utf-8"?>
<s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/">
  <s:Body>
	<UpdateStatus xmlns="http://VMFactory.Services">
	  <id>' + $VmId + '</id>
	  <newStatus>' + $currentState + '</newStatus>
	  <additionalLogInfo>' + $additionalLogInfo + '</additionalLogInfo>
	</UpdateStatus>
  </s:Body>
</s:Envelope>'

$http_request = New-Object -ComObject Msxml2.XMLHTTP
$http_request.open('POST', $VmStatusServiceUrl, $false)
$http_request.setRequestHeader("Content-type", "text/xml")
$http_request.setRequestHeader("Content-length", $parameters.length)
$http_request.setRequestHeader("Connection", "close")
$http_request.setRequestHeader("SOAPAction", "http://VMFactory.Services/IVMRequestManagement/UpdateStatus")
$http_request.send($parameters)
$http_request.statusText
$http_request.responseText
