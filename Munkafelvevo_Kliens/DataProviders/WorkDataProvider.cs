using Munkafelvevo_Kliens.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Munkafelvevo_Kliens.DataProviders
{
    public static class WorkDataProvider
    {
        private static string _url = "http://localhost:5000/api/car_mechanic_work";

        public static IList<Work> GetWorks()
        {
            //works listáját lekérjük a szerverről
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(_url).Result;

                //Ha sikeres akkor a response-tól elkérjük a http message tartalmát, azaz a content-jét, ami stringbe csomagolt json.
                if (response.IsSuccessStatusCode)
                {
                    var rawData = response.Content.ReadAsStringAsync().Result;
                    //Ez json lesz és deszerializációval work-ök kollekciójává kell alakítani
                    var works = JsonConvert.DeserializeObject<IList<Work>>(rawData);
                    return works;
                }
                else
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }
        public static void CreateWork(Work work)
        {
            using (var client = new HttpClient())
            {
                var rawData = JsonConvert.SerializeObject(work);
                var content = new StringContent(rawData, Encoding.UTF8, "application/json");

                var response = client.PostAsync(_url, content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }

        public static void UpdateWork(Work work)
        {
            using (var client = new HttpClient())
            {
                var rawData = JsonConvert.SerializeObject(work);
                var content = new StringContent(rawData, Encoding.UTF8, "application/json");

                var response = client.PutAsync(_url, content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }

        public static void DeleteWork(long id)
        {
            using (var client = new HttpClient())
            {
                var response = client.DeleteAsync(_url + "/" + id).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }
    }
}
