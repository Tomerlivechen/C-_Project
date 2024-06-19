using Common_Classes.Classes;
using Common_Classes.Common_Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace Store_Database.Resources.Classes
{
    public static class Security
    {
        public static bool checkManagerCode()
        {
      
            var number_of_field = 1;
            var title = "Manager Approval";
            var Input_field1 = new Input_box_field();
            Input_field1.Input_label = "Insert Manager Passcode";
            Input_box input_Box;
            UniversalVars.inputBoxReturn = null;
            do
            {
                input_Box = new Input_box(number_of_field, title, Input_field1);
                input_Box.ShowDialog();
                if (UniversalVars.inputBoxReturn == null)
                {
                    MessageBox.Show("Please enter a pascode", "Manager Approval is needed");
                }
            }
            while (UniversalVars.inputBoxReturn == null);
            if (UniversalVars.inputBoxReturn[0].ToString() == Static_Data.ManagerPassward)
            {
                Log.addToLog($"Manager Passwared used");
                return true;
            }
            MessageBox.Show("Wrong Passcode");
            Log.addToLog($"Manager Passwared failed");
            return false;
        }
        public static void changeManagerCode()
        {
            bool hasInput = false;
            var number_of_field = 3;
            var title = "Insert New Manager passcode";
            var Input_field1 = new Input_box_field();
            var Input_field2 = new Input_box_field();
            var Input_field3 = new Input_box_field();
            Input_field1.Input_label = "Enter Manager edit passcode:";
            Input_field2.Input_label = "Enter Old Manager passcode:";
            Input_field3.Input_label = "Enter New Manager passcode:";
            do
            {
                var input_Box = new Input_box(number_of_field, title, Input_field1, Input_field2, Input_field3);
                input_Box.ShowDialog();
                if (UniversalVars.inputBoxReturn.Count == 3)
                {
                    hasInput = true;
                }
                else
                {
                    MessageBox.Show("Enter a value in all fields", "Error");
                }
            } while (!hasInput);
            if (UniversalVars.inputBoxReturn[0].ToString() == Static_Data.ManagerEditPassward)
            {
                if (UniversalVars.inputBoxReturn[1].ToString() == Static_Data.ManagerPassward)
                {
                    Static_Data.ManagerPassward = UniversalVars.inputBoxReturn[2].ToString();
                    MessageBox.Show("Passcode changed successfully", "success");
                    Log.addToLog($"Manager Passwared Changed to {Static_Data.ManagerPassward}");
                    return;
                }
                MessageBox.Show("Manager passcode incorrect", "Error");
                Log.addToLog($"Manager Passwared Changed to attempted");
                return;
            }
            MessageBox.Show("Manager edit passcode incorrect", "Error");
            Log.addToLog($"Manager Passwared Changed to attempted");
            return;
        }
    }
}
