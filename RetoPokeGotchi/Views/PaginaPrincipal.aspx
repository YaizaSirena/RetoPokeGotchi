<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="PaginaPrincipal.aspx.cs" Inherits="RetoPokeGotchi.Views.PaginaPrincipal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
				<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
				<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/css/bootstrap.min.css"/>
				<script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
				<script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" ></script>
				<script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/js/bootstrap.min.js"></script>
				<script src="https://kit.fontawesome.com/a385db07c8.js"></script>
			
			<title>Pokedotchi:Principal</title>
		</head>
<body style="background-image: url('https://localhost:44331/JPG/519728.jpg')">
    <form id="form1" runat="server">
        <div class="container"> 
			<br /><br /><br /><br />
			<div class="row">
				<div class="col-md-3 offset-md-5">
                    <asp:TextBox ID="textNombre" runat="server"></asp:TextBox>
				</div>
			</div>
			<br />
			<div class="row">
				<div class="col-md-6 offset-md-5" >
                    <asp:Button ID="butCargarPartida" runat="server" Text="Cargar Partida" CssClass="btn-light focus" OnClick="butCargarPartida_Click" />
				</div>
			</div>
			<br />
			<div class="row">
				<div class="col-md-5 offset-md-5"  >
                 <asp:Button ID="butNuevaPartida" runat="server" Text="Nueva Partida" CssClass="btn-light focus" OnClick="butNuevaPartida_Click" />
				</div>
			</div>
		</div>
    </form>
</body>
</html>
