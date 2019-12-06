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

            //лямбда выражения, Linq
            list.Sort((a, b) => a.Surname.CompareTo(b.Surname));
            return list;
        }

        /// <summary>
        /// Поиск по имени или фамилии.
        /// </summary>
        public List<Contact> GetByNameOrSurname(string text)
        {
            return Sort().FindAll(a => a.Surname.Contains(text) || a.Name.Contains(text));
        }
    }
}
