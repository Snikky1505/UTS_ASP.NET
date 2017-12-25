<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="JenisBuku.aspx.cs" Inherits="Konteks_JenisBuku" %>

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
                    <strong>-Data Buku-</strong>
                    </h2>
                    <hr class="divider mx-auto"/>
                    <table class="m-md-auto" border="1">
                        <tr>
                            <td>Cari Jenis Buku</td>
                            <td>&nbsp;:&nbsp;</td>
                            <td>
                                &nbsp;<asp:TextBox ID="CariData" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:GridView ID="gvJenis" runat="server" Width="370px" HorizontalAlign="Center" AllowPaging="True" AutoGenerateColumns="False" EmptyDataText="Grid Tidak Ada" PageSize="5" CellPadding="4" ForeColor="#333333" GridLines="None">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:CommandField SelectText="Pilih" ShowSelectButton="True" />
                                        <asp:BoundField DataField="PKdJenis" HeaderText="Kode Jenis" />
                                        <asp:BoundField DataField="PNmJenis" HeaderText="Nama Jenis" />
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
                            <td>Kode Jenis</td>
                            <td>&nbsp;:&nbsp;</td>
                            <td>
                                &nbsp;<asp:TextBox ID="KdJenis" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator0" runat="server" ControlToValidate="KdJenis" ErrorMessage="Kode Tidak Boleh Kosong" ValidationGroup="JNS"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>Nama Jenis</td>
                            <td>&nbsp;:&nbsp;</td>
                            <td>
                                &nbsp;<asp:TextBox ID="NmJenis" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="NmJenis" ErrorMessage="Jenis Tidak Boleh Kosong" ValidationGroup="JNS"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" class="m-md-auto">
                                <asp:Button id="btnSimpan" text="Simpan" runat="server" width="100px" OnClick="btnSimpan_Click"/>
                                <asp:Button id="btnUbah" text="Ubah" runat="server" width="100px" OnClick="btnUbah_Click"/>
                                <asp:Button id="btnHapus" text="Hapus" runat="server" width="100px" OnClick="btnHapus_Click"/>
                                <asp:Button id="btnBatal" text="Batal" runat="server" width="100px" OnClick="btnBatal_Click"/>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
</asp:Content>

