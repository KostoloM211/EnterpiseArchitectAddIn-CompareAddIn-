using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using EA;
using Solution.Forms;


namespace Solution
{
    public class CompareAddIn
    {
        public string EA_Connect(Repository repository)
        {
            // nothing special
            return "EaProjectStats.AddIn - connected";
        }

        // Called when user Click Add-Ins Menu item.
        public object EA_GetMenuItems(Repository repository, string location, string menuName)
        {
            switch (menuName)
            {
                case "":
                    return "compare this package";
            }
            return "";
        }

        // Sets the state of the menu depending if there is
        // an active project or not
        static bool IsProjectOpen(Repository repository)
        {
            try
            {
                return null != repository.Models;
            }
            catch
            {
                return false;
            }
        }

        // Called once Menu has been opened to see what menu
        // items are active.
        public void EA_GetMenuState(Repository repository, string location, string menuName, string itemName,
            ref bool isEnabled, ref bool isChecked)
        {
            if (IsProjectOpen(repository))
            {   
                isEnabled = true;
            }
            else
                // If no open project, disable all menu options
                isEnabled = false;
        }

        // Called when user makes a selection in the menu.
        // This is your main exit point to the rest of your Add-in
        public void EA_MenuClick(Repository repository, string location, string menuName, string itemName)
        {
            switch (itemName)
            {
                case "compare this package":
                    var frm = new Choise(repository);
                    frm.ShowDialog();
                    break;
            }
        }
        
    }
}

