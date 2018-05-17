using System;
using System.Collections.Generic;
using System.IO;

namespace Samples
{
    class Program
    {
        /// <summary>
        /// 
        ///    Menu Options
        ///     addtoList   Ask user for max number, then ask for input string add to different lists based on length or value of input
        ///     array       fill an array with names, search for name in array using Equals
        ///     change      make proper change from a transaction
        ///     dictionary  build a dictionary of courses containing students
        ///     english     convert the numbers 0 to 99 to english words 73 Seventy-Three   13 Thirteen
        ///     eq          enter in an equation (separated by spaces) 5 + 666 or 5 ! or 100 ^2 or 1000 sqrt
        ///     exit      x or exit to close
        ///     fib         dispaly the first X number of Fibonacci numbers
        ///     file        read a file and search it
        ///     fill        fill an array with names and display the array
        ///     for         ask user for start, end and increment values for a loop; then do the loop
        ///     gcd         determine the Greatest Common Divisor or two numbers
        ///     if          using if to compare three numbers to determine the largest
        ///     isword      does an input string follow the rules of a word
        ///     lottery     enter a lottery and calulate your odds
        ///     list        add names to a List<string> use Contains and IndexOf to find matched elements and FindAll
        ///     menu        show the menu
        ///     mult        multiplication table
        ///     num         play with number - comparing
        ///     parse       three arras int, float and string. Based on user input figure out if it is a string, float or int, put value in correct array
        ///     phone       convert words to phone number
        ///     strings     various fun things you can do with strings 
        ///     string      just different ways to compare strings
        ///     time        seconds in time period day, hour, week, year
        ///     try         request test scores from user, calc total and average. Use TryParse to convert to number 
        ///     var         play with variables
        ///     words       get string of words find longs word and number of words in string

        ///     
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            while (true)
            {
                switch (GetInput("? "))
                {
                    case "exit": return;
                    case "x": return;
                    case "":
                    case "menu":
                        Console.WriteLine(
                            "\taddToList\tarray\tchange\tdictionary\tenglish\teq\tfib\tfile\tfill\n" +
                            "\tfor\tgcd\tif\tlist\tlottery\tmult\tnum\tparse\tphone\n" +
                            "\tstrings\tstring\ttime\ttry\tvar\twords\n\texit");
                        break;

                    case "addtolist": AddToList(); break;
                    case "array": ArrayExamples(); break;
                    case "change": MakeChange(); break;
                    case "dictionary": DictionaryDemo(); break;
                    case "english": ConvertToEnglishDriver(); break;
                    case "eq": Equation(); break;
                    case "fib": Fibonacci(); break;
                    case "file": ReadFile(); break;
                    case "fill": GetNameList(GetNumber("Array Size? ")); break;

                    case "for": ForStatements(); break;
                    case "gcd": GCD(); break;
                    case "if": IfStatements(); break;
                    case "isword": IsWordDriver(); break;
                    case "list": ListDemo(); break;
                    case "lottery": PlayLottery(); break;
                    case "mult": MultiplicationTable(); break;
                    case "num": NumberCompare(); break;
                    case "parse": ParsingTest(); break;
                    case "phone": PhoneNumber(); break;

                    case "strings": FunWithStrings(); break;
                    case "string": StringTests(); break;
                    case "time": GetSeconds(); break;
                    case "try": LoopWithTryParse(); break;
                    case "var": Variables(); break;
                    case "words": WordArrays(); break;
                    case "test":
                        break;
                }
            }
        }

        /*
            create variables that have the correct type
                    bool wasVowelFound;
                    int  vowelsFound;

                    body temp 98.6 float
                  const int SPEED_OF_LIGHT   299998 KM / S
                  altitude    int
                  miles per gallon          float
                  is my car running         boolean
                  money                     decimal
                  non-integer               float, double
                  Bill Gates net worth      long, ulong
                  ave test scores           float
                  world population > 8B     long  ulong
                  distance                  ulong measure in miles, ly

            declaration assignment
                    decimal salary;     //      this is the declaration of the variable
                    salary = 100000M;   //      this is the assignment

                    int numOfApples;    //      declaration
                    numOfApples = 0;    //      assignment to initialize our counter
                    numOfApples++;      //      done inside a loop. this is also an assignment statement

                    string name = "edge tech";      //  declaration and assignment
                    
                    int numberOfAlienVisitations;
                    

            comparison     
                    if (oneThing ComparisonOperator anotherThing)
                    ComparisonOperator      ==  <   >   <= >= !=
                    compare X to Z
                    if ( x ComparisonOperator z )
                    {
                    }

            loops
                    for         when you know how many times
                    foreach     when you don't need the index
                    do-while    Test at the bottom so you will do the loop at least one time
                    while       Test at the top. execute 0 or more times

                    break       exiting a loop
                    return      exit the method (oh and BTW exit the loop)

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
                public void TruncateTable(string tableName)
                {
                    sqlExecute ("Truncate table " + tableName);
                }

                public int CountZebras(Zoo zoo)
                {
                    int cntZebras;
                    cntZebras = 0;
                    foreach (Animal animal in zoo)
                    {
                        if (animal.Type == "Zebra")
                        {
                            cntZebras++;
                        }
                    }
                    return cntZebras;
                }

            classes
                properties
                methods
                constructors
                */

