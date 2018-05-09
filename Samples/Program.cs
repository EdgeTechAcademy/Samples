using System;
using System.Collections.Generic;

namespace Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                switch (GetUserInput("? "))
                {
                    case "exit": return;
                    case "x": return;
                    case "":
                    case "menu":
                        Console.WriteLine("\tif\tfor\ttry\tgcd\tarray\tparse\tfib\n" +
                            "\tstrings\n\tlottery\tlist\tbar\tstring\tnum\twords\tfill\n" +
                            "\tchange\ttime\tlist\tenglish\tequation\n\texit");
                        break;
                    case "if": IfStatements(); break;
                    case "for": ForStatements(); break;
                    case "try": LoopWithTryParse(); break;
                    case "gcd": GreatestCommonDivisor(); break;
                    case "array": ArrayExamples(); break;
                    case "parse": ParsingTest(); break;
                    case "fib": Fibonacci(); break;
                    case "strings": FunWithStrings(); break;
                    case "lottery": PlayLottery(); break;
                    case "list": ListDemo(); break;
                    case "var": Variables(); break;
                    case "string": StringTests(); break;
                    case "num": NumberCompare(); break;
                    case "change": MakeChange(); break;
                    case "time":
                        int seconds = 0;
                        while (seconds >= 0)
                        {
                            string time = GetUserInput("Unit of Time: ");
                            seconds = GetSeconds(time);
                            Console.WriteLine("There are " + seconds + " seconds in a " + time);
                        }
                        break;

                    case "words": WordArrays(); break;
                    case "fill":
                        string[] names = GetNameList(GetUserNumber("Array Size? "));
                        for (int i = 0; i < names.Length; i++)
                        {
                            Console.WriteLine("Name {0} : {1}", i, names[i]);
                        }
                        break;

                    case "equation":
                        Equation();
                        break;

                    case "english":
                        for (int i = 0; i < 100; i++)
                        {
                            string english = ConvertToEnglish(i);
                            Console.WriteLine("{0} in English: {1}", i, english);
                        }
                        break;
                }
            }
        }

        public static void Equation()
        {
            while (true)
            {
                double num1, num2 = 0;
                //  ask user for equation
                //  we trust the user to enter a proper equation with
                //  a number followed by an operator followed by a number
                //  separated by spaces
                //      i.e.    10 * 55         5 + 2   
                //              11 / 5          111 - 6
                //              22345 % 17      22 ^ 2 = 484
                //              5 ^2 = 3           -999 n = 999
                //              100 sqrt
                string eq = GetUserInput("Enter Equation: ");
                if (eq.Length == 0)
                    break;

                //  break equation into individual pieces
                string[] aEq = eq.Split(" ");

                //      Convert the first and last elements to integers
                double.TryParse(aEq[0], out num1);

                //  we have a problem here if only one number is entered
                //      i.e. 5 n or 6 ^2 or 100 sqrt
                if(aEq.Length == 3)        //  what will keep me from dieing on the next line of code?!?!?!
                {
                    double.TryParse(aEq[2], out num2);
                }

                //      Decide how to do the math operation
                //      aEq[1] holds the character representation of a math operator
                double result = 0;
                switch (aEq[1])
                {
                    case "*":       result = num1 * num2;       break;
                    case "+":       result = num1 + num2;       break;
                    case "-":       result = num1 - num2;       break;
                    case "/":       result = num1 / num2;       break;
                    case "%":       result = num1 % num2;       break;
                    case "^":       result = Math.Pow(num1,num2); break;
                    case "n":       result = -num1;             break;
                    case "sqrt":    result = Math.Sqrt(num1);   break;
                    case "^2":      result = Math.Pow(num1, 2); break;
                    case "|":       result = Math.Abs(num1); break;
                    case "!":       result = Factorial((ulong)num1); break;
                    default:        result = 0;                 break;
                }
                //  Console.WriteLine("{3:F2} = {0} {1}" + ((aEq.Length == 3) ? "{2}" : "", num1, aEq[1], num2, result);
                if (aEq.Length == 3)
                    Console.WriteLine("{3:F2} = {0} {1} {2}", num1, aEq[1], num2, result);
                else
                    Console.WriteLine("{2:F2} = {0} {1}", num1, aEq[1], result);
            }
        }

        public static string ConvertToEnglish(int num)
        {
            string word;
            string oneWord = "", tenWord;

            //      table driven design
            //string[] aTens = { "", "", "Twenty-", "Thirty-", "Forty-", "Fifty-", "Sixty-", "Seventy-", "Eighty-", "Ninety-" };
            //string[] aOnes = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };

            int tens = num / 10;
            int ones = num % 10;

            //      table driven design
            //word = aTens[tens] + aOnes[ones];

            //  convert the TENs digit
            switch (tens)
            {
                case 2: tenWord = "Twenty-"; break;
                case 3: tenWord = "Thirty-"; break;
                case 4: tenWord = "Forty-"; break;
                case 5: tenWord = "Fifty-"; break;
                case 6: tenWord = "Sixty-"; break;
                case 7: tenWord = "Seventy-"; break;
                case 8: tenWord = "Eighty-"; break;
                case 9: tenWord = "Ninety-"; break;
                default: tenWord = ""; break;
            }

            //  covert the ONEs digit
            switch (ones)
            {
                case 0: oneWord = ""; break;
                case 1: oneWord = "One"; break;
                case 2: oneWord = "Two"; break;
                case 3: oneWord = "Three"; break;
                case 4: oneWord = "Four"; break;
                case 5: oneWord = "Five"; break;
                case 6: oneWord = "Six"; break;
                case 7: oneWord = "Seven"; break;
                case 8: oneWord = "Eight"; break;
                case 9: oneWord = "Nine"; break;
            }

            //  now we have a good word for the numbers 1 - 9 and 20 - 99
            word = tenWord + oneWord;

            //      Special Cases 0 and 10 - 19
            switch (num)
            {
                case 0: word = "Zero"; break;
                case 10: word = "Ten"; break;
                case 11: word = "Eleven"; break;
                case 12: word = "Twelve"; break;
                case 13: word = "Thirteen"; break;
                case 15: word = "Fifteen"; break;
                case 18: word = "Eighteen"; break;
                case 14:
                case 16:
                case 17:
                case 19:
                    word = oneWord + "teen";
                    break;
            }
            return word.TrimEnd('-');
        }

        private static int GetSeconds(string time)
        {
            int seconds;
            switch (time.ToUpper())
            {
                case "Y": seconds = 365 * 24 * 60 * 60; break;
                case "W": seconds = 7 * 24 * 60 * 60; break;
                case "D": seconds = 24 * 60 * 60; break;
                case "H": seconds = 60 * 60; break;
                case "M": seconds = 60; break;
                case "S": seconds = 1; break;
                default: seconds = -1; break;
            }
            return seconds;
        }

        private static void MakeChange()
        {
            Random rnd = new Random();
            string exit = "";
            while (!exit.Equals("x"))
            {
                int intPrice = rnd.Next(1, 100);
                decimal price = (decimal)intPrice / 100.00M + rnd.Next(10);
                int tendered = rnd.Next((int)price, (int)price + rnd.Next(20));
                string change = MakingChange(tendered, price);
                exit = GetUserInput(change);
            }
        }

        public static string MakingChange(decimal tenderedAmt, decimal price)
        {
            string[] name = { "Dollar", "Quater", "Dime", "Nickel", "Cent" };
            decimal coin;
            decimal[] denom = { 1.00M, .25M, .10M, 0.05M, 0.01M };
            string change = "Change from " + tenderedAmt + " for " + price + "\n\t";
            decimal remainder = tenderedAmt - price;

            for (int z = 0; z < denom.Length; z++)
            {
                coin = (int)(remainder / denom[z]);
                remainder %= denom[z];
                change += name[z] + (coin != 1 ? "s " : "  ") + coin + " ";
            }

            return change;
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

        private static void DictionaryDemo()
        {
            //string course, student;
            //Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            //do
            //{
            //    course = GetUserInput("Add to Courses");
            //    student = GetUserInput("Add to Student");
            //    courses.Add(course);

            //} while (!userResponse.ToLower().Equals("stop"));

            //Console.WriteLine();
            //do
            //{
            //    userResponse = GetUserInput("Search List for: ");
            //    bool found = names.Contains(userResponse);
            //    if (found)
            //    {
            //        int where = names.IndexOf(userResponse);
            //        Console.WriteLine("\t" + userResponse + " Was found at " + where);
            //    }
            //    else
            //    {
            //        Console.WriteLine("\t" + userResponse + " Was not found");
            //    }
            //} while (!userResponse.ToLower().Equals("stop"));

            //Console.WriteLine();
            //do
            //{
            //    userResponse = GetUserInput("Find in List: ");
            //    List<string> subNames = names.FindAll(p => p.Contains(userResponse));
            //    foreach (var item in subNames)
            //    {
            //        Console.WriteLine("\t" + item);
            //    }
            //} while (userResponse.Length > 0);

        }

        private static void ListDemo()
        {
            string userResponse;
            Console.WriteLine("Enter 'stop' to stop entering names");
            List<string> names = new List<string>() { "Gary", "Thomas", "James" };
            do
            {
                userResponse = GetUserInput("Add to List ");
                names.Add(userResponse);

            } while (!userResponse.ToLower().Equals("stop"));

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
            while (!Int32.TryParse(strNumber, out userNumber))
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
            } while (!search.Equals("stop"));
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
            Console.WriteLine("Which string is 'bigger'?  {0}", str1.CompareTo("STRING 1"));
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
