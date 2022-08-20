using HawkerCenterFinder.Model;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace HawkerCenterFinder.DataLayer.Parser
{
    public static class HawkerCenterClient
    {
        public static HawkerData GetDataFromFile()
        {
            using (StreamReader r = new StreamReader("hawker-centres-geojson.geojson"))
            {
                string json = r.ReadToEnd();
                var items = JsonConvert.DeserializeObject<HawkerData>(json);
                return items;
            }
        }
    }
}
