<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ReportManagementEditor.aspx.vb" Inherits="VoteReporterNEW.ReportManagementEditor" %>


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
    <body style="background-color:#eeeeee">
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
                                   <asp:LinkButton CssClass="btn btn-primary hidden" runat="server" ID="linkLogout" ForeColor="white">Sign out  <i class="fa fa-sign-out fa-1x"></i></asp:LinkButton>
                                <a class="btn btn-primary" href="Login.aspx">Sign Out <i class="fa fa-sign-out fa-1x"></i></a>
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
                            <h1 style="color:#2c3e50">Report Management Editor</h1>
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
                   
                        <div class="col-lg-4 col-lg-offset-1">
                            <div id="reportTypes" class="list-group">
                              
                            </div>
                        </div>


                    <div class="col-lg-6">

                        <div class="col-lg-6">
                               <h4>Name</h4>
                            <input class="form-control" id="name" placeholder="Report Name" />
                         
                        </div>
                         <div class="col-lg-6">
                              <h4>Type</h4>
                              <input class="form-control" id="type" disabled="disabled" placeholder="Report Type" />
                        </div>
                      

                      <div class="col-lg-6">
                                <h4>Minimum Access Level</h4>
                         <asp:DropDownList ID="ddlAccessLevel"  CssClass="form-control" runat="server">
                        
                      </asp:DropDownList>
                       
                          <br />
                          <ul class="list-inline">

                              <li> <input type="button" value="Edit" class="btn btn-sm btn-danger" id="btnEdit"></li>
                               <li> <input type="button" value="Save Changes" id="btnSaveChanges" class="btn btn-sm btn-primary"></li>
                              <li><h4 runat="server" id="successMsg" style="color:#0fa34d"></h4></li>
                          </ul>
                         
                      </div>

                    <div class="col-lg-6">
                        <h4>Use Report</h4>
                        <asp:DropDownList ID="ddlUseReport" CssClass="form-control" runat="server">
                            <asp:ListItem Value="Default">---</asp:ListItem>
                            <asp:ListItem Value="1">Yes</asp:ListItem>
                            <asp:ListItem Value="0">No</asp:ListItem>
                        </asp:DropDownList>

                    </div>
                      

                  
                    </div>


                     
                    
                    </div>
                    
                </div>

            </div>
            <!-- /.container -->


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






            $("#name").attr("disabled", "disabled");
            $("#<%=ddlAccessLevel.ClientID%>").attr("disabled", "disabled");
            $("#<%=ddlUseReport.ClientID%>").attr("disabled", "disabled");

            //load report types 
            $.ajax({

                type: "POST",
                url: "WebServices/ReportManagementService.asmx/LoadReportTypes",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {

                    //take data and append as list item parameters to be selected by user
                    var result = data.d;
                    $("#reportTypes").empty();
                    $.each(result, function (index, item) {

                        var content = "<a href='#' id='" + item.ID + "' data-rtype='" + item.ID + "'   data-type='" + item.Type + "' data-selected='0'  data-isUsed='" + item.IsUsed + "'  data-name='" + item.Name + "' data-access=" + item.MinAccess + " class='list-group-item reportz'>" + item.Name + "</a>";
                        $(content).hide().appendTo("#reportTypes").fadeIn();
                    })

                },
                failure: function (msg) {
                    alert(msg);
                },
                error: function (err) {
                    console.log(err);
                }
            }) //end ajax 


            $("#btnEdit").click(function () {
                $("#name").removeAttr("disabled");
                $("#<%=ddlAccessLevel.ClientID%>").removeAttr("disabled");
                $("#<%=ddlUseReport.ClientID%>").removeAttr("disabled");
            })


            var SelectedOne;


            $("#reportTypes").delegate(".reportz", "click", function (e) {


                if ($(this).data("selected") == 1) {

                    $(this).removeClass('active');
                    $(this).data("selected", 0);

                    $("#name").val("");
                    $("#type").val("");
                    $("#<%=ddlAccessLevel.ClientID%>").val("Default");
                    $("#<%=ddlUseReport.ClientID%>").val("Default");




                } else {

                    $(".reportz").removeClass('active');
                    $(this).addClass('active');
                    $(this).data("selected", 1);

                    var dataUSED = ($(this).attr('data-IsUsed'));



                    if (dataUSED == 0) {
                        $("#<%=ddlUseReport.ClientID%>").val("0");
                    } else {
                        $("#<%=ddlUseReport.ClientID%>").val("1");
                    }

                  <%--  switch (dataUSED) {

                        case 1:
                            // Is used
                            $("#<%=ddlUseReport.ClientID%>").val("1");
                            break;
                        case 2:
                            //Hide
                            $("#<%=ddlUseReport.ClientID%>").val("0");
                            break;
                    }
                  --%>



                    switch ($(this).data("access")) {

                        case 1:
                            //Admin
                            $("#<%=ddlAccessLevel.ClientID%>").val("1");
                            break;
                        case 2:
                            //Standard
                            $("#<%=ddlAccessLevel.ClientID%>").val("2");
                            break;
                        case 3:
                            //Public 
                            $("#<%=ddlAccessLevel.ClientID%>").val("3");
                            break;

                    }





                    $("#name").val($(this).data("name"));
                    $("#type").val($(this).data("type"));
                    SelectedOne = $(this).data("rtype");


                }

            })


            $("#btnSaveChanges").click(function () {

                var newName = $("#name").val();
                var access = $("#<%=ddlAccessLevel.ClientID%> option:selected").val();
                var UseReport = $("#<%=ddlUseReport.ClientID%>").val();




                if ($("#<%=ddlAccessLevel.ClientID%> option:selected").val() == "Default" || $.trim(newName) == "") {
                    alert("Please make sure you have selected a report and all fields are filled out completely.");
                    return;
                }


                $.ajax({

                    type: "POST",
                    url: "WebServices/ReportManagementService.asmx/EditReportDetails",
                    data: "{Name:'" + newName + "',AccessLevel:'" + access + "',ID:'" + SelectedOne + "',UseReport:'" + UseReport + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        location.reload(true);

                    },
                    failure: function (msg) {
                        alert(msg);
                    },
                    error: function (err) {
                        console.log(err);
                    }
                }) //end ajax 

            })
        })
    </script>
 </html>


  




