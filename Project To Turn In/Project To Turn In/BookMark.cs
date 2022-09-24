using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Project_To_Turn_In
{
    /// <summary>
    /// A class representing the bookmark
    /// </summary>
    public class BookMark
    {
        [JsonPropertyName("Bookmark id")]
        public string id { get; set; } = Guid.NewGuid().ToString();

        [JsonPropertyName("Bookmark location")]
        public int BookMarkLocation { get; set; } = 0;

        public BookMark(int location)
        {
            BookMarkLocation = location;
        }

        public override string ToString()
        {
            return "BookMark at " + BookMarkLocation;
        }
    }
}
