
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniKindleForm
{
    /// <summary>
    /// The class representing the page 
    /// </summary>
    public  class Page: IEquatable<Page>, IComparable<Page>
    {

        /// <summary>
        /// the words on the page
        /// </summary>
        [JsonPropertyName("words")]
        public string Words { get; set; } = "<nothing to see>";

        /// <summary>
        /// The header on the page
        /// </summary>
        [JsonPropertyName("header")]
        public string PageHeader { get; set; } = "<no header>";

        /// <summary>
        /// The page number
        /// </summary>
        [JsonPropertyName("page number")]
        public int PageNumber { get; set; } = 0;

        public int CompareTo(Page other)
        {
            if (other == null) return 1;

            if (other.PageNumber == PageNumber)
                throw new ArgumentException("two pages cannot have the same page number"); //might be some issues with icomparable and equatable....

            return PageNumber.CompareTo(other.PageNumber);
        }

        public bool Equals(Page other)
        {
            if (other == null) return false;

            if(ReferenceEquals(this, other)) return true;


            return false;
        }
    }
}
