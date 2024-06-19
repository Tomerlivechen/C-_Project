using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace Store_Database.Resources.Classes
{
    public class DB_Item
    {

        public string Id { get; set; }
        public string ItemName { get; set; }
        public string MainCategory { get; set; }
        public string SeconderyCategory { get; set; }
        public double Amount {  get; set; }
        public double MinAmount { get; set; }
        public string AddedDate { get; set; }
        public string LastUpdate { get; set; }
        public string LastUpdater { get; set; }
        public int Index {  get; set; }
        public DB_Item(string itemName, string mainCategory, string seconderyCategory, double amount, double minAmount , string lastUpdater )
        {
            AddedDate = DateTime.Now.ToString("yyyy-MM-dd");
            LastUpdate = DateTime.Now.ToString("yyyy-MM-dd");
            Id = Guid.NewGuid().ToString();
            ItemName = itemName;
            MainCategory = mainCategory;
            SeconderyCategory = seconderyCategory;
            Amount = amount;
            MinAmount = minAmount;
            LastUpdater = lastUpdater;
        }
        public DB_Item()
        {
        }
        [JsonConstructor]
        public DB_Item(int index, string id, string itemName, string mainCategory, string seconderyCategory, double amount, double minAmount, string addedDate, string lastUpdate, string lastUpdater)
        {
            this.Index = index;
            this.Id = id;
            this.ItemName = itemName;
            this.MainCategory = mainCategory;
            this.SeconderyCategory = seconderyCategory;
            this.Amount = amount;
            this.MinAmount = minAmount;
            this.AddedDate = addedDate;
            this.LastUpdate = lastUpdate;
            this.LastUpdater = lastUpdater;
    }
        public void AddAmount(double amount)
        {
            Amount = amount;
            updateLastUpdate();

        }
        public void UpdateMinAmount (double amount)
        {
            MinAmount = amount;
            updateLastUpdate();

        }
        public override string ToString()
        {
            string tostring = $"ID: {Id} , Item Name: {ItemName} , Main Category: {MainCategory} , Secondery Category: {SeconderyCategory} , Amount: {Amount} , Min Amount: {MinAmount} , Added Date: {AddedDate}, Last Update: {LastUpdate},Last Updater: {LastUpdater}";
            return tostring;
        }
        public void updateLastUpdate()
        {
            LastUpdate = DateTime.Now.ToString("yyyy-MM-dd");
        }
        public void ChangeCat1(string catName)
        {
            MainCategory = catName;
            updateLastUpdate();
        }
        public void ChangeCat2(string catName)
        {
            SeconderyCategory = catName;
            updateLastUpdate();
        }
    }
}
