using System.Collections.Generic;

namespace ContactsAppClassLibrary
{
    public class Project
    {
        /// <summary>
        /// Список контактов
        /// </summary>
        public List<Contact> ContactList;
        
        /// <summary>
        /// Конструктор списка 
        /// </summary>
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
            list.Sort((First, Second) => First.Surname.CompareTo(Second.Surname));
            return list;
        }

        /// <summary>
        /// Поиск по фамилии.
        /// </summary>
        public List<Contact> GetBySurname(string text)
        {
            return Sort().FindAll(First => First.Surname.Contains(text));
        }
    }
}
