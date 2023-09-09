﻿using Useragent.Service.Interfaces;

namespace Useragent.Service.Services;

public class GeoInfoProvider : IGeoInfoProvider
{
    private readonly HttpClient _httpClient;
    //create constructor and call HttpClient
    public GeoInfoProvider()
    {
        _httpClient = new HttpClient()
        {
            Timeout = TimeSpan.FromSeconds(5)
        };
    }
    private async Task<string> GetIPAddress()
    {
        var ipAddress = await _httpClient.GetAsync($"http://ipinfo.io/ip");
        if (ipAddress.IsSuccessStatusCode)
        {
            var json = await ipAddress.Content.ReadAsStringAsync();
            return json.ToString();
        }
        return "";
    }

    public async Task<string> GetGeoInfo()
    {
        //I have already created this function under GeoInfoProvider class.
        var ipAddress = await GetIPAddress();
        // When geting ipaddress, call this function and pass ipaddress as given below
        var response = await _httpClient.GetAsync($"http://api.ipstack.com/" 
            + ipAddress + "?access_key=84dbd3278e624e0f8b9416ca87f0754f");
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            return json;
        }
        return null;
    }

}