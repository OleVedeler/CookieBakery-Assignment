using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace cookieBakerySomething
{
    class Person
    {

        public String Name { get; private set; }
        public Bakery FavoriteBakery { get; private set; }
        /// <summary>
        /// Creates a new person able to buy cookies
        /// </summary>
        /// <param name="name">Name of the person</param>
        /// <param name="bakery">reference to the favorite bakery of the person</param>
        public Person(String name, Bakery bakery)
        {
            FavoriteBakery = bakery;
            Name = name;
            //Creates a new thread of the lookforcookies method
            Thread thread = new Thread(LookForCookies);
            thread.Start();
        }
        /// <summary>
        /// Looks for a cookie available for purchase at the favorite bakery
        /// </summary>
        public void LookForCookies()
        {
            //Sets a time for the cookiegrabbing loop
            Stopwatch timer = new Stopwatch();
            timer.Start();
            while (true)
            {
                //if less than a second has passed since we last tried to grab a cookie has passed jump to next iteration
                if (timer.ElapsedMilliseconds < 1000)
                    continue;

                timer.Restart();
                //Locks this thread making only it available to access the cookie count of our bakery
                lock (FavoriteBakery.Lock)
                {
                    if (FavoriteBakery.getCookiesCount() > 0)
                    {
                        FavoriteBakery.SellCookieTo(this);
                    }
                }
            }
        }
        
        /// <summary>
        /// Returns a string of this object
        /// </summary>
        /// <returns>Name of the person object</returns>
        public override String ToString()
        {
            return Name;
        }
    }
}
