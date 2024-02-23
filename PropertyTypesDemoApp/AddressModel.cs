using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyTypesDemoApp
{
    public class AddressModel
    {
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public string FullAddress => $"{StreetAddress},{City}: {State} - {ZipCode}";


        public AddressModel(string streetAddress, string city, string state, string zipCode)
        {
            StreetAddress = streetAddress;
            City = city;
            State = state;
            ZipCode = zipCode;
        }
        public AddressModel()
        {

        }


    }
}
