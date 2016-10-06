using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System;

namespace cookieBakerySomething
{
    class Bakery
    {
        public Object Lock = new Object();
        public List<Cookie> Cookies { get; set; }

        public Bakery()
        {
            //Creates list of cookies and our person containing our eating threads
            Cookies = new List<Cookie>();
            Person Greg = new Person("Greg", this);
            Person Fred = new Person("Fred", this);
            Person Ted = new Person("Ted", this);
            BakeCookies();

        }
        /// <summary>
        /// Sells Cookie to a person
        /// </summary>
        /// <param name="Customer">Person buying the cookie at the top of the cookie list</param>
        public void SellCookieTo(Person Customer)
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("\t\t\t ");
            stringBuilder.Append(Customer.Name);
            stringBuilder.Append(" recieved cookie ");
            stringBuilder.Append(Cookies[0].ToString());
            Console.WriteLine(stringBuilder.ToString());
            Cookies.RemoveAt(0);

        }
        /// <summary>
        /// Gets the current amout of cookies available for purchase
        /// </summary>
        /// <returns>The available amout of cookie for purchase</returns>
        public int getCookiesCount()
        {
            return Cookies.Count();
        }
        /// <summary>
        /// Starts the barkery, making a cookie every 667 ms
        /// </summary>
        public void BakeCookies()
        {
            //Create a cookietimer, telling the program when to bake a new cookie
            Stopwatch CookieTimer = new Stopwatch();
            CookieTimer.Start();
            int CookieCounter = 0;
            while (CookieCounter < 12)
            {
                //if the time hasn't passed 677 seconds jump to next iteration
                if (CookieTimer.ElapsedMilliseconds < 667)
                    continue;
                //Creating a temperate cookie outside the add method of the list enabling us to use this to get the number of the cookie for later when we print it.
                Cookie tempCookie = new Cookie(CookieCounter);
                Cookies.Add(tempCookie);
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("Bakery made cookie ");
                stringBuilder.Append(tempCookie.ToString());
                Console.WriteLine(stringBuilder.ToString());
                //Add to the amout of cookies being made
                CookieCounter++;
                //Restart the timer for making a cookie
                CookieTimer.Restart();
            }
        }
    }
}
