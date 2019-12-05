using System;
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
    public partial class AddEditForm : Form
    {
        public Contact Contact;
        public AddEditForm()
        {
            InitializeComponent();
        }

        private void AddEditForm_Load(object sender, EventArgs e)
        {
            if (Contact == null)
                Contact = new Contact();
            else PhoneTextBox.Text = Contact.Phone.Number.ToString();


            SurnameTextBox.Text = Contact.Surname;
            NameTextBox.Text = Contact.Name;
            BirthdayDateTimePicker.Value = Contact.BirthDate;

            EmailTextBox.Text = Contact.Email;
            VkTextBox.Text = Contact.VkId;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
