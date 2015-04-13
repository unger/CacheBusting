<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CacheBusting.Sample.Default" %>
<%@ Import Namespace="CacheBusting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="<%= FingerPrint.WithFileDate("/css/main.css") %>" rel="stylesheet"/>
    <link href="<%= FingerPrint.WithContentHash("/css/main.css") %>" rel="stylesheet"/>
</head>
<body>
    <h1>
        Cachebusting Sample
    </h1>
</body>
</html>
