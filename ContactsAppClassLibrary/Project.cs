using System;
using System.Collections.Generic;

namespace ContactsAppClassLibrary
{
    public class Project
    {
        /// <summary>
        /// Список контактов.
        /// </summary>
        public List<Contacts> ContactList;

        public Project()
        {
            ContactList = new List<Contacts>();
        }
    }
}
