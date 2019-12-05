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
        public Contacts Contact;
        public AddEditForm()
        {
            InitializeComponent();
        }

        //Подсветка ошибок поля "Surname".
        private void SurnameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (SurnameTextBox.Text.Length == 0 || SurnameTextBox.Text.Length > 50)
            {
                SurnameTextBox.BackColor = Color.LightSalmon;
            }
            else
            {
                SurnameTextBox.BackColor = Color.White;
            }
        }

        //Подсветка ошибок поля "Name".
        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (NameTextBox.Text.Length == 0 || NameTextBox.Text.Length > 50)
            {
                NameTextBox.BackColor = Color.LightSalmon;
            }
            else
            {
                NameTextBox.BackColor = Color.White;
            }
        }

        //Подсветка ошибок поля "Phone".
        private void PhoneTextBox_TextChanged(object sender, EventArgs e)
        {
            long num = 0;
            if (PhoneTextBox.Text.Length == 0 || PhoneTextBox.Text.Length > 11 || PhoneTextBox.Text[0] != '7' ||
                !long.TryParse(PhoneTextBox.Text, out num))
            {
                PhoneTextBox.BackColor = Color.LightSalmon;
            }
            else
            {
                PhoneTextBox.BackColor = Color.White;
            }
        }

        //Подсветка ошибок поля "Email".
        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {
            if (EmailTextBox.Text.Length == 0 || EmailTextBox.Text.Length > 50)
            {
                EmailTextBox.BackColor = Color.LightSalmon;
            }
            else
            {
                EmailTextBox.BackColor = Color.White;
            }
        }

        //Подсветка ошибок поля "vk.com".
        private void VkTextBox_TextChanged(object sender, EventArgs e)
        {
            if (VkTextBox.Text.Length == 0 || VkTextBox.Text.Length > 15)
            {
                VkTextBox.BackColor = Color.LightSalmon;
            }
            else
            {
                VkTextBox.BackColor = Color.White;
            }
        }
        
        //Действия при нажатии кнопки "Ok"
        private void OkButton_Click(object sender, EventArgs e)
        {
            try
            {
                Contact.Surname = SurnameTextBox.Text;
                Contact.Name = NameTextBox.Text;
                Contact.BirthDate = BirthdayDateTimePicker.Value;
                Contact.Phone.Number = long.Parse(PhoneTextBox.Text);
                Contact.Email = EmailTextBox.Text;
                Contact.VkId = VkTextBox.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        // Действия при нажатии кнопки "Cancel"
        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }




        private void AddEditForm_Load(object sender, EventArgs e)
        {
            if (Contact == null)
                Contact = new Contacts();
            else PhoneTextBox.Text = Contact.Phone.Number.ToString();


            SurnameTextBox.Text = Contact.Surname;
            NameTextBox.Text = Contact.Name;
            BirthdayDateTimePicker.Value = Contact.BirthDate;

            EmailTextBox.Text = Contact.Email;
            VkTextBox.Text = Contact.VkId;
        }
    }
}
