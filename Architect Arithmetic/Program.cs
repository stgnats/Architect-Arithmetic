using System;

namespace ArchitectArithmetic
{
    class Program
    {
        //main code
        public static void Main(string[] args)
        {
            double tileCost = 0;
            double totalCost = 0;
            start:
            Console.WriteLine("What shape area would you like to calculate?");
            string ans = Console.ReadLine();
            switch (ans.ToLower())
            {
                case "triangle":
                    Console.Write("Please enter the height: ");
                    string tAns = Console.ReadLine();
                    double hResult = TParse(tAns); //the parse method uses the TryParse method and a while loop to keep going until the user has entered an eligible number
                    Console.Write("Please enter the base: ");
                    tAns = Console.ReadLine();
                    double bResult = TParse(tAns);
                    double tArea = TriArea(bResult, hResult); //takes the parsed numbers and calculates the area, outputs to tArea
                    Console.WriteLine("Please enter the cost of the tiles");
                    string tileCostStr = Console.ReadLine();
                    tileCost = TParse(tileCostStr);
                    totalCost = TileCost(tArea, tileCost); //takes the parsed tile cost and shape area and calculates the total cost
                    Console.WriteLine(totalCost);
                    break;
                case "rectangle":
                    Console.Write("Please enter the height: ");
                    string rAns = Console.ReadLine();
                    hResult = TParse(rAns);
                    Console.Write("Please enter the width: ");
                    rAns = Console.ReadLine();
                    double wResult = TParse(rAns);
                    double rArea = RectArea(wResult, hResult);
                    Console.WriteLine("Please enter the cost of the tiles");
                    tileCostStr = Console.ReadLine();
                    tileCost = TParse(tileCostStr);
                    totalCost = TileCost(rArea, tileCost);
                    Console.WriteLine(totalCost);
                    break;
                case "circle":
                    Console.Write("Please enter the radius: ");
                    string cAns = Console.ReadLine();
                    double rResult = TParse(cAns);
                    double cArea = CircArea(rResult);
                    Console.WriteLine("Please enter the cost of the tiles");
                    tileCostStr = Console.ReadLine();
                    tileCost = TParse(tileCostStr);
                    totalCost = TileCost(cArea, tileCost);
                    Console.WriteLine(totalCost);
                    break;
                default:
                    Console.WriteLine("Please enter circle, triange, or square");
                    goto start;
                    break;
            }
        }

        //calculating rectangular area
        public static double RectArea(double width = 0, double length = 0)
        {
            double area = width * length;
            return area;
        }

        //calculating circular area
        public static double CircArea(double radius = 0)
        {
            double area = Math.PI * Math.Pow(radius, 2); //math.pi gets the pi value and math.pow raises radius to the power of 2
            return area;
        }

        //calculating triangular area
        public static double TriArea(double bottom = 0, double height = 0)
        {
            double area = 0.5 * bottom * height;
            return area;
        }

        //calculating cost
        public static double TileCost(double calcResult = 0, double cost = 0)
        {
            double totalCost = calcResult * cost;
            return totalCost;
        }

        //try parse loop to tell user if they put in wrong data
        public static double TParse(string ans)
        {
            double result = 0;
            bool success = false;
            while (!success)
            {
                success = false;
                success = double.TryParse(ans, out result);
                if (success)
                {
                    break;
                }
                Console.Write("That's not correct, please try again: ");
            }
            return result;
        }
    }
}
