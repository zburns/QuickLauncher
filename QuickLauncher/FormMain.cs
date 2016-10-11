using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuickLauncher
{
    public partial class FormMain : Form
    {
        System.Collections.Generic.List<Shortcuts> shortcuts;
        System.Windows.Forms.ImageList imagelist;

        public FormMain()
        {
            InitializeComponent();

            shortcuts = new List<Shortcuts>();

            imagelist = new ImageList();
            listViewBusiness.LargeImageList = imagelist;
            listViewBusiness.SmallImageList = imagelist;
            listViewPersonal.LargeImageList = imagelist;
            listViewPersonal.SmallImageList = imagelist;

            GetGridViewSettingsFromRegistry();
            GetSettingsFromRegistry("Business");
            GetSettingsFromRegistry("Personal");

            PopulateListViews();
        }

        #region "Grid View Preferences"
        private void GetGridViewSettingsFromRegistry()
        {
            Microsoft.Win32.RegistryKey keys = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\QuickLauncher",true);
            if (keys != null)
            {
                object businessgridview = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\QuickLauncher").GetValue("BusinessGridViewSetting");
                object personalgridview = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\QuickLauncher").GetValue("PersonalGridViewSetting");

                if (businessgridview != null)
                    comboBoxBusinessViewMode.SelectedItem = businessgridview;
                else
                {
                    keys.SetValue("BusinessGridViewSetting", "LargeIcon", Microsoft.Win32.RegistryValueKind.String);
                    comboBoxBusinessViewMode.SelectedItem = "LargeIcon";
                }

                if (personalgridview != null)
                    comboBoxPersonalViewMode.SelectedItem = personalgridview;
                else
                {
                    comboBoxPersonalViewMode.SelectedItem = "LargeIcon";
                    keys.SetValue("PersonalGridViewSetting", "LargeIcon", Microsoft.Win32.RegistryValueKind.String);
                }
            }
            else
            {
                keys = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\QuickLauncher");
                keys.CreateSubKey("Business");
                keys.CreateSubKey("Personal");
            }
            keys.Close();
            keys = null;
        }

        private void SetGridViewSettingsToRegistry()
        {
            Microsoft.Win32.RegistryKey keys = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\QuickLauncher",true);
            if (keys != null)
            {
                try
                {
                    keys.SetValue("BusinessGridViewSetting", comboBoxBusinessViewMode.SelectedItem.ToString(), Microsoft.Win32.RegistryValueKind.String);
                    keys.SetValue("PersonalGridViewSetting", comboBoxPersonalViewMode.SelectedItem.ToString(), Microsoft.Win32.RegistryValueKind.String);
                }
                catch
                {
                    keys.SetValue("BusinessGridViewSetting", "LargeIcon", Microsoft.Win32.RegistryValueKind.String);
                    keys.SetValue("PersonalGridViewSetting", "LargeIcon", Microsoft.Win32.RegistryValueKind.String);
                }
            }
            else
            {
                keys = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\QuickLauncher");
                keys.CreateSubKey("Business");
                keys.CreateSubKey("Personal");
            }
            keys.Close();
            keys = null;
        }
        #endregion

        private void GetSettingsFromRegistry(string Category)
        {
            Microsoft.Win32.RegistryKey keys = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\QuickLauncher");
            if (keys != null)
            {
                //read keys
                string[] subkeys = keys.GetSubKeyNames();
                foreach (string subkey in subkeys)
                {
                    if (subkey.ToUpper() == Category.ToUpper())
                    {
                        string[] businesskeys = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\QuickLauncher\\" + Category).GetValueNames();
                        foreach (string businesssubkeys in businesskeys)
                        {
                            Shortcuts sc = new Shortcuts();
                            sc.Category = Category;
                            sc.Name = businesssubkeys;
                            sc.ShortcutLocation = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\QuickLauncher\\" + Category).GetValue(businesssubkeys).ToString();
                            if (System.IO.File.Exists(sc.ShortcutLocation))
                            {
                                sc.Icon = System.Drawing.Icon.ExtractAssociatedIcon(sc.ShortcutLocation);
                                sc.ImageNumber = imagelist.Images.Count;
                                imagelist.Images.Add(sc.Icon);
                            }
                            else
                            {
                                sc.ImageNumber = -1;
                            }
                            shortcuts.Add(sc);
                            sc = null;
                        }
                    }
                }
            }
            else
            {
                //create program key and category keys
                keys = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\QuickLauncher");
                keys.CreateSubKey("Business");
                keys.CreateSubKey("Personal");
            }
            keys.Close();
            keys = null;
        }

        private void SaveSettingsToRegistry(string Category)
        {
            Microsoft.Win32.RegistryKey keys = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\QuickLauncher",true);
            if (keys != null)
            {
                keys.DeleteSubKeyTree(Category);
                keys.CreateSubKey(Category);

                Microsoft.Win32.RegistryKey subkeys = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\QuickLauncher\\" + Category, true);
                foreach (Shortcuts sc in shortcuts)
                {
                    if (sc.Category.ToUpper() == Category.ToUpper())
                    {
                        subkeys.SetValue(sc.Name, sc.ShortcutLocation);
                    }
                }
                subkeys.Close();
                subkeys = null;
            }
            else
            {
                //Missing some keys - create them then saveSettingsToRegistry
                keys = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\QuickLauncher");
                keys.CreateSubKey(Category);
                Microsoft.Win32.RegistryKey subkeys = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\QuickLauncher\\" + Category, true);
                foreach (Shortcuts sc in shortcuts)
                {
                    if (sc.Category.ToUpper() == Category.ToUpper())
                    {
                        subkeys.SetValue(sc.Name, sc.ShortcutLocation);
                    }
                }
                subkeys.Close();
                subkeys = null;
            }
            keys.Close();
            keys = null;
        }

        private void PopulateListViews()
        {
            foreach (Shortcuts sc in shortcuts)
            {
                switch (sc.Category)
                {
                    case "Business":
                        {
                            listViewBusiness.Items.Add(new ListViewItem(sc.Name, sc.ImageNumber));
                            break;
                        }
                    case "Personal":
                        {
                            listViewPersonal.Items.Add(new ListViewItem(sc.Name, sc.ImageNumber));
                            break;
                        }
                    default:
                        break;
                }
            }
        }

        private void FormMain_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            MessageBox.Show("Simply drag a program or shortcut to 'Business' or 'Personal' category");
        }

        #region "Switch View Mode"
        private void comboBoxBusinessViewMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxBusinessViewMode.Text)
            {
                case "LargeIcon":
                    {
                        listViewBusiness.View = View.LargeIcon;
                        break;
                    }
                case "SmallIcon":
                    {
                        listViewBusiness.View = View.SmallIcon;
                        break;
                    }
                case "List":
                    {
                        listViewBusiness.View = View.List;
                        break;
                    }
                case "Tile":
                    {
                        listViewBusiness.View = View.Tile;
                        break;
                    }
            }
            
        }

        private void comboBoxPersonalViewMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxPersonalViewMode.Text)
            {
                case "LargeIcon":
                    {
                        listViewPersonal.View = View.LargeIcon;
                        break;
                    }
                case "SmallIcon":
                    {
                        listViewPersonal.View = View.SmallIcon;
                        break;
                    }
                case "List":
                    {
                        listViewPersonal.View = View.List;
                        break;
                    }
                case "Tile":
                    {
                        listViewPersonal.View = View.Tile;
                        break;
                    }
            }
        }
        #endregion

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //Save Business Items
                foreach (object o in listViewBusiness.Items)
                {
                    SaveSettingsToRegistry("Business");
                }

                //Save Personal Items
                foreach (object o in listViewPersonal.Items)
                {
                    SaveSettingsToRegistry("Personal");
                }

                SetGridViewSettingsToRegistry();

                e.Cancel = false;
            }
            catch
            {
                e.Cancel = true;
                MessageBox.Show("Unable to save your changes to the registry");
            }
        }

        private void listViewBusiness_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop,false) == true)
                e.Effect = DragDropEffects.All;
        }

        private void listViewBusiness_DragDrop(object sender, DragEventArgs e)
        {
            HandleDragDropped(e, "Business");
        }

        private void HandleDragDropped(DragEventArgs e, string Category)
        {
            //Make sure it doesn't already exist.
            //if it doesn't exist, then copy it in there
            string[] filesdropped = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in filesdropped)
            {
                Shortcuts sc = new Shortcuts();
                sc.Category = Category;
                string tmp = file.Substring(file.LastIndexOf('\\') + 1);
                if (tmp.Contains("."))
                    tmp = tmp.Remove(tmp.LastIndexOf('.'));
                sc.Name = tmp;
                sc.ShortcutLocation = file;
                if (System.IO.File.Exists(sc.ShortcutLocation))
                {
                    sc.Icon = System.Drawing.Icon.ExtractAssociatedIcon(sc.ShortcutLocation);
                    sc.ImageNumber = imagelist.Images.Count;
                    imagelist.Images.Add(sc.Icon);
                }
                else
                {
                    sc.ImageNumber = -1;
                }
                if (!shortcuts.Contains(sc))
                {
                    //just add to business list if not already in there

                    if (Category == "Business")
                    {
                        shortcuts.Add(sc);
                        listViewBusiness.Items.Add(new ListViewItem(sc.Name, sc.ImageNumber));
                    }
                    else if (Category == "Personal")
                    {
                        shortcuts.Add(sc);
                        listViewPersonal.Items.Add(new ListViewItem(sc.Name, sc.ImageNumber));
                    }
                    else
                    {
                        //do nothing
                    }
                }
                sc = null;
            }
        }

        private void listViewPersonal_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
                e.Effect = DragDropEffects.All;            
        }

        private void listViewPersonal_DragDrop(object sender, DragEventArgs e)
        {
            HandleDragDropped(e, "Personal");
        }

        private void listViewBusiness_DoubleClick(object sender, EventArgs e)
        {
            LaunchItem("Business");
        }

        private void LaunchItem(string Category)
        {
            switch (Category)
            {
                case "Business":
                    {
                        if (listViewBusiness.SelectedItems.Count == 1)
                        {
                            Shortcuts found = shortcuts.Find(delegate(Shortcuts tofind) { return tofind.Name == listViewBusiness.SelectedItems[0].Text && tofind.Category == Category; });
                            if (found != null)
                                if (System.IO.File.Exists(found.ShortcutLocation))
                                    System.Diagnostics.Process.Start(found.ShortcutLocation);
                                else
                                    MessageBox.Show("Cannot Launch.  Program, File, or Shortcut is missing.");
                            else
                                MessageBox.Show("Cannot Launch.  Program, File, or Shortcut is missing.");
                        }
                        break;
                    }
                case "Personal":
                    {

                        Shortcuts found = shortcuts.Find(delegate(Shortcuts tofind) { return tofind.Name == listViewPersonal.SelectedItems[0].Text && tofind.Category == Category; });
                        if (found != null)
                            if (System.IO.File.Exists(found.ShortcutLocation))
                                System.Diagnostics.Process.Start(found.ShortcutLocation);
                            else
                                MessageBox.Show("Cannot Launch.  Program, File, or Shortcut is missing.");
                        else
                            MessageBox.Show("Cannot Launch.  Program, File, or Shortcut is missing.");
                        break;
                    }
                default:
                    break;
            }
        }

        private void listViewPersonal_DoubleClick(object sender, EventArgs e)
        {
            LaunchItem("Personal");
        }

        private void listViewBusiness_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (listViewBusiness.SelectedItems.Count == 1)
                {
                    Shortcuts toremove = new Shortcuts();
                    toremove.Category = "Business";
                    toremove.Name = listViewBusiness.SelectedItems[0].Text;
                    shortcuts.Remove(toremove);
                    toremove = null;
                    listViewBusiness.Items.Remove(listViewBusiness.SelectedItems[0]);
                }                
            }
        }

        private void listViewPersonal_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (listViewPersonal.SelectedItems.Count == 1)
                {
                    Shortcuts toremove = new Shortcuts();
                    toremove.Category = "Personal";
                    toremove.Name = listViewPersonal.SelectedItems[0].Text;
                    shortcuts.Remove(toremove);
                    toremove = null;
                    listViewPersonal.Items.Remove(listViewPersonal.SelectedItems[0]);
                }
            }
        }
    }
}
