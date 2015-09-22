<%@ Page Language="vb" MasterPageFile="~/Content.Master" EnableEventValidation="false" AutoEventWireup="false" CodeBehind="RollCallSummary.aspx.vb" Inherits="VoteReporterNEW.RollCallSummary" %>


<asp:Content runat="server" ContentPlaceHolderID="PageTitle">Roll Call History</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="PageSubTitle"></asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">

    <script src="js/jquery.js"></script>
    <script>
        $(document).ready(function () {
            $("<%=ckAllBills.ClientID%>").attr("checked",false)
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

                },
                failure: function (msg) {
                    alert(msg);
                },
                error: function (err) {
                    alert(err);
                }
            }) //end ajax calendar item load

            var isAllBills = 0;
            $("#clearAllBills").click(function (e) {

                e.preventDefault();
                $('.selectedBill').remove();
                $(".calitem").removeClass('active');
                isAllBills = 0;
                $(".calitem").data("selected", 0);
                $("#<%=ckAllBills.ClientID%>").attr("checked", false);

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
                        data: "{Bills:'" + arrayman + "',StartDate:'" + startDate + "',EndDate:'" + endDate + "',SortBy:'" + SortBy + "',IsAll:'" + isAllBills + "',ckYea:'" + ckYES + "',ckNay:'" + ckNO + "',ckAbstain:'" + ckABSTAIN + "',ckExcused:'" + ckEXC + "',ckAbsent:'" + ckABSENT + "',ckNotVoting:'"+ckNV+"'}",
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


     <div class="container">

         <div class="row">
             <div class="col-lg-12">
                 <a href="#" class="btn btn-primary btn-sm pull-right" data-toggle="modal" data-target="#myModal"><span class="glyphicon glyphicon-info-sign"></span>Need Help?</a>
                 <div class="col-lg-8 col-lg-offset-2">

                     <div class="col-lg-6">
                         <h4>Available Bills</h4>
                         <ul class="list-inline">
                             <li>
                                 <asp:CheckBox runat="server" ID="ckAllBills" CssClass="checkbox-inline" Text="Select All" /></li>
                         </ul>
                         <div id="BillList" class="list-group" style="overflow-y: scroll; height: 265px"></div>


                       
                              <h4>Subject Search</h4>
                        <asp:TextBox runat="server" ID="txtSearchSubject"  CssClass="form-control"></asp:TextBox>
                        
                        <label id="lblSearchResults"></label>

                            <h4>Sort By</h4> 
                        <ul class="list-inline">
                            <li><asp:CheckBox runat="server" ID="ckRCSSort" /> RCS Number</li>
                             <li><asp:CheckBox runat="server" ID="ckLegSort" />   Doc Number</li>
                        </ul>
                                    <div id="Votes" style="height:265px">
                     <br />
                                        
                         <h4>Votes to Report</h4>
                        <ul class="list-unstyled">
                            <li id="l1" runat="server"><asp:CheckBox runat="server" ID="ckYea2"/><%=_YeaName%></li>
                             <li id="l2" runat="server"><asp:CheckBox runat="server" ID="ckNay2"/><%=_NayName%></li>
                             <li id="l3" runat="server"><asp:CheckBox runat="server" ID="ckAbstain2"/><%=_AbstainName%></li>
                             <li id="l4" runat="server"><asp:CheckBox runat="server" ID="ckExc2"/><%=_ExcName%></li>
                             <li id="l5" runat="server"><asp:CheckBox runat="server" ID="ckAbsent2"/><%=_AbsentName%></li>
                             <li id="l6" runat="server"><asp:CheckBox runat="server" ID="ckNV2"/><%=_NVName%></li>
                        </ul>
                      
                       
                    </div> 

                       
                        
                            </div>

                     <div class="col-lg-6">

                         <h4>Bills to Report  <span id="lblAllBills" style="color: #1f7048">(All)</span></h4>
                         <ul class="list-unstyled">

                             <li><a href="#" class="label label-danger" id="clearAllBills">Clear Selection </a></li>
                         </ul>
                         <div id="selectedBillsList" class="list-group" style="overflow-y: scroll; height: 250px">
                         </div>

                         <br />
                         <h4>Select Dates</h4>
                         <div class="col-lg-6">
                            <h4>Begin Date </h4>
                                <asp:DropDownList CssClass="form-control" runat="server" ID="ddlBeginDate">
                                     
                                </asp:DropDownList>
                             </div>
                         <div class="col-lg-6">
                           <h4>End Date</h4>
                                <asp:DropDownList CssClass="form-control" runat="server" ID="ddlEndDate"></asp:DropDownList>


                     



                         </div>

                         <div class="col-lg-12" style="padding-top: 40px">
                             <asp:Button runat="server" ID="btnDoReport" CssClass="btn btn-sm btn-primary" Text="Generate Report" />
                         </div>


                     </div>
                        



                     <div class="col-lg-12 text-center" style="padding: 50px">
                         <h4 id="errMsg" style="color: red"></h4>
                         <h4 id="errMsg2" style="color: red"></h4>
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
                    <h3 class="modal-title" id="myModalLabel">Roll Call Summary Report Help</h3>
                </div>
               
                <div class="col-lg-12 text-left">
                     <h4>Filter Options</h4>
                    <p>
                        To get all available data, simply 'select all' bills and motions, and leave the date filters empty. If you want to look up particular bills select
                        from the list, and check all motions. Vice versa if you want to look up bills by motion. Lastly, to filter by date select both a start and end date.
                    </p>


                    
                </div>
                       
                        
     
                <div class="modal-footer">
                   
                
                    <button type="button" class="btn btn-default" data-dismiss="modal">Okay</button>
                    
                </div>
            </div>
        </div>
    </div>
    <!-- End New User Modal -->
</asp:Content>
