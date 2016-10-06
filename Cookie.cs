using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cookieBakerySomething
{
    class Cookie
    {
        public int CookieNumber { get; set; }
        /// <summary>
        /// Creates a new new cookie
        /// </summary>
        /// <param name="cookieNumber">Cookienumber for the current cookie</param>
        public Cookie(int cookieNumber)
        {
            CookieNumber = cookieNumber;
        }
        /// <summary>
        /// Make a string of the object
        /// </summary>
        /// <returns>The objects cookienumber with a hashtag infront of it</returns>
        public override String ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append('#');
            stringBuilder.Append(CookieNumber);
            return stringBuilder.ToString();
        }
    }
}
