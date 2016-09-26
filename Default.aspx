<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Houses</title>

    <script type="text/javascript"
        src="http://www.google.com/jsapi?key=AIzaSyC1LxETcMumK9zUuXY6aAY86TsrOHxOgBs"></script>
    <script type="text/javascript">
     google.load("maps", "2");
     function initialize() {
        var map = new google.maps.Map2(document.getElementById("map"));
        map.setCenter(new google.maps.LatLng("<%=lat%>", "<%=lon%>"), 10);
        var point = new GPoint("<%=lon%>", "<%=lat%>");
        var marker = new GMarker(point);
        map.addOverlay(marker);
        map.addControl(new GLargeMapControl());
     }
     google.setOnLoadCallback(initialize);
   </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <div id="map" style="width:100%;height:500px"></div>

        <label>Choose a city: </label>
        <asp:DropDownList id="CityList"
                          AutoPostBack="True"
                          OnSelectedIndexChanged="Set_City"
                          runat="server">

            <asp:ListItem Selected="True" Value="Moscow"> Moscow </asp:ListItem>
            <asp:ListItem Value="Novokuznetsk"> Novokuznetsk </asp:ListItem>

        </asp:DropDownList>
    
    </div>
    </form>
</body>
</html>
