<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="npall.aspx.cs" Inherits="ControlVehicularF4.NoProgramada.npall" %>

<!DOCTYPE html>

<html style="" class=" js flexbox flexboxlegacy canvas canvastext webgl touch geolocation postmessage websqldatabase indexeddb hashchange history draganddrop websockets rgba hsla multiplebgs backgroundsize borderimage borderradius boxshadow textshadow opacity cssanimations csscolumns cssgradients cssreflections csstransforms no-csstransforms3d csstransitions fontface no-generatedcontent video audio localstorage sessionstorage webworkers applicationcache svg inlinesvg smil svgclippaths">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width">
    <title>Agendar Unidad No Programda</title>
    <link href="/Content/bootstrap.css" rel="stylesheet">
    <link href="/Content/site.css" rel="stylesheet">

    <script src="/Scripts/modernizr-2.6.2.js"></script>



</head>


<body style="">
    <form id="form1" runat="server">

        <div class="navbar navbar-default navbar-fixed-top">
            <div class="container">
                <div class="navbar-header">
                    <a href="/Home/Index" class="navbar-brand">Revista Vehicular</a>
                    <button class="navbar-toggle" type="button" data-toggle="collapse" data-target="#navbar-main">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                </div>

                <div class="navbar-collapse collapse" id="navbar-main">
                    <ul class="nav navbar-nav">

                        <li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown" href="#" id="14">Revista <span class="caret"></span></a>
                            <ul class="dropdown-menu" aria-labelledby="14">
                                <li><a href="/Revistas/Ejecutor/EjecucionRevista"><i class="fa fa-list-ul fa-fw"></i>Ejecución </a></li>
                                <li><a href="/Revistas/Ejecutor/Programacion"><i class="fa fa-list-ul fa-fw"></i>Avances </a></li>
                                <li><a href="/Revistas/Ejecutor/CapturaRevista"><i class="fa fa-list-ul fa-fw"></i>Captura </a></li>
                            </ul>
                        </li>
                        <li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown" href="#" id="15">Consultas <span class="caret"></span></a>
                            <ul class="dropdown-menu" aria-labelledby="15">
                                <li><a href="/Revistas/Consultas/ConsultaRevistas"><i class="fa fa-list-ul fa-fw"></i>Revistas </a></li>
                                <li><a href="/Revistas/Consultas/ConsultaResumen"><i class="fa fa-list-ul fa-fw"></i>Resumen Revistas </a></li>
                                <li><a href="/Revistas/Consultas/ConsultaResumenEjecutores"><i class="fa fa-list-ul fa-fw"></i>Resumen Ejecutores </a></li>
                            </ul>
                        </li>
                    </ul>

                    <ul class="nav navbar-nav navbar-right">
                        <li><a href="/">Cerrar Sesión</a></li>
                    </ul>

                </div>
            </div>
        </div>

        <div id="body" class="container body-content">

            <section class="content-wrapper main-content clear-fix">

                <link href="/Content/DataTable/jquery-ui.css" rel="stylesheet" type="text/css" media="screen">
                <link href="/Content/DataTable/dataTables.jqueryui.min.css" rel="stylesheet" type="text/css" media="screen">
                <link href="/Content/DataTable/DatatTableGrouping.css" rel="stylesheet" type="text/css" media="screen">
                <link href="/Content/bootstrap-toggle.min.css" rel="stylesheet" type="text/css" media="screen">
                <link href="/Content/ControlVehicular/Revista.css" rel="stylesheet" type="text/css" media="screen">
                <link href="/Content/chosen.css" rel="stylesheet" type="text/css" media="screen">
                <link href="/Content/bootstrap-datetimepicker.min.css" rel="stylesheet" type="text/css" media="screen">
                <link href="/Content/ControlVehicular/signature-pad.css" rel="stylesheet" type="text/css" media="screen">

                <link href="/Content/Select2/select2.css" rel="stylesheet" type="text/css" media="screen">
                <link href="/Content/select2-bootstrap.css" rel="stylesheet" type="text/css" media="screen">
                <style>
                    .toggle.ios, .toggle-on.ios, .toggle-off.ios {
                        border-radius: 20px;
                    }

                        .toggle.ios .toggle-handle {
                            border-radius: 20px;
                        }

                    .wizard {
                        margin: 10px auto;
                        background: #fff;
                    }

                        .wizard .nav-tabs {
                            position: relative;
                            margin: 10px auto;
                            margin-bottom: 0;
                            border-bottom-color: #e0e0e0;
                        }

                        .wizard > div.wizard-inner {
                            position: relative;
                        }

                    .connecting-line {
                        height: 2px;
                        background: #e0e0e0;
                        position: absolute;
                        width: 80%;
                        margin: 0 auto;
                        left: 0;
                        right: 0;
                        top: 50%;
                        z-index: 1;
                    }

                    .wizard .nav-tabs > li.active > a, .wizard .nav-tabs > li.active > a:hover, .wizard .nav-tabs > li.active > a:focus {
                        color: #555555;
                        cursor: default;
                        border: 0;
                        border-bottom-color: transparent;
                    }

                    span.round-tab {
                        width: 70px;
                        height: 70px;
                        line-height: 70px;
                        display: inline-block;
                        border-radius: 100px;
                        background: #fff;
                        border: 2px solid #e0e0e0;
                        z-index: 2;
                        position: absolute;
                        left: 0;
                        text-align: center;
                        font-size: 25px;
                    }

                        span.round-tab i {
                            color: #555555;
                        }

                    .wizard li.active span.round-tab {
                        background: #fff;
                        border: 2px solid #5bc0de;
                    }

                        .wizard li.active span.round-tab i {
                            color: #5bc0de;
                        }

                    span.round-tab:hover {
                        color: #333;
                        border: 2px solid #333;
                    }

                    .wizard .nav-tabs > li {
                        width: 20%;
                    }

                    .wizard li:after {
                        content: " ";
                        position: absolute;
                        left: 46%;
                        opacity: 0;
                        margin: 0 auto;
                        bottom: 0px;
                        border: 5px solid transparent;
                        border-bottom-color: #5bc0de;
                        transition: 0.1s ease-in-out;
                    }

                    .wizard li.active:after {
                        content: " ";
                        position: absolute;
                        left: 46%;
                        opacity: 1;
                        margin: 0 auto;
                        bottom: 0px;
                        border: 10px solid transparent;
                        border-bottom-color: #5bc0de;
                    }

                    .wizard .nav-tabs > li a {
                        width: 70px;
                        height: 70px;
                        margin: 20px auto;
                        border-radius: 100%;
                        padding: 0;
                    }

                        .wizard .nav-tabs > li a:hover {
                            background: transparent;
                        }

                    .wizard .tab-pane {
                        position: relative;
                        padding-top: 2x;
                    }

                    .wizard h3 {
                        margin-top: 0;
                    }

                    /*media( max-width : 585px ) {*/

                    .wizard {
                        width: 100%;
                        height: auto !important;
                    }

                    span.round-tab {
                        font-size: 16px;
                        width: 50px;
                        height: 50px;
                        line-height: 50px;
                    }

                    .wizard .nav-tabs > li a {
                        width: 50px;
                        height: 50px;
                        line-height: 50px;
                    }

                    .wizard li.active:after {
                        content: " ";
                        position: absolute;
                        left: 35%;
                    }

                    .no-js #loader {
                        display: none;
                    }

                    .js #loader {
                        display: block;
                        position: absolute;
                        left: 100px;
                        top: 0;
                    }

                    .se-pre-con {
                        position: fixed;
                        left: 0px;
                        top: 0px;
                        width: 100%;
                        height: 100%;
                        z-index: 9999;
                        background: url(../Images/loadingRubic.gif) center no-repeat #fff;
                    }

                    .se-text {
                        position: absolute;
                        left: 47%;
                        top: 54%;
                        z-index: 9999;
                    }
                </style>

                <h4>
                    <span class="label label-default">PROGRAMAR REVISTA INDIVIUAL VEHICULO</span>
                </h4>

                <div class="wizard">

                    <form role="form">
                        <div class="tab-content">

                            <div class="row" style="text-align: center;">
                                <div class="col-sm-6">
                                    <span id="spnUnidad"></span>
                                </div>
                                <div class="col-sm-6">
                                    <span id="spnPeriodo"></span>
                                </div>
                            </div>
                            <div class="row" style="text-align: center;">
                                <div class="col-sm-6">
                                </div>
                                <div class="col-sm-6">
                                    <span id="spnFin"></span>
                                </div>
                            </div>
                            <div class="col-lg-11">
                                <div class="panel panel-default">
                                    <div class="panel-heading h4 text-primary text-center">
                                        PROGRAMACION REVISTA POR ESTACION Y ESTATUS
                                    </div>
                                    <div class="panel-body">
                                        <div class="form-horizontal" role="form">

                                            <div class="form-group">

                                                <label class="col-sm-2 col-lg-2 control-label" for="cmbEstatus">ESTATUS</label>
                                                <div class=" col-sm-4 col-lg-4">
                                                    <asp:DropDownList ID="cmbEstatus" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="cmbEstatus_SelectedIndexChanged" />
                                                    <%--<asp:DropDownList ID="cmbUnidades" runat="server" CssClass="form-control" />--%>
                                                    <%--<asp:TextBox class="form-control" ID="txtConductor" placeholder="Contrato ID" runat="server"></asp:TextBox>--%>
                                                </div>
                                            </div>

                                            <div class="form-group">

                                                <label class="col-sm-2 col-lg-2 control-label" for="cmbEstacion">ESTACION</label>
                                                <div class=" col-sm-4 col-lg-4">
                                                    <asp:DropDownList ID="cmbEstacion" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="cmbEstacion_SelectedIndexChanged" />
                                                    <%--<asp:DropDownList ID="cmbUnidades" runat="server" CssClass="form-control" />--%>
                                                    <%--<asp:TextBox class="form-control" ID="txtConductor" placeholder="Contrato ID" runat="server"></asp:TextBox>--%>
                                                </div>
                                            </div>




                                            <div class="form-group">

                                                <label class="col-sm-2 control-label" for="txtUbicacion">Fecha</label>
                                                <div class="col-sm-2 col-md-4 col-lg-4">


                                                    <div class='input-group date' id='date1' runat="server">
                                                        <input type='text' runat="server" id="dtp" class="form-control" />
                                                        <span class="input-group-addon">
                                                            <span class="glyphicon glyphicon-calendar"></span>
                                                        </span>

                                                    </div>
                                                </div>
                                            </div>




                                            <asp:GridView ID="gvUnidades" runat="server" HeaderStyle-BackColor="#003399" HeaderStyle-ForeColor="White"
                                                AutoGenerateColumns="false">
                                                <HeaderStyle BackColor="#003399" Height="26px" />
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <%--<asp:CheckBox ID="chkRow" runat="server" onclick="CheckAll(this)" />--%>
                                                            <input id="chkall" type="checkbox" onclick="CheckAll(this)" runat="server"    />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkRow" runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="unidad_id" HeaderText="ID" ItemStyle-Width="150">
                                                        <ItemStyle Width="150px"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="NumeroEconomico" HeaderText="NE" ItemStyle-Width="150">
                                                        <ItemStyle Width="150px"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Descripcion" HeaderText="DESCRIPCION" ItemStyle-Width="150">
                                                        <ItemStyle Width="150px"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Anio" HeaderText="AÑO" ItemStyle-Width="150">
                                                        <ItemStyle Width="150px"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Kilometraje" HeaderText="KM" ItemStyle-Width="150">
                                                        <ItemStyle Width="150px"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Placas" HeaderText="PLACAS" ItemStyle-Width="150">
                                                        <ItemStyle Width="150px"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="NumeroSerie" HeaderText="SERIE" ItemStyle-Width="150">
                                                        <ItemStyle Width="150px"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="NumeroSerieMotor" HeaderText="MOTOR" ItemStyle-Width="150">

                                                        <ItemStyle Width="150px"></ItemStyle>
                                                    </asp:BoundField>

                                                    <%-- <asp:TemplateField HeaderText="Country" ItemStyle-Width="150">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCountry" runat="server" Text='<%# Eval("Country") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                </Columns>
                                            </asp:GridView>
                                            <br />
                                            <div class=" col-sm-2 col-lg-2">
                                                <asp:Button CssClass="btn btn-success" ID="btnGrabar" runat="server" Text="Grabar"></asp:Button>
                                            </div>
                                            <%--<asp:Button ID="btnGetSelected" runat="server" Text="Get selected records" OnClick="GetSelectedRecords" />--%>
                                            
                                             
                                            <div class="form-group">
                                                <div class="col-sm-offset-2 col-sm-10 col-lg-12">
                                                    <asp:Label CssClass="label label-danger" ID="lblmsg" runat="server" Visible="false"></asp:Label>
                                                </div>
                                            </div>
                                        </div>






                                    </div>
                                </div>
                            </div>
                        </div>




                        <button id="next1" type="button" class="btn btn-warning btn-lg next-step" style="visibility: hidden;"><i class="glyphicon glyphicon-arrow-right"></i></button>

                        <div class="clearfix"></div>
                    </form>
                </div>

            </section>
        </div>



        <!-- Modal Evidencia -->
        <div class="modal fade" id="modalEvidencia" role="dialog">
            <div class="modal-dialog modal-lg" style="z-index: 3500;">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">×</button>
                        <h4 class="modal-title">Agregar Evidencia</h4>
                    </div>
                    <div class="modal-body">

                        <div class="row">
                            <div class="col-sm-12">


                                <div id="divInCarrusel">
                                </div>

                            </div>
                        </div>

                        <br>
                        <br>

                        <div class="row">
                            <div class="col-sm-12" style="background-color: darkgray">
                                <div class="fileinput fileinput-new" data-provides="fileinput">
                                    <span class="btn btn-default btn-file">
                                        <i class="glyphicon glyphicon-picture"></i><span>Capturar</span>
                                        <input type="file" id="snapshot" value="Capture Imagen" class="btn btn-success" accept="image/*" capture="">
                                    </span>
                                    <span class="fileinput-filename"></span><span class="fileinput-new">Sin imagen</span>
                                    <a id="arfSaveFile" class="btn btn-success" onclick="saveFile();"><i class="glyphicon glyphicon-arrow-up"></i>Cargar </a>
                                </div>
                            </div>
                        </div>

                        <div id="divMsjEvidencia">
                        </div>

                        <div class="modal-footer">
                            <a id="lnCancelar" class="btn btn-warning" data-dismiss="modal"><i class="glyphicon glyphicon-remove"></i>Cerrar </a>
                        </div>


                    </div>
                </div>
            </div>
        </div>


        <!-- Modal Firma -->
        <div class="modal fade" id="modalFirma" role="dialog">
            <div class="modal-dialog modal-lg" style="z-index: 3500;">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">×</button>
                        <h4 class="modal-title">Agregar Firma</h4>
                    </div>
                    <div class="modal-body">


                        <div id="signature-pad" class="m-signature-pad">
                            <div class="m-signature-pad--body">
                                <canvas id="newSignature" width="549" height="512" onresize="loadFirma();"></canvas>
                            </div>
                            <div class="m-signature-pad--footer">
                                <div class="description">Firma del Conductor</div>
                                <button type="button" class="button clear btn btn-default" data-action="clear" onclick="resizeCanvas();"><i class="glyphicon glyphicon-erase"></i>Iniciar</button>
                                <button type="button" class="button save btn btn-success" onclick="saveFirma()"><i class="glyphicon glyphicon-floppy-disk"></i>Guardar</button>
                            </div>
                        </div>

                    </div>

                    <div class="modal-footer">
                        <a id="lnCancelar" class="btn btn-warning" data-dismiss="modal"><i class="glyphicon glyphicon-remove"></i>Cerrar </a>
                    </div>

                </div>
            </div>
        </div>


        <!-- Modal Mensaje -->
        <div class="modal fade" id="modalMensaje" role="dialog">
            <div class="modal-dialog modal-md" style="z-index: 3500;">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">×</button>
                        <h4 class="modal-title">Información</h4>
                    </div>
                    <div class="modal-body">
                        <div class="alert alert-warning" role="alert">
                            <div id="divMsj">
                                Unidad sin Revista Asignada.
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>



        <!-- Modal Mensaje -->
        <div class="modal fade" id="modalMensajeTanqueGas" role="dialog">
            <div class="modal-dialog modal-md" style="z-index: 3500;">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">×</button>
                        <h4 class="modal-title">Información</h4>
                    </div>
                    <div class="modal-body">
                        <div class="alert alert-warning" role="alert">
                            <img width="500" src="/Images/etiquetaserie.JPG">
                            <div id="divMsj">
                                Serie Tanque de Gas no concuerda con el capturado para esta unidad.
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>



        <!-- Modal Mensaje -->
        <div class="modal fade" id="modalParo" role="dialog">
            <div class="modal-dialog modal-md" style="z-index: 3500;">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" onclick="cancelaParoMotor();">×</button>
                        <h4 class="modal-title">Confirmación Paro de Motor</h4>
                    </div>
                    <div class="modal-body">
                        <div class="alert alert-danger" role="alert">
                            <div>
                                <h4>¿Esta Seguro de Solicitar Paro de Motor?.</h4>
                                <p>Se enviará Correo Electronico al area de monitoreo para solicitar paro de motor.</p>

                                <br>
                                <h5><strong>Mensaje:</strong></h5>
                                <textarea id="txtComentarioParo" class="form-control" style="width: 100%; height: 100%;"></textarea>
                            </div>
                        </div>
                    </div>

                    <div class="modal-footer">
                        <a id="lnGuardarParo" onclick="envioParoMotor();" class="btn btn-success" data-dismiss="modal"><i class="glyphicon glyphicon-envelope"></i>Solicitar </a>
                        <a id="lnCancelarParo" onclick="cancelaParoMotor();" class="btn btn-warning" data-dismiss="modal"><i class="glyphicon glyphicon-remove"></i>Cancelar </a>
                    </div>

                </div>
            </div>
        </div>


        <div>
            <div class="se-pre-con" style="display: none;"></div>
            <div class="se-text" style="display: none;">Procesando...</div>
        </div>







        <hr>
        <footer style="text-align: center;">
            <img src="/Content/Images/copasa_logo.png" height="50" width="75">
            <p>© 2018 - Copasa</p>
        </footer>



        <script src="/Scripts/jquery-1.10.2.js"></script>
        <script src="/Scripts/jquery-2.1.4.js"></script>

        <script src="/Scripts/bootstrap.js"></script>
        <script src="/Scripts/respond.js"></script>

        <script src="/Scripts/jquery.flexnav.min.js" type="text/javascript"></script>

        <script type="text/javascript">

            $(document).ready(function () {
                $(".flexnav").flexNav({ 'animationSpeed': 'fast' });
            });
        </script>




        <script src="/Scripts/jquery.dataTables.min.js"></script>

        <script src="/Scripts/dataTables.jqueryui.min.js"></script>

        <script src="/Scripts/jquery.dataTables.rowGrouping.js"></script>

        <script src="/Scripts/bootstrap-toggle.min.js"></script>

        <script src="/Scripts/chosen.jquery.js"></script>

        <script src="/Scripts/jasny-bootstrap.js"></script>

        <script src="/Scripts/bootstrap-datetimepicker.js"></script>

        <script src="/Scripts/locales/bootstrap-datetimepicker.fr.js"></script>

        <script src="/Scripts/GeneralesJS/signature.js"></script>

        <script src="/Scripts/GeneralesJS/signature_pad.js"></script>

        <script src="/Scripts/GeneralesJS/app.js"></script>

        <script src="/Content/Select2/select2.js"></script>













        <script type="text/javascript">
            function CheckAll(oCheckbox) {
                var gvUnidadesx = document.getElementById("<%=gvUnidades.ClientID %>");
                for (i = 1; i < gvUnidadesx.rows.length; i++) {
                    gvUnidadesx.rows[i].cells[0].getElementsByTagName("INPUT")[0].checked = oCheckbox.checked;
                }
            }


            $('#date1').datetimepicker({ format: 'yyyy-mm-dd', autoclose: true });


            var inputImageFile = $("#snapshot");
            var valUsuario_id = "revista.piloto";

            var rutaConsulta = "/Ejecutor/ObtienePlantillaUnidad";
            var revistaUnidades_ID;
            var revistaUnidadesDetalle_ID;
            var spanCantidadEvidencia;
            var Estatus_ID;
            var FechaActual = new Date().toISOString().substring(0, 10);



            $(document).ready(function () {

                $('.form_date').datetimepicker({
                    language: 'es',
                    setStartDate: FechaActual,
                    todayBtn: 1,
                    autoclose: 1,
                    todayHighlight: 1,
                    startView: 2,
                    minView: 2,
                    forceParse: 0
                });
                $('.form_date').datetimepicker('setStartDate', FechaActual);

                limpiarControlesNextPrev();
                inicializaWizard();
                //reloadChosen('cmbUnidades');
                $("#cmbUnidades").select2();
                $('.select2-container').width($('#KilometrajeManto').width());

                reloadChosen('cmbEstaciones');
                desHabilitaRevista(true);
                //Oculta el boton de finalizar
                $("#finalizar").css("visibility", "hidden");
                $("#btnMuestraFirma").css("visibility", "hidden");

                //Asingna eventos para guardar informacion
                $("#cmbUnidades").change(function () {
                    if (conexionInternet()) {
                        readaccionesOffline();
                    } else {
                        return false;
                    }
                    showLoading();
                    obtieneInformacionRevista();
                    verBotonesNext();
                    hideLoading();
                });





                //  var _serieTanque = $('#hdntxtTanque').val();
                //  if (_serieTanque.length != 0) {
                $("#txtSerieTanque").change(function () {
                    //Aqui llamo a guardar datos de Revista
                    actualizarRevistaUnidadMaestro(this);
                    verBotonesNext();
                });

                //            }




                $("#cmbEstaciones").change(function () {
                    //Aqui llamo a guardar datos de Revista
                    actualizarRevistaUnidadMaestro(this);
                    verBotonesNext();
                });
                $("#Kilometraje").blur(function () {
                    //Aqui llamo a guardar datos de Revista
                    actualizarRevistaUnidadMaestro(this);
                    verBotonesNext();
                });
                $("#Taximetro").blur(function () {
                    //Aqui llamo a guardar datos de Revista
                    actualizarRevistaUnidadMaestro(this);
                    verBotonesNext();
                });
                $("#NombreConductorDiferente").blur(function () {
                    //Aqui llamo a guardar datos de Revista
                    actualizarRevistaUnidadMaestro(this);
                    verBotonesNext();
                });

                //Asingna eventos para guardar informacion
                $("#snapshot").change(function () {
                    limpiarFileSave();
                });

            });

            $(window).load(function () {
                hideLoading();
            });

            function showLoading() {
                $(".se-pre-con").fadeIn("slow");
                $(".se-text").fadeIn("slow");
            }
            function hideLoading() {
                $(".se-pre-con").fadeOut("slow");
                $(".se-text").fadeOut("slow");
            }




            function verBotonesNext() {
                if ($("#cmbUnidades").val() != "-1") {
                    $("#next1").css("visibility", "");
                    $("#prev2").css("visibility", "");
                } else {
                    $("#next1").css("visibility", "hidden");
                    $("#prev2").css("visibility", "hidden");
                }

                if (validarDatosMaestroSinMsj()) {
                    $("#prev2").css("visibility", "");
                    $("#next2").css("visibility", "");
                    $("#prev3").css("visibility", "");
                } else {
                    $("#next2").css("visibility", "hidden");
                    $("#prev3").css("visibility", "hidden");
                    $("#next3").css("visibility", "hidden");
                    $("#prev4").css("visibility", "hidden");
                }

                if ($("#finalizar").css('visibility') === "visible") {
                    $("#prev3").css("visibility", "");
                    $("#next3").css("visibility", "hidden");
                    $("#prev4").css("visibility", "hidden");
                } else {
                    $("#next3").css("visibility", "");
                    $("#prev4").css("visibility", "");
                }
            }

            function limpiarControlesNextPrev() {
                $("#next1").css("visibility", "hidden");
                $("#next2").css("visibility", "hidden");
                $("#next3").css("visibility", "hidden");
                $("#prev2").css("visibility", "hidden");
                $("#prev3").css("visibility", "hidden");
                $("#prev4").css("visibility", "hidden");
                //$("li[role='presentation']").addClass('disabled');
                $("#liRevista").addClass('disabled');
                $("#liPuntos").addClass('disabled');
                $("#liEvaluacion").addClass('disabled');
            }




            function limpiarFileSave() {
                if ($("#snapshot").val().length > 0) {
                    $("#arfSaveFile").css('visibility', 'visible');
                } else {
                    $("#arfSaveFile").css('visibility', 'hidden');
                }
                $("#divMsjEvidencia").html('');
            }


            function inicializaWizard() {
                //Initialize tooltips
                $('.nav-tabs > li a[title]').tooltip();

                //Wizard
                $('a[data-toggle="tab"]').on('show.bs.tab', function (e) {
                    var $target = $(e.target);
                    if ($target.parent().hasClass('disabled')) {
                        return false;
                    }
                });

                $(".next-step").click(function (e) {
                    var $active = $('.wizard .nav-tabs li.active');
                    $active.next().removeClass('disabled');
                    nextTab($active);
                });

                $(".prev-step").click(function (e) {
                    var $active = $('.wizard .nav-tabs li.active');
                    prevTab($active);
                });
            }
            function nextTab(elem) {
                $(elem).next().find('a[data-toggle="tab"]').click();
                $('#RevistaDataTable').DataTable().columns.adjust();
                $('#tableEjecuccion').DataTable().columns.adjust();
            }
            function prevTab(elem) {
                $(elem).prev().find('a[data-toggle="tab"]').click();
                $('#RevistaDataTable').DataTable().columns.adjust();
                $('#tableEjecuccion').DataTable().columns.adjust();
            }

            function GrabarX() {

                alert("Prueba");
                // document.getElementById("cmdGrabar").click();
                $("#cmdGrabar").click;
            }



        </script>




        <div class="datetimepicker datetimepicker-dropdown-bottom-right dropdown-menu" style="left: 0px; z-index: 10009;">
            <div class="datetimepicker-minutes" style="display: none;">
                <table class=" table-condensed">
                    <thead>
                        <tr>
                            <th class="prev" style="visibility: hidden;"><span class="glyphicon glyphicon-arrow-left"></span></th>
                            <th colspan="5" class="switch">23 April 2018</th>
                            <th class="next" style="visibility: visible;"><span class="glyphicon glyphicon-arrow-right"></span></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td colspan="7"><span class="minute">15:00</span><span class="minute">15:05</span><span class="minute">15:10</span><span class="minute">15:15</span><span class="minute">15:20</span><span class="minute active">15:25</span><span class="minute">15:30</span><span class="minute">15:35</span><span class="minute">15:40</span><span class="minute">15:45</span><span class="minute">15:50</span><span class="minute">15:55</span></td>
                        </tr>
                    </tbody>
                    <tfoot>
                        <tr>
                            <th colspan="7" class="today">Today</th>
                        </tr>
                        <tr>
                            <th colspan="7" class="clear" style="display: none;">Clear</th>
                        </tr>
                    </tfoot>
                </table>
            </div>
            <div class="datetimepicker-hours" style="display: none;">
                <table class=" table-condensed">
                    <thead>
                        <tr>
                            <th class="prev" style="visibility: hidden;"><span class="glyphicon glyphicon-arrow-left"></span></th>
                            <th colspan="5" class="switch">23 April 2018</th>
                            <th class="next" style="visibility: visible;"><span class="glyphicon glyphicon-arrow-right"></span></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td colspan="7"><span class="hour">0:00</span><span class="hour">1:00</span><span class="hour">2:00</span><span class="hour">3:00</span><span class="hour">4:00</span><span class="hour">5:00</span><span class="hour">6:00</span><span class="hour">7:00</span><span class="hour">8:00</span><span class="hour">9:00</span><span class="hour">10:00</span><span class="hour">11:00</span><span class="hour">12:00</span><span class="hour">13:00</span><span class="hour">14:00</span><span class="hour active">15:00</span><span class="hour">16:00</span><span class="hour">17:00</span><span class="hour">18:00</span><span class="hour">19:00</span><span class="hour">20:00</span><span class="hour">21:00</span><span class="hour">22:00</span><span class="hour">23:00</span></td>
                        </tr>
                    </tbody>
                    <tfoot>
                        <tr>
                            <th colspan="7" class="today">Today</th>
                        </tr>
                        <tr>
                            <th colspan="7" class="clear" style="display: none;">Clear</th>
                        </tr>
                    </tfoot>
                </table>
            </div>
            <div class="datetimepicker-days" style="display: block;">
                <table class=" table-condensed">
                    <thead>
                        <tr>
                            <th class="prev" style="visibility: hidden;"><span class="glyphicon glyphicon-arrow-left"></span></th>
                            <th colspan="5" class="switch">April 2018</th>
                            <th class="next" style="visibility: visible;"><span class="glyphicon glyphicon-arrow-right"></span></th>
                        </tr>
                        <tr>
                            <th class="dow">Su</th>
                            <th class="dow">Mo</th>
                            <th class="dow">Tu</th>
                            <th class="dow">We</th>
                            <th class="dow">Th</th>
                            <th class="dow">Fr</th>
                            <th class="dow">Sa</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td class="day old disabled">25</td>
                            <td class="day old disabled">26</td>
                            <td class="day old disabled">27</td>
                            <td class="day old disabled">28</td>
                            <td class="day old disabled">29</td>
                            <td class="day old disabled">30</td>
                            <td class="day old disabled">31</td>
                        </tr>
                        <tr>
                            <td class="day disabled">1</td>
                            <td class="day disabled">2</td>
                            <td class="day disabled">3</td>
                            <td class="day disabled">4</td>
                            <td class="day disabled">5</td>
                            <td class="day disabled">6</td>
                            <td class="day disabled">7</td>
                        </tr>
                        <tr>
                            <td class="day disabled">8</td>
                            <td class="day disabled">9</td>
                            <td class="day disabled">10</td>
                            <td class="day disabled">11</td>
                            <td class="day disabled">12</td>
                            <td class="day disabled">13</td>
                            <td class="day disabled">14</td>
                        </tr>
                        <tr>
                            <td class="day disabled">15</td>
                            <td class="day disabled">16</td>
                            <td class="day disabled">17</td>
                            <td class="day disabled">18</td>
                            <td class="day disabled">19</td>
                            <td class="day disabled">20</td>
                            <td class="day disabled">21</td>
                        </tr>
                        <tr>
                            <td class="day disabled">22</td>
                            <td class="day today active">23</td>
                            <td class="day">24</td>
                            <td class="day">25</td>
                            <td class="day">26</td>
                            <td class="day">27</td>
                            <td class="day">28</td>
                        </tr>
                        <tr>
                            <td class="day">29</td>
                            <td class="day">30</td>
                            <td class="day new">1</td>
                            <td class="day new">2</td>
                            <td class="day new">3</td>
                            <td class="day new">4</td>
                            <td class="day new">5</td>
                        </tr>
                    </tbody>
                    <tfoot>
                        <tr>
                            <th colspan="7" class="today">Today</th>
                        </tr>
                        <tr>
                            <th colspan="7" class="clear" style="display: none;">Clear</th>
                        </tr>
                    </tfoot>
                </table>
            </div>
            <div class="datetimepicker-months" style="display: none;">
                <table class="table-condensed">
                    <thead>
                        <tr>
                            <th class="prev" style="visibility: hidden;"><span class="glyphicon glyphicon-arrow-left disabled"></span></th>
                            <th colspan="5" class="switch">2018</th>
                            <th class="next" style="visibility: visible;"><span class="glyphicon glyphicon-arrow-right disabled"></span></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td colspan="7"><span class="month disabled">Jan</span><span class="month">Feb</span><span class="month">Mar</span><span class="month active">Apr</span><span class="month">May</span><span class="month">Jun</span><span class="month">Jul</span><span class="month">Aug</span><span class="month">Sep</span><span class="month">Oct</span><span class="month">Nov</span><span class="month">Dec</span></td>
                        </tr>
                    </tbody>
                    <tfoot>
                        <tr>
                            <th colspan="7" class="today">Today</th>
                        </tr>
                        <tr>
                            <th colspan="7" class="clear" style="display: none;">Clear</th>
                        </tr>
                    </tfoot>
                </table>
            </div>
            <div class="datetimepicker-years" style="display: none;">
                <table class="table-condensed">
                    <thead>
                        <tr>
                            <th class="prev" style="visibility: hidden;"><span class="glyphicon glyphicon-arrow-left"></span></th>
                            <th colspan="5" class="switch">2010-2019</th>
                            <th class="next" style="visibility: visible;"><span class="glyphicon glyphicon-arrow-right"></span></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td colspan="7"><span class="year old disabled">2009</span><span class="year disabled">2010</span><span class="year disabled">2011</span><span class="year disabled">2012</span><span class="year disabled">2013</span><span class="year disabled">2014</span><span class="year disabled">2015</span><span class="year disabled">2016</span><span class="year disabled">2017</span><span class="year active">2018</span><span class="year">2019</span><span class="year old">2020</span></td>
                        </tr>
                    </tbody>
                    <tfoot>
                        <tr>
                            <th colspan="7" class="today">Today</th>
                        </tr>
                        <tr>
                            <th colspan="7" class="clear" style="display: none;">Clear</th>
                        </tr>
                    </tfoot>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
