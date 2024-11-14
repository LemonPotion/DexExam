namespace Domain.ValueObjects;

public class Address
{
    public Address(string streetName, int streetNumber, string countryCode, string cityName)
    {
        StreetName = streetName;
        StreetNumber = streetNumber;
        CountryCode = countryCode;
        CityName = cityName;
    }

    public string StreetName { get; private set; }
    
    public int StreetNumber { get; private set; }
    
    public string CountryCode { get; private set; }
    
    public string CityName { get; private set; }
}