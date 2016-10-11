using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace QuickLauncher
{
    class Shortcuts : IEquatable<Shortcuts>
    {
        private string _Name;
        private string _ShortcutLocation;
        private System.Drawing.Icon _Icon;
        private string _Category;
        private int _ImageNumber;

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

        public string ShortcutLocation
        {
            get
            {
                return _ShortcutLocation;
            }
            set
            {
                _ShortcutLocation = value;
            }
        }

        public System.Drawing.Icon Icon
        {
            get
            {
                return _Icon;
            }
            set
            {
                _Icon = value;
            }
        }

        public string Category
        {
            get
            {
                return _Category;
            }
            set
            {
                _Category = value;
            }
        }

        public int ImageNumber
        {
            get
            {
                return _ImageNumber;
            }
            set
            {
                _ImageNumber = value;
            }
        }

        public Shortcuts()
        {

        }

        public bool Equals(Shortcuts test)
        {
            if (test == null)
                return false;
            else if (this.Category == test.Category && this.Name.ToUpper() == test.Name.ToUpper())
                return true;
            else
                return false;
        }

        public Shortcuts FindMatch(Shortcuts test)
        {
            if (this.Category == test.Category && this.Name.ToUpper() == test.Name.ToUpper())
                return this;
            else
                return null;
        }
    }
}
