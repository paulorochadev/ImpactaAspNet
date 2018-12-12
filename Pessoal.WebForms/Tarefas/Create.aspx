<%@ page title="" language="C#" masterpagefile="~/Site.Master" autoeventwireup="true" codebehind="Create.aspx.cs" inherits="Pessoal.WebForms.Tarefas.Create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Nova Tarefa</h1>
    <hr />

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />

    <table>
        <tr>
            <td style="width: 124px">Nome</td>
            <td>
                <asp:TextBox ID="nomeTextBox" runat="server"></asp:TextBox></td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ErrorMessage="Nome é Obrigatório !" CssClass="text-danger" ControlToValidate="nomeTextBox">(!)</asp:RequiredFieldValidator>
        </tr>
        <tr>
            <td style="width: 124px">Prioridade</td>
            <td>
                <asp:DropDownList ID="prioridadeDropDownList" DataSourceID="prioridadesObjectDataSource" AppendDataBoundItems="true" runat="server">
                    <asp:ListItem Text="Selecione" Value="0" />
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ErrorMessage="Selecione a Prioridade" CssClass="text-danger" ControlToValidate="prioridadeDropDownList" InitialValue="0">(!)</asp:RequiredFieldValidator>
                <asp:ObjectDataSource ID="prioridadesObjectDataSource" runat="server" SelectMethod="ObterPrioridades" TypeName="Pessoal.WebForms.Tarefas.Create"></asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td style="width: 124px">Concluida</td>
            <td>
                <asp:CheckBox Text="" ID="concluidaCheckBox" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 124px">Observações</td>
            <td>
                <asp:TextBox TextMode="MultiLine" ID="observacoesTextBox" Rows="5" runat="server" />
            </td>
        </tr>
    </table>
    <asp:Button Text="Gravar" ID="gravarButton" runat="server" OnClick="gravarButton_Click" />
</asp:Content>
