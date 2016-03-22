<%@ Page Language="vb" AutoEventWireup="false"  EnableEventValidation="false" CodeBehind="VoterAttendance.aspx.vb" Inherits="VoteReporterNEW.VoterAttendance" %>

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
                                <a href="default.aspx"><i class="fa fa-home"></i>Home</a>
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
                <!-- /.container -->
            </nav>

            <div class="ContentArea">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="contentMessage" style="margin-top: 25px">
                               <h1 style="color: #2c3e50"><span id="reportName"></span> </h1>
                                <hr style="border:none;height:2px;background-color:#2c3e50;margin-left:45%;margin-right:45%" />
                                <h3 style="color: #2c3e50"><span id="lblsessioncode"></span> Session</h3>
                                <h4 style="color: #2c3e50"><span id="txtCurrentLeg"></span></h4>

                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="container">
               
            <div class="row">
            <div class="col-lg-12">

                <div class="col-lg-2"></div>

                <div class="col-lg-4">
                    <h3>Available Members</h3>
                    <p style="color: #ff6a00" id="loadingMembers">Loading Members...</p>
                    <ul class="list-unstyled">
                        <li><asp:CheckBox runat="server" ID="ckAllMembers" CssClass="checkbox-inline" Text="Select All" /></li>
                    </ul>
                    <div id="MemberList" class="list-group" style="overflow-y: scroll; height: 250px"> </div>
                    
                </div>


                <div class="col-lg-4">
                    <h3>Members to Report <span id="lblAllMem" style="color:#1f7048">(All)</span></h3>
                     <ul class="list-unstyled">
                       
                        <li><a href="#" class="label label-danger" id="clearAllMembers"> Clear Selection </a></li>
                    </ul>
                    <div id="selectedMemberList" class="list-group" style="overflow-y:scroll;height:250px">
                       
                    </div> 
                </div>



                <div class="col-lg-2"></div>

                

                <div class="col-lg-12">
                    <div class="col-lg-4 col-lg-offset-2">

                       <ul class="list-inline">
                            <li><h4>Begin Date </h4>
                                <asp:DropDownList CssClass="form-control" runat="server" ID="ddlBeginDate">
                                     
                                </asp:DropDownList>
                            </li>
                             <li><h4>End Date</h4>
                                <asp:DropDownList CssClass="form-control" runat="server" ID="ddlEndDate"></asp:DropDownList>
                            </li>


                          
                        </ul>
                       
                       




                        <br />
                        <br />

                        <ul class="list-inline">
                            <li><button id="btnDoReport" class="btn btn-primary pull-left"><i class="fa fa-user"></i>  Standard Report</button></li>
                                 <li><button id="btnDoOptionalReport" class="btn btn-danger pull-left"><i class="fa fa-book"></i>  Optional Report</button></li>
                             </ul>
                         
                    </div>
                      
                </div>

    
            </div>
        </div>

        <div class="row">
            <div class="col-lg-12 text-center" style="padding:20px">
               <h4 id="errorMsg" style="color:#c9302c"></h4>
            </div>
        </div>

            </div>
           



        </form>
        </body>
    </html>




    <script src="js/jquery.js"></script>
    <script>
        $(document).ready(function () {

            $("#<%=ckAllMembers.ClientID%>").attr("checked", "checked");
            var isAllMembers = 1;
            $("#loadingMembers").show();
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
                $("#ddlSessionSelect").val(_CurrentSession);
                setPageLinks();

            }


            getName();

            function getName() {

                $.ajax({
                    type: "POST",
                    url: "Engine.asmx/getReportNames",
                    data: "{type:" + 7 + "}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        var result = data.d;
                        $("#reportName").text(result);
                    }
                })
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
                            $("#txtCurrentLeg").text(item.currentSessionLegislature);

                            if (item.showOptionalAttendance) {
                                $("#btnDoOptionalReport").show();
                            } else {
                                $("#btnDoOptionalReport").hide();
                            }

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



            //Load Calendar Dates 
            $.ajax({

                type: "POST",
                url: "WebServices/ReportService.asmx/LoadCalendarDates",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {

                    //take data and append as list item parameters to be selected by user

                    var result = data.d;
                    $("#<%=ddlBeginDate.ClientID%>").empty();
                    $("#<%=ddlEndDate.ClientID%>").empty();

                    $("#<%=ddlBeginDate.ClientID%>").append($("<option></option>").val
                         ("").text(""));
                    $("#<%=ddlEndDate.ClientID%>").append($("<option></option>").val
                        ("").text(""));

                    $.each(result, function (index, item) {

                        $("#<%=ddlBeginDate.ClientID%>").append($("<option></option>").val
                        (item.createDate).text(item.createDate));
                        $("#<%=ddlEndDate.ClientID%>").append($("<option></option>").val
                       (item.createDate).text(item.createDate));

                    })

                },
                failure: function (msg) {
                    alert(msg);
                },
                error: function (err) {
                    console.log(err);
                }
            }) //end ajax date load




            $("#lblAllMem").hide();
            //Load Members
            $.ajax({

                type: "POST",
                url: "WebServices/ReportService.asmx/LoadMembers",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {

                    //take data and append as list item parameters to be selected by user
                    var result = data.d;
                    $("#MemberList").empty();
                    $.each(result, function (index, item) {

                        var content = "<a href='#' data-who='" + item.MemberId + "' id='" + item.MemberId + "' data-selected='0' class='list-group-item mbritem'>" + item.VotingName + "</a>";
                        $(content).hide().appendTo("#MemberList").fadeIn();
                    })

                    $("#loadingMembers").hide();
                    $(".mbritem").addClass('active');
                    $(".mbritem").data("selected", 1);
                    $("#lblAllMem").show();

                },
                failure: function (msg) {
                    alert(msg);
                },
                error: function (err) {
                    console.log(err);
                }
            }) //end ajax 

            $("#MemberList").delegate(".mbritem", "click", function (e) {

                e.preventDefault();

                if (isAllMembers) {
                    alert("To select individual members, please uncheck 'Select All'.");
                    return;
                }

                if ($(this).data("selected") == 1) {
                    $(this).removeClass('active');
                    $(this).data("selected", 0);
                    var MemID = $(this).attr('id');
                    var MbrName = $(this).text();


                    $("#selectedMemberList div").filter(":contains('" + MbrName + "')").remove();

                } else {

                    $(this).addClass('active');
                    $(this).data("selected", 1);

                    var MembersName = $(this).text();
                    var Who = $(this).attr('id');
                    var selectedMbr = " <div class='list-group-item selectedMem' data-who='" + Who + "' ><a class='delete' href='#'><i style='color:#c9302c' class='fa fa-close'></i></a>" + " " + MembersName + "</div> "
                    $(selectedMbr).hide().prependTo("#selectedMemberList").fadeIn();

                }

            })

            $("#selectedMemberList").delegate(".delete", "click", function (e) {

                e.preventDefault();
                var m = $(this).closest('div').data('who');
                $(this).closest('div').remove();

                $('.mbritem[data-who="' + m + '"]').removeClass('active');
                $('.mbritem[data-who="' + m + '"]').data("selected", 0);

            })



            $("#clearAllMembers").click(function (e) {
                e.preventDefault();
                $('.selectedMem').remove();
                $(".mbritem").removeClass('active');
                isAllMembers = 0;
                $(".mbritem").data("selected", 0);
                $("#<%=ckAllMembers.ClientID%>").attr("checked", false);
                $("#lblAllMem").hide();

            })

            $("#<%=ckAllMembers.ClientID%>").change(function (e) {

                e.preventDefault();

                if (isAllMembers == 0) {
                    $(".mbritem").addClass('active');
                    $(".mbritem").data("selected", 1);
                    $("#lblAllMem").show();
                    $('.selectedMem').remove();
                    isAllMembers = 1;
                } else {
                    $(".mbritem").removeClass('active');
                    isAllMembers = 0;
                    $(".mbritem").data("selected", 0);
                    $("#lblAllMem").hide();
                    $('.selectedMem').remove();
                }
            }) //end check all 



            IsOptional = false;
            //End Member Handlers
            $("#btnDoReport").click(function (e) {

                e.preventDefault();

                var Mbritem = $('.mbritem');
                var selectedMbrItemsArray = new Array();
                var totMbrItems = 0;
                var totMbrNonSelected = 0;

                $.each(Mbritem, function (index, item) {

                    if ($(item).data('selected') == 1) {
                        selectedMbrItemsArray.push($(item).attr('id').toString());
                        totMbrItems = totMbrItems + 1;
                    } else {
                        totMbrItems = totMbrItems + 1;
                        totMbrNonSelected = totMbrNonSelected + 1;
                    }
                })

                if (totMbrItems == totMbrNonSelected) {

                    $("#errorMsg").text("Please select at least one member to continue.");
                    return;
                }

 
                //Get all array elements into one string. 
                var MemberArray = selectedMbrItemsArray.join();
  
                var StartDate = $("#<%=ddlBeginDate.ClientID%>").val();
                var EndDate = $("#<%=ddlEndDate.ClientID%>").val();
                var SessionEndedOn = $("#<%=ddlBeginDate.ClientID%> option:nth-child(2)").val();
                var SessionStartedOn = $("#<%=ddlEndDate.ClientID%> option:nth-last-child(1)").val();


                $.ajax({

                    type: "POST",
                    url: "WebServices/ReportService.asmx/SetAttendanceData",
                    data: "{Members:'" + MemberArray + "',StartDate:'"+ StartDate +"',EndDate:'"+ EndDate +"',SessionStarted:'"+ SessionStartedOn +"',SessionEnded:'"+ SessionEndedOn +"'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {


                        if (IsOptional) {
                            window.open("RV_MemberAttendance.aspx");
                        } else {
                            window.open("RVMemberAttendance_Optional.aspx");
                        }

                       


                    },
                    failure: function (msg) {
                        alert(msg);
                    },
                    error: function (err) {
                        console.log(err);
                    }
                })

            }) //end do report click

            $("#btnDoOptionalReport").click(function (e) {


                IsOptional = true;

                $("#btnDoReport").trigger("click");

            }) //end optional report click

        })
    </script>
    



