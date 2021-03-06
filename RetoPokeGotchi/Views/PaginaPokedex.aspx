<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="PaginaPokedex.aspx.cs" Inherits="RetoPokeGotchi.Views.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
				<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/css/bootstrap.min.css"/>
				<script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
				<script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" ></script>
				<script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/js/bootstrap.min.js"></script>
				<script src="https://kit.fontawesome.com/a385db07c8.js"></script>
			
			<title>Pokegotchi:Pokédex</title>
</head>
	<body style="background-image: url('https://localhost:44331/JPG/21778-pikachu.jpg'); vertical-align: inherit; background-repeat: repeat-x;">
    
		<form id="form1" runat="server">
			   <div class="container"> <br /><br /><br /><br />
			

				   <div class="row">
						<div class="col-md-5 offset-md-2">
							<asp:Label ID="labelBienvenida" runat="server" Text="Bienvenid@ a tu Pokédex" BorderStyle="Outset" ForeColor="#660066" BackColor="White"></asp:Label> 
						</div>
					</div><br />

					<div class="row">
						<div class="col-md-5 offset-md-2">
							<asp:Label ID="labelPeticion" runat="server" Text="Escribe el nombre del Pokémon que quieras capturar" BorderStyle="Outset" ForeColor="#660066" BackColor="White"></asp:Label> 
						</div>
					</div><br />
			
					<div class="row">
						<div class="col-md-6 offset-md-2" >
							<asp:TextBox ID="textPedirPokemon" runat="server"></asp:TextBox>
                            <asp:Button ID="butCapturar" runat="server" Text="Capturar" OnClick="butCapturar_Click"/>
                            						</div>
					</div><br />
	
				   <div class="row">
						<div class="col-md-5 offset-md-2"  >
                            <asp:Label ID="labelPokedex" runat="server" Text="Éstos son tus Pokémons" BorderStyle="Outset" ForeColor="#660066" BackColor="White"></asp:Label> 
						</div>
					</div>
				   <br />
					<div class="row">
						<div class="col-md-5 offset-md-2"  >
							<asp:ScriptManager ID="ScriptManager1" runat="server" />
							<asp:UpdatePanel ID="UpdatePanel1" runat="server">
							<ContentTemplate>
								<asp:ListBox ID="listPokemons"  runat="server" Width="648px" Rows="10" OnSelectedIndexChanged="listPokemons_SelectedIndexChanged" AutoPostBack="True"></asp:ListBox>
								<asp:Button ID="butRecolectar" runat="server" Text="Recolectar" OnClick="butRecolectar_Click" />
								<asp:Button ID="butJugar" runat="server" Text="Jugar" OnClick="butJugar_Click" />
							</ContentTemplate>
							</asp:UpdatePanel>
						</div>
						<div class="col-md-3 offset-md-2">
							<asp:UpdatePanel ID="UpdatePanel2" runat="server">
								<ContentTemplate>
									<asp:Image ID="Image1" runat="server" Height="211px" Width="248px" />
								</ContentTemplate>
							</asp:UpdatePanel>
						</div>
					</div>
				</div>
		    
		</form>
	</body>
</html>
