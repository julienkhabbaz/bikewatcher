﻿using System;
using System.Linq;
using bikewatcher.Utilitaire;
using System.Globalization;

namespace bikewatcher.Entity
{
    public class BikeStation
    {
        public BikeStation()
        {

        }

        public BikeStation(BikeStationBordeaux bdx)
        {
            available_bikes = bdx.bike_count_total.ToString();
            bike_stands = bdx.slot_count.ToString();
            lng = bdx.longitude;
            lat = bdx.latitude;
            name = bdx.name;
        }

        public string number { get; set; }
        public string pole { get; set; }
        public string available_bikes { get; set; }
        public string code_insee { get; set; }
        public string lng { get; set; }
        public string availability { get; set; }
        public string availabilitycode { get; set; }
        public string etat { get; set; }
        public string startdate { get; set; }
        public string langue { get; set; }
        public string bike_stands { get; set; }
        public string last_update { get; set; }
        public string available_bike_stands { get; set; }
        public string gid { get; set; }
        public string titre { get; set; }
        public string status { get; set; }
        public string commune { get; set; }
        public string description { get; set; }
        public string nature { get; set; }
        public string bonus { get; set; }
        public string address2 { get; set; }
        public string address { get; set; }
        public string lat { get; set; }
        public string last_update_fme { get; set; }
        public string enddate { get; set; }
        public string name { get; set; }
        public string banking { get; set; }
        public string nmarrond { get; set; }

        public double distance;

        public double GetDistanceFromUser(float lat, float lon)
        {
            distance = DistanceGeographicTool.GetDistanceBetweenPoints(float.Parse(this.lat, CultureInfo.InvariantCulture), float.Parse(this.lng, CultureInfo.InvariantCulture), lat, lon);
            return distance;
        }
    }
}
