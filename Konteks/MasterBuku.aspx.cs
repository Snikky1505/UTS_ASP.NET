using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Konteks_MasterBuku : System.Web.UI.Page
{
    clsMBuku _MBuku = new clsMBuku();
    clsJBuku _JBuku = new clsJBuku();
    private void BindddJenis()
    {
        
        ddJenis.DataSource = _JBuku.TampilData();
        ddJenis.DataValueField = "PKdJenis";
        ddJenis.DataTextField = "PNmJenis";
        ddJenis.DataBind();
    }
    private void BindGrid()
    {
        gvBuku.DataSource = _MBuku.TampilData(); 
        gvBuku.SelectedIndex = -1;
        gvBuku.DataBind();
        
        
    }
    private void bersih()
    {
        KdBuku.Text = "";
        Judul.Text = "";
        Harga.Text = "";
        Stok.Text = "";
        CariData.Text = "";
        BindddJenis();
        BindGrid();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            Judul.Focus();
            bersih();
            KdBuku.Text = _MBuku.autonumber();
        }
        BindGrid();
    }
    protected void btnSimpan_Click(object sender, EventArgs e)
    {
        
        try
        {
            int _hasil;
            _MBuku.PKdBuku = KdBuku.Text;
            _MBuku.PJudul = Judul.Text;
            _MBuku.PHarga = System.Convert.ToDouble(Harga.Text);
            _MBuku.PPengarang = Pengarang.Text;
            string GbrBuku = "";
            if (FUGbr.HasFile == true)
            {
                GbrBuku = System.IO.Path.GetFileName(FUGbr.PostedFile.FileName);
                FUGbr.SaveAs(Server.MapPath("~/Gambar/Upload/") + GbrBuku);
            }
            _MBuku.PGambar = GbrBuku;
            _MBuku.PStock = System.Convert.ToInt32(Stok.Text);
            _MBuku.PKdJenis = ddJenis.SelectedValue;

            


            _hasil = _MBuku.Simpan();
            if (_hasil == 1)
            {

                string pesan = "alert(\"Data Behasil Disimpan\");";
                ScriptManager.RegisterStartupScript
                    (this, GetType(), "SIMPAN DATA", pesan, true);
                bersih();
                KdBuku.Text = _MBuku.autonumber();
            }
            else
            {
                string pesan = "alert(\"Data Tidak Berhasil Disimpan\");";
                ScriptManager.RegisterStartupScript
                    (this, typeof(string), "SIMPAN DATA", pesan, true);
            }
        }
        catch (Exception ex)
        {
            string errorex = ex.Message;
            string pesan = "alert(\"ERROR LAINNYA;'" + errorex + "\");";
            ScriptManager.RegisterStartupScript
                (this, GetType(), "SIMPAN DATA", pesan, true);
        }

    }
    protected void btnUbah_Click(object sender, EventArgs e)
    {
        try
        {
            _MBuku = new clsMBuku();
            int _hasil;
            _MBuku.PKdBuku = KdBuku.Text;
            _MBuku.PJudul = Judul.Text;
            _MBuku.PHarga = System.Convert.ToDouble(Harga.Text);
            _MBuku.PPengarang = Pengarang.Text;
            string GbrBuku = "";
            if (FUGbr.HasFile == true)
            {
                GbrBuku = System.IO.Path.GetFileName(FUGbr.PostedFile.FileName);
                FUGbr.SaveAs(Server.MapPath("~/Gambar/Upload/") + GbrBuku);
            }
            _MBuku.PGambar = GbrBuku;
            _MBuku.PStock = System.Convert.ToInt32(Stok.Text);
            _MBuku.PKdJenis = ddJenis.SelectedItem.Value.ToString();
            _hasil = _MBuku.Ubah();
            if (_hasil == 1)
            {
                string pesan = "alert(\"Data Behasil Diubah\");";
                ScriptManager.RegisterStartupScript
                    (this, GetType(), "UBAH DATA", pesan, true);
                bersih();
                KdBuku.Text = _MBuku.autonumber();
            }
            else
            {
                string pesan = "alert(\"Data Tidak Berhasil Diubah\");";
                ScriptManager.RegisterStartupScript
                    (this, typeof(string), "UBAH DATA", pesan, true);
            }
        }
        catch (Exception ex)
        {
            string errorex = ex.Message;
            string pesan = "alert(\"ERROR LAINNYA;'" + errorex + "\");";
            ScriptManager.RegisterStartupScript
                (this, GetType(), "UBAH DATA", pesan, true);
        }

    }
    protected void btnHapus_Click(object sender, EventArgs e)
    {
        try
        {
            int _hasil;
            _MBuku.PKdBuku = KdBuku.Text;
            _hasil = _MBuku.Hapus();
            if (_hasil == 1)
            {
                string pesan = "alert(\"Data Behasil Dihapus\");";
                ScriptManager.RegisterStartupScript
                    (this, GetType(), "HAPUS DATA", pesan, true);
                bersih();
                KdBuku.Text = _MBuku.autonumber();
            }
            else
            {
                string pesan = "alert(\"Data Tidak Berhasil Dihapus\");";
                ScriptManager.RegisterStartupScript
                    (this, typeof(string), "HAPUS DATA", pesan, true);
            }
        }
        catch (Exception ex)
        {
            string errorex = ex.Message;
            string pesan = "alert(\"ERROR LAINNYA;'" + errorex + "\");";
            ScriptManager.RegisterStartupScript
                (this, GetType(), "HAPUS DATA", pesan, true);
        }

    }
    protected void btnBatal_Click(object sender, EventArgs e)
    {
        bersih();
        KdBuku.Text = _MBuku.autonumber();
    }
    protected void CariData_TextChanged(object sender, EventArgs e)
    {
        BindGrid();
    }
    protected void ddJenis_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }
    protected void gvBuku_SelectedIndexChanged(object sender, EventArgs e)
    {
        KdBuku.Text = gvBuku.SelectedDataKey["PKdBuku"].ToString();
        ddJenis.SelectedValue = gvBuku.SelectedDataKey["PKdJenis"].ToString();
        Judul.Text = gvBuku.SelectedRow.Cells[1].Text.ToString();
        Harga.Text = gvBuku.SelectedRow.Cells[2].Text.ToString();
        Stok.Text = gvBuku.SelectedRow.Cells[3].Text.ToString();
    }
    protected void gvBuku_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBuku.PageIndex = e.NewPageIndex;
        gvBuku.DataSource = _MBuku.TampilData("", "");
        gvBuku.DataBind();
        gvBuku.SelectedIndex = -1;
        
    }


}