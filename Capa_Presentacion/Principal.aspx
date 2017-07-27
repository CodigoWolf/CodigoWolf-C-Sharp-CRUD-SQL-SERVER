<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="Capa_Presentacion.Principal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
    <title>Principal</title>
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/v/bs/dt-1.10.15/datatables.min.css" />
</head>
<body>
    <div class="container">
        <div class="row">
            <div class="col-sm-10">
                <h1 class="text-center">Bienvenido <asp:Label ID="lblUsuario" runat="server" Text=""></asp:Label></h1>                
            </div>
            <div class="col-sm-2">
                <form runat="server" method="POST">
                <asp:Button ID="btnCerrarSesion" type="button" class="btn btn-info" runat="server" Text="Cerrar Sesión" OnClick="btnCerrarSesion_Click" />
                </form>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <!-- Modal -->
                <form id="frmRegistrar" class="form-horizontal" action="" method="POST">
                <div class="modal fade" id="modalregistrar" tabindex="-1" role="dialog" aria-labelledby="modalregistrarLabel">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                <h4 class="modal-title" id="modalregistrarLabel">Registrar Anime</h4>
                            </div>
                            <div class="modal-body">
                                
                                    <input type="hidden" id="idanime" name="idanime" value=""/>
                                    <input type="hidden" id="opcion" name="opcion" value="registrar"/>

                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"
                                            for="nombre">
                                            Nombre</label>
                                        <div class="col-sm-10">
                                            <input id="nombre" name="nombre" type="text" class="form-control"/>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"
                                            for="sinopsis">
                                            Sinopsis</label>
                                        <div class="col-sm-10">
                                            <input id="sinopsis" name="sinopsis" type="text" class="form-control"/>
                                        </div>
                                    </div>
                                    <!-- Combo Género -->
							        <div class="form-group">
								         <label  class="col-sm-2 control-label"
                              		        for="sinopsis">Género</label>
								        <div class="col-sm-10">
									        <select id="idgenero" name="idgenero" class="form-control">
                                              <option value="0">Seleccionar</option>
                                              <option value="1">Psicológico</option>
                                              <option value="2">Artes Marciales</option>
                                              <option value="3">Aventura</option>                                    
                                            </select>
								        </div>
							        </div>
							
                            </div>

                            <div class="modal-footer">
                                <button type="submit" id="registrar-anime" class="btn btn-primary" data-dismiss="modal">Guardar</button>
                                <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                            </div>
                        </div>
                    </div>
                </div>
                </form>
            </div>
        </div>
        <div class="row">
            <div class="col sm-12">
                <!--<button type="button" id="boton" class="btn btn-primary">Test Anime</button>-->
                <button type="button" id="modalanime" data-target='#modalregistrar' data-toggle='modal'  class="btn btn-success">Agregar Anime</button>
            </div>
            <br />
            <div class="col-sm-12">
                <table id="dtanime" class="table table-hover">
                    <thead>
                        <th>ID</th>
                        <th>Anime</th>
                        <th>Sinopsis</th>
                        <th>idgenero</th>
                        <th>Genero</th>
                        <th></th>
                        <th></th>
                    </thead>
                </table>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-6">
                <p class="mensaje"></p>
            </div>
        </div>
    </div>


    <!-- Latest jQuery minified -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/v/bs/dt-1.10.15/datatables.min.js"></script>
    <script src="public/js/anime.js"></script>
</body>
</html>
