/***************************************************************
* Name        : List Arrays
* Author      : Jeremy Brannen
* Created     : 10/06/2020
* Course      : CIS 169 - C#
* Version     : 1.0
* OS          : Windows XX, Visual Studio XX
* Copyright   : This is my own original work based on
*               specifications issued by our instructor
* Description : This program overall description here
*               Input:  list and describe
*               Output: list and describe
* Academic Honesty: I attest that this is my original work.
* I have not used unauthorized source code, either modified or 
* unmodified. I have not given other fellow student(s) access 
* to my program.         
***************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;

namespace ListArraysBrannen
{
    class Program
    {   //method to sort list in alphabetical order, returns the list
        public static List<string> SortList(List<string> List)
        {
            List.Sort();
            return List;
        }
        //method to sort and array of scores, returns scores desending order
        public static double[] SortArray(double[] scores)
        {
            Array.Sort(scores);
            Array.Reverse(scores);
            return scores;
        }
        //method takes a string and compares to elements in list, returns boolean
        public static bool SearchList(List<string> List, string major)
        {
            bool valMajor;
            valMajor = List.Contains(major);
            return valMajor;
        }
        //method takes a string and searches for match in an array, returns boolean
        public static bool SearchArray(string[] array, string name)
        {
            bool found = array.Contains(name);

            return found;
        }
        static void Main(string[] args)
        {
            //list with literal variables added
            List<string> subjects = new List<string>();
            subjects.Add("Computer Science");
            subjects.Add("Web Development");
            subjects.Add("Cybersecurity");
            subjects.Add("Networking");

            //variables and arrays with literal variables
            string major;
            bool valMajor;
            bool found;
            int idx;
            string[] studentName = { "Ayah", "Manual", "Mohamed", "Vasavi", "Rosa" };
            int[] majorSubject = { 0, 1, 2, 3, 3 };
            int[] studentId = { 322, 323, 334, 325, 318 };
            double[] studentScore = { -1, -1, -1, -1, -1 };
            double validScore;
            const int MAX_SCORE = 100;
            const int MIN_SCORE = 0;

            //method call to sort subjects alphabetically
            SortList(subjects);

            //prompt user for a major, calls method to see if major is in array
            Console.WriteLine("What is your major?");
            major = Console.ReadLine();
            valMajor = SearchList(subjects, major);

            if (valMajor == true)
            {
                Console.WriteLine("That major does exist.\n");
            }
            else
            {
                Console.WriteLine("That major does not exist.\n");
            }

            //prompts user for all students scores for each student
            for (int index = 0; index < studentName.Length; index++)
            {
                Console.Write("Enter a score for ");
                Console.Write(studentName[index] + ", ");
                Console.Write("Id: " + studentId[index].ToString() + ", ");
                Console.Write("Major: " + subjects[majorSubject[index]] + ": ");
                validScore = -9999;

                //while loop to prompt user for valid input if invalid input is entered
                while (validScore != studentScore[index])
                {
                    if (!double.TryParse(Console.ReadLine(), out validScore) || validScore > MAX_SCORE || validScore < MIN_SCORE)
                    {   
                        Console.WriteLine("Enter a valid score (0-100)");
                    }
                    else
                    {
                        studentScore[index] = validScore;
                    }
                }
            }

            //prompts user to enter a stundent name (ignores casing) to output the score 
            //previously entered by user that is stored in an array
            Console.Write("\nEnter a students name to retrieve their score: ");
            string name = Console.ReadLine();
            name = name.Substring(0, 1).ToUpper() + name.Substring(1).ToLower();
            found = SearchArray(studentName, name);
            if (found == true)
            {
                idx = Array.IndexOf(studentName, name);
                Console.WriteLine("\nThat student was found.");
                Console.WriteLine(studentName[idx] + "'s score is: " + studentScore[idx]);
            }
            else
            {
                Console.WriteLine("\nThat student was not found.");
            }
            //calls method to sort scores and output in decending order
            SortArray(studentScore);
            Console.Write("\nThe scores from highest to lowest are: ");
            foreach(double var in studentScore)
            {
                Console.Write(var + " ");
            }
        }
    }
}
