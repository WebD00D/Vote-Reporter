<%@ Page Language="vb" EnableEventValidation="false" AutoEventWireup="false" CodeBehind="VoterStatistics.aspx.vb" Inherits="VoteReporterNEW.VoterStatistics" %>



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
    <body style="background-color:white">
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
            <div class="col-lg-12" >

                <div class="col-lg-2"></div>

                <div class="col-lg-4">
                    <h4>Available Members</h4>
                    <p style="color: #ff6a00" id="loadingMembers">Loading Members...</p>
                    <ul class="list-unstyled">
                        <li><asp:CheckBox runat="server" ID="ckAllMembers" CssClass="checkbox-inline" Text="Select All" /></li>
                    </ul>
                    <div id="MemberList" class="list-group" style="overflow-y: scroll; height: 250px"> </div>
                    

                    <h4>Available Bills</h4>
                    <p style="color: #ff6a00" id="loadingBills">Loading Bills...</p>
                    <ul class="list-inline">
                        <li><asp:CheckBox runat="server" ID="ckAllBills" CssClass="checkbox-inline" Text="Select All" /></li>
                    </ul>
                     <div id="BillList" class="list-group" style="overflow-y: scroll; height: 250px"> </div>
                </div>


                <div class="col-lg-4">
                    <h4>Members to Report <span id="lblAllMem" style="color:#1f7048">(All)</span></h4>
                     <ul class="list-unstyled">
                       
                        <li><a href="#" class="label label-danger" id="clearAllMembers"> Clear Selection </a></li>
                    </ul>
                    <div id="selectedMemberList" class="list-group" style="overflow-y:scroll;height:250px">
                       
                    </div> 

                    <h4 style="padding-top:3px">Bills to Report  <span id="lblAllBills" style="color:#1f7048">(All)</span></h4>
                      <ul class="list-unstyled">
                       
                        <li><a href="#" class="label label-danger" id="clearAllBills"> Clear Selection </a></li>
                    </ul>
                    <div id="selectedBillsList" class="list-group" style="overflow-y:scroll;height:250px">
                       
                    </div>
                    
                    
                  

                </div>



                <div class="col-lg-2"></div>

                

                <div class="col-lg-12">
                    <div class="col-lg-4 col-lg-offset-2">

                             <h4 class="hidden">Subject Search</h4>
                        <asp:TextBox runat="server" ID="txtSearchSubject"  CssClass="form-control hidden"></asp:TextBox>
                        
                        <label id="lblSearchResults"></label> 


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
                        <ul class="list-inline">
                             <li><button id="btnOptionalReport" class="btn btn-sm btn-primary pull-left"><i class="fa fa-user"></i>  Standard Report</button></li>
                            <li><button id="btnDoReport" class="btn btn-sm btn-danger pull-left"><i class="fa fa-book"></i>  Optional Report</button></li>
                   
                            <li><a data-toggle="modal" data-target="#myModal"  class="hidden btn btn-sm btn-info pull-left"><i class="fa fa-question"></i></a></li>
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
                    <!--New User Modal -->
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="myModalLabel">Standard VS Optional</h4>
                </div>
               
                 
                  <div>
                     
                      <div style="padding: 20px">
                          <h5>What's the difference?</h5>
                          <p>A standard report will show all members selected in a grid and their voting 
                             information. However, by selecting to run an optional report only information
                             for one selected member will be shown. 
                           
                          </p>
                         

                      </div>

   
                     
                  </div>   
                 
                <div class="modal-footer">
                    <p id="lblError" style="color:red"></p>
                
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                
                </div>
            </div>
        </div>
    </div>



        </form>
    </body>
