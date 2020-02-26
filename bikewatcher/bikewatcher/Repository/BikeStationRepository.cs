using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using bikewatcher.Entity;

namespace bikewatcher.Repository
{
    public class BikeStationRepository
    {
        private static string url = "https://download.data.grandlyon.com/ws/rdata/jcd_jcdecaux.jcdvelov/all.json";
        private static string urlBordeaux = "https://api.alexandredubois.com/vcub-backend/vcub.php";

        private static readonly HttpClient client = new HttpClient();

        public static async Task<List<BikeStation>> ProcessBikeStation()
        {
            var streamTask = await client.GetStreamAsync(url);

            var result = await JsonSerializer.DeserializeAsync<RootObject>(streamTask);
            return result.values;
        }

        public static async Task<List<BikeStation>> ProcessBikeStationBordeauxx()
        {
            var streamTask = await client.GetStreamAsync(urlBordeaux);
            var stationsBdx = await JsonSerializer.DeserializeAsync<List<BikeStationBordeaux>>(streamTask);

            List<BikeStation> stations = new List<BikeStation>();
            foreach (BikeStationBordeaux stationBdx in stationsBdx)
            {
                stations.Add(new BikeStation(stationBdx));
            }

            return stations;
        }
    }
}
