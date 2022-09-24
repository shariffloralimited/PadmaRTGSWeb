<?xml version="1.0"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 	xmlns:k="urn:swift:saa:xsd:saa.2.0"
	xmlns:m="urn:iso:std:iso:20022:tech:xsd:head.001.001.01" xmlns:n="urn:swift:xsd:camt.006.001.05" >
<xsl:template match="/">
  <html>
  <head>
  <link rel="stylesheet" type="text/css" href="content/sitec.css"/>
  </head>
  <body>
  <br />
  <Div class="Head">RTSX Response (camt.006)</Div>
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
	<xsl:for-each select="//n:OrgnlBizQry">
    <tr>
	<td class="NormalBold" width="150">Original Msg ID</td>	
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
  <br/>
  <table class="LightBorderTable">
	<xsl:for-each select="//n:ShrtBizId">
    <tr>
	  <td class="Normal" bgcolor="aliceblue" width="150">Trans ID</td>
      <td class="Normal" bgcolor="aliceblue" width="250"><xsl:value-of select="//n:TxId"/></td>
	</tr>
	<tr>
	  <td class="Normal" bgcolor="aliceblue">Settlement Date</td>
      <td class="Normal" bgcolor="aliceblue"><xsl:value-of select="//n:IntrBkSttlmDt"/></td>
	</tr>
	<tr>
	  <td class="Normal" bgcolor="aliceblue">BICFI</td>
      <td class="Normal" bgcolor="aliceblue"><xsl:value-of select="//n:BICFI"/></td>
	</tr>
    </xsl:for-each>
  </table>
  <br/><span class="NormalBold">Result</span><br/>
  <table  class="LightBorderTable">
    <tr bgcolor="aliceblue">
      <th class="NormalBold" width="200">Msg ID</th>
      <th class="NormalBold" width="100">Status</th>
      <th class="NormalBold" width="100">Reason CD</th>
      <th class="NormalBold" width="250">Reason</th>
	</tr>
    <xsl:for-each select="//n:TxOrErr/n:Tx/n:Pmt">
    <tr>
      <td class="NormalBold" align="center"><xsl:value-of select="n:MsgId"/></td>
      <td class="NormalRed" align="center"><xsl:value-of select="n:Sts/n:Cd/n:Prtry"/></td>
      <td class="NormalRed" align="center"><xsl:value-of select="//n:PrtryStsRsn"/></td>
      <td class="NormalBold" align="center"><xsl:value-of select="//n:Rsn"/></td>
	</tr>
    </xsl:for-each>
  </table>
  </body>
  </html>
</xsl:template>

</xsl:stylesheet>