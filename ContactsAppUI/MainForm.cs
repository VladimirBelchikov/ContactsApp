using System;
using System.IO;
using System.Windows.Forms;
using ContactsAppClassLibrary;

namespace ContactsAppUI
{
    public partial class MainForm : Form
    {
        private Project _contactList;

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод добавления контакта.
        /// </summary>
        private void AddContact()
        {
            var form = new AddEditForm();

            if (form.ShowDialog() == DialogResult.OK)
            {
                _contactList.ContactList.Add(form.Contact);
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
                var form = new AddEditForm();
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
                    _contactList.ContactList.Remove((Contact)ContactListBox.SelectedItem);
                    RefreshList();
                }
            }
        }



        /// <summary>
        /// Метод обновления списка контактов.
        /// </summary>
        private void RefreshList()
        {
            ContactListBox.DataSource = null;
            ContactListBox.DataSource = _contactList.GetBySurname(FindTextBox.Text);
            ContactListBox.DisplayMember = "Surname";
            ProjectManager.SaveToFile(_contactList, ProjectManager.DocumentsPath);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (File.Exists(ProjectManager.DocumentsPath))
            {
                _contactList = ProjectManager.LoadFromFile(ProjectManager.DocumentsPath);
            }
            else
            {
                _contactList = new Project();
                ProjectManager.SaveToFile(_contactList, ProjectManager.DocumentsPath);
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
        /// 
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
                BirthdayDateTimePicker.Value = contact.BirthDate;
                PhoneTextBox.Text = contact.Phone.Number.ToString();
                EmailTextBox.Text = contact.Email;
                VkTextBox.Text = contact.VkId;
            }
        }
    }
}
