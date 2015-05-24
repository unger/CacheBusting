<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CacheBusting.Sample.Default" %>
<%@ Import Namespace="CacheBusting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="<%= FingerPrint.WithFileDate("/css/main.css", false) %>" rel="stylesheet"/>
    <link href="/css/main.1.3.4.css" rel="stylesheet"/>
</head>
<body>
    <h1>
        Cachebusting Sample
    </h1>
</body>
</html>
