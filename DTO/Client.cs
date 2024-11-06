using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodManagement.DTO
{
    public class Client
    {
        public Client() { }
        public Client(String name, string email, string stk, int ba)
        {
            this.Name_Client = name;
            this.Email = email;
            this.STK = stk;
            this.Balance = ba;
        }
        public Client(DataRow row)
        {
            this.id = (int)row["ID"];
            this.flag = (int)row["flag"];
            this.Name_Client = row["Name_Client"].ToString();
            this.Email = row["Email"].ToString();
            this.STK = row["STK"].ToString();
            (this.Balance) = (int)row["Balance"];
            this.LoaiNH = row["LoaiNH"].ToString();
            this.Pass = row["Pass"].ToString();
            (this.Gender) = (int)row["Gender"];
            this.IMG = row["IMG"].ToString();
            this.Pass = row["Pass"].ToString();



        }
        public Client(int id, string name, string pass, int gender, DateTime ngsinh, string email, string loainh, int ba, string img)
        {
            this.Id = id;
            this.Name_Client = name;
            this.Pass = pass;
            this.Gender = gender;
            this.Email = email;
            this.LoaiNH = loainh;
            this.NgSinh = ngsinh;
            this.Balance = ba;
            this.IMG = img;
        }

        public Client(string name_Client, string pass, string sTK, int gender, DateTime ngSinh, string email, string loaiNH, int balance, string iMG) : this(name_Client, pass, sTK, gender)
        {
            NgSinh = ngSinh;
            Email = email;
            LoaiNH = loaiNH;
            Balance = balance;
            IMG = iMG;
        }

        public Client(string name_Client, string pass, string sTK, int gender, DateTime ngSinh, string email, string loaiNH, int balance, string iMG, int id, int flag) : this(name_Client, pass, sTK, gender, ngSinh, email, loaiNH, balance, iMG)
        {
            Id = id;
            this.flag = flag;
        }
        public string FormatWithCommas(int value)
        {
            // Định dạng số có dấu phân cách
            string formattedValue = value.ToString("#,##0");

            return formattedValue;
        }

        private int id;
        public string Name_Client { get; set; }
        public string Pass { get; set; }
        public string STK { get; set; }
        public int Gender { get; set; }
        public DateTime NgSinh { get; set; }
        public string Email { get; set; }
        public string LoaiNH { get; set; }
        public int Balance { get; set; }
        public string IMG { get; set; }
        public int Id { get => id; set => id = value; }
        public int getID() { return id; }
        public int flag { get; set; }
    }
}
