<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="header2" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentutama" Runat="Server">
            <div class="container">
                <!-- Data Mahasiswa -->
                <div class="bg-faded p-4 my-4">
                    <hr class="divider mx-auto" />
                    <h2 class="text-center text-lg text-uppercase my-0">Welcome to <br />
                    <strong>Snikky's</strong> Book Store
                    </h2>
                    <hr class="divider mx-auto"/>
                    <table class="m-md-auto">
                        <tr>
                            <td>NIM</td>
                            <td>&nbsp;:&nbsp;</td>
                            <td>1512501170</td>
                        </tr>
                        <tr>
                            <td>Nama</td>
                            <td>&nbsp;:&nbsp;</td>
                            <td>Nikko Handiarto</td>
                        </tr>
                        <tr>
                            <td>Kelompok</td>
                            <td>&nbsp;:&nbsp;</td>
                            <td>SI</td>
                        </tr>
                    </table>
                </div>

                <!-- Iklan -->
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
            </div>
</asp:Content>

