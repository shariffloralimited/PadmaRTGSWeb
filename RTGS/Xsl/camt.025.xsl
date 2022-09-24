<?xml version="1.0"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 	xmlns:k="urn:swift:saa:xsd:saa.2.0"
	xmlns:m="urn:iso:std:iso:20022:tech:xsd:head.001.001.01" xmlns:n="urn:swift:xsd:camt.025.001.03" >
<xsl:template match="/">
  <html>
  <head>
  <link rel="stylesheet" type="text/css" href="content/sitec.css"/>
  </head>
  <body>
  <br />
  <Div class="Head">RTSX Response (camt.025)</Div>
  <br />

  <table class="LightBorderTable">
	<xsl:for-each select="//m:AppHdr">
    <tr>
	  <td class="NormalBold" width="150">Report Creation Date</td>
      <td class="Normal" width="250"><xsl:value-of select="m:CreDt" /></td>
	</tr>
    </xsl:for-each>
    <xsl:for-each select="//m:To">
      <tr>
        <td class="NormalBold" width="150">To BICFI</td>
        <td class="Normal" width="250">
          <xsl:value-of select="//m:To//m:BICFI"/>
        </td>
      </tr>
    </xsl:for-each>
	<xsl:for-each select="//m:AppHdr">
    <tr>
	<td class="NormalBold" width="150">BizMsgIdr</td>	
	<td class="Normal" width="250"><xsl:value-of select="m:BizMsgIdr"/></td>
	</tr>
    </xsl:for-each>
	<xsl:for-each select="//n:OrgnlMsgId">
    <tr>
	<td class="NormalBold" width="150">Msg ID</td>	
	<td class="Normal" width="250"><xsl:value-of select="//n:MsgId"/></td>
	</tr>
    </xsl:for-each>
	<xsl:for-each select="//n:ReqTp">
    <tr>
	<td class="NormalBold" width="150">Request Type</td>	
	<td class="Normal" width="250"><xsl:value-of select="//n:Id"/></td>
	</tr>
    </xsl:for-each>
	
  </table>
  <br/><span class="NormalBold">Result</span><br/>
  <table  class="LightBorderTable">
    <tr bgcolor="aliceblue">
      <th class="NormalBold" width="200">Original Msg ID</th>
      <th class="NormalBold" width="100">Status</th>
      <th class="NormalBold" width="250">Desc</th>
	</tr>
    <xsl:for-each select="//n:Rct">
    <tr>
      <td class="NormalBold" align="center"><xsl:value-of select="//n:OrgnlMsgId//n:MsgId"/></td>
      <td class="NormalRed" align="center"><xsl:value-of select="//n:ReqHdlg/n:StsCd"/></td>
      <td class="NormalBold" align="center"><xsl:value-of select="//n:ReqHdlg/n:Desc"/></td>
	</tr>
    </xsl:for-each>
  </table>
  </body>
  </html>
</xsl:template>

</xsl:stylesheet>