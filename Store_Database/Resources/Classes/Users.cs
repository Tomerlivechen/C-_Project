using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace Store_Database.Resources.Classes
{
    public class Users
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public string StartDate { get; set; }
        public string? EndDate { get; set; }
        public bool StillEmployed { get; set; }
        public bool Manager { get; set; }
        public int Index { get; set; }
        public Users(string Name, string ID, bool StillEmployed, bool Manager, int index)
        {
            this.Name = Name;
            this.ID = ID;
            this.StartDate = DateTime.Now.ToString("yyyy-MM-dd");
            this.EndDate = null;
            this.StillEmployed = StillEmployed;
            this.Manager = Manager;
            this.Index = index;
        }
        [JsonConstructor]
        public Users(int Index, string Name, string ID, string StartDate, string EndDate, bool StillEmployed, bool Manager)
        {
            this.Index = Index;
            this.Name = Name;
            this.ID = ID;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.StillEmployed = StillEmployed;
            this.Manager = Manager;
        }
        public Users()
        {
        }
        public void LetGo()
        {
            EndDate = DateTime.Now.ToString("yyyy-MM-dd");
            StillEmployed = false;
        }
        public override string ToString()
        {
            string tostring;
            tostring = $"ID: {ID} , Name: {Name} , Start Date: {StartDate} , End Date: {EndDate} , Manager: {Manager} , Still Employed: {StillEmployed}";
            return tostring;
        }
    }
}
