using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Collections.Generic;

public class clsJBuku
{
    public string FKdJenis;
    public string FNmJenis;
    public string StrConn =
        WebConfigurationManager.ConnectionStrings["UTS_Online"].ConnectionString;
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

    public string PNmJenis
    {
        get
        {
            return FNmJenis;
        }

        set
        {
            FNmJenis = value;
        }
    }

    public int simpan()
    {
        using (SqlConnection conn = new SqlConnection(StrConn))
        {
            String Query =
       "INSERT INTO Jenis(KdJenis,NmJenis)" +
       "VALUES(@1,@2);";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@1", FKdJenis);
            cmd.Parameters.AddWithValue("@2", FNmJenis);
            int Hasil = 0;
            conn.Open();
            Hasil = cmd.ExecuteNonQuery();
            return Hasil;

        }
    }

    //note untuk nikko, coba ini diliat ko, ini udah bener begini belum? emang harus banget dia nampilin kode jenis disitu 0001JBK?
    //kalo misal di db udah ada datanya, dia nanti apakah akan tetep nampilin 0001JBK ?
    public string autonumber()
    {
        using (SqlConnection conn = new SqlConnection(StrConn))
        {
            string NilaiAwal, NilaiAsli, NilaiAuto;
            int NilaiTambah;
            string Query = "SELECT KdJenis FROM Jenis ORDER BY KdJenis DESC";
            SqlCommand cmd = new SqlCommand(Query, conn);
            SqlDataReader reader;
            conn.Open();
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                NilaiAsli = reader["KdJenis"].ToString();
                NilaiTambah = System.Convert.ToInt32(NilaiAsli.Substring(0, 4)) + 1;
                NilaiAwal = System.Convert.ToString(NilaiTambah);
                NilaiAuto = "0001" + "JBK".Substring(NilaiAwal.Length) + NilaiAwal;
            }
            else
            { NilaiAuto = "0001JBK"; }
            return NilaiAuto;
        }
    }

    public int hapus()
    {
        using (SqlConnection conn = new SqlConnection(StrConn))
        {
            string Query = "DELETE FROM Jenis WHERE KdJenis=@1";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@1", PKdJenis);
            int Hasil = 0;
            conn.Open();
            Hasil = cmd.ExecuteNonQuery();
            return Hasil;

        }
    }

    public int ubah()
    {
        using (SqlConnection conn = new SqlConnection(StrConn))
        {
            string Query =
               "UPDATE Jenis SET NmJenis=@1 WHERE KdJenis=@2";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@1", PNmJenis);
            cmd.Parameters.AddWithValue("@2", PKdJenis);
            int Hasil = 0;
            conn.Open();
            Hasil = cmd.ExecuteNonQuery();
            return Hasil;

        }
    }

    public List<clsJBuku> TampilData()
    {
        using (SqlConnection conn = new SqlConnection(StrConn))
        {
            string Query = "SELECT * FROM Jenis;";
            List<clsJBuku> tmpBaca = new List<clsJBuku>();
            SqlCommand cmd = new SqlCommand(Query, conn);

            SqlDataReader reader;
            conn.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    clsJBuku objTemp = new clsJBuku();
                    objTemp.FKdJenis = reader["KdJenis"].ToString();
                    objTemp.FNmJenis = reader["NmJenis"].ToString();
                    tmpBaca.Add(objTemp);
                }
            }
            return tmpBaca;
        }
    }

    public List<clsJBuku> TampilData(string xNmJenis)
    {
        using (SqlConnection conn = new SqlConnection(StrConn))
        {
            string Query = "SELECT*FROM Jenis WHERE NmJenis LIKE '%" + xNmJenis + "%'";
            List<clsJBuku> tmpBaca = new List<clsJBuku>();
            SqlCommand cmd = new SqlCommand(Query, conn);

            SqlDataReader reader;
            conn.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    clsJBuku objTemp = new clsJBuku();
                    objTemp.FKdJenis = reader["KdJenis"].ToString();
                    objTemp.FNmJenis = reader["NmJenis"].ToString();
                    tmpBaca.Add(objTemp);
                }
            }
            return tmpBaca;
        }
    }


}