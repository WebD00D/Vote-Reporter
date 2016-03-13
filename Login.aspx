<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="VoteReporterNEW.Skeleton" %>

<!DOCTYPE html>
<html lang="en">

<head>

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="IRC's Vote Reporter Application">
    <meta name="author" content="International Roll Call">

    <title>IRC's Vote Reporter</title>

    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom CSS -->
    <link href="css/landing-page.css" rel="stylesheet">

    <!-- Custom Fonts -->
    <link href="font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
    <link href="http://fonts.googleapis.com/css?family=Lato:300,400,700,300italic,400italic,700italic" rel="stylesheet" type="text/css">

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->

</head>

<body>

    <!-- Navigation -->
    <nav class="navbar navbar-default navbar-fixed-top" role="navigation">
        <div class="container">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header">
              <%--  <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>--%>
                <a class="navbar-brand" href="#">International Roll Call</a>
            </div>
            <!-- Collect the nav links, forms, and other content for toggling -->
           <%-- <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <ul class="nav navbar-nav navbar-right">
                    <li>
                        <a href="#">Link 1</a>
                    </li>
                    <li>
                        <a href="#">Link 2</a>
                    </li>
                    <li>
                        <a href="#">Link 3</a>
                    </li>
                </ul>
            </div>--%>
            <!-- /.navbar-collapse -->
        </div>
        <!-- /.container -->
    </nav>
     <form id="NETForm" runat="server">
    <!-- Header -->
    <div class="intro-header"  style="background-color:rgba(255,255,255,0.5)">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">


                     <div class="intro-message" style="padding-top:70px">
                       
                        <h1>Vote Reporter</h1>
                        <h3>by International Roll Call</h3>
                            <div class="col-lg-4 col-lg-offset-4">
                        <h5 style="color:#ffffff" class="text-left">Username</h5>
                        <asp:textbox runat="server" ID="txtUsername" CssClass="form-control"></asp:textbox>
                        <h5 style="color:#ffffff" class="text-left">Password</h5>
                        <asp:textbox runat="server" TextMode="Password" ID="txtPassword" CssClass="form-control"></asp:textbox>
                       
                        <br />
                        <asp:Button runat="server" ID="btnLogin" CssClass="btn btn-lg btn-danger btn-block hidden" Text="Login" />
                        <a href="#" id="btnLogin2" class="btn btn-lg btn-danger btn-block">Login</a>
                          <br />
                            <asp:Label runat="server" ForeColor="#ff0000" ID="lblError"></asp:Label>
                        </div>
                      </div>
                  


                </div>
            </div>
        </div>
        <!-- /.container -->
    </div>
    <!-- /.intro-header -->
         </form>

    <!-- Page Content -->



    <!-- Footer -->
    <footer class="text-center">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <ul class="list-inline">
                        <li>
                            <a href="http://www.roll-call.com">IRC Home</a>
                        </li>
                        
                       
                        <li class="footer-menu-divider">&sdot;</li>
                        <li>
                            <a href="IRCLogin.aspx">Developers</a>
                        </li>
                    </ul>
                    <p class="copyright text-muted small">Copyright &copy; International Roll Call <%=Date.Today.Year%>. All Rights Reserved</p>
                </div>
            </div>
        </div>
    </footer>

    <!-- jQuery -->
    <script src="js/jquery.js"></script>
    <!-- Bootstrap Core JavaScript -->
    <script src="js/bootstrap.min.js"></script>
    <script>

        $(document).ready(function () {

  


            $("#btnLogin2").click(function () {

                $("#btnLogin2").text("Loading Settings...");
                //check user, set base class data, and if successful direct to main screen.
                $.ajax({
                    type: "POST",
                    url: "Engine.asmx/ValidateUser",
                    data: "{Username:'" + $("#<%=txtUsername.ClientID%>").val() + "',Password:'" + $("#<%=txtPassword.ClientID%>").val() + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        var result = data.d;


                   

                        if (result) {
                            window.location.href="Default.aspx"
                        } else {

                        }


                    },
                    failure: function (msg) {
                        alert(msg);
                    },
                    error: function (err) {
                        alert(err);
                    }
                }) //end ajax
            })

          
        })

    </script>
</body>
</html>

