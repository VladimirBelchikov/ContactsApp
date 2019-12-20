using System;
using System.IO;
using System.Windows.Forms;
using ContactsAppClassLibrary;

namespace ContactsAppUI
{
    public partial class MainForm : Form
    {
       /// <summary>
       /// Поле с классом проекта
       /// </summary>
        private Project _project;

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод добавления контакта.
        /// </summary>
        private void AddContact()
        {
            var form = new ContactForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                _project.ContactList.Add(form.Contact);
                RefreshList();
            }
        }

        /// <summary>
        /// Метод редактирования контакта.
        /// </summary>
        private void EditContact()
        {
            if (ContactListBox.SelectedItem != null)
            {
                var form = new ContactForm();
                form.Contact = (Contact)ContactListBox.SelectedItem;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    RefreshList();
                }
            }
        }

        /// <summary>
        /// Метод удаления контакта.
        /// </summary>
        private void RemoveContact()
        {
            if (ContactListBox.SelectedItem != null)
            {
                if (MessageBox.Show("Вы точно хотите удалить контакт?", "Предупреждение", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _project.ContactList.Remove((Contact)ContactListBox.SelectedItem);
                    RefreshList();
                }
            }
        }

        /// <summary>
        /// Обновление списка
        /// </summary>
        private void RefreshList()
        {
            ContactListBox.DataSource = null;
            ContactListBox.DataSource = _project.GetBySurname(FindTextBox.Text);
            ContactListBox.DisplayMember = "Surname";
            ProjectManager.SaveToFile(_project, ProjectManager.DocumentsPath);
        }

        /// <summary>
        /// Загрузка формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (File.Exists(ProjectManager.DocumentsPath))
            {
                _project = ProjectManager.LoadFromFile(ProjectManager.DocumentsPath);
            }
            else
            {
                _project = new Project();
                ProjectManager.SaveToFile(_project, ProjectManager.DocumentsPath);
            }

            RefreshList();
        }

        /// <summary>
        /// Вызов окна About
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new AboutForm();
            form.ShowDialog();
        }

        /// <summary>
        /// Кнопка Add
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton_Click(object sender, EventArgs e)
        {
            AddContact();
        }

        /// <summary>
        /// Кнопка Edit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditButton_Click(object sender, EventArgs e)
        {
            EditContact();
        }

        /// <summary>
        /// Кнопка Remove
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            RemoveContact();
        }

        /// <summary>
        /// Кнопка Add в MenuStrip
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddContact();
        }

        /// <summary>
        /// Отображение контакта при выборе в ListBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContactListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ContactListBox.SelectedItem != null)
            {
                var contact = (Contact)ContactListBox.SelectedItem;
                SurnameTextBox.Text = contact.Surname;
                NameTextBox.Text = contact.Name;
                BirthdayDateTimePicker.Value = contact.BirthDay;
                PhoneTextBox.Text = contact.Phone.Number.ToString();
                EmailTextBox.Text = contact.Email;
                VkTextBox.Text = contact.VkId;
            }
        }

        /// <summary>
        /// Обновление при вводе в поле Find
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindTextBox_TextChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

        /// <summary>
        /// Кнопка Edit в MenuStrip
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditContact();
        }

        /// <summary>
        /// Кнопка Remove в MenuStrip
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveContact();
        }

        /// <summary>
        /// Кнопка Exit в MenuStrip
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
