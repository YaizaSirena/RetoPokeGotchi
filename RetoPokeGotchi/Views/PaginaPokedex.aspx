<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="Pokedex.aspx.cs" Inherits="RetoPokeGotchi.Views.WebForm1" %>

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
	<body style="background-image: url('https://localhost:44331/JPG/686182.jpg'); vertical-align: inherit; background-repeat: repeat-x;">
    
		<form id="form1" runat="server">
			   <div class="container"> <br /><br /><br /><br />
			

				   <div class="row">
						<div class="col-md-5 offset-md-4">
							<asp:Label ID="labelBienvenida" runat="server" Text="Bienvenid@ a tu Pokédex" BorderStyle="Outset" ForeColor="#660066" BackColor="White"></asp:Label> 
						</div>
					</div><br />

					<div class="row">
						<div class="col-md-5 offset-md-4">
							<asp:Label ID="labelPeticion" runat="server" Text="Escribe el nombre del Pokémon que quieras capturar" BorderStyle="Outset" ForeColor="#660066" BackColor="White"></asp:Label> 
						</div>
					</div><br />
			
					<div class="row">
						<div class="col-md-6 offset-md-4" >
							<asp:TextBox ID="textPedirPokemon" runat="server"></asp:TextBox>
                            <asp:Button ID="butCapturar" runat="server" Text="Capturar" OnClick="butCapturar_Click"/>
						</div>
					</div><br />
	
				   <div class="row">
						<div class="col-md-5 offset-md-4"  >
                            <asp:Label ID="labelPokedex" runat="server" Text="Éstos son tus Pokémons" BorderStyle="Outset" ForeColor="#660066" BackColor="White"></asp:Label> 
						</div>
					</div>
				   <br />
					<div class="row">
						<div class="col-md-5 offset-md-4"  >
                            <asp:ListBox ID="listPokemons" runat="server" Width="496px"></asp:ListBox>
                            <asp:Button ID="butRecolectar" runat="server" Text="Recolectar" />
                            <asp:Button ID="butJugar" runat="server" Text="Jugar" />
						</div>
					</div>
				</div>
		    
		</form>
	</body>
</html>
