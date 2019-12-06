using System;
using System.IO;
using Newtonsoft.Json;


namespace ContactsAppClassLibrary
{
    public class ProjectManager
    {
        // Путь в папку "Документы".
        public static string DocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal)
                                + @"\ContactsApp.con";

        /// <summary>
        /// Сохранение списка заметок в файл.
        /// </summary>
        /// <param name="contactList">Список заметок.</param>
        /// <param name="fileName">Имя файла назначения.</param>
        public static void SaveToFile(Project contactList, string fileName)
        {
            JsonSerializer serializer = new JsonSerializer();
            //Открываем поток для записи в файл с указанием пути
            using (StreamWriter sw = new StreamWriter(fileName))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                //Вызываем сериализацию и передаем объект, который хотим сериализовать
                serializer.Serialize(writer, contactList);
            }
        }

        /// <summary>
        /// Сохранение контактов в путь по умолчанию.
        /// </summary>
        /// <param name="contactList">Список контактов</param>
        public static void SaveToFile(Project contactList)
        {
            SaveToFile(contactList, DocumentsPath);
        }

        /// <summary>
        /// Получение список заметок из файла.
        /// </summary>
        /// <param name="filename">Имя файла.</param>
        /// <returns></returns>
        public static Project LoadFromFile(string fileName)
        {
            Project notes = new Project();
            //Создаём экземпляр сериализатора.
            JsonSerializer serializer = new JsonSerializer();
            //Открываем поток для чтения из файла с указанием пути.
            using (StreamReader sr = new StreamReader(fileName))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                //Вызываем десериализацию и явно преобразуем результат в целевой тип данных.
                var noteList = serializer.Deserialize<Project>(reader);
                notes = noteList;
            }
            return notes;
        }

        /// <summary>
        /// Возвращает список контактов из файла по умолчанию.
        /// </summary>
        /// <returns>Список контактов.</returns>
        public static Project LoadFromFile()
        {
            return LoadFromFile(DocumentsPath);
        }
    }
}
