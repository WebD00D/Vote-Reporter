<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="UserManagementEditor.aspx.vb" Inherits="VoteReporterNEW.UserManagementEditor" %>


<!DOCTYPE html>
<html lang="en">

<head>

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="IRC's Vote Reporter Application">
    <meta name="author" content="International Roll Call">
    
  
    <title>IRC's Vote Reporter</title>
    <link rel="icon" href="favicon.ico" />

    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/landing-page.css" rel="stylesheet">
    <link href="font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
    <link href="http://fonts.googleapis.com/css?family=Lato:300,400,700,300italic,400italic,700italic" rel="stylesheet" type="text/css">

</head>
    <body>
        <form id="NETForm" runat="server">
            <nav class="navbar navbar-default navbar-fixed-top" role="navigation">
            <div class="container">
            
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a id="lnkSiteTitle" class="navbar-brand" href="default.aspx"></a>
                </div>
                <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                    <ul class="nav navbar-nav navbar-right">
                        <li>
                            <a href="default.aspx"><i class="fa fa-home"></i> Home</a>
                        </li>
                        <li>
                            <a id="lnk1" href="#"><span id="txtLink1"></span></a>
                        </li>
                        <li>
                            <a id="lnk2" href="#"><span id="txtLink2"></span></a>
                        </li>
                        <li>
                            <a id="lnk3" href="#"><span id="txtLink3"></span></a>
                        </li>
                        <li>
                            <div class="navbar-form navbar-left" role="search">
                                 <div class="input-group margin-bottom-sm">
                                     <span class="input-group-addon">Current Session:</span>

                                     <select id="ddlSessionSelect" class="form-control">
                                       
                                     </select>
                                 </div>
                                    <asp:LinkButton CssClass="btn btn-primary" runat="server" ID="linkLogout" ForeColor="white">Sign out  <i class="fa fa-sign-out fa-1x"></i></asp:LinkButton>
                            </div>
                        </li>
 
                    </ul>
                </div>
                <!-- /.navbar-collapse -->
            </div>
         
        </nav>    <!-- / end navigation -->

              <!-- Header -->
        <div class="ContentArea">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="contentMessage" style="margin-top: 25px">
                            <h1 style="color:#2c3e50">User Management Editor</h1>
                            <h3 style="color:#2c3e50"><span id="lblsessioncode"></span> Session</h3>
                        </div>
                    </div>
                </div>
            </div>
            <!-- /.container -->
        </div>

            
     <div class="container">

                <div class="row">
                    <div class="col-lg-12" style="margin-top:10%">
                   
                    <div class="col-lg-5">
                        <h4>Current Users</h4>
                         <br />
                        <div id="currentUsers"  style="overflow-y:scroll;height:150px" class="list-group">
                           
                        </div>
                        <!-- Button trigger modal -->
                        <button type="button" class="btn btn-info btn-sm" data-toggle="modal" data-target="#myModal">
                         Create New User
                        </button>
                        <br />
                        <br />
                        <h4 runat="server" id="lblSuccess" style="color:green"></h4>

                    </div>

                        <div class="col-lg-7">
                        <h4>User Details</h4>

                       
                        <div class="col-lg-6">
                             <h5>First Name</h5>
                        <input id="txtFirst" class="form-control" />
                        </div>
                              <div class="col-lg-6">
                             <h5>Last Name</h5>
                        <input id="txtLast" class="form-control" />
                        </div>
                       
                            <div class="col-lg-12">
                             <h5>Username</h5>
                        <input id="txtUser" class="form-control" />
                        </div>
                        
                            <div class="col-lg-6">
                             <h5>Type</h5>
                        <asp:DropDownList ID="ddlUserType" runat="server" CssClass="form-control">

                        </asp:DropDownList>
                                <br />
                                <input type="button" id="btnSaveChanges" class="btn btn-primary btn-block btn-sm" value="Save Changes">


                                  <br />
                                  <input type="button" id="btnDeleteUser" class="btn btn-danger btn-block btn-sm" value="Delete User">
                        </div>

                       <div class="col-lg-6">


                       </div>
                          
                        <div class="col-lg-6">
                             <h5>Password</h5>
                        <input id="txtPassword" class="form-control" />
                          <br />
                            <h5>Confirm Password</h5>
                                  <input id="txtConfPassword" class="form-control" />
                                  <br />


                            <small style="font-style:italic">**Leave password fields empty if no change.</small>
                            <input type="hidden" id="person" />
                        </div>
                                <div class="col-lg-6">
                         
                        </div>

                    </div>
                     
                    
                    </div>
                    
                </div>

            </div>
            <!-- /.container -->
            
    <!--New User Modal -->
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="myModalLabel">New User</h4>
                </div>
               
                 
                        <div class="col-lg-6">
                             <h5>First Name</h5>
                        <input id="newFirst" class="form-control" />
                        </div>
                              <div class="col-lg-6">
                             <h5>Last Name</h5>
                        <input id="newLast" class="form-control" />
                        </div>
                       
                            <div class="col-lg-12">
                             <h5>Username</h5>
                        <input id="newUser" class="form-control" />
                        </div>
                        
                            <div class="col-lg-6">
                             <h5>Type</h5>
                        <asp:DropDownList ID="ddlNewType" runat="server" CssClass="form-control">
                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                            <asp:ListItem Value="1">Admin</asp:ListItem>
                            <asp:ListItem Value="2">Standard</asp:ListItem>
                            <asp:ListItem Value="3">Public</asp:ListItem>
                        </asp:DropDownList>
                        </div>

                         <%--   <div class="col-lg-6">
                             <h5>Chamber</h5>
                        <asp:DropDownList ID="ddlNewChamber" runat="server" CssClass="form-control">
                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                            <asp:ListItem Value="1">House</asp:ListItem>
                            <asp:ListItem Value="2">Senate</asp:ListItem>
                            <asp:ListItem Value="3">Other</asp:ListItem>
                        </asp:DropDownList>
                        </div>--%>

                               
                        <div class="col-lg-6">
                             <h5>Password</h5>
                        <input id="txtNewPass" class="form-control" />
                          
                     
                        </div>
                              <div class="col-lg-6">
                             <h5>Confirm Password</h5>
                        <input id="txtConfirmNewPass" class="form-control" />
                        <br />
                      
                        </div>

                  
                <div class="modal-footer">
                    <p id="lblError" style="color:red"></p>
                
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                    <button type="button" id="btnCreateUser" class="btn btn-primary">Save User</button>
                </div>
            </div>
        </div>
    </div>
    <!-- End New User Modal -->

        </form>
    </body>
    
