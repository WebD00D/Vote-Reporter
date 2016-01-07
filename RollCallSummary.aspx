<%@ Page Language="vb"  EnableEventValidation="false" AutoEventWireup="false" CodeBehind="RollCallSummary.aspx.vb" Inherits="VoteReporterNEW.RollCallSummary" %>







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
                                    <asp:LinkButton CssClass="btn btn-primary" runat="server" ID="linkLogout" ForeColor="white">Sign out  <i class="fa fa-sign-out fa-1x"></i></asp:LinkButton>
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
                                <h1 style="color: #2c3e50">Roll Call History </h1>
                                <h3 style="color: #2c3e50"><span id="lblsessioncode"></span> Session</h3>

                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="container">
                

                <div class="container">

         <div class="row">
             <div class="col-lg-12">

                 <div class="col-lg-8 col-lg-offset-2" style="padding-top:50px;">

                     <div class="col-lg-6">
                         <h4>Available Bills</h4>
                         <p style="color: #ff6a00" id="loadingBills">Loading Bills...</p>
                         <ul class="list-inline">
                             <li>
                                 <asp:CheckBox runat="server" ID="ckAllBills" CssClass="checkbox-inline" Text="Select All" /></li>
                         </ul>
                         <div id="BillList" class="list-group" style="overflow-y: scroll; height: 265px"></div>

                         <h4>Sort By</h4>
                         <ul class="list-inline">
                             <li>
                                 <asp:CheckBox runat="server" ID="ckRCSSort" />
                                 RCS Number</li>
                             <li>
                                 <asp:CheckBox runat="server" ID="ckLegSort" />
                                 Doc Number</li>
                         </ul>

                         <br />
                         
                         <div id="Votes" >
                             <h4>Votes to Report</h4>
                             <ul class="list-inline">
                                 <li id="l1" runat="server">
                                     <asp:CheckBox runat="server" ID="ckYea2" /><%=_YeaName%></li>
                                 <li id="l2" runat="server">
                                     <asp:CheckBox runat="server" ID="ckNay2" /><%=_NayName%></li>
                                 <li id="l3" runat="server">
                                     <asp:CheckBox runat="server" ID="ckAbstain2" /><%=_AbstainName%></li>
                                 <li id="l4" runat="server">
                                     <asp:CheckBox runat="server" ID="ckExc2" /><%=_ExcName%></li>
                                 <li id="l5" runat="server">
                                     <asp:CheckBox runat="server" ID="ckAbsent2" /><%=_AbsentName%></li>
                                 <li id="l6" runat="server">
                                     <asp:CheckBox runat="server" ID="ckNV2" /><%=_NVName%></li>
                             </ul>
                         </div>
                         <br />

                          <h4>Subject Search</h4>
                        <asp:TextBox runat="server" ID="txtSearchSubject"  CssClass="form-control"></asp:TextBox>
                        
                        <label id="lblSearchResults"></label>
                         <br />
                         <ul class="list-inline">
                             <li> <h4>Begin Date </h4>
                                <asp:DropDownList CssClass="form-control" runat="server" ID="ddlBeginDate">
                                     
                                </asp:DropDownList></li>
                             <li>
                                  <h4>End Date</h4>
                                <asp:DropDownList CssClass="form-control" runat="server" ID="ddlEndDate"></asp:DropDownList>
                             </li>
                         </ul>
                         <br />
                        
                             <asp:Button runat="server" ID="btnDoReport" CssClass="btn btn-sm btn-primary" Text="Generate Report" />
                       
                           
                             
                        
                          
                         
                     </div>



                     <div class="col-lg-6">

                         <h4>Bills to Report  <span id="lblAllBills" style="color: #1f7048">(All)</span></h4>
                         <ul class="list-unstyled">

                             <li><a href="#" class="label label-danger" id="clearAllBills">Clear Selection </a></li>
                         </ul>
                         <div id="selectedBillsList" class="list-group" style="overflow-y: scroll; height: 250px">
                         </div>

                         <br />

                     </div>

                     
                      
                        




                     <div class="col-lg-12 text-center" style="padding: 50px">
                         <h4 id="errMsg" style="color: red"></h4>
                         <h4 id="errMsg2" style="color: red"></h4>
                     </div>


                 </div>
                    
                    </div>
                    
                </div>

            </div>

            </div>
           



        </form>
         <script src="js/jquery.js"></script>
    <script>
        $(document).ready(function () {
           
            $("#<%=ckAllBills.ClientID%>").attr("checked", "checked");
            $("#lblAllBills").hide();
            $("#loadingBills").show();
            $("#lblSearchResults").text("");
            var isAllBills = 0;

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
                    alert(err);
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
                    alert(err);
                }
            }) //end ajax calendar item load

          
            $("#clearAllBills").click(function (e) {

                e.preventDefault();
                $('.selectedBill').remove();
                $(".calitem").removeClass('active');
                isAllBills = 0;
                $(".calitem").data("selected", 0);
                $("#<%=ckAllBills.ClientID%>").attr("checked", false);
             
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






            ////////////////////////

            $("#<%=btnDoReport.ClientID%>").click(function (e) {


                var ckYES = false;
                var ckNO = false;
                var ckABSTAIN = false;
                var ckEXC = false;
                var ckABSENT = false;
                var ckNV = false;

                if ($("#<%=ckYea2.ClientID%>").is(':checked')) {
                    ckYES = true
                }
                if ($("#<%=ckNay2.ClientID%>").is(':checked')) {
                    ckNO = true
                }
                if ($("#<%=ckAbstain2.ClientID%>").is(':checked')) {
                    ckABSTAIN = true
                }
                if ($("#<%=ckExc2.ClientID%>").is(':checked')) {
                    ckEXC = true
                }
                if ($("#<%=ckAbsent2.ClientID%>").is(':checked')) {
                    ckABSENT = true
                }
                if ($("#<%=ckNV2.ClientID%>").is(':checked')) {
                    ckNV = true
                }




                var calitem = $('.calitem');
                var selectedItemsArray = new Array();
                var totItems = 0;
                var totNonSelected = 0;



                $.each(calitem, function (index, item) {

                    // for error handling, we get the total count of items available to check. If an item is not selected, we will increment
                    // a 'not-selected' counter. At the end of the loop, if total items available == total number of unselected items, then we
                    // know that nothing was selected, and can show an error.

                    if ($(item).data('selected') == 1) {
                        selectedItemsArray.push($(item).attr('id').toString());
                        totItems = totItems + 1;
                    } else {
                        totItems = totItems + 1;
                        totNonSelected = totNonSelected + 1;
                    }
                })

                if (UsingSearchText == false) {
                    if (totItems == totNonSelected) {
                        $("#errMsg").show();
                        $("#errMsg").text("Please select at least one bill to continue.");
                        e.preventDefault();
                        // $("#errMsg").fadeOut(6000);
                        return;
                    } else {
                        $("#errMsg").text("");
                    }
                }


                //Get all array elements into one string. 
                var arrayman = selectedItemsArray.join();

                var startDate = $("#<%=ddlBeginDate.ClientID%>").val();
                var endDate = $("#<%=ddlEndDate.ClientID%>").val()
                var RCSSort = false;
                if ($("#<%=ckRCSSort.ClientID%>").is(':checked')) {
                    RCSSort = true
                }
                var LegSort = false;
                if ($("#<%=ckLegSort.ClientID%>").is(':checked')) {
                    LegSort = true
                }

                if (LegSort == true) {
                    if (RCSSort == true) {
                        $("#errorMsg").text("Please select only one sort order.");
                        return;
                    }

                }

                var SortBy = "";
                if (LegSort == true) {
                    SortBy = "LegNbr ASC"
                }
                if (RCSSort == true) {
                    SortBy = "RCSNbr ASC"
                }


                //ajax call 
                $.ajax({

                    type: "POST",
                    url: "WebServices/ReportService.asmx/SetRollCallSummaryDetails",
                    data: "{Bills:'" + arrayman + "',StartDate:'" + startDate + "',EndDate:'" + endDate + "',SortBy:'" + SortBy + "',IsAll:'" + isAllBills + "',ckYea:'" + ckYES + "',ckNay:'" + ckNO + "',ckAbstain:'" + ckABSTAIN + "',ckExcused:'" + ckEXC + "',ckAbsent:'" + ckABSENT + "',ckNotVoting:'" + ckNV + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        window.open("RV_RollCallSummary.aspx");

                        location.reload(true);

                    },
                    failure: function (msg) {
                        alert(msg);
                    },
                    error: function (err) {
                        alert(err);
                    }
                }) //end ajax 


            }) //end btn Do Report

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
                            alert(err);
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
                            alert(err);
                        }
                    }) //end ajax calendar item load

                }

            })
        })
    </script>


     
            <!-- /.container -->


  
    </body>
</html>




   

