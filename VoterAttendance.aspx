<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Content.Master" EnableEventValidation="false" CodeBehind="VoterAttendance.aspx.vb" Inherits="VoteReporterNEW.VoterAttendance" %>

<asp:Content runat="server" ContentPlaceHolderID="PageTitle">Member Attendance</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="PageSubTitle"></asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">

    <script src="js/jquery.js"></script>
    <script>
        $(document).ready(function () {


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


                $.ajax({

                    type: "POST",
                    url: "WebServices/ReportService.asmx/SetAttendanceData",
                    data: "{Members:'" + MemberArray + "',StartDate:'"+ StartDate +"',EndDate:'"+ EndDate +"'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {


                        window.open("RV_MemberAttendance.aspx");


                    },
                    failure: function (msg) {
                        alert(msg);
                    },
                    error: function (err) {
                        alert(err);
                    }
                })

            }) //end do report click

        })
    </script>
    <div class="container">
        <div class="row">
            <div class="col-lg-12">

                <div class="col-lg-2"></div>

                <div class="col-lg-4">
                    <h3>Available Members</h3>
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
                            <li><button id="btnDoReport" class="btn btn-sm btn-primary pull-left"><i class="fa fa-book"></i>  Generate Report</button></li>
                              
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