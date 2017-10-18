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
    class Cat
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
}
