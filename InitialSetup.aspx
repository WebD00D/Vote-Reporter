<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="InitialSetup.aspx.vb" Inherits="VoteReporterNEW.InitialSetup" %>

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
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="#">International Roll Call</a>
            </div>
            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <ul class="nav navbar-nav navbar-right">
                    <li>
                        <a href="Login.aspx">Main Login</a>
                    </li>
                    
                </ul>
            </div>
            <!-- /.navbar-collapse -->
        </div>
        <!-- /.container -->
    </nav>

    <!-- Header -->
    <div class="ContentArea">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <h1>Initial Setup</h1>
                    <hr />

                    <div class="col-lg-4 col-lg-offset-4 text-left">
                        <form runat="server" id="NETForm">
                            <h3 class="text-center">Vote Reporter Database </h3>
                            <h4 style="color:#093d62">Name</h4>
                             <asp:TextBox runat="server" ID="txtVRDBName"  CssClass="form-control"></asp:TextBox>
                            <h4 style="color:#093d62">Server</h4>
                            <asp:TextBox runat="server" ID="txtVRDBServer" CssClass="form-control"></asp:TextBox>
                             <h4 style="color:#093d62">User ID</h4>
                            <asp:TextBox runat="server" ID="txtVRDBUser" CssClass="form-control"></asp:TextBox>
                               <h4 style="color:#093d62">Password</h4>
                            <asp:TextBox runat="server" ID="txtVRDBPassword" CssClass="form-control"></asp:TextBox>

                        <h3 class="text-center">Voting Database </h3>
                             <h4 style="color:#093d62">Name</h4>
                             <asp:TextBox runat="server" ID="txtVoteDBName" CssClass="form-control"></asp:TextBox>
                            <h4 style="color:#093d62">Server</h4>
                            <asp:TextBox runat="server" ID="txtVoteServer" CssClass="form-control"></asp:TextBox>
                              <h4 style="color:#093d62">User ID</h4>
                            <asp:TextBox runat="server" ID="txtVoteUser" CssClass="form-control"></asp:TextBox>
                               <h4 style="color:#093d62">Password</h4>
                            <asp:TextBox runat="server" ID="txtVotePassword" CssClass="form-control"></asp:TextBox>


                            <br />
                            <br />
                            <label style="color:#093d62">Click 'Finish Setup' and login with your IRC credentials.</label>
                            <br />
                            <br />

                        <asp:Button runat="server" ID="btnFinish" CssClass="btn btn-lg btn-danger btn-block" Text="Finish Setup" OnClick="Unnamed5_Click" />

                            <br />
                            <asp:Label runat="server" ID="lblError" ForeColor="#E74C3C"></asp:Label>

                        </form>
                        


                    </div>
                </div>
            </div>
        </div>
        <!-- /.container -->
    </div>
    <!-- /.intro-header -->

   

   

   

    



    <!-- Footer -->
    <footer class="text-center">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <ul class="list-inline">
                        <li>
                            <a href="#home">Home</a>
                        </li>
                        <li class="footer-menu-divider">&sdot;</li>
                        <li>
                            <a href="#about">About</a>
                        </li>
                        <li class="footer-menu-divider">&sdot;</li>
                        <li>
                            <a href="#services">Contact</a>
                        </li>
                        <li class="footer-menu-divider">&sdot;</li>
                        <li>
                            <a href="IRCLogin.aspx">Developers</a>
                        </li>
                    </ul>
                    <p class="copyright text-muted small">Copyright &copy; Your Company 2014. All Rights Reserved</p>
                </div>
            </div>
        </div>
    </footer>

    <!-- jQuery -->
    <script src="js/jquery.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="js/bootstrap.min.js"></script>

</body>

</html>