</html>



    <!--START OLD CODEEEEEEE-->

    <script src="js/jquery.js" type="text/javascript"></script>
    <script>
        $(document).ready(function () {

           // $("#lblAllMem").hide();
            //$("#lblAllBills").hide();
            $("#loadingMembers").show();
            $("#loadingBills").show();

            // -----------------BASE PAGE FUNCTIONS START ------------------//
            var isAllMembers = 1;
            var isAllBills = 1;



            $("#<%=ckAllBills.ClientID%>").attr("checked", "checked");
            $("#<%=ckAllMembers.ClientID%>").attr("checked", "checked");


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

            //Load Motions
            $.ajax({

                type: "POST",
                url: "WebServices/ReportService.asmx/LoadMotions",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {

                    //take data and append as list item parameters to be selected by user
                    var result = data.d;
                    $("#ddlMotionfilter").empty();
                    var emtpyoption = "<option val='NOTHING'> </option>";
                    $(emtpyoption).appendTo("#ddlMotionfilter");
                    $.each(result, function (index, item) {

                        var content = "<option>" + item.Motion + "</option>";
                        $(content).appendTo("#ddlMotionfilter");
                    })

                },
                failure: function (msg) {
                    console.log(msg);
                },
                error: function (err) {
                    console.log(err);
                }
            }) //end ajax Motions Load





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

            getName();

            function getName() {

                $.ajax({
                    type: "POST",
                    url: "Engine.asmx/getReportNames",
                    data: "{type:" + 5 + "}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        var result = data.d;
                        $("#reportName").text(result);
                    }
                })
            }


            // -----------------BASE PAGE FUNCTIONS START ------------------//


            $("#lblAllBills").hide();
            $("#lblAllMem").hide();
            $("#lblSearchResults").text("");

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


            //Load Calendar Items
            $.ajax({

                type: "POST",
                url: "WebServices/ReportService.asmx/LoadCalendarItems",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {

                    //take data and append as list item parameters to be selected by user
                    var result = data.d;
                    $("#BillList").empty();
                    $.each(result, function (index, item) {

                        var content = "<a href='#' data-who='" + item.calendarItemID + "' id='" + item.calendarItemID + "' data-selected='0' class='list-group-item calitem'>" + item.billPrefix + " " + item.legislationNbr + " | " + item.Motion + "</a>";
                        $(content).hide().appendTo("#BillList").fadeIn();
                    })
                    
                    $("#loadingBills").hide();
                    $(".calitem").addClass('active');
                    $(".calitem").data("selected", 1);
                    $("#lblAllBills").show();

                },
                failure: function (msg) {
                    alert(msg);
                },
                error: function (err) {
                    console.log(err);
                }
            }) //end ajax calendar item load

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
                  

                    $("#selectedMemberList div").filter(":contains('"+ MbrName +"')").remove();

                } else {

                    $(this).addClass('active');
                    $(this).data("selected", 1);

                    var MembersName = $(this).text();
                    var Who = $(this).attr('id');
                    var selectedMbr = " <div class='list-group-item selectedMem' data-who='"+ Who +"' ><a class='delete' href='#'><i style='color:#c9302c' class='fa fa-close'></i></a>" + " " + MembersName + "</div> "
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

            //End Member Handlers

            // Bill Selection Handlers

            $("#BillList").delegate(".calitem", "click", function (e) {

                e.preventDefault();

                if (isAllBills) {
                    alert("To select individual bills, please uncheck 'Select All'.");
                    return;
                }

                var bill = $(this).text()
                var billIdentify = $(this).attr('id');
                

                if ($(this).data("selected") == 1) {

                    $(this).removeClass('active');
                    $(this).data("selected", 0);
                    $("#selectedBillsList div").filter(":contains('" + bill + "')").remove();
                  

                } else {

                    $(this).addClass('active');
                    $(this).data("selected", 1);
                  
                    
                    var selectedBillz = " <div class='list-group-item selectedBill' data-who='" + billIdentify + "' ><a class='delete' href='#'><i style='color:#c9302c' class='fa fa-close'></i></a>" + " " + bill + "</div> "
                    $(selectedBillz).hide().prependTo("#selectedBillsList").fadeIn();

                }

            })


            $("#selectedBillsList").delegate(".delete", "click", function (e) {

                e.preventDefault();
                var w = $(this).closest('div').data('who');
                $(this).closest('div').remove();
             
                $('.calitem[data-who="' + w + '"]').removeClass('active');
                $('.calitem[data-who="' + w + '"]').data("selected", 0);
                
            })

         
            $("#clearAllBills").click(function (e) {

                e.preventDefault();
                $('.selectedBill').remove();
                $(".calitem").removeClass('active');
                isAllBills = 0;
                $(".calitem").data("selected", 0);
                $("#<%=ckAllBills.ClientID%>").attr('checked', false);
                $("#lblAllBills").hide();

            })


          
            $("#<%=ckAllBills.ClientID%>").change(function () {

                if (isAllBills == 0) {
                    $(".calitem").addClass('active');
                    $(".calitem").data("selected", 1);
                    isAllBills = 1;
                    $("#lblAllBills").show();
                    $('.selectedBill').remove();
                } else {
                    $(".calitem").removeClass('active');
                    isAllBills = 0;
                    $(".calitem").data("selected", 0);
                    $("#lblAllBills").hide();
                }
            }) //end check all

            //End Bill Handlers

            var UsingSearchText = false;

            $("#<%=txtSearchSubject.ClientID%>").keyup(function () {

                var key = event.keyCode || event.charCode;
                var SearchText = $("#<%=txtSearchSubject.ClientID%>").val();

                //if (key == 8 || key == 46) {
                //    alert("backspace");
                //}


                if ($("#<%=txtSearchSubject.ClientID%>").val().length > 2) {

                    $.ajax({

                        type: "POST",
                        url: "WebServices/ReportManagementService.asmx/CheckSubject",
                        data: "{SearchText:'" + SearchText + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            var result = data.d;
                            if (result != "empty") {
                                UsingSearchText = true;
                                $("#<%=txtSearchSubject.ClientID%>").css("border-color", "green");
                                $("#lblSearchResults").css("color", "green");
                                $("#lblSearchResults").text("Results found matching search query.");

                            } else {
                                UsingSearchText = false;
                                $("#<%=txtSearchSubject.ClientID%>").css("border-color", "red");
                                $("#lblSearchResults").css("color", "red");
                                $("#lblSearchResults").text("No results found matching search query.");
                            }

                        },
                        failure: function (msg) {
                            alert(msg);
                        },
                        error: function (err) {
                            console.log(err);
                        }
                    }) //end ajax calendar item load



                } else {

                    $.ajax({

                        type: "POST",
                        url: "WebServices/ReportManagementService.asmx/ClearSubjectSearch",
                        data: "{}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            var result = data.d;
                            $("#<%=txtSearchSubject.ClientID%>").css("border-color", "");
                            $("#lblSearchResults").text("");
                            UsingSearchText = false;

                        },
                        failure: function (msg) {
                            alert(msg);
                        },
                        error: function (err) {
                            console.log(err);
                        }
                    }) //end ajax calendar item load

                }

            })

            IsOptional = false;


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

                var calitem = $('.calitem');
                var selectedCalItemsArray = new Array();
                var totCalItems = 0;
                var totCalNonSelected = 0;

                $.each(calitem, function (index, item) {


                    if ($(item).data('selected') == 1) {
                        selectedCalItemsArray.push($(item).attr('id').toString());
                        totCalItems = totCalItems + 1;
                    } else {
                        totCalItems = totCalItems + 1;
                        totCalNonSelected = totCalNonSelected + 1;
                    }
                })

                if (totCalItems == totCalNonSelected) {
                    if (UsingSearchText == false) {
                        $("#errorMsg").text("Please select at least one bill to continue.");
                        return;
                    }
                   
                }

             

                //Get all array elements into one string. 
                var MemberArray = selectedMbrItemsArray.join();
                var BillsArray = selectedCalItemsArray.join();
             //   var StatsArray = selectedStatsArray.join();

                var StartDate = $("#<%=ddlBeginDate.ClientID%>").val();
                var EndDate = $("#<%=ddlEndDate.ClientID%>").val();

                var SessionEndedOn = $("#<%=ddlBeginDate.ClientID%> option:nth-child(2)").val();
                var SessionStartedOn = $("#<%=ddlEndDate.ClientID%> option:nth-last-child(1)").val();
               
             //   alert(StatsArray);

                $.ajax({

                    type: "POST",
                    url: "WebServices/ReportService.asmx/SetVoterStatsData",
                    data: "{IsAllBills:'" + isAllBills + "',Members:'" + MemberArray + "',Bills:'" + BillsArray + "',StartDate:'" + StartDate + "',EndDate:'" + EndDate + "',SessionStarted:'" + SessionStartedOn + "',SessionEnded:'"+ SessionEndedOn +"'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        if (IsOptional) {
                            window.open("RV_VoterStatistics_Optional.aspx");
                        } else {
                            window.open("RV_VoterStatisticsNEW.aspx");
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

            $("#btnOptionalReport").click(function (e) {
               
                
                IsOptional = true;
                
                $("#btnDoReport").trigger("click");

            }) //end optional report click

            
        })
    </script>

   


   
