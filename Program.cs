using System;
using System.IO;
//used for http requests
using System.Net.Http;
using System.Text;
namespace CrackerTest
{
    class Program
    {
        static void Main(string[] args)
        {
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



            //used for the get request
            /*
            Task t = new Task(GetRequest);
            t.Start();
            Console.ReadLine();
            */
            OriginalCrack();
            //PostData();
        }

        private static void PostData()
        {
            string filePath = @"C:\\Users\\Victor\\Desktop\\ZipTest.zip";
            byte[] fileData = File.ReadAllBytes(filePath);

            string test1 = Convert.ToBase64String(fileData);


            Console.WriteLine(Convert.ToBase64String(fileData));
            //File.WriteAllBytes("C:\\Users\\Victor\\Desktop\\PasswordCracker\\test.zip", fileData);
            Console.ReadLine();
        }

        private static void OriginalCrack()
        {
            string currentAdding;
            string passwordText = "password";
            Console.WriteLine(passwordText[1].ToString().ToUpper());
            StringBuilder printText = new StringBuilder();
            StringBuilder topPrint = new StringBuilder(passwordText);
            int j = 0;

            //for each is redundant how I wrote the progarm sill need to make some changes to it to make it consider symbols as well

            //romove comment on foreach loop to see if looping is indeed redundant 
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
                            Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
                        }
                        */
                        secondPrint[uppercase] = Convert.ToChar(currentAdding);

                        Console.WriteLine(secondPrint + "  Second");
                        StringBuilder thirdPrint = new StringBuilder(secondPrint.ToString());

                        for (int symbols = 0; symbols < passwordText.Length; symbols++)
                        {
                            //follows the same logic as previous loop with the differance if only swaps the characters back to lowercase
                            //if the character does not have the same value as the previous loops itterator meaning all letters will become lowercase
                            //exccept the one that shares the value of that loop
                            currentAdding = printText[symbols].ToString().ToUpper();
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

        private async static void GetRequest()
        {
            //this will be called in a looop untill the statuscode indicates success
            //sets the url that the progarm will request data from
            string url = "http://recruitment.warpdevelopment.co.za/api/authenticate";

            //creats a new client to send and recieve data
            HttpClient client = new HttpClient();
            //try and catch for any unexpected errors that might occur
            try
            {
                //sets the variable that will be used for username and password
                // string password = (not set yet will do so in final version)
                var byteArray = Encoding.ASCII.GetBytes("john:password");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("basic", Convert.ToBase64String(byteArray));
                //gets the data from the website 
                HttpResponseMessage response = await client.GetAsync(url);
                //sets the content equal to a variable to be used when needed
                HttpContent content = response.Content;

                //outputs to console to know if the attempt was successfull or not
                Console.WriteLine("Status Code:" + (int)response.StatusCode);
                Console.WriteLine("Status Code:" + response.ReasonPhrase);

                //result of the response is set eaul to a varibale to be used as the programmer sees fit
                string result = await content.ReadAsStringAsync();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}