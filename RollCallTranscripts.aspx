<%@ Page Language="vb"  EnableEventValidation="false" AutoEventWireup="false" CodeBehind="RollCallTranscripts.aspx.vb" Inherits="VoteReporterNEW.RollCallTranscripts" %>





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
            <div class="col-lg-12">

            

                 <div class="col-lg-6">
                     <h4>Available Bills</h4>
                      <p style="color: #ff6a00" id="loadingBills">Loading Bills...</p>
                       <ul class="list-inline">
                        <li><asp:CheckBox runat="server" ID="ckAllBills" CssClass="checkbox-inline" Text="Select All" /></li>
                    </ul>
                      <div id="calendaritemList" class="list-group" style="overflow-y:scroll;height:270px">

                      </div>




                   <div class="col-lg-5 col-md-5 ">
                      <h4>Specific Date </h4>
                      <h6>Make sure to select all bills to run a specific date search</h6>
                                <asp:DropDownList CssClass="form-control" runat="server" ID="ddlBeginDate">
                                     
                                </asp:DropDownList>
                      <br />
                       <h4>Motion Filter</h4>
                        <select id="ddlMotionfilter" class="form-control"></select>
                       <br />
                       <ul class="list-inline">
                           <li> <input type="button" id="btnDoReport" class="btn btn-danger btn-sm btn-block" value="Generate Report" /></li>
   
                       </ul>
                       
                      <h5 id="errorMsg" style="color:#c9302c"></h5>
                   </div>

                </div>


                <div class="col-lg-6">
                    <h4>Bills to Report  <span id="lblAllBills" style="color:#1f7048">(All)</span></h4>
                      <ul class="list-unstyled">
                       
                        <li><a href="#" class="label label-danger" id="clearAllBills"> Clear Selection </a></li>
                    </ul>
                    <div id="selectedBillsList" class="list-group" style="overflow-y:scroll;height:270px">
                       
                    </div> 

                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-12 text-center" style="padding:20px">
               
            </div>
        </div>
              

            </div>
           



        </form>
         <script src="js/jquery.js"></script>
    <script>
        $(document).ready(function () {
            $("#errorMsg").text("");
            $("#lblAllBills").hide();
            $("#loadingBills").show();
            var isAllBills = 1;
            $("#<%=ckAllBills.ClientID%>").attr("checked", "checked");

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



            getName();

            function getName() {

                $.ajax({
                    type: "POST",
                    url: "Engine.asmx/getReportNames",
                    data: "{type:" + 1 + "}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        var result = data.d;
                        $("#reportName").text(result);
                    }
                })
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

                    $("#<%=ddlBeginDate.ClientID%>").append($("<option></option>").val
                         ("").text(""));


                    $.each(result, function (index, item) {

                        $("#<%=ddlBeginDate.ClientID%>").append($("<option></option>").val
                        (item.createDate).text(item.createDate));


                    })

                },
                failure: function (msg) {
                
                },
                error: function (err) {
                    
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
                    $("#calendaritemList").empty();
                    $.each(result, function (index, item) {

                        var content = "<a href='#'  data-who='" + item.calendarItemID + "' id='" + item.calendarItemID + "' data-selected='0' class='list-group-item calitem'>" + item.billPrefix + " " + item.legislationNbr + " | " + item.Motion + "</a>";
                        $(content).hide().appendTo("#calendaritemList").fadeIn();
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

            var itemCount = 0;

            $("#calendaritemList").delegate(".calitem", "click", function (e) {

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


            $("#btnDoReport").click(function () {


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

                if (totItems == totNonSelected) {

                    $("#errorMsg").text("Please select at least one item to continue.");
                    return;
                }



                //Get all array elements into one string. 
                var arrayman = selectedItemsArray.join();
                var SelectAll;
                var VoteDate = $("#<%=ddlBeginDate.ClientID%>").val()

                var motionFilter = $("#ddlMotionfilter option:selected").text();

                alert("Please Note - The Roll Call Transcript Report can take several minutes to load. Please be patient during this process.");

                $.ajax({

                    type: "POST",
                    url: "WebServices/ReportService.asmx/SetTranscriptItems",
                    data: "{Arr:'" + arrayman + "',DateFilter:'" + VoteDate + "',Motion:'"+ motionFilter +"'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        var result = data.d;
                        window.open("RV_RollCallTranscript.aspx");
                    },
                    failure: function (msg) {
                        alert(msg);
                    },
                    error: function (err) {
                        console.log(err);
                    }
                })



            }) // end 'Generate Report' button click



        })
    </script>
    </body>
</html>




   


    

    




