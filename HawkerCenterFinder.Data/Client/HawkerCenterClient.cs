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

        public static List<Hawker> ParseHawkerDataToHawker(HawkerData hawkerData)
        {
            List<Hawker> hawkers = new();

            foreach (var feature in hawkerData.features)
            {
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(feature.properties.Description);
                var table = htmlDoc.DocumentNode.SelectNodes("//table/tr/th");
                Hawker hawker = new();
                hawker.Latitude = feature.geometry.coordinates[0].ToString();
                hawker.Longitude = feature.geometry.coordinates[1].ToString();
                foreach (var tableElements in table)
                {
                    if (tableElements.InnerText == "NAME")
                    {
                        hawker.Name = tableElements.ParentNode.SelectSingleNode("td").InnerHtml;
                    }
                    if (tableElements.InnerText == "PHOTOURL")
                    {
                        hawker.ImgUrl = tableElements.ParentNode.SelectSingleNode("td").InnerHtml;
                    }
                }
                hawkers.Add(hawker);
            }

            return hawkers;
        }
    }
}
