using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Services;
using System.Web.Services.Protocols;

public class clsMBuku
{
    public String FKdBuku;
    public string FJudul;
    public string FPengarang;
    public int FStock;
    public string FKdJenis;
    public string FGambar;
    public string StrConn = WebConfigurationManager.ConnectionStrings["UTS_Online"].ConnectionString;
    public double FHarga;

    public string PKdBuku
    {
        get
        {
            return FKdBuku;
        }

        set
        {
            FKdBuku = value;
        }
    }

    public string PPengarang
    {
        get
        {
            return FPengarang;
        }

        set
        {
            FPengarang = value;
        }
    }

    public int PStock
    {
        get
        {
            return FStock;
        }

        set
        {
            FStock = value;
        }
    }

    public double PHarga
    {
        get
        {
            return FHarga;
        }

        set
        {
            FHarga = value;
        }
    }

    public string PKdJenis
    {
        get
        {
            return FKdJenis;
        }

        set
        {
            FKdJenis = value;
        }
    }

    public string PJudul
    {
        get
        {
            return FJudul;
        }

        set
        {
            FJudul = value;
        }
    }

    public string PGambar
    {
        get
        {
            return FGambar;
        }

        set
        {
            FGambar = value;
        }
    }

    public string autonumber()
    {
        using (SqlConnection conn = new SqlConnection(StrConn))
        {
            string NilaiAwal, NilaiAsli, NilaiAuto;
            int NilaiTambah;
            string Query = "SELECT KdBuku FROM Buku ORDER BY KdBuku DESC";
            SqlCommand cmd = new SqlCommand(Query, conn);
            SqlDataReader reader;
            conn.Open();
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                NilaiAsli = reader["KdBuku"].ToString();
                NilaiTambah = Convert.ToInt32(NilaiAsli.Substring(3, 4)) + 1;
                NilaiAwal = Convert.ToString(NilaiTambah);
                NilaiAuto = "BKU" + "0000".Substring(NilaiAwal.Length) + NilaiAwal;
            }
            else
            { NilaiAuto = "BKU0001"; }
            return NilaiAuto;
        }
    }

    public int Hapus()
    {
        using (SqlConnection conn = new SqlConnection(StrConn))
        {
            string Query = "DELETE FROM Buku WHERE KdBuku=@1";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@1", FKdBuku);
            int Hasil = 0;
            conn.Open();
            Hasil = cmd.ExecuteNonQuery();
            return Hasil;

        }
    }

    public int Simpan()
    {
        using (SqlConnection conn = new SqlConnection(StrConn))
        {
            String Query =
       "INSERT INTO Buku (KdBuku, Judul, Pengarang, Harga, Stock, Gambar, KdJenis) VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7);";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@p1", PKdBuku);
            cmd.Parameters.AddWithValue("@p2", PJudul);
            cmd.Parameters.AddWithValue("@p3", PPengarang);
            cmd.Parameters.AddWithValue("@p4", PHarga);
            cmd.Parameters.AddWithValue("@p5", PStock);
            cmd.Parameters.AddWithValue("@p6", PGambar);
            cmd.Parameters.AddWithValue("@p7", PKdJenis);

            int Hasil = 0;
            conn.Open();
            Hasil = cmd.ExecuteNonQuery();
            return Hasil;

        }
    }

    public List<clsMBuku> TampilData(string xJudul, string xKdBuku)
    {
        using (SqlConnection conn = new SqlConnection(StrConn))
        {
            string Query = "SELECT*FROM Buku WHERE Judul LIKE '%" + xJudul + "%' AND KdBuku='" + xKdBuku + "'";
            List<clsMBuku> tmpBaca = new List<clsMBuku>();
            SqlCommand cmd = new SqlCommand(Query, conn);

            SqlDataReader reader;
            conn.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    clsMBuku objTemp = new clsMBuku();
                    objTemp.FKdJenis = reader["KdJenis"].ToString();
                    objTemp.FKdBuku = reader["KdBuku"].ToString();
                    objTemp.FJudul = reader["Judul"].ToString();
                    objTemp.FPengarang = reader["Pengarang"].ToString();
                    objTemp.FHarga = System.Convert.ToDouble(reader["Harga"]);
                    objTemp.FGambar = reader["Gambar"].ToString();
                    objTemp.FStock = System.Convert.ToInt32(reader["Stock"]);
                    tmpBaca.Add(objTemp);
                }
            }
            return tmpBaca;
        }
    }

    public List<clsMBuku> TampilData()
    {
        using (SqlConnection conn = new SqlConnection(StrConn))
        {
            string Query = "SELECT * FROM Buku;";
            List<clsMBuku> tmpBaca = new List<clsMBuku>();
            SqlCommand cmd = new SqlCommand(Query, conn);

            SqlDataReader reader;
            conn.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    clsMBuku objTemp = new clsMBuku();
                    objTemp.FKdJenis = reader["KdJenis"].ToString();
                    objTemp.FKdBuku = reader["KdBuku"].ToString();
                    objTemp.FJudul = reader["Judul"].ToString();
                    objTemp.FPengarang = reader["Pengarang"].ToString();
                    objTemp.FHarga = System.Convert.ToDouble(reader["Harga"]);
                    objTemp.FGambar = reader["Gambar"].ToString();
                    objTemp.FStock = System.Convert.ToInt32(reader["Stock"]);
                    tmpBaca.Add(objTemp);
                }
            }
            return tmpBaca;
        }
    }

    public int Ubah()
    {
        using (SqlConnection conn = new SqlConnection(StrConn))
        {
            string Query = "";
            SqlCommand cmd;
            if (PGambar != "")
            {
                Query =
               "UPDATE Buku SET Judul=@1, Pengarang=@2, Harga=@3, " +
               "Gambar=@4, Stock=@5, KdJenis=@6 WHERE KdBuku=@7";
                cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@1", PJudul);
                cmd.Parameters.AddWithValue("@2", PPengarang);
                cmd.Parameters.AddWithValue("@3", PHarga);
                cmd.Parameters.AddWithValue("@4", PGambar);
                cmd.Parameters.AddWithValue("@5", PStock);
                cmd.Parameters.AddWithValue("@6", PKdJenis);
                cmd.Parameters.AddWithValue("@7", PKdBuku);
            }
            else
            {
                Query =
               "UPDATE Buku SET Judul=@1, Pengarang=@2, Harga=@3, " +
               "Stock=@4, KdJenis=@5 WHERE KdBuku=@6";
                cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@1", PJudul);
                cmd.Parameters.AddWithValue("@2", PPengarang);
                cmd.Parameters.AddWithValue("@3", PHarga);
                cmd.Parameters.AddWithValue("@4", PStock);
                cmd.Parameters.AddWithValue("@5", PKdJenis);
                cmd.Parameters.AddWithValue("@6", PKdBuku);
            }
            
            
            int Hasil = 0;
            conn.Open();
            Hasil = cmd.ExecuteNonQuery();
            return Hasil;

        }
    }
}