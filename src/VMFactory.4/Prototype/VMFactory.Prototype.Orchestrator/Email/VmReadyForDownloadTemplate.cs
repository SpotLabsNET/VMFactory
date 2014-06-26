﻿
namespace VMFactory.Prototype.Orchestrator.Email
{

		public static class VMRequestEmailTemplate
		{

            public static string vMRequestEmailTemplatebody = @"
<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 3.2//EN"">
<html lang=""en"" xmlns=""http://www.w3.org/1999/xhtml"">
<head>
	<meta charset=""utf-8"" />
	<title></title>
	<style type=""text/css"">

p.MsoPlainText
	{margin-bottom:.0001pt;
	font-size:11.0pt;
	font-family:""Calibri"",""sans-serif"";
			margin-left: 0cm;
			margin-right: 0cm;
			margin-top: 0cm;
		}
	</style>
</head>
<body>

	<p class=""MsoPlainText"">
		<img alt="""" src=""https://vmfactory.almrangers.com/Images/VS2012.ALMRangers.Logo.NoTrademark.Transparent.Purple.1416x475.png"" /><a href=""https://vmfactory.almrangers.com/"" style=""color: rgb(200, 200, 200); outline: none; padding-left: 3px; padding-right: 3px; text-decoration: none; background-color: rgb(255, 255, 255); background-image: none; font-family: Rockwell, Consolas, 'Courier New', Courier, monospace; font-size: 31px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-position: initial initial; background-repeat: initial initial;"">Virtual Machine Factory</a></p>
	<p class=""MsoPlainText"">
		&nbsp;</p>
	<p class=""MsoPlainText"">
		&nbsp;</p>
	<p class=""MsoPlainText"">
		Hello!,</p>
	<p class=""MsoPlainText"">
		&nbsp;</p>
	<p class=""MsoPlainText"">
		Thank you for your interest.</p>
	<p class=""MsoPlainText"">
		<strong>Your VM is ready for pickup. </strong>
	</p>
	<p class=""MsoPlainText"">
		<table style=""width:100%;"">
			<tr>
				<td>File</td>
				<td>Creation date</td>
			</tr>
{{ROWS}}
		</table>
	</p>
	<p></p>
	<p class=""MsoPlainText"">
		Loved it? Hated it? Just reply to this email and let us know how are we doing! All the feedback is most appreciated as it allows us to get closer to your goals.</p>
	<p class=""MsoPlainText"">
		&nbsp;</p>
	<p class=""MsoPlainText"">
		Best regards,</p>
	<p class=""MsoPlainText"">
		&nbsp;</p>
	<p class=""MsoPlainText"">
		The VM Factory Team</p>
	<p class=""MsoPlainText"">
		&nbsp;</p>
	<p class=""MsoPlainText"">
		<strong>Note: DO reply to this email. This IS a monitored mailbox :)</strong></p>

</body>
</html>
";

	}
}
