using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            if (ContactsListBox.SelectedItem != null)
            {
                var form = new AddEditForm();
                form.Contact = (Contact)ContactsListBox.SelectedItem;
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
            if (ContactsListBox.SelectedItem != null)
            {
                if (MessageBox.Show("Вы точно хотите удалить контакт?", "Предупреждение", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _contactList.ContactList.Remove((Contact)ContactsListBox.SelectedItem);
                    RefreshList();
                }
            }
        }

        /// <summary>
        /// Метод обновления списка контактов.
        /// </summary>
        private void RefreshList()
        {
            ContactsListBox.DataSource = null;
            ContactsListBox.DisplayMember = "Surname";
            ProjectManager.SaveToFile(_contactList, ProjectManager.DocumentsPath);
        }



        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new AboutForm();
            form.ShowDialog();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddContact();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            EditContact();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            RemoveContact();
        }
    }
}
