<%@ Page Language="vb"  EnableEventValidation="false"  AutoEventWireup="false" CodeBehind="VoterComparison.aspx.vb" Inherits="VoteReporterNEW.VoterComparison" %>




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
                                <h1 style="color: #2c3e50">Voter History </h1>
                                <h3 style="color: #2c3e50"><span id="lblsessioncode"></span> Session</h3>

                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="container">
               
                <div class="row">
            <div class="col-lg-12 text-left">

               <div class="col-lg-6">
               <h4>Available Bills</h4>
                    <p style="color: #ff6a00" id="loadingBills">Loading Bills...</p>
                   <ul class="list-inline">
                      <li><asp:CheckBox ID="ckAll" runat="server" CssClass="checkbox-inline " Text="Select all bills" /></li>
                 </ul>
               <div id="BillList" class="list-group" style="overflow-y:scroll;height:180px"></div>

            
                        <div class="col-lg-12">
                     <h4>Voter 1</h4>
               <asp:DropDownList ID="ddlVoter1" CssClass="form-control" runat="server"></asp:DropDownList>
                <h4>Voter 2</h4>
               <asp:DropDownList ID="ddlVoter2" CssClass="form-control" runat="server"></asp:DropDownList>
                <h4>Voter 3 <small>optional</small></h4>
               <asp:DropDownList ID="ddlVoter3" CssClass="form-control" runat="server"></asp:DropDownList>
                      <h4>Voter 4 <small>optional</small></h4>
               <asp:DropDownList ID="ddlVoter4" CssClass="form-control" runat="server"></asp:DropDownList>
                      <h4>Voter 5 <small>optional</small></h4>
               <asp:DropDownList ID="ddlVoter5" CssClass="form-control" runat="server"></asp:DropDownList>
                            <h4>Voter 6 <small>optional</small></h4>
               <asp:DropDownList ID="ddlVoter6" CssClass="form-control" runat="server"></asp:DropDownList>
                            <h4>Voter 7 <small>optional</small></h4>
               <asp:DropDownList ID="ddlVoter7" CssClass="form-control" runat="server"></asp:DropDownList>

                <br />
                      
             
                 </div>
                
               

                  


               </div>

                <div class="col-lg-6">
                    <h4>Bills to Report  <span id="lblAllBills" style="color:#1f7048">(All)</span></h4>
                      <ul class="list-unstyled">
                   <li><a id="clearme" class="label label-danger">Clear Selection</a></li> </ul>
                    <div id="selectedBillsList" class="list-group" style="overflow-y:scroll;height:180px"></div> 

                       <div class="col-lg-12">
                     <h4>Begin Date </h4>
                                <asp:DropDownList CssClass="form-control" runat="server" ID="ddlBeginDate">
                                     
                                </asp:DropDownList>
                    <h4>End Date</h4>
                                <asp:DropDownList CssClass="form-control" runat="server" ID="ddlEndDate"></asp:DropDownList>
                  
                       




                 <h4>Subject Search</h4>
                        <asp:TextBox runat="server" ID="txtSearchSubject"  CssClass="form-control"></asp:TextBox>
                        
                        <label id="lblSearchResults"></label>

                                 <h4>Motions</h4>
                        <select id="ddlMotions" class="form-control">
                         
                        </select>




                  <h4>Sort By</h4> 
                        <ul class="list-inline">
                            <li><asp:CheckBox runat="server" ID="ckRCSSort" /> RCS Number</li>
                             <li><asp:CheckBox runat="server" ID="ckLegSort" />   Doc Number</li>
                        </ul>
                                  <br />
                <input id="btnDoReport" type="button" class="btn btn-sm btn-primary pull-left" value="Generate Report" /> 
                       
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
        
    <script type="text/javascript" src="js/jquery.js"></script>
    <script>
        $(document).ready(function () {

            $("#lblAllBills").hide();
            $("#lblSearchResults").text("");
            $("#loadingBills").show();

            $("#<%=ckAll.ClientID%>").attr("checked", "checked");
            var isAll = 1;



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
                    $("#ddlMotions").empty();
                    var emtpyoption = "<option val='NOTHING'> </option>";
                    $(emtpyoption).appendTo("#ddlMotions");
                    $.each(result, function (index, item) {

                        var content = "<option>" + item.Motion + "</option>";
                        $(content).appendTo("#ddlMotions");
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



            $("#lblAllBills").hide();
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





            //Load Members
            $.ajax({

                type: "POST",
                url: "WebServices/ReportService.asmx/LoadMembers",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {

                    $("#<%=ddlVoter1.ClientID%>").empty();
                    $("#<%=ddlVoter2.ClientID%>").empty();
                    $("#<%=ddlVoter3.ClientID%>").empty();
                    $("#<%=ddlVoter4.ClientID%>").empty();
                    $("#<%=ddlVoter5.ClientID%>").empty();
                    $("#<%=ddlVoter6.ClientID%>").empty();
                    $("#<%=ddlVoter7.ClientID%>").empty();

                    $("#<%=ddlVoter1.ClientID%>").append($("<option></option>").val(0).html("--Select--"));
                    $("#<%=ddlVoter2.ClientID%>").append($("<option></option>").val(0).html("--Select--"));
                    $("#<%=ddlVoter3.ClientID%>").append($("<option></option>").val(0).html("--Select--"));
                    $("#<%=ddlVoter4.ClientID%>").append($("<option></option>").val(0).html("--Select--"));
                    $("#<%=ddlVoter5.ClientID%>").append($("<option></option>").val(0).html("--Select--"));
                    $("#<%=ddlVoter6.ClientID%>").append($("<option></option>").val(0).html("--Select--"));
                    $("#<%=ddlVoter7.ClientID%>").append($("<option></option>").val(0).html("--Select--"));

                    var result = data.d;

                    $.each(result, function (index, item) {

                        $("#<%=ddlVoter1.ClientID%>").append($("<option></option>").val(item.MemberId).html(item.VotingName));
                        $("#<%=ddlVoter2.ClientID%>").append($("<option></option>").val(item.MemberId).html(item.VotingName));
                        $("#<%=ddlVoter3.ClientID%>").append($("<option></option>").val(item.MemberId).html(item.VotingName));
                        $("#<%=ddlVoter4.ClientID%>").append($("<option></option>").val(item.MemberId).html(item.VotingName));
                        $("#<%=ddlVoter5.ClientID%>").append($("<option></option>").val(item.MemberId).html(item.VotingName));
                        $("#<%=ddlVoter6.ClientID%>").append($("<option></option>").val(item.MemberId).html(item.VotingName));
                        $("#<%=ddlVoter7.ClientID%>").append($("<option></option>").val(item.MemberId).html(item.VotingName));
                    })

                },
                failure: function (msg) {
                    alert(msg);
                },
                error: function (err) {
                    alert(err);
                }
            }) //end ajax calendar item load


            $("#BillList").delegate(".calitem", "click", function (e) {

                e.preventDefault();

                if (isAll) {
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


          
            $("#<%=ckAll.ClientID%>").change(function () {

                if (isAll == 0) {
                    $(".calitem").addClass('active');
                    $(".calitem").data("selected", 1);
                    isAll = 1;
                    $("#lblAllBills").show();
                    $('.selectedBill').remove();
                    $("#errorMsg").text("");
                } else {
                    $(".calitem").removeClass('active');
                    isAll = 0;
                    $(".calitem").data("selected", 0);
                    $("#lblAllBills").hide();
                    $("#errorMsg").text("");
                }

            }) //end check all cal items

            $("#clearme").click(function (e) {

                e.preventDefault();
                $('.selectedBill').remove();
                $(".calitem").removeClass('active');
                isAll = 0;
                $(".calitem").data("selected", 0);
                $("#<%=ckAll.ClientID%>").attr("checked", false);
                $("#lblAllBills").hide();

             


            })

            var UsingSearchText = false;

            $("#<%=txtSearchSubject.ClientID%>").keyup(function () {

                var key = event.keyCode || event.charCode;
                var SearchText = $("#<%=txtSearchSubject.ClientID%>").val();

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


            $("#btnDoReport").click(function () {

                var MotionFilterString;
                MotionFilterString = $("#ddlMotions option:selected").text()


                var voter1ID = $('#<%=ddlVoter1.ClientID%> option:selected').val();
                var voter2ID = $('#<%=ddlVoter2.ClientID%> option:selected').val();
                var voter3ID = $('#<%=ddlVoter3.ClientID%> option:selected').val();
                var voter4ID = $('#<%=ddlVoter4.ClientID%> option:selected').val();
                var voter5ID = $('#<%=ddlVoter5.ClientID%> option:selected').val();
                var voter6ID = $('#<%=ddlVoter6.ClientID%> option:selected').val();
                var voter7ID = $('#<%=ddlVoter7.ClientID%> option:selected').val();


                if (voter1ID == 0 || voter2ID == 0) {
                    $("#errorMsg").text("Make sure values are selected for voter 1 and 2.");
                    return;
                } else {
                    $("#errorMsg").text("");
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

                if (totItems == totNonSelected) {
                    if (UsingSearchText == false) {
                        $("#errorMsg").text("Please select at least one bill to continue.");
                        return;
                    }
                }

                //Get all array elements into one string. 
                var arrayman = selectedItemsArray.join();

                var SelectAll;

                if ($("#<%=ckAll.ClientID%>").is(':checked')) {
                    SelectAll = true
                } else {
                    SelectAll = false
                }

                var ckYES = false;
                var ckNO = false;
                var ckABSTAIN = false;
                var ckEXC = false;
                var ckABSENT = false;
                var ckNV = false;

                var StartDate = $("#<%=ddlBeginDate.ClientID%>").val();
                var EndDate = $("#<%=ddlEndDate.ClientID%>").val();

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
                    SortBy = "Column1 ASC"
                }
                if (RCSSort == true) {
                    SortBy = "RCSNbr ASC"
                }



                var SessionEndedOn = $("#<%=ddlBeginDate.ClientID%> option:nth-child(2)").val();
                var SessionStartedOn = $("#<%=ddlEndDate.ClientID%> option:nth-last-child(1)").val();


                $.ajax({

                    type: "POST",
                    url: "WebServices/ReportService.asmx/SetVoterComparisonDetails",
                    data: "{BillArr:'" + arrayman + "',IsAllBills:'" + SelectAll + "',Voter1ID:'" + voter1ID + "',Voter2ID:'" + voter2ID + "',Voter3ID:'" + voter3ID + "',Voter4ID:'"+ voter4ID +"',Voter5ID:'"+ voter5ID +"',Voter6ID:'"+ voter6ID +"',Voter7ID:'"+ voter7ID +"',StartDate:'" + StartDate + "',EndDate:'" + EndDate + "',SortBy:'" + SortBy + "',MotionFilter:'"+ MotionFilterString +"',SessionStarted:'"+ SessionStartedOn +"',SessionEnded:'"+ SessionEndedOn +"'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

 

                        // erase result , and alert functions after testing. All we need is window.open 
                        var result = data.d;

                        window.open("RV_VoterComparison.aspx");
                        location.reload(true);

                    },
                    failure: function (msg) {
                        alert(msg);
                    },
                    error: function (err) {
                        alert(err);
                    }
                })
            }) // end do report

        })
    </script>
    </body>

</html>








   


