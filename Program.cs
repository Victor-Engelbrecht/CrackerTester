using System;
//used for converting file into bytes and writing the password to text file 
using System.IO;
//used for http requests
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace CrackerTest
{
    class JsonClass
    {
        public string base64FileString;
    }
    class Program
    {
        static void Main(string[] args)
        {

            //used for the get request

            /*Task t = new Task(GetRequest);
            t.Start();*/
            //test();
            GetRequest();
            Console.ReadLine();


            //loopToEnd();

            //PostData();

            bruteForce();
            jaggedArrayCrack();
            //OriginalCrack();
            //newCrack();
            //retical();

        }

        private static void test()
        {

            string url = "http://recruitment.warpdevelopment.co.za/api/authenticate";

            //creats a new client to send and recieve data
            HttpClient client = new HttpClient();


            string fileDirectoryFind = Path.GetFullPath(@"C:\\Users\\Victor\\Desktop");
            string filename = "dict.txt";
            string filePath = Path.Combine(fileDirectoryFind, filename);
            int statusCode = 0;

            StreamReader sr = new StreamReader(filePath);
            string currentPass;
            while ((currentPass = sr.ReadLine()) != null && statusCode != 200)
            {
                try
                {
                    //sets the variable that will be used for username and password
                    // string password = (not set yet will do so in final version)
                    var byteArray = Encoding.ASCII.GetBytes("john:" + currentPass);
                    //Console.WriteLine(currentPass);
                    //Console.WriteLine(Convert.ToBase64String(byteArray));
                    // Console.WriteLine( "http://recruitment.warpdevelopment.co.za/api/authenticate/john/" + currentPass);
                    Console.WriteLine(client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray)));
                }
                catch { }
            }
        }

        //simplest way of doing the password loop but there has to be a better way than this 
        //too manual not proper method never use 
        //
        private static void loopToEnd()
        {
            string fileDirectoryFind = Path.GetFullPath(@"C:\\Users\\Victor\\Desktop");
            string filename = "dict.txt";
            string filePath = Path.Combine(fileDirectoryFind, filename);
            string password = "password";
            StringBuilder testPass = new StringBuilder(password);

            StreamWriter sw = new StreamWriter(filePath);

            for (int p = 0; p < 2; p++)
            {
                //testPass = new StringBuilder(password);

                if (p == 0)
                {
                    // Console.WriteLine(password.Replace("p", "P"));
                    testPass[0] = 'p';
                }
                else if (p == 1)
                {
                    // Console.WriteLine(password.Replace("p", "P"));
                    testPass[0] = 'P';
                }
                Console.WriteLine("##########" + testPass);
                sw.WriteLine(testPass);

                for (int a = 0; a < 3; a++)
                {
                    //testPass = new StringBuilder(password);

                    if (a == 0)
                    {
                        //Console.WriteLine(password.Replace("a", "A"));
                        testPass[1] = 'a';
                    }
                    else if (a == 1)
                    {
                        //Console.WriteLine(password.Replace("a", "A"));
                        testPass[1] = 'A';
                    }
                    else if (a == 2)
                    {
                        //Console.WriteLine(password.Replace("A", "@"));
                        testPass[1] = '@';
                    }
                    Console.WriteLine("##########" + testPass);
                    sw.WriteLine(testPass);

                    for (int s = 0; s < 3; s++)
                    {
                        //testPass = new StringBuilder(password);

                        if (s == 0)
                        {
                            // Console.WriteLine(password.Replace("s", "S"));
                            testPass[2] = 's';
                        }
                        else if (s == 1)
                        {
                            // Console.WriteLine(password.Replace("s", "S"));
                            testPass[2] = 'S';
                        }
                        else if (s == 2)
                        {
                            //Console.WriteLine(password.Replace("S", "5"));
                            testPass[2] = '5';
                        }
                        Console.WriteLine("##########" + testPass);
                        sw.WriteLine(testPass);

                        for (int s2 = 0; s2 < 3; s2++)
                        {
                            //testPass = new StringBuilder(password);

                            if (s2 == 0)
                            {
                                // Console.WriteLine(password.Replace("s", "S"));
                                testPass[3] = 's';
                            }
                            else if (s2 == 1)
                            {
                                // Console.WriteLine(password.Replace("s", "S"));
                                testPass[3] = 'S';
                            }
                            else if (s2 == 2)
                            {
                                //Console.WriteLine(password.Replace("S", "5"));
                                testPass[3] = '5';
                            }
                            Console.WriteLine("##########" + testPass);
                            sw.WriteLine(testPass);

                            for (int w = 0; w < 2; w++)
                            {
                                //testPass = new StringBuilder(password);

                                if (w == 0)
                                {
                                    // Console.WriteLine(password.Replace("w", "W"));
                                    testPass[4] = 'w';
                                }
                                else if (w == 1)
                                {
                                    // Console.WriteLine(password.Replace("w", "W"));
                                    testPass[4] = 'W';
                                }
                                Console.WriteLine("##########" + testPass);
                                sw.WriteLine(testPass);

                                for (int o = 0; o < 3; o++)
                                {
                                    //testPass = new StringBuilder(password);

                                    if (o == 0)
                                    {
                                        // Console.WriteLine(password.Replace("o", "O"));
                                        testPass[5] = 'o';
                                    }
                                    else if (o == 1)
                                    {
                                        // Console.WriteLine(password.Replace("o", "O"));
                                        testPass[5] = 'O';
                                    }
                                    else if (o == 2)
                                    {
                                        // Console.WriteLine(password.Replace("O", "0"));
                                        testPass[5] = '0';
                                    }
                                    Console.WriteLine("##########" + testPass);
                                    sw.WriteLine(testPass);

                                    for (int r = 0; r < 2; r++)
                                    {
                                        //testPass = new StringBuilder(password);

                                        if (r == 0)
                                        {
                                            //Console.WriteLine(password.Replace("r", "R"));
                                            testPass[6] = 'r';
                                        }
                                        else if (r == 1)
                                        {
                                            //Console.WriteLine(password.Replace("r", "R"));
                                            testPass[6] = 'R';
                                        }
                                        Console.WriteLine("##########" + testPass);
                                        sw.WriteLine(testPass);

                                        for (int d = 0; d < 2; d++)
                                        {
                                            //testPass = new StringBuilder(password);

                                            if (d == 0)
                                            {
                                                //Console.WriteLine(password.Replace("d", "D"));
                                                testPass[7] = 'd';
                                                //Console.WriteLine(testPass + "          *******************************");
                                            }
                                            else if (d == 1)
                                            {
                                                //Console.WriteLine(password.Replace("d", "D"));
                                                testPass[7] = 'D';
                                                //Console.WriteLine(testPass+ "          *******************************");
                                            }
                                            Console.WriteLine("##########" + testPass);
                                            sw.WriteLine(testPass);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                //Console.WriteLine(password);
            }
            sw.Flush();
            sw.Close();
            Console.WriteLine("\n END: " + testPass);
            Console.WriteLine("FILEPATH: " + filePath);
            Console.ReadLine();
        }



        private static void PostData(string password, string url)
        {
            //code added later for making connection to the website and posting data to it instead of requesting data
            //this will be called in a looop untill the statuscode indicates success
            //sets the url that the progarm will request data from


            //string url = "http://recruitment.warpdevelopment.co.za/api/authenticate";

            //creats a new client to send and recieve data
            HttpClient client = new HttpClient();
            //try and catch for any unexpected errors that might occur


            string fileDirectoryFind = Path.GetFullPath(@"C:\\Users\\Victor\\Desktop");
            string filename = "dict.txt";
            string filePath = Path.Combine(fileDirectoryFind, filename);
            int statusCode = 0;

            StreamReader sr = new StreamReader(filePath);

            //sets the variable that will be used for username and password
    
            var byteArray = Encoding.ASCII.GetBytes("john:" + password);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            //sends the data to the website 

            HttpResponseMessage response;

            //original post code
            string filePathToZip = @"C:\\Users\\Victor\\Desktop\\ZipTest.zip";
            byte[] fileData = File.ReadAllBytes(filePathToZip);

            string test1 = Convert.ToBase64String(fileData);


            //Console.WriteLine(Path.GetFullPath("CrackerTest\\Resources"));
            Console.WriteLine(Convert.ToBase64String(fileData));
            //File.WriteAllBytes("C:\\Users\\Victor\\Desktop\\PasswordCracker\\test.zip", fileData);
            Console.ReadLine();
        }



        private async static void GetRequest()
        {
            //this will be called in a looop untill the statuscode indicates success
            //sets the url that the progarm will request data from
            string url = "http://recruitment.warpdevelopment.co.za/api/authenticate";

            //creats a new client to send and recieve data
            HttpClient client = new HttpClient();
            //try and catch for any unexpected errors that might occur


            string fileDirectoryFind = Path.GetFullPath(@"C:\\Users\\Victor\\Desktop");
            string filename = "dict.txt";
            string filePath = Path.Combine(fileDirectoryFind, filename);
            int statusCode = 0;

            StreamReader sr = new StreamReader(filePath);
            string currentPass;
            while ((currentPass = sr.ReadLine()) != null)
            {
                try
                {
                    //sets the variable that will be used for username and password
                    // string password = (not set yet will do so in final version)
                    var byteArray = Encoding.ASCII.GetBytes("john:" + currentPass);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    //gets the data from the website 
                    HttpResponseMessage response = await client.GetAsync(url);
                    //sets the content equal to a variable to be used when needed
                    HttpContent content = response.Content;

                    //outputs to console to know if the attempt was successfull or not

                    if ((int)response.StatusCode == 200)
                    {
                    Console.WriteLine("Status Code:" + (int)response.StatusCode);
                    Console.WriteLine(currentPass);
                    string postUrl = await content.ReadAsStringAsync();
                    Console.WriteLine("RESPONSE: " + postUrl);
                    break;
                    }
                    Console.WriteLine("Status Code:" + (int)response.StatusCode);
                    Console.WriteLine(currentPass);
                    //Console.WriteLine("Status Code:" + response.ReasonPhrase);

                    //result of the response is set eaul to a varibale to be used as the programmer sees fit
                    string result = await content.ReadAsStringAsync();
                    Console.WriteLine("RESPONSE: " +result);

            }
                catch (HttpRequestException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            


        }



        /// <summary>
        /// all the previous methods I have tried and expermimented with in the state they were last looked at
        /// as well as the order I last worked on them.
        /// I chose to move on to a method I knew would work as at least the project would be delivered at a 
        /// reasonalbe time in working condition rather than way over time or never completed
        /// </summary>




        /// <summary>
        /// too many possible combinations and thus would not work
        /// </summary>
        private static void bruteForce()
        {
                char[] characters = new char[] { 'p', 'a', 's', 'w', 'o', 'r', 'd', 'P', 'A', 'S', 'W', 'O', 'R', 'D', '@', '5', '0' };
                foreach (char character in characters)
                {

                }
        }



        /// <summary>
        /// This method was meant to
        /// </summary>


        //use a jagged array to loop through
        //will have 3 diffrent possbile values
        //0 password
        //1 PASSWORD
        //2 @50
        private static void jaggedArrayCrack()
        {

        // First possible way of creating the needed jagged array
            /*char[][] password = new char[3][];
            password[0] = new char[] { 'p', 'a', 's', 's', 'w', 'o', 'r', 'd' };
            password[1] = new char[] { 'P', 'A', 'S', 'S', 'W', 'O', 'R', 'D' };
            password[2] = new char[] { '@', '5', '0' };*/

        // second and possibly more easier to use array
        // values are sorted into rows and columns each row has a the number of columns based on the amount of possible
        // values the character in that rowposition could be
            char[][] password = new char[8][];
            password[0] = new char[] { 'p', 'P' };
            password[1] = new char[] { 'a', 'A', '@' };
            password[2] = new char[] { 's', 'S', '5' };
            password[3] = new char[] { 's', 'S', '5' };
            password[4] = new char[] { 'w', 'W' };
            password[5] = new char[] { 'o', 'O', '0' };
            password[6] = new char[] { 'r', 'R' };
            password[7] = new char[] { 'd', 'D' };

            /*int counter = 0;
            for (int i = 0; i < password[0].Length; i++)
            {
                counter++;
                for (int j = 0; j < password[1].Length; j++)
                {
                    counter++; 
                    for (int l = 0; l < password[2].Length; l++)
                    {
                        counter++;

                        Console.WriteLine(password[0][i]+""+password[1][j]+""+password[2][l]);
                    }
                }
            }
            Console.WriteLine(counter);
            */
            int test = 0;
            StringBuilder print = new StringBuilder("password");
            char replaceChar;
            print.Length = password.Length;
            foreach (char[] row in password)
            {

                foreach (char item in row)
                {
                    print.Clear();
                    for (int i = 0; i < password.Length; i++)
                    {
                        print = new StringBuilder("password");
                        replaceChar = item;
                        print[test] = replaceChar;
                        Console.WriteLine(print);

                        for (int j = 0; j < password[i].Length; j++)
                        {

                            //replaceChar = password[j][];
                            print[test] = replaceChar;
                            Console.WriteLine("boo Print: " + print);
                            if (j == test)
                            {

                            }
                            else if (j != test)
                            {
                                //replaceChar = password[j][]
                            }
                            //test++;
                            //print
                        }


                    }
                    //test++;
                    //Console.WriteLine(print);
                    Console.WriteLine(item);
                }
                test++;
                Console.WriteLine(" ");
            }

            Console.WriteLine(test);
            Console.ReadLine();
        }


        // the most efficent method of finding the conclution just was not feasible to complete in a
        // small enough time window
        private static void retical()
        {
            string password = "password";
            StringBuilder lowerCase = new StringBuilder("password");//"password"
            StringBuilder upperCase = new StringBuilder("PASSWORD");
            StringBuilder symbols = new StringBuilder("@50");
            StringBuilder print = new StringBuilder();
            StringBuilder printTwo = new StringBuilder();
            //crawler is used to define how many letters should be uppercase concurrently
            int crawler = 0;
            //replaceChar is used to inpunt the characters into the stringbuilders
            char replaceChar;
            /*
             * for loop for password
             * for loop for how many characters to take
             * when to skip characterss
             * for loop to 
             */
            for (int i = 0; i < password.Length; i++)
            {
                //resets the print string
                print.Clear();
                print.Append(password);

                //size of the crawler
                int crawlerLength = crawler;
                int crawlerForward = crawlerLength;
                int[] crawlerSkip = new int[password.Length];

                Console.WriteLine("            First ");

                //should the crawler be half the size of the strng use diffrent loops else IndexOutOfRangeException
                if (crawler < password.Length / 2)
                {

                    //use crawlerskip to not replace the elements that are already in the array
                    Array.Clear(crawlerSkip, 0, crawlerLength);
                    for (int j = 0; j < i + 1; j++)
                    {
                        //use crawler length to make them shift replaced with j for function
                        crawlerSkip[j] = crawlerLength;
                        replaceChar = upperCase[j];
                        print[j] = replaceChar;
                        crawlerLength++;
                        // Console.WriteLine(crawlerSkip[j]);
                    }

                    //jagged array 
                    //this should work but prints value is overwritten for some reason I don't know
                    Console.WriteLine(print + " If one");
                    for (int m = 0; m < password.Length - i; m++)
                    {
                        printTwo = print;
                        replaceChar = upperCase[m];
                        printTwo[m] = replaceChar;
                        Console.WriteLine("PrintTwo " + printTwo);
                        replaceChar = lowerCase[m];
                        printTwo[m] = replaceChar;
                    }
                }
                else if (crawler >= Convert.ToDouble(password.Length / 2))
                {
                    crawlerLength = password.Length - crawlerLength;
                    for (int j = 0; j != i + 1; j++)
                    {
                        replaceChar = upperCase[crawlerLength - 1];
                        print[crawlerLength - 1] = replaceChar;
                        crawlerLength++;
                    }
                    Console.WriteLine(print + " if TWO");

                }


                crawler++;
                //crawler = crawler - password.Length;
                Console.WriteLine(lowerCase);
            }

            Console.ReadLine();
        }

        // how I originally thought of looping through the password would yeald all possible results
        // is wrong as it doesn't consider values like pASsword since the first character can never be
        //lowercase again using this logic
        /*
         *                                  <Example>
         *                  orignial        password
         *                   changed        Password
         *                   changed        pAssword
         *                                  p@ssword
         *                                  paSsword
         *                                  pa5sword
         *                                  pasSword...
         *                  original        PAssword
         *                                  P@ssword
         *                                  PaSsword
         *                                  Pa5sword
         *                                  PasSword
         *                                  Pas5word...
         *                                  PAssword
         *                                  P@ssword
         *                                  pASsword
         *                                  p@Ssword
         *                                  pA5sword...
        */

        //The earlier version of the retical method
        private static void newCrack()
        {
            string password = "password";
            StringBuilder lowerCase = new StringBuilder();//"password"
            StringBuilder upperCase = new StringBuilder("PASSWORD");
            StringBuilder Symbols = new StringBuilder("@50");
            int crawler = 0;
            /*
             * for loop for password
             * for loop for how many characters to take
             * when to skip characters
             * for loop to 
             */
            for (int i = 0; i < password.Length; i++)
            {
                lowerCase.Clear();
                lowerCase.Append(password);

                Console.WriteLine("            First ");
                for (int j = 0; j < password.Length; j++)
                {
                    int numberOfUpperCase = 1;
                    //size of the crawler
                    int crawlerLength = crawler;
                    char replaceChar;
                    //should the crawler be half the size of the strng use diffrent loops else noIndexError
                    if (crawler < password.Length / 2)
                    {


                        replaceChar = upperCase[crawlerLength];
                        lowerCase[crawlerLength] = replaceChar;
                        /*for (int c = crawler; c < password.Length; c++)
                        {
                            replaceChar = upperCase[crawlerLength];
                            lowerCase[crawlerLength] = replaceChar;
                            Console.WriteLine(lowerCase + " in if");
                            crawlerLength++;
                            for (int k = 0; k < crawlerLength; k++)
                            {

                            }
                        }*/
                        Console.WriteLine(lowerCase + " If one");
                    }
                    else if (crawler >= Convert.ToDouble(password.Length / 2))
                    {

                        /*for (int c = crawler; c < password.Length; c++)
                        {
                            lowerCase[crawlerLength] = upperCase[crawlerLength];
                            crawlerLength++;
                            Console.WriteLine(lowerCase + " If two");
                        }*/
                        Console.WriteLine(lowerCase + " if TWO");

                    }
                    crawler++;

                }
                crawler = crawler - password.Length;
                Console.WriteLine(lowerCase);
            }

            Console.ReadLine();
        }

        // The first attempt at cracking the password that doesn't just consist of for loops but would dynamically change depending on
        // the password entered by the user as well as the length special characters would only be considered if the user wants to 
        // replace spesific characters with a certain character
        private static void OriginalCrack()
        {
            string currentAdding;
            string passwordText = "password";
            Console.WriteLine(passwordText[1].ToString().ToUpper());
            StringBuilder printText = new StringBuilder();
            StringBuilder topPrint = new StringBuilder(passwordText);
            int j = 0;

            //for each is redundant how I wrote the progarm sill need to make some changes to it to make it consider symbols as well

            //remove comment on foreach loop to see if looping is indeed redundant 
            //foreach (char item in passwordText)
            {
                //making more than one character crawl
                currentAdding = topPrint[j].ToString().ToUpper();
                topPrint[j] = Convert.ToChar(currentAdding);

                Console.WriteLine(topPrint + " MMMMMMMMMMMMMMM");
                //for experimental loop
                if (printText.Length > 0)
                {
                    printText.Remove(0, 8);
                }

                //inserts the passwordtext into a stringbuilder for better use of memory and to be able to access chars in a loop without further conversion
                printText.Insert(0, passwordText);
                Console.WriteLine(passwordText + "*********************");

                //loops for the lenght of the password 
                for (int lowercase = 0; lowercase < passwordText.Length; lowercase++)
                {
                    //sets value of currentAdding to the char that needs to become an uppercase character
                    currentAdding = printText[lowercase].ToString().ToUpper();
                    //Console.WriteLine(currentAdding);

                    //replaces the character in the array with the new character
                    printText[lowercase] = Convert.ToChar(currentAdding);
                    StringBuilder secondPrint = new StringBuilder(printText.ToString());
                    Console.WriteLine(printText);

                    for (int uppercase = 0; uppercase < passwordText.Length; uppercase++)
                    {

                        //follows the same logic as previous loop
                        currentAdding = printText[uppercase].ToString().ToUpper();
                    /*
                    if (currentAdding == "A")
                    {
                        if (uppercase - 1 < 0)
                        {

                        }
                        else
                        {
                            currentAdding = "@";
                            //uppercase--;
                        }
                        Console.WriteLine("AAAAAAAAAAAAAAAAAAAAA");
                    }*/

                    secondPrint[uppercase] = Convert.ToChar(currentAdding);

                        Console.WriteLine(secondPrint + "  Second");
                        StringBuilder thirdPrint = new StringBuilder(secondPrint.ToString());

                        for (int symbols = 0; symbols < passwordText.Length; symbols++)
                        {
                            //follows the same logic as previous loop with the differance if only swaps the characters back to lowercase
                            //if the character does not have the same value as the previous loops itterator meaning all letters will become lowercase
                            //exccept the one that shares the value of that loop
                            currentAdding = printText[symbols].ToString().ToUpper();
                            /*
                            if (currentAdding == "A"|| currentAdding=="a")
                            {
                                if (uppercase - 1 < 0)
                                {

                                }
                                else
                                {
                                    currentAdding = "@";
                                    //uppercase--;
                                }
                                Console.WriteLine("AAAAAAAAAAAAAAAAAAAAA");
                            }
                            */
                            thirdPrint[symbols] = Convert.ToChar(currentAdding);
                            Console.WriteLine(thirdPrint + "  Third");
                            if (symbols != uppercase)
                            {
                                currentAdding = printText[symbols].ToString().ToLower();
                                thirdPrint[symbols] = Convert.ToChar(currentAdding);
                            }

                        }

                    }
                    //swaps the character that was uppercase back to a lowercase character
                    currentAdding = printText[lowercase].ToString().ToLower();
                    printText[lowercase] = Convert.ToChar(currentAdding);
                }

                //redundant without the for each loop in the beginning 
                currentAdding = printText[j].ToString().ToUpper();
                printText[j] = Convert.ToChar(currentAdding);
                j++;
            }
            Console.ReadLine();
        }

        //unnamed version if making creating all the permutation of password
        /*string currentAdding = "";
        string passwordText = "password";
        StringBuilder printText = new StringBuilder();
        StringBuilder topPrint = new StringBuilder(passwordText);
        StringBuilder addTest = new StringBuilder();
        int j = 0;
        int count = 0;
        foreach (char item in passwordText) 
        {

            Console.WriteLine(item.ToString().ToUpper());
            for (int i = 0; i < passwordText.Length; i++)
            {
                currentAdding = topPrint[i].ToString().ToUpper();
                topPrint[i] = Convert.ToChar(currentAdding);
                Console.WriteLine(topPrint);
                currentAdding = topPrint[i].ToString().ToLower();
                topPrint[i] = Convert.ToChar(currentAdding);
            }
            Console.WriteLine(item.ToString().ToLower());
        }
        Console.ReadLine();*/
    }
}