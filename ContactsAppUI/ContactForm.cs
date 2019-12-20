using System;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsAppUI
{
    /// <summary>
    /// Создание формы ContactForm
    /// </summary>
    public partial class ContactForm : Form
    {
        /// <summary>
        /// Поле с классом контакта
        /// </summary>
        public Contact _contact;
        public ContactForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Действия при загрузке формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddEditForm_Load(object sender, EventArgs e)
        {
            if (_contact == null)
            {
                _contact = new Contact();
            }
            else
            {
                PhoneTextBox.Text = _contact.Phone.Number.ToString();
                SurnameTextBox.Text = _contact.Surname;
                NameTextBox.Text = _contact.Name;
                BirthdayDateTimePicker.Value = _contact.BirthDay;
                EmailTextBox.Text = _contact.Email;
                VkTextBox.Text = _contact.VkId;

            }
        }

        /// <summary>
        /// Закрытие формы при нажатии Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Обработчик исключений и присваивание при нажатии кнопки Ok
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OkButton_Click(object sender, EventArgs e)
        {
            try
            {
                _contact.Surname = SurnameTextBox.Text;
                _contact.Name = NameTextBox.Text;
                _contact.BirthDay = BirthdayDateTimePicker.Value;
                _contact.Phone.Number = long.Parse(PhoneTextBox.Text);
                _contact.Email = EmailTextBox.Text;
                _contact.VkId = VkTextBox.Text;
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
