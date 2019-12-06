using System.Collections.Generic;

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

        /// <summary>
        /// Сортировка списка по алфавиту.
        /// </summary>
        public List<Contact> Sort()
        {
            var list = ContactList;
            list.Sort((a, b) => a.Surname.CompareTo(b.Surname));
            return list;
        }

        /// <summary>
        /// Поиск по имени или фамилии.
        /// </summary>
        public List<Contact> GetBySurname(string text)
        {
            return Sort().FindAll(a => a.Surname.Contains(text));
        }
    }
}
