<%@ Page Language="vb" MasterPageFile="~/Content.Master" EnableEventValidation="false"  AutoEventWireup="false" CodeBehind="VoterComparison.aspx.vb" Inherits="VoteReporterNEW.VoterComparison" %>


<asp:Content ContentPlaceHolderID="PageTitle" runat="server">Voter Comparison</asp:Content>
<asp:Content ContentPlaceHolderID="PageSubTitle" runat="server"></asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript" src="js/jquery.js"></script>
    <script>
        $(document).ready(function () {

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

                    $("#<%=ddlVoter1.ClientID%>").append($("<option></option>").val(0).html("--Select--"));
                    $("#<%=ddlVoter2.ClientID%>").append($("<option></option>").val(0).html("--Select--"));
                    $("#<%=ddlVoter3.ClientID%>").append($("<option></option>").val(0).html("--Select--"));
                  
                    var result = data.d;
         
                    $.each(result, function (index, item) {
                        
                        $("#<%=ddlVoter1.ClientID%>").append($("<option></option>").val(item.MemberId).html(item.VotingName));
                        $("#<%=ddlVoter2.ClientID%>").append($("<option></option>").val(item.MemberId).html(item.VotingName));
                        $("#<%=ddlVoter3.ClientID%>").append($("<option></option>").val(item.MemberId).html(item.VotingName));
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


            var isAll = 0;
            $("#<%=ckAll.ClientID%>").change(function () {

                if (isAll == 0) {
                    $(".calitem").addClass('active');
                    $(".calitem").data("selected", 1);
                    isAll = 1;
                    
                    $("#errorMsg").text("");
                } else {
                    $(".calitem").removeClass('active');
                    isAll = 0;
                    $(".calitem").data("selected", 0);
                    
                    $("#errorMsg").text("");
                }
            }) //end check all cal items

            $("#clearme").click(function (e) {

                e.preventDefault();
                $('.selectedBill').remove();
                $(".calitem").removeClass('active');
                isAllBills = 0;
                $(".calitem").data("selected", 0);
                $("#<%=ckAll.ClientID%>").attr("checked", false);


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

             var voter1ID = $('#<%=ddlVoter1.ClientID%> option:selected').val();
             var voter2ID = $('#<%=ddlVoter2.ClientID%> option:selected').val();
             var voter3ID = $('#<%=ddlVoter3.ClientID%> option:selected').val();

            
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

                $.ajax({
                    
                    type: "POST",
                    url: "WebServices/ReportService.asmx/SetVoterComparisonDetails",
                    data: "{BillArr:'" + arrayman + "',IsAllBills:'" + SelectAll + "',Voter1ID:'"+ voter1ID +"',Voter2ID:'"+ voter2ID +"',Voter3ID:'"+ voter3ID +"',StartDate:'"+ StartDate +"',EndDate:'"+ EndDate +"',SortBy:'"+ SortBy +"'}",
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



    <div class="container">
   
        <div class="row">
            <div class="col-lg-12 text-left">

               <div class="col-lg-6">
               <h4>Available Bills</h4>
                   <ul class="list-inline">
                      <li><asp:CheckBox ID="ckAll" runat="server" CssClass="checkbox-inline " Text="Select all bills" /></li>
                 </ul>
               <div id="BillList" class="list-group" style="overflow-y:scroll;height:180px"></div>

                 <%--  <h3>Votes to Report</h3>
                        <ul class="list-unstyled">
                            <li id="l1" runat="server"><asp:CheckBox runat="server" ID="ckYea"/><%=_YeaName%></li>
                             <li id="l2" runat="server"><asp:CheckBox runat="server" ID="ckNay"/><%=_NayName%></li>
                             <li id="l3" runat="server"><asp:CheckBox runat="server" ID="ckAbstain"/><%=_AbstainName%></li>
                             <li id="l4" runat="server"><asp:CheckBox runat="server" ID="ckExc"/><%=_ExcName%></li>
                             <li id="l5" runat="server"><asp:CheckBox runat="server" ID="ckAbsent"/><%=_AbsentName%></li>
                             <li id="l6" runat="server"><asp:CheckBox runat="server" ID="ckNV"/><%=_NVName%></li>
                        </ul>--%>
                      
                   <div class="col-lg-6">
                     <h4>Begin Date </h4>
                                <asp:DropDownList CssClass="form-control" runat="server" ID="ddlBeginDate">
                                     
                                </asp:DropDownList>
                    <h4>End Date</h4>
                                <asp:DropDownList CssClass="form-control" runat="server" ID="ddlEndDate"></asp:DropDownList>
                  
                       




                 <h4>Subject Search</h4>
                        <asp:TextBox runat="server" ID="txtSearchSubject"  CssClass="form-control"></asp:TextBox>
                        
                        <label id="lblSearchResults"></label>



                  <h4>Sort By</h4> 
                        <ul class="list-inline">
                            <li><asp:CheckBox runat="server" ID="ckRCSSort" /> RCS Number</li>
                             <li><asp:CheckBox runat="server" ID="ckLegSort" />   Doc Number</li>
                        </ul>
                       
                  </div>
                 <div class="col-lg-6">
                     <h4>Voter 1</h4>
               <asp:DropDownList ID="ddlVoter1" CssClass="form-control" runat="server"></asp:DropDownList>
                <h4>Voter 2</h4>
               <asp:DropDownList ID="ddlVoter2" CssClass="form-control" runat="server"></asp:DropDownList>
                <h4>Voter 3 <small>optional</small></h4>
               <asp:DropDownList ID="ddlVoter3" CssClass="form-control" runat="server"></asp:DropDownList>

                <br />
                      
                    <br />
                <input id="btnDoReport" type="button" class="btn btn-sm btn-primary pull-right" value="Generate Report" /> 
                 </div>

                  


               </div>

                <div class="col-lg-6">
                    <h4>Bills to Report  <span id="lblAllBills" style="color:#1f7048">(All)</span></h4>
                      <ul class="list-unstyled">
                   <li><a id="clearme" class="label label-danger">Clear Selection</a></li> </ul>
                    <div id="selectedBillsList" class="list-group" style="overflow-y:scroll;height:180px"></div> 
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