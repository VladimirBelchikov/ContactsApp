using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactsAppClassLibrary
{
    public class Project
    {
        /// <summary>
        /// Список контактов.
        /// </summary>
        public List<Contact> ContactList;

        public Project()
        {
            ContactList = new List<Contact>();
        }
    }
}
