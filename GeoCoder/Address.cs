using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GeoCoder
{
    class Address
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string AddressString { get; set; }

        public Address(string address)
        {
            AddressString = address;
        }

        public void GeoCode()
        {
            //Setup a streamreader for retrieving data from Google.
            //This is line that requires System.IO.
            StreamReader sr = null;

            string mapskey = "AIzaSyC1LxETcMumK9zUuXY6aAY86TsrOHxOgBs";

            //Create the url string to send our request to googsie.
                                        
            string url = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?address={0}&key={1}", this.AddressString, mapskey);

            //Create a web request client.
            //This is where the System.Net import is used.
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            sr = new StreamReader(response.GetResponseStream());
            
            try
            {
                //Now that we have the results, lets parse the returned data with an xmltextreader.
                //Why an XMLTextReader vs. An XMLDocument?  Simple, XMLTextReaders are faster and this is
                //Simple enough not to warrant a full XMLDocument.
                XmlTextReader xtr = new XmlTextReader(sr);

                //Start reading our xml document.
                bool coordread = false;
                while (xtr.Read() && !coordread)
                {
                    xtr.MoveToElement();
                    switch (xtr.Name)
                    {
                        case "location": //Check for the address details node
                            xtr.Read();
                            xtr.Read();
                            if (xtr.Name == "lat")
                            {
                                xtr.Read();
                                Latitude = xtr.Value;
                            }
                            xtr.Read();
                            xtr.Read();
                            xtr.Read();
                            if (xtr.Name == "lng")
                            {
                                xtr.Read();
                                Longitude = xtr.Value;
                            }
                            coordread = true;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while parsing GeoCoded results from Google, the error was: " + ex.Message);
            }
            response.Close();
        }
    }
}
