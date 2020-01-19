using ContactsApp;
using Newtonsoft.Json;
using NUnit.Framework;
using System.IO;
using System;

namespace СontactsAppUnitTests
{
    [TestFixture]
    public class ProjectManagerTest
    {

        public string DocPathActual = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\TestActual.txt";
        public string DocPathTest = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\Test.txt";
        [Test(Description = "Позитивный тест сериализации. Сохранение")]
        public void TestProjectManagerSaveTToFile_CorrectValue()
        {
            var project = new Project();

            Contact FirstTestContact = new Contact();
            FirstTestContact.Surname = "Смирнов";
            FirstTestContact.Name = "Иван";
            FirstTestContact.VkId = "id712383132";
            FirstTestContact.Email = "Ivan@mail.ru";
            FirstTestContact.BirthDay = new DateTime(2000,1,1);
            FirstTestContact.Phone = new PhoneNumber(79009000909);

            project.ContactList.Add(FirstTestContact);


            Contact SecondTestContact = new Contact();
            SecondTestContact.Surname = "Петров";
            SecondTestContact.Name = "Алексей";
            SecondTestContact.VkId = "id1238073127";
            SecondTestContact.Email = "Petrov@mail.ru";
            SecondTestContact.BirthDay = new DateTime(1999, 12, 11);
            SecondTestContact.Phone = new PhoneNumber(79999009010);

            project.ContactList.Add(SecondTestContact);

            ProjectManager.SaveToFile(project, DocPathActual);

            Assert.AreEqual(File.ReadAllText(DocPathActual), File.ReadAllText(DocPathTest), "Сериализация работает неверно.");

            File.Delete(DocPathActual);
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
            var fileName = DocPathActual;
            File.WriteAllText(fileName, text);
            Assert.Throws<JsonReaderException>(() => { var project = ProjectManager.LoadFromFile(fileName); }, "Должно возникать исключение, если файл испорчен.");
        }
    }
}