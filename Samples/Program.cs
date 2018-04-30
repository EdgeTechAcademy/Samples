﻿using System;
using System.Collections.Generic;

namespace Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            //IfStatements();
            //ForStatements();
            //LoopWithTryParse();
            //GreatestCommonDivisor();
            //ArrayExamples();
            ParsingTest();
            //Fibonacci();
            //FunWithStrings();
            //PlayLottery();
            //ListDemo();
            //Variables();
            //StringTests();
            //NumberCompare();
            //WordArrays();
            //int number1 = GetUserNumber("Array Size? ");
            //string[] names = GetNameList(number1);
            //for (int i = 0; i < names.Length; i++)
            //{
            //    Console.WriteLine("Name {0} : {1}", i, names[i]);
            //}
            Console.ReadLine();
        }

        private static void WordArrays()
        {
            int result;
            string line = GetUserInput("Enter a string ");
            result = GetWordCount(line);
            Console.WriteLine("WordCount for {0} : {1} words", line, result);

            string longestWord = GetLongestWord(line);
            Console.WriteLine("Longest word: {0}", longestWord);

        }

        private static void NumberCompare()
        {
            int result;
            int number1, number2;

            number1 = GetUserNumber("#1 ");
            number2 = GetUserNumber("#2 ");
            result = GetBigger(number1, number2);
            Console.WriteLine("This is the bigger number: {0}", result);

            number1 = GetUserNumber("#1 ");
            number2 = GetUserNumber("#2 ");
            result = GetBigger2(number1, number2);
            Console.WriteLine("This is the bigger number: {0}", result);

        }

        /*
            create variables that have the correct type
                  body temp 98.6 float
                  altitude    int
                  miles per gallon          float
                  is my car running         boolean
                  salary                    float, decimal, double
                  Bill Gates net worth      long, ulong
                  ave test scores           float, decimal
                  world population > 8B     long  ulong
                  distance                  ulong measure in miles, ly

            comparison     
                    if
                    operators   ==  <   >   <=  !=
                    compare X to Z
                    if ( x operator z )
                    {
                    }

            loops
                    for         when you know how many times
                    do-while    (at least one time)    
                    while

                    break       exiting a loop
                    return      exit loop and exit the method

                    continue    skip part of the loop. Go to the top of the loop

            methods
                signature
                    return      TYPE     
                    method      name
                    parameters  zero or more
                        opening paren (
                                    TYPE parma1,  TYPE param2, TYPE param3
                        closing paren )

                body
                    {
                            every thing between the braces
                    }
            classes
                properties
                methods
                constructors
                */

        /*
Assignment
    save the return value of each function to an appropriately typed variable
    print a message and the return value
*/
        /*
                    get two numbers from user
                    create function to return the larger number, code must use if statments
                    create function to return the smaller number, code must use the ? : construct
                    */
        public static int GetBigger(int num1, int num2)
        {
            if (num1 > num2)
            {
                return num1;
            }
            else
            {
                return num2;
            }
        }

        public static int GetBigger2(int num1, int num2)
        {
            return (num1 > num2) ? num1 : num2;
        }

        /*
        get string from user in main
        create function to return the number of words
        function is called GetWordCount
        */
        public static int GetWordCount(string str)
        {
//            return str.Split(" ").Length;
            string[] strArray = str.Split(" ");
            int wordCount = 0;
            for (int i = 0; i < strArray.Length; i++)
            {
                if (strArray[i].Length > 0)
                    wordCount++;
            }
            return wordCount;
        }

        /*
            create function to return the longest word in a string
        */
        public static string GetLongestWord(string sentence)
        {
            string[] words = sentence.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string longestWord = "";

            foreach (string word in words)
            {
                if (word.Length > longestWord.Length)
                {
                    longestWord = word;
                }
            }
            return longestWord;
        }
        /*
        ask user for a number in main
        create a function GetNameList, passing in the number
            create an array of strings the size of the number passed in
            use a for loop to ask the user for names
            add the names to the string array you created
            return the array
            up in main print out the array using foreach 
        */
        public static string[] GetNameList(int size)
        {
            string[] list = new string[size];

            for (int i = 0; i < size; i++)
            {
                list[i] = GetUserInput("Name " + (i + 1) + " ");
            }
            return list;
        }

        public static void StringTests()
        {
            while (true)
            {
                string str1 = GetUserInput("String 1: ");
                if (str1.Length == 0)
                    break;
                string str2 = GetUserInput("String 2: ");
                Console.WriteLine("{0} :  {1} {2} Ignore case", str1, str2, str1.Equals(str2, StringComparison.OrdinalIgnoreCase));
                Console.WriteLine("{0} == {1} {2} ", str1, str2, str1 == str2);
                Console.WriteLine("{0} ?  {1} {2} CompareTo", str1, str2, str1.CompareTo(str2));
                Console.WriteLine("{0} != {1} {2} ", str1, str2, (str1 != str2));
            }
        }
        public static void Variables()
        {
            /*
                name the C# primatives types
                        string, int, float, long, ulong, uint, double, bool, char
                        decimal, byte, short, ushort
            */
            //  1   2 numbers 0 or 1
            //  2   4 numbes 00, 01, 10, 11
            //  3   8 numbers 000, 001, 010, 011, 100, 101, 110, 111
            //  4   16
            //  5   32

            //  32 bit number X000 1111 0000 1111 0000 1111 0000 1111
            //      -2B - 2B
            //      unint   4B
            int age, hour, dayOfMonth, weatherTemp, windSpeed, numberOfBigMacs;
            int num1 = 10_000_000, num2 = 2;
            if (num1 > num2)
            {
                Console.WriteLine("Bigger # : {0}", num1);
            }
            else
            {
                Console.WriteLine("Bigger # : {0}", num2);
            }

            //  "", "1234"
            string str1 = "10000000", str2 = "9";
            if (str1.CompareTo(str2) > 0)
            {
                Console.WriteLine("Bigger String : {0]", str1);
            }
            else
            {
                Console.WriteLine("Bigger String : {0}", str2);
            }
            string name, desc, sku, city, zip, ssn, phoneNum;

            float bodyTemp, distanceToHome, ageBefore10, longitude;
            bodyTemp = 98.6f;
            ageBefore10 = (float)9.5;


            Console.WriteLine("{0:C}", 78888.894);
            String.Format("[{0, 10}]", "Foo"); //   [∙∙∙∙∙∙∙Foo]
            String.Format("[{0, 5}]", "Foo");      //   [∙∙Foo]
            String.Format("[{0, -5}]", "Foo");     //   [Foo∙∙]
            String.Format("[{0, -10}]", "Foo");    //   [Foo∙∙∙∙∙∙∙]
    }

        public static int CalculateCentury(int year)
        {
            return year / 100 + ((year % 100 == 0) ? 0 : 1);
        }

        private static void ParsingTest()
        {
            float floatNum;
            int intNum, fCnt = 0, iCnt = 0, sCnt = 0;
            string[] strArray = new string[5];
            int[] intArray = new int[3];
            float[] floatArray = new float[2];

            while (true)
            {
                string input = GetUserInput("give me anything or 'exit' or 'stats'\n\t-> ");
                
                //      exit if user types exit
                if (input.Equals("exit"))
                    break;

                //  show some stats
                if (input.Equals("stats"))
                {
                    Console.WriteLine("\n\tFloats {0}\n\tInts {1}\n\tStrings {2}\n", floatArray.Length, intArray.Length, strArray.Length);
                    continue;
                }

                //      did we get an integer
                //          then add to the int array IF there is room
                if (Int32.TryParse(input, out intNum))
                {
                    if (iCnt < intArray.Length)
                        intArray[iCnt++] = intNum;
                    else
                    {
                        Console.WriteLine("Int array is full!");
                        foreach (int item in intArray)
                        {
                            Console.WriteLine("\t{0}", item);
                        }
                    }
                }

                //      did we get a float
                //          then add to the float array IF there is room
                else if (float.TryParse(input, out floatNum))
                {
                    if (fCnt < floatArray.Length)
                        floatArray[fCnt++] = floatNum;
                    else
                    {
                        Console.WriteLine("Float array is full!");
                        foreach (float item in floatArray)
                        {
                            Console.WriteLine("\t{0}", item);
                        }
                    }
                }

                //      if MUST be a string 
                //          then add to the string array IF there is room
                else
                {
                    if (sCnt < strArray.Length)
                        strArray[sCnt++] = input;
                    else
                    {
                        Console.WriteLine("String array is full!");
                        foreach (string item in strArray)
                        {
                            Console.WriteLine("\t{0}", item);
                        }
                    }
                }
            }
        }

        private static void ListDemo()
        {
            string userResponse;
            List<string> names = new List<string>() { "Gary", "Thomas", "James" };
            do
            {
                userResponse = GetUserInput("Add to List ");
                names.Add(userResponse);

            } while (userResponse.ToLower().CompareTo("stop") != 0);

            Console.WriteLine();
            do
            {
                userResponse = GetUserInput("Search List for: ");
                bool found = names.Contains(userResponse);
                if (found)
                {
                    int where = names.IndexOf(userResponse);
                    Console.WriteLine("\t" + userResponse + " Was found at " + where);
                }
                else
                {
                    Console.WriteLine("\t" + userResponse + " Was not found");
                }
            } while (!userResponse.ToLower().Equals("stop"));

            Console.WriteLine();
            do
            {
                userResponse = GetUserInput("Find in List: ");
                List<string> subNames = names.FindAll(p => p.Contains(userResponse));
                foreach (var item in subNames)
                {
                    Console.WriteLine("\t" + item);
                }
            } while (userResponse.Length > 0);

        }

        private static int GetUserNumber(string prompt)
        {
            int userNumber;
            string strNumber = GetUserInput(prompt);
            while ( ! Int32.TryParse(strNumber, out userNumber))
            {
                Console.WriteLine("That is not an integer");
                strNumber = GetUserInput(prompt);
            }

            return userNumber;
        }

        private static string GetUserInput(string prompt)
        {
            Console.Write(prompt);
            string str = Console.ReadLine();
            return str;
        }

        private static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        private static void ArrayExamples()
        {
            int[] nums = { 3, 4, 1, 5, 7, 2, 1, 7, 8, 9 };
            for (int i = 0; i < nums.Length; i += 2)
            {
                Console.WriteLine("index : " + i + " = " + nums[i]);
            }

            int[] array2 = new int[10];
            string[] strArray = new string[10];

            Console.WriteLine("Enter a Student names: ");
            for (int i = 0; i < strArray.Length; i++)
            {
                Console.Write(i + ": ");
                strArray[i] = Console.ReadLine();
            }

            string search;
            do
            {
                search = GetUserInput("Search for Student: ");
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (strArray[i].Equals(search))
                    {
                        Console.WriteLine("Found " + search + " at entry " + i);
                    }
                }
            } while (! search.Equals("stop"));
        }

        public static void PlayLottery()
        {
            ulong balls, pick;
            while (true)
            {
                Console.Write("Enter a Number (0 to quit): ");
                balls = Convert.ToUInt64(Console.ReadLine());
                Console.Write("Enter a Number: ");
                pick = Convert.ToUInt64(Console.ReadLine());
                if (balls <= 0)
                    break;
                Console.WriteLine(Factorial(balls) / Factorial(pick));
            }
        }

        private static ulong Factorial(ulong num)
        {
            ulong factorial = 1;
            for (ulong i = 1; i <= num; i++)
            {
                factorial *= i;
            }
            return factorial;
        }

        private static void GreatestCommonDivisor()
        {
            long bigNum, smallNum;
            long remainder;
            string yes;
            do
            {
                Console.Write("Enter a Number: ");
                bigNum = Convert.ToInt64(Console.ReadLine());
                Console.Write("Enter a Number: ");
                smallNum = Convert.ToInt64(Console.ReadLine());
                do
                {
                    remainder = bigNum % smallNum;
                    Console.WriteLine(bigNum + " % " + smallNum + " r=" + remainder);
                    if (remainder != 0)
                    {
                        bigNum = smallNum;
                        smallNum = remainder;
                    }
                } while (remainder != 0);
                Console.WriteLine("GCD is: " + smallNum);

                Console.Write("Enter Y to continue: ");
                yes = Console.ReadLine().ToLower();

            } while (yes.Equals("y"));
        }

        private static void GCD()
        {
            long bigNum, smallNum;
            long remainder;
            string yes;
            do
            {
                Console.Write("Enter a Number: ");
                smallNum = Convert.ToInt64(Console.ReadLine());
                Console.Write("Enter a Smaller Number: ");
                remainder = Convert.ToInt64(Console.ReadLine());
                do
                {
                    bigNum = smallNum;
                    smallNum = remainder;
                    remainder = bigNum % smallNum;
                    Console.WriteLine(bigNum + " % " + smallNum + " r=" + remainder);
                } while (remainder != 0);
                Console.WriteLine("GCD is: " + smallNum);
                Console.Write("Enter Y to continue: ");
                yes = Console.ReadLine().ToLower();

            } while (yes.Equals("y"));
        }

        private static void Fibonacci()
        {
            ulong fib1 = 1, fib2 = 1;
            ulong next;
            int num;
            Console.Write("Enter how many Fibonacci numbers you want: ");
            num = Convert.ToInt32(Console.ReadLine());

            for (int i = 3; i < num; i++)
            {
                next = fib1 + fib2;
                fib2 = fib1;
                fib1 = next;
                Console.WriteLine("Fibonacci # " + i + " = " + next);
            }
        }

        private static void FunWithStrings()
        {
            string name = "this is a longer string with more words and more chances to find and replace letters like e";
            name = "Edge Tech Academy";
            Console.WriteLine("My name is '" + name + "' and it is " + name.Length + " characters long");

            bool hasTech = name.Contains("Tech");
            Console.WriteLine("Does my name contain Tech? " + (hasTech ? "Why yes is does!" : "No Tech :-("));

            bool isBoring = name.Contains("boring stuff");
            Console.WriteLine("Does my name contain 'boring stuff'? " + (isBoring ? "Not So!" : "All exciting stuff"));

            bool ending = name.EndsWith("h Academy");
            Console.WriteLine("Does my name end with 'h Academy'? " + (ending ? "yup" : "nope"));

            bool starting = name.StartsWith("Edge");
            Console.WriteLine("Does my name start with 'Edge'? " + (starting ? "yup" : "nope"));

            bool doTheyMatch = name.Equals("EDGE tech ACADemy");
            Console.WriteLine("Are they equal? " + (doTheyMatch ? "yup" : "nope"));

            bool ignoreCase = name.Equals("EDGE tech ACADemy", StringComparison.CurrentCultureIgnoreCase);
            Console.WriteLine("Can I compare and ignore case? " + (ignoreCase ? "yup" : "nope"));

            string str1 = "STRING 1";
            Console.WriteLine("Which string is 'bigger'?  {0}", str1.CompareTo("STRING 1") );
            Console.WriteLine("Which string is 'bigger'?  {0}", str1.CompareTo("STRING 2"));
            Console.WriteLine("Which string is 'bigger'?  {0}", String.Compare(str1, "string 1", StringComparison.CurrentCultureIgnoreCase));

            int eIndex = name.IndexOf("e");
            while (eIndex >= 0)
            {
                Console.WriteLine("Found 'e' at: " + eIndex);
                eIndex = name.IndexOf("e", eIndex + 1);
            }
            string newString = name.Insert(8, ">HELLO!<");
            Console.WriteLine(newString);

            int dIndex = name.LastIndexOf('d');
            Console.WriteLine("Found last 'd' at: " + dIndex);

            name = "Gary Thomas James";
            string initials = "";
            string[] aNames = name.Split(" ");
            foreach (string str in aNames)
            {
                initials += str.Substring(0, 1);
                string padLeft = str.PadLeft(15, '.');
                string padRight = str.PadRight(15, '_');
                Console.WriteLine("Pad Left  ->" + padLeft + "<");
                Console.WriteLine("Pad Right ->" + padRight + "<");

                Console.WriteLine("Unpad " + padLeft.Trim('.'));
                Console.WriteLine("Unpad " + padRight.Trim('_'));
            }
            Console.WriteLine("Intials for {0} are {1}", name, initials);

            string nickName = name.Remove(4);
            Console.WriteLine(nickName);

            Console.WriteLine("Chop characters out of the middle: " + name.Substring(7, 8));

            Console.WriteLine("Look Ma! No 'e's! " + name.Replace('e', '_'));

            string just1Letter = name.Substring(3, 1);

            Console.WriteLine("UPPER: {0} {1}", name, name.ToUpper());
            Console.WriteLine("lower: {0} {1}", name, name.ToLower());
        }

        private static void ForStatements()
        {
            Console.Write("Initialize loop: ");
            int start = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter loop termination: ");
            int loop = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter loop increment: ");
            int increment = Convert.ToInt32(Console.ReadLine());

            for (int i = start; i < loop; i += increment)
            {
                Console.WriteLine("loop index: " + i);
            }
        }

        static void LoopWithTryParse()
        {
            int nTestScore = 0, nTotalScores = 0;
            double dblRunningTotal = 0;

            //loops until negative score value < 0 is typed.
            while (nTestScore >= 0)
            {
                //initial prompt
                Console.Write("Enter a test score or < 0 to exit: ");
                if (Int32.TryParse(Console.ReadLine(), out nTestScore) == false)
                {
                    Console.WriteLine("That is not an integer.  Please Reenter.");
                }
                else
                {
                    if (nTestScore >= 0)
                    {
                        nTotalScores++;
                        dblRunningTotal += nTestScore;
                    }
                }
            }
            Console.WriteLine("The score Total   is: " + dblRunningTotal);
            Console.WriteLine("The score Average is: " + dblRunningTotal / nTotalScores);
            Console.ReadLine();
        }

        private static void IfStatements()
        {
            Console.Write("Enter Student 1 age: ");
            int student1Age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Student 2 age: ");
            int student2Age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Student 3 age: ");
            int student3Age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Student " + ((student1Age > student2Age && student1Age > student3Age) ? 1 :
                                            (student2Age > student3Age) ? 2 : 3) + " is the oldest student");

            if (student1Age > student2Age && student1Age > student3Age)
            {
                // student 1 is older than student 2 and student 3
                Console.WriteLine("Student 1 is the oldest student");
            }
            else
            {
                if (student2Age > student3Age)
                {
                    // student 2 is older than student 1 and student 3
                    Console.WriteLine("Student 2 is the oldest student");
                }
                else
                {
                    // student 3 is older than student 1 and student 3
                    Console.WriteLine("Student 3 is the oldest student");
                }
            }

            if (student1Age > student2Age)
            {
                //  student 1 is older than student 2
                if (student1Age > student3Age)
                {
                    // student 1 is older than student 2 and student 3
                    Console.WriteLine("Student 1 is the oldest student");
                }
                else
                {
                    // student 3 is older than student 2 and student 1
                    Console.WriteLine("Student 3 is the oldest student");
                }
            }
            else
            {
                //  student 2 is older that student 1
                if (student2Age > student3Age)
                {
                    // student 2 is older than student 2 and student 1
                    Console.WriteLine("Student 2 is the oldest student");
                }
                else
                {
                    // student 3 is older than student 2 and student 1
                    Console.WriteLine("Student 3 is the oldest student");
                }
            }
        }

        static DateTime GetDay()
        {
            DateTime dt = new DateTime();
            return dt;
        }
    }
}