        /// <summary>
        ///     Ask user for max number, then ask for input string add to different lists based on length or value of input
        /// 
        /// </summary>
        private static void AddToList()
        {
            List<string> smallStuff = new List<string>();
            List<string> bigStuff = new List<string>();
            List<int> bigInt = new List<int>();
            List<int> littleInt = new List<int>();
            long big = GetNumber("Enter a number: ");
            while (true)
            {
                string input = GetInput("Enter something ");
                if (input == "")
                    break;

                int theNumber;
                if (Int32.TryParse(input, out theNumber))
                {
                    if (theNumber >= big)
                        bigInt.Add(theNumber);
                    else
                        littleInt.Add(theNumber);
                }
                else if (input.Length >= big)
                    bigStuff.Add(input);
                else
                    smallStuff.Add(input);
            }
            Console.WriteLine();
            foreach (var item in bigStuff)
            {
                Console.WriteLine("Big   " + item);
            }
            Console.WriteLine();
            foreach (var item in smallStuff)
            {
                Console.WriteLine("Small " + item);
            }
            Console.WriteLine();
            foreach (var item in littleInt)
            {
                Console.WriteLine("Little# " + item);
            }
            Console.WriteLine();
            foreach (var item in bigInt)
            {
                Console.WriteLine("Big#    " + item);
            }
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

            Console.WriteLine("Enter names: ");
            for (int i = 0; i < strArray.Length; i++)
            {
                strArray[i] = GetInput(i + ": ");
            }

            string search;
            do
            {
                search = GetInput("Search for Student: ");
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (strArray[i].Equals(search))
                    {
                        Console.WriteLine("Found " + search + " at entry " + i);
                    }
                }
            } while (!search.Equals("stop"));
        }

        public static void ConvertToEnglishDriver()
        {
            int num;
            do
            {
                num = (int)GetNumber("Enter # bewteen 0 and 100");
                string english = ConvertToEnglish(num);
                Console.WriteLine("{0} in English: {1}", num, english);
            } while (num != 0);
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

        public static int CalculateCentury(int year)
        {
            return year / 100 + ((year % 100 == 0) ? 0 : 1);
        }

        private static void DictionaryDemo()
        {
            // Create a new dictionary of strings, with string keys.
            //
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            while (true)
            {
                string className = GetInput("Class Name: ");
                if (className.Length == 0)
                    break;
                List<string> students = new List<string>();
                int s = 0;
                while (true)
                {
                    string student = GetInput("Student " + s + ": ");
                    if (student.Length == 0)
                        break;
                    // The Add method throws an exception if the new key is 
                    // already in the dictionary.
                    try
                    {
                        students.Add(student);
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("Student {0} is already in the class", student);
                    }
                }
                // ContainsKey can be used to test keys before inserting 
                // them.
                if (!courses.ContainsKey(className))
                {
                    courses.Add(className, students);
                }
                else
                {
                    Console.WriteLine("Class {0} is already in the system. Students will be added to existing class.", className);
                    courses[className].AddRange(students);
                }
            }

            foreach (KeyValuePair<string, List<string>> course in courses)
            {
                Console.WriteLine("{0}", course.Key);
                foreach (var student in course.Value)
                {
                    Console.WriteLine("\t{0}", student);
                }
            }

            while (true)
            {
                string findStudent = GetInput("Search for: ");
                if (findStudent.Length == 0)
                    break;

                List<string> takingCourses = new List<string>();
                foreach (KeyValuePair<string, List<string>> course in courses)
                {
                    if (course.Value.Contains(findStudent))
                    {
                        takingCourses.Add(course.Key);
                    }
                }
                Console.WriteLine("{0}: is taking these course:", findStudent);
                foreach (var course in takingCourses)
                {
                    Console.WriteLine("\t{0}", course);
                }
            }
            // The Item property is another name for the indexer, so you 
            // can omit its name when accessing elements. 
            //Console.WriteLine("For key = \"rtf\", value = {0}.", courses["rtf"]);

            //// The indexer can be used to change the value associated
            //// with a key.
            //openWith["rtf"] = "winword.exe";
            //Console.WriteLine("For key = \"rtf\", value = {0}.", openWith["rtf"]);

            //// If a key does not exist, setting the indexer for that key
            //// adds a new key/value pair.
            //openWith["doc"] = "winword.exe";

            //// The indexer throws an exception if the requested key is
            //// not in the dictionary.
            //try
            //{
            //    Console.WriteLine("For key = \"tif\", value = {0}.",
            //        openWith["tif"]);
            //}
            //catch (KeyNotFoundException)
            //{
            //    Console.WriteLine("Key = \"tif\" is not found.");
            //}

            //// When a program often has to try keys that turn out not to
            //// be in the dictionary, TryGetValue can be a more efficient 
            //// way to retrieve values.
            //string value = "";
            //if (openWith.TryGetValue("tif", out value))
            //{
            //    Console.WriteLine("For key = \"tif\", value = {0}.", value);
            //}
            //else
            //{
            //    Console.WriteLine("Key = \"tif\" is not found.");
            //}


            //// When you use foreach to enumerate dictionary elements,
            //// the elements are retrieved as KeyValuePair objects.
            //Console.WriteLine();
            //foreach (KeyValuePair<string, string> kvp in openWith)
            //{
            //    Console.WriteLine("Key = {0}, Value = {1}",
            //        kvp.Key, kvp.Value);
            //}

            //// To get the values alone, use the Values property.
            //Dictionary<string, string>.ValueCollection valueColl =
            //    openWith.Values;

            //// The elements of the ValueCollection are strongly typed
            //// with the type that was specified for dictionary values.
            //Console.WriteLine();
            //foreach (string s in valueColl)
            //{
            //    Console.WriteLine("Value = {0}", s);
            //}

            //// To get the keys alone, use the Keys property.
            //Dictionary<string, string>.KeyCollection keyColl =
            //    openWith.Keys;

            //// The elements of the KeyCollection are strongly typed
            //// with the type that was specified for dictionary keys.
            //Console.WriteLine();
            //foreach (string s in keyColl)
            //{
            //    Console.WriteLine("Key = {0}", s);
            //}

            //// Use the Remove method to remove a key/value pair.
            //Console.WriteLine("\nRemove(\"doc\")");
            //openWith.Remove("doc");

            //if (!openWith.ContainsKey("doc"))
            //{
            //    Console.WriteLine("Key \"doc\" is not found.");
            //}
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
                string eq = GetInput("Enter Equation: ");
                if (eq.Length == 0)
                    break;

                //  break equation into individual pieces
                string[] aEq = eq.Split(" ");

                //      Convert the first and last elements to integers
                double.TryParse(aEq[0], out num1);

                //  we have a problem here if only one number is entered
                //      i.e. 5 n or 6 ^2 or 100 sqrt
                if (aEq.Length == 3)        //  what will keep me from dieing on the next line of code?!?!?!
                {
                    double.TryParse(aEq[2], out num2);
                }

                //      Decide how to do the math operation
                //      aEq[1] holds the character representation of a math operator
                double result = 0;
                switch (aEq[1])
                {
                    case "*": result = num1 * num2; break;
                    case "+": result = num1 + num2; break;
                    case "-": result = num1 - num2; break;
                    case "/": result = num1 / num2; break;
                    case "%": result = num1 % num2; break;
                    case "gcd": result = (double)GetGCD((long)num1, (long)num2); break;
                    case "^": result = Math.Pow(num1, num2); break;
                    case "n": result = -num1; break;
                    case "sqrt": result = Math.Sqrt(num1); break;
                    case "^2": result = Math.Pow(num1, 2); break;
                    case "|": result = Math.Abs(num1); break;
                    case "!": result = Factorial((long)num1); break;
                    default: result = 0; break;
                }

                //  Console.WriteLine("{3:F2} = {0} {1}" + ((aEq.Length == 3) ? "{2}" : "", num1, aEq[1], num2, result);
                if (aEq.Length == 3)
                    Console.WriteLine("{3:F2} = {0} {1} {2}", num1, aEq[1], num2, result);
                else
                    Console.WriteLine("{2:F2} = {0} {1}", num1, aEq[1], result);
            }
        }

        /// <summary>
        ///     get two numbers from user
        ///     create function to return the larger number, code must use if statments
        ///     create function to return the smaller number, code must use the ? : construct
        /// 
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static long GetBigger(long num1, long num2)
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

        public static long GetBigger2(long num1, long num2)
        {
            return (num1 > num2) ? num1 : num2;
        }

        /// <summary>
        /// get string from user in main
        /// create function to return the number of words
        /// function is called GetWordCount
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
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

        /// <summary>
        ///     create function to return the longest word in a string
        /// 
        /// </summary>
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

        /// <summary>
        /// ask user for a number in main
        ///     create a function GetNameList, passing in the number
        ///     create an array of strings the size of the number passed in
        ///      use a for loop to ask the user for names
        ///     add the names to the string array you created
        ///     return the array
        ///     main print out the array using foreach 
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static string[] GetNameList(long size)
        {
            string[] list = new string[size];

            for (int i = 0; i < size; i++)
            {
                list[i] = GetInput("Name " + (i + 1) + " ");
            }
            for (int i = 0; i < list.Length; i++)
            {
                Console.WriteLine("Name {0} : {1}", i, list[i]);
            }
            return list;
        }

        private static ulong Factorial(long num)
        {
            ulong factorial = 1;
            for (int i = 1; i <= num; i++)
            {
                factorial *= (ulong)i;
            }
            return factorial;
        }

        private static void Fibonacci()
        {
            ulong curr = 1, prev = 1;
            ulong next;
            int num;
            Console.Write("Enter how many Fibonacci numbers you want: ");
            num = Convert.ToInt32(Console.ReadLine());

            for (int i = 3; i < num; i++)
            {
                next = curr + prev;
                prev = curr;
                curr = next;
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

            name = "Edge Tech Academy";
            string initials = "";
            string[] aNames = name.Split(" ");
            foreach (string str in aNames)
            {
                initials += str[0];
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

            long start = GetNumber("Initialize loop: ");
            long loop = GetNumber("Enter loop termination: ");
            long inc = GetNumber("Enter loop increment: ");

            for (long i = start; i < loop; i += inc)
            {
                Console.WriteLine("loop index: " + i);
            }
        }

        private static void GetSeconds()
        {
            int seconds;
            do
            {
                string time = GetInput("Unit of Time: ");
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
                Console.WriteLine("There are " + seconds + " seconds in a " + time);
            } while (seconds >= 0);
        }

        private static void GCD()
        {
            long smallNum, remainder, gcd;
            do
            {
                smallNum = GetNumber("Enter a Number: ");
                remainder = GetNumber("Enter a Number: ");
                gcd = GetGCD(smallNum, remainder);
            } while (GetInput("GCD is: " + gcd + " Enter Y to continue: ").Equals("y"));
        }

        private static long GetGCD(long smallNum, long remainder)
        {
            long bigNum;
            do
            {
                bigNum = smallNum;
                smallNum = remainder;
                remainder = bigNum % smallNum;
                Console.WriteLine(bigNum + " % " + smallNum + " r=" + remainder);
            } while (remainder != 0);
            return smallNum;
        }

        private static DateTime GetDay()
        {
            DateTime dt = new DateTime();
            return dt;
        }

        private static void IfStatements()
        {
            long student1Age = GetNumber("Enter Student 1 age: ");
            long student2Age = GetNumber("Enter Student 2 age: ");
            long student3Age = GetNumber("Enter Student 3 age: ");

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

        private static void IsWordDriver()
        {
            while (true)
            {
                string word = GetInput("Enter a 'word': ");
                if (word.Length == 0)
                    break;
                Boolean ok = IsWord(word);
                Console.WriteLine("Word {0} was {1}a word", word, ok ? "" : "not ");
            }
        }

        private static bool IsWord(string word)
        {
            bool vowel = false, consanant = false, firstLetter = true;

            foreach (char letter in word)
            {
                switch (letter)
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        Console.WriteLine("Bad Word: {0}. Contains a number!", word);
                        return false;
                }
                if (letter >= '0' && letter <= '9')
                {
                    Console.WriteLine("Bad Word: {0}. Contains a number!", word);
                    return false;
                }
                if ("0123456789".Contains(letter + ""))
                {
                    Console.WriteLine("Bad Word: {0}. Contains a number!", word);
                    return false;
                }

                if (!firstLetter && letter >= 'A' && letter <= 'Z')
                {
                    Console.WriteLine("Bad Word: {0}. Contains a Capital letter!", word);
                    return false;
                }
                if ("aeiouy".Contains(letter + ""))
                {
                    vowel = true;
                }
                if ("bcdfghjklmnpqrstvwxyz".Contains(letter + ""))
                {
                    consanant = true;
                }
                firstLetter = false;
            }

            //  we only get here if we have searched all of the letters and not found a number
            //  so if we found a vowel and a consant then we are good
            if (vowel && consanant)
            {
                return true;
            }

            //  how about if we found a vowel and not a consant and the length is one 
            return (vowel && !consanant && word.Length == 1 && "ai".Contains(word));
        }

        private static void ListDemo()
        {
            string userResponse;
            Console.WriteLine("Empty line to stop");
            List<string> names = new List<string>() { "Able", "Baker", "Charlie", "Dorthy" };
            while (true)
            {
                userResponse = GetInput("Add a Name: ");
                if (userResponse.Length == 0)
                    break;
                names.Add(userResponse);
            }
            foreach (string name in names)
            {
                Console.WriteLine("\t{0}", name);
            }

            Console.WriteLine();
            while (true)
            {
                userResponse = GetInput("Search for name: ");
                if (userResponse.Length == 0)
                    break;
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
            }

            Console.WriteLine();
            while (true)
            {
                userResponse = GetInput("Find in List: ");
                if (userResponse.Length == 0)
                    break;
                List<string> subNames = names.FindAll(name => name.Contains(userResponse));

                //  The above line of code is doing this
                //List<string> subNames = new List<string>();
                //foreach (string name in names)
                //{
                //    if (name.Contains(userResponse))
                //        subNames.Add(name);
                //}

                foreach (var item in subNames)
                {
                    Console.WriteLine("\t" + item);
                }
            }

        }

        public static void LoopWithTryParse()
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

        private static void MakeChange()
        {
            string change;
            Random rnd = new Random();
            do
            {
                int intPrice = rnd.Next(1, 100);
                decimal price = (decimal)intPrice / 100.00M + rnd.Next(10);
                decimal tendered = rnd.Next((int)price, (int)price + rnd.Next(30)) + 1;
                change = MakingChange(tendered, price);
            } while (!GetInput(change).Equals("x"));
        }

        public static string MakingChange(decimal tenderedAmt, decimal price)
        {
            string[] name = { "$10", "$5", "$1", "Quater", "Dime", "Nickel", "Cent" };
            decimal[] denom = { 10.00M, 5.00M, 1.00M, .25M, .10M, 0.05M, 0.01M };
            decimal coin;
            decimal remainder = tenderedAmt - price;
            string change = String.Format("Change from {0:F2} for {1:F2} = {2:F2}\n\t", tenderedAmt, price, remainder);

            for (int z = 0; z < denom.Length; z++)
            {
                coin = (int)(remainder / denom[z]);
                remainder %= denom[z];
                change += name[z] + (coin != 1 ? "s " : "  ") + coin + " ";
            }

            return change;
        }

        public static void MultiplicationTable()
        {
            int max = (int)GetNumber("Enter # < = 20 ");
            Console.Write("       ");
            for (int i = 0; i <= max; i++)
            {
                Console.Write("{0,4}", i);
            }
            Console.WriteLine();

            for (int i = 0; i <= max; i++)
            {
                Console.Write("{0,4} | ", i);
                for (int j = 0; j <= max; j++)
                {
                    Console.Write("{0,4}", i * j);
                }
                Console.WriteLine();
            }
        }

        private static void NumberCompare()
        {
            long result;
            long number1, number2;

            number1 = GetNumber("#1 ");
            number2 = GetNumber("#2 ");
            result = GetBigger(number1, number2);
            Console.WriteLine("This is the bigger number: {0}", result);

            number1 = GetNumber("#1 ");
            number2 = GetNumber("#2 ");
            result = GetBigger2(number1, number2);
            Console.WriteLine("This is the bigger number: {0}", result);

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
                string input = GetInput("give me anything or 'exit' or 'stats'\n\t-> ");

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
            for (int i = 0; i < strArray.Length; i++)
            {
                Console.WriteLine(i + " : " + strArray[i]);
            }
            for (int i = 0; i < intArray.Length; i++)
            {
                Console.WriteLine(i + " : " + intArray[i]);
            }
            for (int i = 0; i < floatArray.Length; i++)
            {
                Console.WriteLine(i + " : " + floatArray[i]);
            }
        }       //  end of ParsingTest

        public static void PhoneNumber()
        {
            string phoneNum;
            string phoneWord;
            do
            {
                phoneWord = GetInput("Enter Phone #: ").ToUpper();
                phoneNum = "";
                for (int i = 0; i < phoneWord.Length; i++)
                {
                    switch (phoneWord[i])
                    {
                        case 'A': case 'B': case 'C': phoneNum += "2"; break;
                        case 'D': case 'E': case 'F': phoneNum += "3"; break;
                        case 'G': case 'H': case 'I': phoneNum += "4"; break;
                        case 'J': case 'K': case 'L': phoneNum += "5"; break;
                        case 'M': case 'N': case 'O': phoneNum += "6"; break;
                        case 'P': case 'Q': case 'R': case 'S': phoneNum += "7"; break;
                        case 'T': case 'U': case 'V': phoneNum += "8"; break;
                        case 'W': case 'X': case 'Y': case 'Z': phoneNum += "9"; break;
                        case ' ': case '-': case '(': case ')': break;
                        default: phoneNum += phoneWord[i]; break;
                    }
                    if (i == 2 || i == 5)
                        phoneNum += "-";
                }
                Console.WriteLine("Dial: {0} for {1}", phoneNum, phoneWord);
            } while (phoneWord != "");
        }

        public static void PlayLottery()
        {
            long balls, pick;
            while (true)
            {
                balls = GetNumber("Enter a Number (0 to quit): ");
                pick = GetNumber("Enter a Number: ");
                if (balls <= 0)
                    break;
                Console.WriteLine(Factorial(balls) / Factorial(pick));
            }
        }

        private static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        private static void ReadFile()
        {
            string line, header;
            List<User> users = new List<User>();

            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(@"..\..\..\users.csv");
            header = file.ReadLine();
            string[] cols = header.Split(",");
            Console.WriteLine("Here are your options to search for");
            foreach (var col in cols)
            {
                Console.WriteLine("\t" + col);
            }

            while ((line = file.ReadLine()) != null)
            {
                string[] properties = line.Split(",");
                User user = new User(properties[0], properties[1], properties[2], decimal.Parse(properties[3]));
                Console.WriteLine(user);
                users.Add(user);
            }

            file.Close();
            Console.WriteLine("There were {0} users.", users.Count);
            while (true)
            {
                string column = GetInput("Column to Search: ");
                if (column == "")
                    break;
                string value = GetInput("Search for: ");
                foreach (var item in users)
                {
                    if (column == cols[0])           //      case "Name":
                    {
                        if (item.Name == value)
                            Console.WriteLine(item);
                    }
                    if (column == cols[1])           //      case "Company":
                    {
                        if (item.Company.Contains(value))
                            Console.WriteLine(item);
                    }
                    if (column == cols[2])           //      case "AccountNUmber":
                    {
                        if (item.AccountNum == value)
                            Console.WriteLine(item);
                    }
                    if (column == cols[3])           //      case "MonthlyFee":
                    {
                        if (item.Fee + "" == value)       //  yes we are cheating big time here by not converting the users input
                            Console.WriteLine(item);
                    }
                }
            }
        }

        public static void StringTests()
        {
            while (true)
            {
                string str1 = GetInput("String 1: ");
                if (str1.Length == 0)
                    break;
                string str2 = GetInput("String 2: ");
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

        private static void WordArrays()
        {
            int result;
            string line = GetInput("Enter a string ");
            result = GetWordCount(line);
            Console.WriteLine("WordCount for {0} : {1} words", line, result);

            string longestWord = GetLongestWord(line);
            Console.WriteLine("Longest word: {0}", longestWord);

        }

        private static long GetNumber(string prompt)
        {
            long userNumber;
            string strNumber = GetInput(prompt);
            while (!Int64.TryParse(strNumber, out userNumber))
            {
                Console.WriteLine("That is not an integer");
                strNumber = GetInput(prompt);
            }

            return userNumber;
        }

        private static string GetInput(string prompt)
        {
            Console.Write(prompt);
            string str = Console.ReadLine();
            return str;
        }
    }
}
