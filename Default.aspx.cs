using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected string lat, lon;

    protected void Page_Load(object sender, EventArgs e)
    {
        lat = "55.7";
        lon = "37.6";
    }

    protected void Set_City(object sender, EventArgs e)
    {
        if (CityList.Text == "Moscow")
        {
            lat = "55.7";
            lon = "37.6";
        }
        else if (CityList.Text == "Novokuznetsk")
        {
            lat = "53.7";
            lon = "87.1";
        }
    }
}