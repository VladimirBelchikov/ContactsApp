using System;
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
    }
}
