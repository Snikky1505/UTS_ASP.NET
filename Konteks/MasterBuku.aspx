<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MasterBuku.aspx.cs" Inherits="Konteks_MasterBuku" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="header2" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentutama" Runat="Server">
            <div class="container">
                <div class="bg-faded p-4 my-4">
                    <div class="container">
                        <div id="splash">
                            <div class="container-fluid">
                                <asp:AdRotator runat="server" Width="980px" Height="300px" DataSourceID="Banner_Source"/>
                                <asp:XmlDataSource ID="Banner_Source" runat="server" DataFile="~/XML_Banner.xml"></asp:XmlDataSource>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="bg-faded p-4 my-4">
                    <hr class="divider mx-auto" />
                    <h2 class="text-center text-lg text-uppercase my-0">Snikky's Book Store<br />
                    <strong>-Data Master-</strong>
                    </h2>
                    <hr class="divider mx-auto"/>
                    <table class="m-md-auto" border="1">
                        <tr>
                            <td>Cari Judul Buku</td>
                            <td>&nbsp;:&nbsp;</td>
                            <td>
                                &nbsp;<asp:TextBox ID="CariData" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:GridView ID="gvBuku" runat="server" Height="80px" Width="371px" HorizontalAlign="Center" AllowPaging="True" 
                                    AutoGenerateColumns="False" CellPadding="4" EmptyDataText="Data Buku Tidak Ada" 
                                    ForeColor="#333333" GridLines="None" PageSize="5"
                                    DataKeyNames="PKdBuku, PJudul, PHarga, PStock, PGambar, PKdJenis" 
                                    OnSelectedIndexChanged="gvBuku_SelectedIndexChanged">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:ImageField DataImageUrlField="PGambar" DataImageUrlFormatString="~/Gambar/Upload/{0}" HeaderText="Gambar">
                                            <ControlStyle Height="100px" Width="100px" />
                                        </asp:ImageField>
                                        <asp:BoundField DataField="PJudul" HeaderText="Judul" />
                                        <asp:BoundField DataField="PHarga" HeaderText="Harga" />
                                        <asp:BoundField DataField="PStock" HeaderText="Stock" />
                                        <asp:CommandField SelectText="Pilih" ShowSelectButton="True" />
                                    </Columns>
                                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                                    <SortedDescendingHeaderStyle BackColor="#820000" />
                                </asp:GridView>
                                
                            </td>
                        </tr>
                        <tr>
                            <td>Jenis Buku</td>
                            <td>&nbsp;:&nbsp;</td>
                            <td>
                                &nbsp;<asp:DropDownList ID="ddJenis" runat="server" AppendDataBoundItems="true">
                                    <asp:ListItem Text="- Tidak ada data Jenis -"  Value=""></asp:ListItem>
                                      </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Kode Buku</td>
                            <td>&nbsp;:&nbsp;</td>
                            <td>
                                &nbsp;<asp:TextBox ID="KdBuku" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="KdBuku" ErrorMessage="Tidak Boleh Kosong" ValidationGroup="BKU"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>Judul</td>
                            <td>&nbsp;:&nbsp;</td>
                            <td>
                                &nbsp;<asp:TextBox ID="Judul" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Judul" ErrorMessage="Tidak Boleh Kosong" ValidationGroup="BKU"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>Pengarang</td>
                            <td>&nbsp;:&nbsp;</td>
                            <td>
                                &nbsp;<asp:TextBox ID="Pengarang" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Pengarang" ErrorMessage="Tidak Boleh Kosong" ValidationGroup="BKU"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>Harga</td>
                            <td>&nbsp;:&nbsp;</td>
                            <td>
                                &nbsp;<asp:TextBox ID="Harga" runat="server" MaxLength="7"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Harga" Display="Dynamic" ErrorMessage="Tidak Boleh Kosong" ValidationGroup="BKU"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Harga" ErrorMessage="Masukkan Angka maksimal 7 digit" ValidationExpression="^[0-9]{1,7}$" ValidationGroup="BKU"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>Stock</td>
                            <td>&nbsp;:&nbsp;</td>
                            <td>
                                &nbsp;<asp:TextBox ID="Stok" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic" ErrorMessage="Tidak Boleh Kosong" ValidationGroup="BKU" ControlToValidate="Stok"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="Stok" Display="Dynamic" ErrorMessage="Masukkan angka maksimal 3 digit" ValidationExpression="^[0-9]{1,3}$ " ValidationGroup="BKU"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>Gambar</td>
                            <td>&nbsp;:&nbsp;</td>
                            <td>
                                &nbsp;<asp:FileUpload ID="FUGbr" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:Button Text="SIMPAN" id="btnSimpan" runat="server" OnClick="btnSimpan_Click" Width="100px"></asp:Button>&nbsp;
                                <asp:Button Text="UBAH" id="btnUbah" runat="server" OnClick="btnUbah_Click" Width="100px"></asp:Button>&nbsp;
                                <asp:Button Text="HAPUS" id="btnHapus" runat="server" OnClick="btnHapus_Click" Width="100px"></asp:Button>
                                <asp:Button Text="BATAL" id="btnBatal" runat="server" OnClick="btnBatal_Click" Width="100px"></asp:Button>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
</asp:Content>

