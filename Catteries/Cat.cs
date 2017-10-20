using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Catteries
{
    /// <summary>
    /// Класс, реализующий информацию о кошке
    /// </summary>
    public class Cat
    {
        int id;
        string name;
        bool isMale;
        DateTime birthDate;
        string colorName;
        string colorCode;
        string earsTypeName;
        string earsTypeCode;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public bool IsMale { get => isMale; set => isMale = value; }
        public DateTime BirthDate { get => birthDate; set => birthDate = value; }
        public string ColorName { get => colorName; set => colorName = value; }
        public string ColorCode { get => colorCode; set => colorCode = value; }
        public string EarsTypeName { get => earsTypeName; set => earsTypeName = value; }
        public string EarsTypeCode { get => earsTypeCode; set => earsTypeCode = value; }

        /// <summary>
        /// Новый кот
        /// </summary>
        /// <param name="Name">Имя</param>
        /// <param name="IsMale">Половой признак</param>
        public Cat(string Name, bool IsMale)
        {
            this.Name = Name;
            this.IsMale = IsMale;
        }

        /// <summary>
        /// Новый кот
        /// </summary>
        /// <param name="row">Строка из БД</param>
        public Cat(DataRow row)
        {
            Id = Convert.ToInt32(row["ID"]);
            Name = row["Name"].ToString();
            IsMale = Convert.ToBoolean(row["IsMale"]);
            BirthDate = Convert.ToDateTime(row["BirthDate"]);
            ColorName = row["ColorName"].ToString();
            ColorCode = row["ColorCode"].ToString();
            EarsTypeName = row["EarsTypeName"].ToString();
            EarsTypeCode = row["EarsTypeCode"].ToString();
        }
    }

    /// <summary>
    /// Класс, реализующий информацию о вязке
    /// </summary>
    public class Cattery
    {
        /// <summary>
        /// Класс, реализующий информацию о хозяине
        /// </summary>
        public class CatOwner
        {
            int id;
            string name;
            string contacts;
            string address;

            public string Name { get => name; set => name = value; }
            public string Contacts { get => contacts; set => contacts = value; }
            public string Address { get => address; set => address = value; }
            public int Id { get => id; set => id = value; }

            /// <summary>
            /// Владелец кошки
            /// </summary>
            /// <param name="Name">Имя владельца</param>
            /// <param name="Contacts">Контакты</param>
            /// <param name="Address">Адрес</param>
            public CatOwner(string Name, string Contacts, string Address)
            {
                this.Name = Name;
                this.Contacts = Contacts;
                this.Address = Address;
            }

            public override string ToString()
            {
                return String.Format("Имя: {0}, Контакты: {1}, Адрес: {2}", Name, Contacts, Address);
            }
        }

        int id;
        int partnerID;
        Cat partner;
        DateTime date;
        DateTime kittiesBirthday;
        double price;
        CatOwner owner;

        internal Cat Partner { get => partner; set => partner = value; }
        public DateTime Date { get => date; set => date = value; }
        public DateTime KittiesBirthday { get => kittiesBirthday; set => kittiesBirthday = value; }
        public double Price { get => price; set => price = value; }
        public CatOwner Owner { get => owner; set => owner = value; }
        public int Id { get => id; set => id = value; }
        public int PartnerID { get => partnerID; set => partnerID = value; }

        /// <summary>
        /// Объект вязки
        /// </summary>
        /// <param name="Partner">Кошка или кот - партнер</param>
        /// <param name="Date">Дата вязки</param>
        /// <param name="Price">Стоимость вязки</param>
        public Cattery(Cat Partner, DateTime Date, double Price)
        {
            this.Partner = Partner;
            this.Date = Date;
            this.Price = Price;
        }

        /// <summary>
        /// Добавление информации о вязки из БД
        /// </summary>
        /// <param name="row">Строка БД</param>
        public Cattery(DataRow row)
        {
            Id = Convert.ToInt32(row["ID"]);
            Date = Convert.ToDateTime(row["Date"]);
            try
            {
                KittiesBirthday = Convert.ToDateTime(row["BirthDate"]);
            }
            catch { }
            Price = Convert.ToDouble(row["Price"]);
            PartnerID = Convert.ToInt32(row["CatPartnerID"]);
        }
    }
}
