using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munkafelvevo_Kliens.Models
{
    public class Work
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Date { get; set; }
        public string TypeOfCar { get; set; }
        public string CarLicencePlate { get; set; }
        public string Issues { get; set; }
        public string StateOfWork { get; set; }

        public override string ToString()
        {
            return $"{Id}. {TypeOfCar}, {CarLicencePlate}: {Issues}";
        }
    }
}
