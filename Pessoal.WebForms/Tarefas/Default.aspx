<%@ Page Title="Tarefas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Pessoal.WebForms.Tarefas.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <h1>Tarefas</h1>

    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="Create">Nova Tarefa</asp:LinkButton>
    <hr />
    <asp:GridView runat="server" DataSourceID="tarefasObjectDataSource" Width="100%" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="Nome" HeaderText="Nome" />
            <asp:BoundField DataField="Prioridade" HeaderText="Prioridade" />
            <asp:CheckBoxField DataField="Concluida" HeaderText="Concluída" />
            <asp:BoundField DataField="Observacoes" HeaderText="Observações" />
        </Columns>
    </asp:GridView>

    <asp:ObjectDataSource runat="server" ID="tarefasObjectDataSource" SelectMethod="Selecionar" TypeName="Pessoal.Repositorio.SqlServer.TarefaRepositorio" />

</asp:Content>
