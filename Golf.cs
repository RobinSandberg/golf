using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golf
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
            // list of values
            double Gravity = 9.8;
            double Radians = 0;
            double Distance = 0;
            double start = Hole();
            int swing = Convert.ToInt32(start / 100) + 1;
            double hit = (start - Distance);
            Console.WriteLine("\nDistance to the hole: " + start + "\r\namount of swings for this hole: " + swing);
            Console.WriteLine("Warning if you shoot over twice the distance to the hole it's game over.\n");
            // List to add how far each swing traveled at the end of the game.
            List<double> swinglist = new List<double>();

            // loop until they run out of swings or hit the hole.
            while (hit > 0.1 && swing > 0)
            {
                //Input for the angle to shoot the ball.
                Radians = (Math.PI / 180) * GetAngle(); // angle in radians.
                //Input for strenght of hitting the ball.
                Distance = Math.Pow(GetVelocity(), 2) / Gravity * Math.Sin(2 * Radians); //distance traveled.   

                if (Distance > start * 2) // For when user hit twice the starting Distance. Game over and shut game down.
                {
                    Console.WriteLine("\nTo hard out of bounds\nGame over\nPress any key to exit.");
                    Console.ReadKey();
                    Environment.Exit(0);
                }

                swinglist.Add(Distance); // Add the distance to each swing to the list.
                //Just a space between lines to make console easier to read.
                Console.WriteLine("");
                //Write out how far you hit and how far left to the hole.
                Console.WriteLine("The distance you shot the ball is: " + Distance);
                // New distance calculation to update hit don't use start.
                hit -= Distance;

                // To stop the distance from becomming negative.
                if (hit < 0)
                {
                    hit = hit * -1;
                }

                // Messages after each swing
                Console.WriteLine("Distance left to the hole: " + hit + "\r\nAmount of swings you got left to hit the hole: " + (swing -= 1));
                Console.WriteLine(""); //Just a space between lines to make console easier to read.
            }

            // when they get below 0.1meters from the hole they win.
            if (hit < 0.1)
            {
                Console.WriteLine("Ball went into the hole. Congratulation!");

            }
            //when they hit 0 swings the game fail.
            else
            {
                Console.WriteLine("You failed to many swings");
            }
            // list of the strikes and distance for each strike printed at the end.
            for (int strikes = 0; strikes < swinglist.Count; strikes++)
                Console.WriteLine($"\nswing {strikes} = traveled {swinglist[strikes]}");

            Console.WriteLine("\nPress any key to Exit.");
            Console.ReadKey();
        }



        // The random distance calculation for each map.
        static Random _r = new Random();
        static double Hole()
        {
            double n = _r.Next(200, 900);
            return n;
        }



        // The starting menu before entering the game.
        static void Menu()
        {
            bool gamestart = true;
            Console.Write("Welcome to the pro golf tournament" + "\r\nDo you wanna enter the tournament?" + "\r\n1. Yes 2. Exit: ");
            while (gamestart)
            {
                char input = GetInput();

                switch (input)
                {
                    case '1':
                        Console.WriteLine("\nStarting the game.");
                        gamestart = false;
                        break;
                    case '2':
                        Console.WriteLine("\nExiting the game.\nPress any key to exit.");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("\nwrong input try again.");
                        break;
                }
            }
        }
        static char GetInput()
        {
            ConsoleKeyInfo userIn = Console.ReadKey(true);
            return userIn.KeyChar;
        }
        static double GetAngle()
        {
            bool keeptrying = true;
            double angle = 0;
            while (keeptrying)
            {
                Console.Write("Select at what angle you wanna hit the golfball between 5 and 80: ");
                string userIn = Console.ReadLine();
                try
                {
                    angle = Convert.ToDouble(userIn);
                    if (angle < 5 || angle > 80)
                    {
                        keeptrying = true;
                    }
                    else
                    {
                        keeptrying = false;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Not a number");
                }
                catch (Exception)
                {
                    Console.WriteLine("Error");
                }
            }
            return angle;
        }
        static double GetVelocity()
        {
            bool keeptrying = true;
            double velocity = 0;
            while (keeptrying)
            {
                Console.Write("Select the velocity you wanna hit the ball between 1 and 100: ");
                string userIn = Console.ReadLine();
                try
                {
                    velocity = Convert.ToDouble(userIn);
                    if (velocity < 1 || velocity > 100)
                    {
                        keeptrying = true;
                    }
                    else
                    {
                        keeptrying = false;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Not a number");
                }
                catch (Exception)
                {
                    Console.WriteLine("Error");
                }
            }
            return velocity;
        }
    }
}