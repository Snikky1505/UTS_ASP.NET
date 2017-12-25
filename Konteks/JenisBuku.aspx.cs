using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class Konteks_JenisBuku : System.Web.UI.Page
{
    clsJBuku _JBuku = new clsJBuku();
    private void BindGrid()
    {
        gvJenis.DataSource =
            _JBuku.TampilData(CariData.Text);
        gvJenis.SelectedIndex = -1;
        gvJenis.DataBind();
    }
    private void bersih()
    {
        KdJenis.Text = "";
        NmJenis.Text = "";
        CariData.Text = "";
        NmJenis.Focus();
        BindGrid();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {

            NmJenis.Focus();
            bersih();
            KdJenis.Text = _JBuku.autonumber();
        }
    }
    protected void btnSimpan_Click(object sender, EventArgs e)
    {
        try
        {
            int _hasil;
            _JBuku.PKdJenis = KdJenis.Text;
            _JBuku.PNmJenis = NmJenis.Text;
            _hasil = _JBuku.simpan();
            if (_hasil == 1)
            {
                string pesan = "alert(\"Data Behasil Disimpan\");";
                ScriptManager.RegisterStartupScript
                    (this, GetType(), "SIMPAN DATA", pesan, true);
                bersih();
                KdJenis.Text = _JBuku.autonumber();
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
            int _hasil;
            _JBuku.PKdJenis = KdJenis.Text;
            _JBuku.PNmJenis = NmJenis.Text;
            _hasil = _JBuku.ubah();
            if (_hasil == 1)
            {
                string pesan = "alert(\"Data Behasil Diubah\");";
                ScriptManager.RegisterStartupScript
                    (this, GetType(), "UBAH DATA", pesan, true);
                bersih();
                KdJenis.Text = _JBuku.autonumber();
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
            _JBuku.PKdJenis = KdJenis.Text;
            _hasil = _JBuku.hapus();
            if (_hasil == 1)
            {
                string pesan = "alert(\"Data Behasil Dihapus\");";
                ScriptManager.RegisterStartupScript
                    (this, GetType(), "HAPUS DATA", pesan, true);
                bersih();
                KdJenis.Text = _JBuku.autonumber();
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
        KdJenis.Text = _JBuku.autonumber();
    }
    protected void CariData_TextChanged(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void gvJenis_SelectedIndexChanged(object sender, EventArgs e)
    {
        KdJenis.Text = gvJenis.SelectedRow.Cells[1].Text.ToString();
        NmJenis.Text = gvJenis.SelectedRow.Cells[2].Text.ToString();

    }

    protected void gvJenis_PageIndexChanging(object sender,
        GridViewPageEventArgs e)
    {
        gvJenis.PageIndex = e.NewPageIndex;
        gvJenis.DataSource = _JBuku.TampilData("");
        gvJenis.DataBind();
        gvJenis.SelectedIndex = -1;
    }




}