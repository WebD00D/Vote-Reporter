<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Content.Master" CodeBehind="UserManagementEditor.aspx.vb" Inherits="VoteReporterNEW.UserManagementEditor" %>


<asp:Content runat="server" ContentPlaceHolderID="PageTitle">User Management</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="PageSubTitle"></asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">

    <script src="js/jquery.js"></script>
    <script>
        $(document).ready(function () {

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
                    if (password == confirmPass ) { 
                        updatePass = true
                    } else {
                        updatePass = false
                    }
                }

                //Ajax 
             
                $.ajax({
                    
                    type: "POST",
                    url: "WebServices/UserManagementService.asmx/UpdateUser",
                    data: "{PersonID:'" + me + "',FirstName:'" + first + "',LastName:'" + last + "',Username:'" + username + "',Type:'" + type + "',Chamber:'" + 1 + "',Password:'" + password + "',PasswordFlag:'"+ updatePass +"'}",

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


     <div class="container">

                <div class="row">
                    <div class="col-lg-12">
                   
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
</asp:Content>