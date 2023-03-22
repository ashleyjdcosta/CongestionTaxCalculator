using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using congestion.calculator.Models;
using congestion.calculator;
using System.Globalization;

public class CongestionTaxCalculator1
{
    //Initialize the variables
    private readonly int maxDailyFee;
    private readonly List<string> tollFreeVehicles;
    private readonly List<DateTime> tollFreeDates;
    private readonly List<TollFee> tollFees;    

    public CongestionTaxCalculator1()
    {        
        //Using the json store to extract data
        string json = File.ReadAllText("appsettings.json");        
        CongestionData congestionData = JsonConvert.DeserializeObject<CongestionData>(json);
        maxDailyFee = congestionData.max_daily_fee;
        tollFreeVehicles = congestionData.toll_free_vehicles;
        tollFreeDates = congestionData.toll_free_dates.Select(dateStr => DateTime.Parse(dateStr)).ToList();
        tollFees = congestionData.toll_fees.Select(fee => new TollFee(fee.start, fee.end, fee.fee)).ToList();
    }   

    public int GetTax(Vehicle vehicle, DateTime[] dates)
    {
        DateTime intervalStart = dates[0];
        int totalFee = 0;
        foreach (DateTime date in dates)
        {
            int nextFee = GetTollFee(date, vehicle);
            int tempFee = GetTollFee(intervalStart, vehicle);

            //Here I have made use of a fix to check the time difference for an hour based on the minutes and not on the milliseconds
            TimeSpan diff = date.Subtract(intervalStart);
            int minutes = (int)diff.TotalMinutes;
            
            //A single charge rule applies in Gothenburg. Under this rule, a vehicle that passes several tolling stations within 60 minutes is only taxed once. The amount that must be paid is the highest one.
            if (minutes <= 60)
            {
                if (totalFee > 0) totalFee -= tempFee;
                if (nextFee >= tempFee) tempFee = nextFee;
                totalFee += tempFee;
            }
            else
            {
                totalFee += nextFee;
            }

            intervalStart = date;
        }
        if (totalFee > maxDailyFee) totalFee = maxDailyFee;
        return totalFee;
    }

    public bool IsTollFreeVehicle(Vehicle vehicle)
    {
        if (vehicle == null) return false;
        string vehicleType = vehicle.GetVehicleType();
        return tollFreeVehicles.Contains(vehicleType.ToLower());
    }

    public bool IsTollFreeDate(DateTime date)
    {
        return tollFreeDates.Any(d => d.Date == date.Date);
    }

    public int GetTollFee(DateTime date, Vehicle vehicle)
    {
        if (IsTollFreeDate(date) || IsTollFreeVehicle(vehicle)) return 0;

        int hour = date.Hour;
        int minute = date.Minute;

        foreach (TollFee fee in tollFees)
        {
            if (DateTime.TryParseExact(fee.start, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startTime))
            {
                if (hour > startTime.Hour || (hour == startTime.Hour && minute >= startTime.Minute))
                {
                    if (DateTime.TryParseExact(fee.end, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime endTime))
                    {
                        if (hour < endTime.Hour || (hour == endTime.Hour && minute <= endTime.Minute))
                        {
                            return fee.fee;
                        }
                    }
                }
            }
        }


        return 0;
    }
}
