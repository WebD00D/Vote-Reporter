<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="VoteReporterNEW._Default" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

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
        <!-- Navigation -->
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



    <%--                                      <asp:DropDownList ID="ddlSession"  CssClass="form-control" runat="server">
                              
                                      </asp:DropDownList>--%>
                                 <%--<span class="input-group-addon"><asp:LinkButton runat="server"><i class="fa fa-refresh"></i></asp:LinkButton></span>--%>

                                 </div>
                               
                                    <asp:LinkButton CssClass="btn btn-primary" runat="server" ID="linkLogout" ForeColor="white">Sign out  <i class="fa fa-sign-out fa-1x"></i></asp:LinkButton>
                             
                             
                            </div>
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
                        <div class="contentMessage" style="margin-top: 25px">
                            <h1 style="color:#2c3e50">Vote Reporter</h1>
                            <h3 style="color:#2c3e50"><span id="lblsessioncode"></span> Session</h3>
                         
                        </div>
                    </div>
                </div>
            </div>
            <!-- /.container -->
        </div>
 
     <div class="container">
         
                <div class="row">
                    
                        <h2 class="section-heading">Reports</h2>
                    <ul class="list-inline text-center">

                                 
                            <li>
                                <h4>
                                    <asp:HyperLink runat="server" ID="lnkVoterDetails" NavigateUrl="~/VoterDetails.aspx">
                                        <i id="ivdet" style="color: #FFA274" runat="server" class="fa fa-user fa-3x"></i>
                                        <br />
                                        <%=_VoterDetails %>
                                    </asp:HyperLink></h4>
                            </li>

                        <li>
                            <h4>
                                <asp:HyperLink runat="server" ID="lnkVoterStats" NavigateUrl="~/VoterStatistics.aspx">
                                    <i id="ivstats" style="color: #326779" runat="server" class="fa fa-area-chart fa-3x"></i>
                                    <br />
                                    <%=_VoterStats %>
                                </asp:HyperLink></h4>
                        </li>


                        <li>

                            <h4>
                                <asp:HyperLink runat="server" ID="lnkVoterComp" NavigateUrl="~/VoterComparison.aspx">
                                    <i id="ivcomp" style="color: #4F92BF" runat="server" class="fa fa-pie-chart fa-3x"></i>
                                    <br />
                                    <%=_VoterComparison%>
                                </asp:HyperLink></h4>
                        </li>



                        <li>
                            <h4>
                                <asp:HyperLink runat="server" ID="lnkMemberAttendance" NavigateUrl="~/VoterAttendance.aspx">
                                    <i runat="server" id="iAtt" style="color: #7AC292" class="fa fa-check fa-3x"></i>
                                    <br />
                                    <%=_MemberAttendance%>
                                </asp:HyperLink></h4>
                        </li>




                        <li>
                            <h4>
                                <asp:HyperLink runat="server" ID="lnkRCSum" NavigateUrl="~/RollCallSummary.aspx">
                                    <i id="ircsum" style="color: #7089AD" runat="server" class="fa fa-gavel fa-3x"></i>
                                    <br />
                                    <%=_RCSummary %>
                                </asp:HyperLink></h4>
                        </li>

                        <%--               <li> <i id="ircdet" runat="server" class="fa fa-tasks fa-3x"></i>
                           <br />
                              <asp:HyperLink runat="server" ID="lnkRCDet"  NavigateUrl="~/RollCallDetails.aspx"><%=_RCDetails%></asp:HyperLink></li>--%>

                        <li>
                            <h4>
                                <asp:HyperLink runat="server" ID="lnkRCTrans" NavigateUrl="~/RollCallTranscripts.aspx">
                                    <i id="irctrans" style="color: #DB6B71" runat="server" class="fa fa-calendar-o fa-3x"></i>
                                    <br />
                                    <%=_RCTranscript%>
                                </asp:HyperLink></h4>
                        </li>

                    </ul>


                    <div runat="server" id="adminSection">
                        <br />
                        <h2 class="section-heading">Administration
                        </h2>
                        <ul class="list-inline text-center">
                            <li>
                                <h4><a href="UserManagementEditor.aspx">
                                    <i style="color: #5C5956" class="fa fa-users fa-3x"></i>
                                    <br />
                                    User Management</a></h4>
                            </li>

                            <li>
                                <h4><a href="ReportManagementEditor.aspx">
                                    <i style="color: #5C5956" class="fa fa-file fa-3x"></i>
                                    <br />
                                    Report Management</a></h4>
                            </li>

                            <li>
                                <h4><a href="Configuration.aspx">
                                    <i style="color: #5C5956" class="fa fa-wrench fa-3x"></i>
                                    <br />
                                    Configuration</a></h4>
                            </li>
                        </ul>
                    </div>
                </div>

            </div>


          
    <%--    <!-- Footer -->
        <footer class="text-center" style="bottom:0">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12">
                        <ul class="list-inline">
                            <li>
                                <a href="http://www.roll-call.com">IRC Home</a>
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
                        <p class="copyright text-muted small">Copyright &copy; <%=Date.Today.Year%> International Roll Call Corp. All Rights Reserved.</p>
                        
                    </div>
                </div>
            </div>
        </footer>--%>

   
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="myModalLabel">Need some help?</h4>
                </div>
                  <div>
                     
                      <div style="padding: 20px">
                          <h4>Please direct all questions, comments, or concerns to:</h4>
                          <address>
                              <i class="fa fa-user"></i>  Christian Bryant
                              <br />
                              <i class="fa fa-envelope-o"></i>  cbryant@roll-call.com
                              <br />
                              <i class="fa fa-phone"></i>  804-730-9600
                          </address>
                          <img src="img/IRC-SINGLE-LINE-DKBLUE.png" class="img-responsive" />
                      </div>
                  </div>   
                 
                <div class="modal-footer">
                    <p id="lblError" style="color:red"></p>
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                
                </div>
            </div>
        </div>
    </div>

        <!-- jQuery -->
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
                            var optiontag = "<option id=" + item.sessionID + " value="+ item.sessionID +">" + item.sessionCode + "</option>";
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
                updateSession( session );
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

















            if ($("#<%=lnkMemberAttendance.ClientID%>").hasClass("hide")) {

                $("#<%=iAtt.ClientID%>").addClass("hide");
            }


            if ($("#<%=lnkRCSum.ClientID%>").hasClass("hide")) {

                $("#<%=ircsum.ClientID%>").addClass("hide");
            }

            if ($("#<%=lnkRCTrans.ClientID%>").hasClass("hide")) {

                $("#<%=irctrans.ClientID%>").addClass("hide");
            }

            if ($("#<%=lnkVoterComp.ClientID%>").hasClass("hide")) {

                $("#<%=ivcomp.ClientID%>").addClass("hide");
            }

            if ($("#<%=lnkVoterDetails.ClientID%>").hasClass("hide")) {

                $("#<%=ivdet.ClientID%>").addClass("hide");
            }

            if ($("#<%=lnkVoterStats.ClientID%>").hasClass("hide")) {

                $("#<%=ivstats.ClientID%>").addClass("hide");
            }



        })
    </script>

    </form>


</body>
    </html>