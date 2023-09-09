/*using System;
using System.Net;
using MaxMind.GeoIP2;
using Useragent.Service.Interfaces;

namespace Useragent.Service.Services;
public class GeoIPService : IGeoIPService
{
    private readonly DatabaseReader _reader;

    public GeoIPService(string databasePath)
    {
        _reader = new DatabaseReader(databasePath);
    }

    public (string Country, string Region) GetCountryAndRegion(string ipAddress)
    {
        try
        {
            var response = _reader.City(IPAddress.Parse(ipAddress));
            var country = response.Country.Name;
            var region = response.MostSpecificSubdivision.Name;

            return (country, region);
        }
        catch (Exception ex)
        {
            // Xatolikni qaytarish yoki xatoni qaytarish uchun kerakli tadbirlarni oling
            Console.WriteLine($"Xatolik: {ex.Message}");
            return ("N/A", "N/A");
        }
    }

}

*/