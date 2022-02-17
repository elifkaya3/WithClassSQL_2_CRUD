using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithClassSQL_2_CRUD
{
    class VeriTabani
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter adaptor;
        string sorguCumlesi;
        DataTable dt;

        //ilk olarak bir veri tbanı bağlantısı yahpacak metod hazırlayın
        public SqlConnection Baglan()
        {

            string baglantiCumlesi = @"Server=DESKTOP-8M7D7GE\SQLEXPRESS; Database=sHastane; User=sa; Pwd=123";
            baglanti = new SqlConnection(baglantiCumlesi);

            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            //ctrl+K+D tabları hizalar
            return baglanti;
        }
        public void Kapat()
        {
            if (baglanti.State != ConnectionState.Closed)
            {
                baglanti.Close();
            }
        }
        public DataTable HastalariGetir()
        {
            sorguCumlesi = $"SELECT * FROM tblHastalar";
            adaptor = new SqlDataAdapter(sorguCumlesi, Baglan());
            dt = new DataTable();
            adaptor.Fill(dt);
            return dt;
        }
        public void Ekle(string TcNo, string Ad, string Soyad, string Cinsiyet, string Adres, string Telefon, string Mail)
        {
            sorguCumlesi = $"INSERT INTO tblHastalar VALUES('{Ad}','{Soyad}','{TcNo}','{Cinsiyet}','{Adres}','{Telefon}','{Mail}')";
            komut = new SqlCommand(sorguCumlesi, Baglan());
            komut.ExecuteNonQuery();
            Kapat();
        }
        public void Duzelt(string TcNo, string Ad, string Soyad, string Cinsiyet, string Adres, string Telefon, string Mail, string ID)
        {
            sorguCumlesi = $"UPDATE tblHastalar SET TcNo='{TcNo}', Ad='{Ad}', Soyad='{Soyad}', Cinsiyet='{Cinsiyet}', Adres='{Adres},'Telefon='{Telefon}',Mail='{Mail}',ID='{ID}'";
            komut = new SqlCommand(sorguCumlesi, Baglan());
            komut.ExecuteNonQuery();
            Kapat();
        }
        private void Sil(string TcNo, string Ad, string Soyad, string Cinsiyet, string Adres, string Telefon, string Mail, string ID)
        {
            sorguCumlesi = $"DELETE tblHastalar WHERE TcNo='{TcNo}', Ad='{Ad}', Soyad='{Soyad}', Cinsiyet='{Cinsiyet}', Adres='{Adres},'Telefon='{Telefon}',Mail='{Mail}',ID='{ID}'";
            komut = new SqlCommand(sorguCumlesi, Baglan());
            komut.ExecuteNonQuery();
            Kapat();
        }
        public bool KontrolEt(params string[] e)
        {
            bool donus = false;
            foreach (var item in e)
            {
                if (item=="")
                {
                    donus = false;
                    break;
                }
            }
            return donus;
        }
    }
}
