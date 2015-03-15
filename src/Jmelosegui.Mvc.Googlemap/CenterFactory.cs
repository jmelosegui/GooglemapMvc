using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jmelosegui.Mvc.Googlemap
{
    public class CenterFactory
    {
        private readonly GoogleMap map;

        public CenterFactory(GoogleMap map)
        {
            this.map = map;
        }
        
        public CenterFactory UseCurrentPosition()
        {
            map.UseCurrentPosition  = true;
            return this;
        }

        public CenterFactory Latitude(double value)
        {
            map.Latitude = value;
            return this;
        }

        public CenterFactory Longitude(double value)
        {
            map.Longitude = value;
            return this;
        }

        public void Address(string address)
        {
            map.Address = address;
        }
    }
}
