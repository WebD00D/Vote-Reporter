<%@ Page Language="vb" MasterPageFile="~/Content.Master" EnableEventValidation="false" AutoEventWireup="false" CodeBehind="VoterDetails.aspx.vb" Inherits="VoteReporterNEW.VoterDetails" %>

<asp:Content runat="server" ContentPlaceHolderID="PageTitle">Voter History</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="PageSubTitle">
    
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <script type="text/javascript" src="js/jquery.js"></script>
    <script>
        $(document).ready(function () {

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
               
                    //take data and append as list item parameters to be selected by user
                    var result = data.d;
                    $("#MemberList").empty();
                    $.each(result, function (index, item) {

                        var content = "<a href='#' data-who='" + item.MemberId + "' id='" + item.MemberId + "' data-selected='0' class='list-group-item mbritem'>" + item.VotingName + "</a>";
                        $(content).hide().appendTo("#MemberList").fadeIn();
                    })

                },
                failure: function (msg) {
                    alert(msg);
                },
                error: function (err) {
                    alert(err);
                }
            }) //end ajax 
            
       
            $("#MemberList").delegate(".mbritem", "click", function (e) {

                e.preventDefault();

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

            var isAllMembers = 0;

            $("#clearAllMembers").click(function (e) {
                e.preventDefault();
                $('.selectedMem').remove();
                $(".mbritem").removeClass('active');
                isAllMembers = 0;
                $(".mbritem").data("selected", 0);
                $("#<%=ckAllMembers.ClientID%>").attr("checked", false);

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
            

            $("#BillList").delegate(".calitem", "click", function (e) {

                e.preventDefault();
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

            var isAllBills = 0;
            $("#clearAllBills").click(function (e) {

                e.preventDefault();
                $('.selectedBill').remove();
                $(".calitem").removeClass('active');
                isAllBills = 0;
                $(".calitem").data("selected", 0);
                $("#<%=ckAllBills.ClientID%>").attr('checked', false);

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

            $("#btnDoReport").click(function (e) {

                e.preventDefault();

                //if (typeof (me) === 'undefined') {
                //    $("#errorMsg").text("Please select a member to continue.");
                //    return;
                //}

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

                    $("#errorMsg").text("Please select at least one bill to continue.");
                    return;
                }


                var ckYES = false;
                var ckNO = false;
                var ckABSTAIN = false;
                var ckEXC = false;
                var ckABSENT = false;
                var ckNV = false;

                if ($("#<%=ckYea.ClientID%>").is(':checked')) {
                    ckYES = true
                }
                if ($("#<%=ckNay.ClientID%>").is(':checked')) {
                    ckNO = true
                }
                if ($("#<%=ckAbstain.ClientID%>").is(':checked')) {
                    ckABSTAIN = true
                }
                if ($("#<%=ckExc.ClientID%>").is(':checked')) {
                    ckEXC = true
                }
                if ($("#<%=ckAbsent.ClientID%>").is(':checked')) {
                   ckABSENT = true
                }
                if ($("#<%=ckNV.ClientID%>").is(':checked')) {
                    ckNV = true
                }


                var beginDate = $("#<%=ddlBeginDate.ClientID%> option:selected").val();
                var endDate = $("#<%=ddlEndDate.ClientID%> option:selected").val();
                var BillsArray = selectedCalItemsArray.join();
                var MemberArray = selectedMbrItemsArray.join();

                //Order By Code

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
              
                alert(BillsArray);
                alert(MemberArray);
           
                //load members
                $.ajax({

                    type: "POST",
                    url: "WebServices/ReportService.asmx/SetVoterHistoryData",
                    data: "{Members:'" + MemberArray + "',Bills:'" + BillsArray + "',useYeas:'"+ ckYES +"',useNays:'"+ ckNO +"',useAbstain:'"+ ckABSTAIN
                           + "',useExcused:'" + ckEXC + "',useAbsent:'" + ckABSENT + "',useNV:'" + ckNV + "',BeginDate:'" + beginDate + "',EndDate:'" + endDate + "',SortBy:'" + SortBy + "',IsAll:'"+ isAllBills +"'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        window.open("RV_VoterDetails.aspx");
                        location.reload(true);
                    },
                    failure: function (msg) {
                        alert(msg);
                    },
                    error: function (err) {
                        alert(err);
                    }
                }) //end ajax calendar item load

            }) // end button do report

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
                                $("#lblSearchResults").css("color","green");
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


    <%-- <div class="col-lg-7 col-md-7 col-sm-7 ">
                    <h4 style="text-decoration:underline">Member Info</h4>
                    <address>
                        Name: <span id="txtMbrName" style="color:#0d3d99"></span>
                        <br />
                        District Name: <span id="txtDistName" style="color:#0d3d99"></span>
                        <br />
                        District Number: <span id="txtDistNbr" style="color:#0d3d99"></span>
                        <br />
                    </address>
                   </div>
                   
                   <div class="col-lg-5 col-md-5 ">
                       <input type="button" id="btnDoReport" class="btn btn-primary btn-sm btn-block" value="Generate Report" />
                    
                   </div>--%>



    <div class="container">
    <asp:HiddenField ID="calitem" runat="server" />
         <div class="row">
            <div class="col-lg-12">

                <div class="col-lg-2"></div>

                <div class="col-lg-4">
                      <h4>Available Members</h4>
                    <ul class="list-unstyled">
                        <li><asp:CheckBox runat="server" ID="ckAllMembers" CssClass="checkbox-inline" Text="Select All" /></li>
                    </ul>
                    <div id="MemberList" class="list-group" style="overflow-y: scroll; height: 250px"> </div>
                    

                    <h4>Available Bills</h4>
                    <ul class="list-inline">
                        <li><asp:CheckBox runat="server" ID="ckAllBills" CssClass="checkbox-inline" Text="Select All" /></li>
                    </ul>
                     <div id="BillList" class="list-group" style="overflow-y: scroll; height: 265px"> </div>
                </div>
              
                <div class="col-lg-4">
                    
                    

                   <h4>Members to Report <span id="lblAllMem" style="color:#1f7048">(All)</span></h4>
                     <ul class="list-unstyled">
                       
                        <li><a href="#" class="label label-danger" id="clearAllMembers"> Clear Selection </a></li>
                    </ul>
                    <div id="selectedMemberList" class="list-group" style="overflow-y:scroll;height:250px">
                       
                    </div> 


                    <h4 style="padding-top:37px">Bills to Report  <span id="lblAllBills" style="color:#1f7048">(All)</span></h4>
                      <ul class="list-unstyled">
                       
                        <li><a href="#" class="label label-danger" id="clearAllBills"> Clear Selection </a></li>
                    </ul>
                    <div id="selectedBillsList" class="list-group" style="overflow-y:scroll;height:250px">
                       
                    </div> 

                </div>



                <div class="col-lg-2"></div>

                

                <div class="col-lg-12">
                    <div class="col-lg-4 col-lg-offset-2">


                        <div id="Votes" style="height:265px">
                     
                         <h4>Votes to Report</h4>
                        <ul class="list-unstyled">
                            <li id="l1" runat="server"><asp:CheckBox runat="server" ID="ckYea"/><%=_YeaName%></li>
                             <li id="l2" runat="server"><asp:CheckBox runat="server" ID="ckNay"/><%=_NayName%></li>
                             <li id="l3" runat="server"><asp:CheckBox runat="server" ID="ckAbstain"/><%=_AbstainName%></li>
                             <li id="l4" runat="server"><asp:CheckBox runat="server" ID="ckExc"/><%=_ExcName%></li>
                             <li id="l5" runat="server"><asp:CheckBox runat="server" ID="ckAbsent"/><%=_AbsentName%></li>
                             <li id="l6" runat="server"><asp:CheckBox runat="server" ID="ckNV"/><%=_NVName%></li>
                        </ul>
                      
                       
                    </div> 


                        <ul class="list-inline">
                            <li><button id="btnDoReport" class="btn btn-sm btn-primary pull-left"><i class="fa fa-book"></i>  Generate Report</button></li>
            
                            </ul>
                         
                    </div>
                    <div class="col-lg-4">
                          <h4>Subject Search</h4>
                        <asp:TextBox runat="server" ID="txtSearchSubject"  CssClass="form-control"></asp:TextBox>
                        
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

                        <h4>Sort By</h4> 
                        <ul class="list-inline">
                            <li><asp:CheckBox runat="server" ID="ckRCSSort" /> RCS Number</li>
                             <li><asp:CheckBox runat="server" ID="ckLegSort" />  Doc Number</li>
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



</asp:Content>