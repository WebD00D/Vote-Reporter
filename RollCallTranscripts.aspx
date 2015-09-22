<%@ Page Language="vb" MasterPageFile="~/Content.Master" EnableEventValidation="false" AutoEventWireup="false" CodeBehind="RollCallTranscripts.aspx.vb" Inherits="VoteReporterNEW.RollCallTranscripts" %>

<asp:Content runat="server" ContentPlaceHolderID="PageTitle">Roll Call Transcripts</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="PageSubTitle"></asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">

    <script src="js/jquery.js"></script>
    <script>
        $(document).ready(function () {
            $("#errorMsg").text("");
            $("#lblAllBills").hide();


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
                    $("#calendaritemList").empty();
                    $.each(result, function (index, item) {

                        var content = "<a href='#'  data-who='" + item.calendarItemID + "' id='" + item.calendarItemID + "' data-selected='0' class='list-group-item calitem'>" + item.billPrefix + " " + item.legislationNbr + " | " + item.Motion + "</a>";
                        $(content).hide().appendTo("#calendaritemList").fadeIn();
                    })

                },
                failure: function (msg) {
                    alert(msg);
                },
                error: function (err) {
                    alert(err);
                }
            }) //end ajax calendar item load

            var itemCount = 0;
            
            $("#calendaritemList").delegate(".calitem", "click", function (e) {

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
                    } else
                    {
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

              <%--  if ($("#<%=ckAll.ClientID%>").is(':checked')) {
                    SelectAll = true
                  
                } else {
                    SelectAll = false
                  
                }--%>
              
                // TO DO: Pass Values string value to Web Service, and store into a session variable. On successful AJAX, open
                // report page. On that page load Use values from Session variable, and call web service to get all necessary data
                // that goes along with that calendaritemID that is passed in. Returned in ajax, and append each section to report. DONE! 

                var VoteDate = $("#<%=ddlBeginDate.ClientID%>").val()

                //Ajax call that passes the calendar item id's that will need to be used in the generated report. 


                alert("Please Note - The Roll Call Transcript Report can take several minutes to load. Please be patient during this process.");

                $.ajax({

                    type: "POST",
                    url: "WebServices/ReportService.asmx/SetTranscriptItems",
                    data: "{Arr:'" + arrayman + "',DateFilter:'"+ VoteDate +"'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        // erase result , and alert functions after testing. All we need is window.open 
                        var result = data.d;
                      
                        window.open("RV_RollCallTranscript.aspx");


                    },
                    failure: function (msg) {
                        alert(msg);
                    },
                    error: function (err) {
                        alert(err);
                    }
                })



            }) // end 'Generate Report' button click

        <%--    var isAll = 0;
            $("#<%=ckAll.ClientID%>").change(function () {

                if (isAll == 0) {
                    $(".calitem").addClass('active');
                    $(".calitem").data("selected", 1);
                    isAll = 1;
                    alert(isAll);
                    $("#errorMsg").text("");
                } else {
                    $(".calitem").removeClass('active');
                    isAll = 0;
                    $(".calitem").data("selected", 0);
                    alert(isAll);
                    $("#errorMsg").text("");
                }

              

            })--%>

            //$("#clearme").click(function () {

            //    $(".calitem").removeClass('active');
            //    $(".calitem").data("selected", 0);
            //})

        })
    </script>


    <div class="container">
        <div class="row">
            <div class="col-lg-12">

            

                 <div class="col-lg-6">
                     <h4>Available Bills</h4>
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


</asp:Content>

