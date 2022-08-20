using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HawkerCenterFinder.Model
{
    public class HawkerData
    {

        public string type { get; set; }
        public Crs crs { get; set; }
        public List<Feature> features { get; set; }

    }
    public class Crs
    {
        public string type { get; set; }
        public Properties properties { get; set; }
    }

    public class Feature
    {
        public string type { get; set; }
        public Properties properties { get; set; }
        public Geometry geometry { get; set; }
    }

    public class Geometry
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }
    }

    public class Properties
    {
        public string name { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

}
