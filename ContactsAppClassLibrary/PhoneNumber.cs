﻿using System;

namespace ContactsAppClassLibrary
{
    /// <summary>
    /// Класс работающий с номером телефона
    /// </summary>
    public class PhoneNumber
    {
        private long _phoneNumber;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public PhoneNumber(long phone)
        {
            Number = phone;
        }

        public long Number
        {
            get => _phoneNumber;

            set
            {
                var valueString = value.ToString();

                if (valueString.Length != 11)
                {
                    throw new ArgumentException("Номер телефона должен состоять из 11 цифр, а было" + valueString.Length);
                }
                else if (valueString[0] != '7')
                {
                    throw new ArgumentException("Номер телефона должен начинаться с '7', а начинается с " + valueString[0]);
                }
                else
                {
                    _phoneNumber = value;
                }
            }
        }
    }
}