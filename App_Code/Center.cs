using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Center
{
    public Center()
    {
    }

    private double lat = 0.0;
    private double lng = 0.0;

    public double Lat
    {
        get { return lat; }
        set { lat = value; }
    }

    public double Lng
    {
        get { return lng; }
        set { lng = value; }
    }
}