<script src="js/jquery.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script>
        $(document).ready(function () {

            // -----------------BASE PAGE FUNCTIONS START ------------------//


            // 1 ) Get Current Session
            var _CurrentSession = getCurrentSesssion()

            function getCurrentSesssion() {
                // make a call to select the current set session.
                // On success, call loadAllSession()
                var result;
                $.ajax({
                    type: "POST",
                    url: "Engine.asmx/getCurrentSession",
                    data: "{}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        _CurrentSession = data.d;
                        loadAllSessions();
                    }
                })
            }


            function loadAllSessions() {

                $.ajax({
                    type: "POST",
                    url: "Engine.asmx/LoadSessions",
                    data: "{}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        var result = data.d;
                        $.each(result, function (index, item) {
                            var optiontag = "<option id=" + item.sessionID + " value=" + item.sessionID + ">" + item.sessionCode + "</option>";
                            $(optiontag).appendTo("#ddlSessionSelect");

                        })
                        setSessionDropDown();
                    }
                })
            }


            function setSessionDropDown() {
                //after drop down has been set, call setPageLinks()
                $("#ddlSessionSelect").val(_CurrentSession);

                setPageLinks();

            }


            function setPageLinks() {
                $.ajax({ //first call to set nav bar links and titles
                    type: "POST",
                    url: "Engine.asmx/GetBaseVoteReporterData",
                    data: "{}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        var result = data.d;
                        $.each(result, function (index, item) {
                            $("#lnkSiteTitle").text(item.siteTitle);
                            $("#lnk1").attr("href", item.link1URL);
                            $("#txtLink1").text(item.link1Name);
                            $("#lnk2").attr("href", item.link2URL);
                            $("#txtLink2").text(item.link2Name);
                            $("#lnk3").attr("href", item.link3URL);
                            $("#txtLink3").text(item.link3Name);

                            setCurrentSessionName();

                        })
                    }
                }) //end ajax call to set links
            }

            function setCurrentSessionName() {

                $.ajax({
                    type: "POST",
                    url: "Engine.asmx/getCurrentSessionCode",
                    data: "{}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        var result = data.d;
                        $("#lblsessioncode").text(result);
                    }
                })

            }


            $("#ddlSessionSelect").change(function () {
                var session = $("#ddlSessionSelect option:selected").attr("value");

                // when the drop down index changes, we need to make a call to update the base vote reporter class
                // with all new session detail.
                updateSession(session);
            })

            function updateSession(sessionID) {
                $.ajax({
                    type: "POST",
                    url: "Engine.asmx/updateSession",
                    data: "{SessionID:" + sessionID + "}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        var result = data.d;
                        window.location.reload();

                    }
                })
            }



            // -----------------BASE PAGE FUNCTIONS START ------------------//


            // Load All Users
            $.ajax({

                type: "POST",
                url: "WebServices/UserManagementService.asmx/GetAllUsers",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {

                    //take data and append as list item parameters to be selected by user
                    var result = data.d;
                    $("#currentUsers").empty();
                    $.each(result, function (index, item) {

                        var content = "<a href='#' id='" + item.UserID + "'    data-type=" + item.Type + "  data-selected='0' data-username=" + item.UserName + " data-last=" + item.LastName + " data-first=" + item.FirstName + " class='list-group-item userz'>" + item.FirstName + " " + item.LastName + "</a>";
                        $(content).hide().appendTo("#currentUsers").fadeIn();
                    })

                },
                failure: function (msg) {
                    alert(msg);
                },
                error: function (err) {
                    alert(err);
                }
            }) //end ajax 


            $("#currentUsers").delegate(".userz", "click", function (e) {

                if ($(this).data("selected") == 1) {

                    $(this).removeClass('active');
                    $(this).data("selected", 0);

                    $("#txtFirst").val("");
                    $("#txtLast").val("");
                    $("#txtUser").val("");
                    $("#<%=ddlUserType.ClientID%>").val("Default");


                } else {

                    $(".userz").removeClass('active');
                    $(this).addClass('active');
                    $(this).data("selected", 1);
                    $("#person").val($(this).attr('id'));



                    switch ($(this).data("type")) {

                        case 1:
                            //Admin
                            $("#<%=ddlUserType.ClientID%>").val("1");
                            break;
                        case 2:
                            //Standard
                            $("#<%=ddlUserType.ClientID%>").val("2");
                            break;
                        case 3:
                            //Public 
                            $("#<%=ddlUserType.ClientID%>").val("3");
                            break;

                    }



                    $("#txtFirst").val($(this).data("first"));
                    $("#txtLast").val($(this).data("last"));
                    $("#txtUser").val($(this).data("username"));

                }

            })


            //CREATE NEW USER SECTION

            $("#btnCreateUser").click(function () {

                var first = $("#newFirst").val();
                var last = $("#newLast").val();
                var username = $("#newUser").val();
                var pass = $("#txtNewPass").val();
                var confirmpass = $("#txtConfirmNewPass").val();

                var type = $("#<%=ddlNewType.ClientID%>").val();
                var isValid = 0;

                if ($.trim(first) === "" || $.trim(last) === "" || $.trim(username) === "" || $("#<%=ddlNewType.ClientID%>").val() == 0 || $.trim(pass) === "" || $.trim(confirmpass) === "") {
                    isValid = isValid + 1;
                }

                if (pass !== confirmpass) {
                    isValid = isValid + 1;
                }

                if (isValid !== 0) {
                    $("#lblError").text("Please make sure to fill out all fields, and confirm your password.");
                } else {

                    //ajax

                    $.ajax({

                        type: "POST",
                        url: "WebServices/UserManagementService.asmx/CreateUser",
                        data: "{first:'" + first + "',last:'" + last + "',username:'" + username + "',type:'" + type + "',chamber:'" + 1 + "',password:'" + pass + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data) {

                            location.reload(true);

                        },
                        failure: function (msg) {
                            alert(msg);
                        },
                        error: function (err) {
                            alert(err);
                        }
                    }) //end ajax calendar item load

                }

            })
            //END CREATE NEW USER SECTION

            //UPDATE USER

            $("#btnSaveChanges").click(function () {

                var first = $("#txtFirst").val();
                var last = $("#txtLast").val();
                var username = $("#txtUser").val();

                var type = $("#<%=ddlUserType.ClientID%>").val();
                var password = $("#txtPassword").val();
                var confirmPass = $("#txtConfPassword").val();
                var updatePass = false;
                var me = $("#person").val();

                //Validation 

                if ($.trim(password) == "" && $.trim(confirmPass == "")) { //no change to password
                    updatePass = false
                } else {
                    updatePass = true
                }

                if (updatePass) {
                    if (password == confirmPass) {
                        updatePass = true
                    } else {
                        updatePass = false
                    }
                }

                //Ajax 

                $.ajax({

                    type: "POST",
                    url: "WebServices/UserManagementService.asmx/UpdateUser",
                    data: "{PersonID:'" + me + "',FirstName:'" + first + "',LastName:'" + last + "',Username:'" + username + "',Type:'" + type + "',Chamber:'" + 1 + "',Password:'" + password + "',PasswordFlag:'" + updatePass + "'}",

                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        location.reload(true);

                    },
                    failure: function (msg) {
                        alert("failed");
                    },
                    error: function (err) {
                        alert("error");
                    }
                }) //End Ajax

            })

            //END UPDATE USER

            //DELETE USER

            $("#btnDeleteUser").click(function () {

                var first = $("#txtFirst").val();
                var last = $("#txtLast").val();
                var who = $("#person").val();

                if ($.trim(first) == "" || $.trim(last) == "") {

                    alert("Please select a user to delete.");
                } else {
                    var doDelete = confirm("Do you really want to delete " + first + " " + last + "?");
                    if (doDelete == true) {

                        //Ajax 
                        $.ajax({

                            type: "POST",
                            url: "WebServices/UserManagementService.asmx/DeleteUser",
                            data: "{Person:'" + who + "'}",

                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (data) {

                                location.reload(true);

                            },
                            failure: function (msg) {
                                alert("failed");
                            },
                            error: function (err) {
                                alert("error");
                            }
                        }) //End Ajax

                    } else {
                        return;
                    }

                }
            })

            //END DELETE USER




        })
    </script>
</html>

    










