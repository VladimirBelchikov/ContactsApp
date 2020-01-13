using ContactsApp;
using Newtonsoft.Json;
using NUnit.Framework;
using System.IO;
using System.Linq;

namespace СontactsAppUnitTests
{
    [TestFixture]
    public class ProjectManagerTest
    {
        [Test(Description = "Позитивный тест сериализации. Сохранение")]
        public void TestProjectManagerSaveTToFile_CorrectValue()
        {
            Contact contact = new Contact();
            contact.Surname = "Смирнов";
            contact.Name = "Иван";
            contact.VkId = "id712383132";
            contact.Email = "Ivan@mail.ru";
            contact.BirthDay = new System.DateTime(2000,1,1);
            var project = new Project();
            project.ContactList.Add(contact);
            ProjectManager.SaveToFile(project);

            var actual = ProjectManager.LoadFromFile().ContactList.Last();
            Assert.AreEqual(contact.Surname, actual.Surname, "Сериализация работает неверно.");
        }
        [Test(Description = "Сохранение в неверный путь.")]
        public void TestProjectManagerSaveToFile_NotCorrectPath()
        {
            Contact contact = new Contact();
            contact.Surname = "Смирнов";
            var project = new Project();
            project.ContactList.Add(contact);
            Assert.Throws<IOException>(() => { ProjectManager.SaveToFile(project, "c:\\New Folder\\"); }, "Должно возникать исключение, если путь неверен.");
        }
        [Test(Description = "Открытие из неверного пути.")]
        public void TestProjectManagerLoadFromFile_NotCorrectPath()
        {
            Assert.Throws<FileNotFoundException>(() => { var project = ProjectManager.LoadFromFile("c:\\New Folder\\"); }, "Должно возникать исключение, если путь неверен.");
        }

        [Test(Description = "Открытие испорченного файла пути.")]
        public void TestProjectManagerLoadFromFile_NotCorrectFile()
        {
            var text = "incorrect file";
            var fileName = "c:\\users\\аааармнрв\\test.txt";
            File.WriteAllText(fileName, text);
            Assert.Throws<JsonReaderException>(() => { var project = ProjectManager.LoadFromFile(fileName); }, "Должно возникать исключение, если файл испорчен.");
        }
    }
}