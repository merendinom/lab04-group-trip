/* 
* Name:                Michael Oliver Merendino
* Course:              CSCI 1250, Section 001
* Assignment:          Lab 04, Group Trip Calculator
* Date:                October 07, 2026
* Description:         Calculates the fuel, food, and work hours behind one road trip with multiple people, by using ethods and arrays.
*/


//================== the constants ====================

int slicesperpizza = 8;
double TaxRate = .18;

//==================== part 1 =====================

Console.Write("what was the round trip in miles? ");
int milesforthetrip = Convert.ToInt32(Console.ReadLine());

Console.Write("what is the miles per gallon of the car you are using? ");
int milespergallon = Convert.ToInt32(Console.ReadLine());

Console.Write("what was the gas price per gallon? ");
double gasprice = Convert.ToDouble(Console.ReadLine());

System.Console.Write("how many pizzas? ");
int numberofpizzas = Convert.ToInt32(Console.ReadLine());

System.Console.Write("price per pizza? ");
double priceperpizza = Convert.ToDouble(Console.ReadLine());


// math for the method
double fuelCost = FuelCost(milesforthetrip, milespergallon, gasprice);
double pizzacost = numberofpizzas * priceperpizza;
double tripTotal = fuelCost + pizzacost;

//do the output

System.Console.WriteLine("\n=== Part 1: The Trip ===");
System.Console.WriteLine("Fuel cost: " + fuelCost.ToString("C"));
System.Console.WriteLine("Pizza cost: " + pizzacost.ToString("C"));
System.Console.WriteLine("Trip total: " + tripTotal.ToString("C"));


//===================== Part 2: The Group ====================

string[] names = { "Ada", "Grace", "Alan", "Katherine" };
double[] hoursWorked = { 22, 15, 30, 18 };
double[] hourlyRates = { 13.50, 16.00, 11.20, 14.80 };

//math for method
double totalSlices = numberofpizzas * slicesperpizza;
double slicesEach = totalSlices / names.Length;
double CostPerPerson = tripTotal / names.Length;

//output
System.Console.WriteLine("\n=== Part 2: The Group ===");
System.Console.WriteLine("People going: " + names.Length);
System.Console.WriteLine("Slices each: " + slicesEach);
System.Console.WriteLine("Cost per person: " + CostPerPerson.ToString("C"));
System.Console.WriteLine();

//=================== Part 3: The Report ==================
System.Console.WriteLine("\n=== Part 3: The Report ===");
double totalHours = 0;
double totalTakeHomePay = 0;
double longestHoursNeeded = 0;

for (int i = 0; i < names.Length; i++)
{
    double takeHomePay = TakeHomePay(hoursWorked[i], hourlyRates[i], TaxRate);
    double takeHomePerHour = takeHomePay / hoursWorked[i];
    double hoursNeeded = HoursToCover(CostPerPerson, takeHomePerHour);

    totalHours += hoursWorked[i];
    totalTakeHomePay += takeHomePay;
    longestHoursNeeded = Math.Max(longestHoursNeeded, hoursNeeded);

    System.Console.WriteLine($"{names[i]}: take home {takeHomePay.ToString("C")} for {hoursWorked[i]} hours, {takeHomePerHour.ToString("C")} per hour, must work {hoursNeeded.ToString("F2")} hours");
}


System.Console.WriteLine("\nTotal hours worked: " + totalHours);
System.Console.WriteLine("Take Home Pay: " + totalTakeHomePay.ToString("C"));
System.Console.WriteLine("Longest anyone ust work: " + longestHoursNeeded.ToString("F2"));



//====================== methods =======================

static double FuelCost(double miles, double milesPerGallon, double pricePerGallon)
{
    double gallons = miles / milesPerGallon;
    return gallons * pricePerGallon;
}

static double TakeHomePay(double hours, double hourlyRate, double taxRate)
{
    double grossPay = hours * hourlyRate;
    double TaxWithheld = grossPay * taxRate;
    return grossPay - TaxWithheld;
}

static double HoursToCover(double amountOwed, double takeHomePerHour)
{
    return amountOwed / takeHomePerHour;
}