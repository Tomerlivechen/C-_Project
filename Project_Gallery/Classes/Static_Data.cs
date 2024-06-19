using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Project_Gallery.Classes
{
    public static class Static_Data
    {
        public static List<Contact_referances> ContactReferances = new List<Contact_referances>() {
        new Contact_referances("", "Contact information"),
        new Contact_referances("Mail.png", "TomerLiveChenWork@Gmail.com"),
        new Contact_referances("What.png", "+972 52-808-82-08"),
        new Contact_referances("", "My Credentials"),
        new Contact_referances("Linked.png", "https://www.linkedin.com/in/tomer-chen-642933a6"),
        new Contact_referances("Git.png", "https://github.com/Tomerlivechen"),
        new Contact_referances("Orcid.png", "https://orcid.org/0000-0001-9320-0009"),
        };
    }
}
