<%@ Page Language="vb" MasterPageFile="~/Content.Master" AutoEventWireup="false" CodeBehind="RollCallDetails.aspx.vb" Inherits="VoteReporterNEW.RollCallDetails" %>


<asp:Content runat="server" ContentPlaceHolderID="PageTitle">Roll Call Summary</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="PageSubTitle">Select a bill below</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">

    <script src="js/jquery.js"></script>
    <script>

        $(document).ready(function () {

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

                        var content = "<a href='#' id='" + item.calendarItemID + "' data-selected='0' class='list-group-item calitem'>" + item.billPrefix + " " + item.legislationNbr + " | " + item.Motion + "</a>";
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

            var me;

            $("#calendaritemList").delegate(".calitem", "click", function (e) {

                if ($(this).data("selected") == 1) {

                    $(this).removeClass('active');

                    $(this).data("selected", 0);
                    $("#errorMsg").text("");

                } else {

                    $('.calitem').removeClass('active');
                    $(this).addClass('active');

                    $(this).data("selected", 1);
                    me =  $(this).attr('id');
                 
                   
                    
                    $("#errorMsg").text("");
                }

            })//Calendar Item Selector Function

            

            $("#btnDoReport").click(function () {

                //Ajax to call web method that sets calendarId into a session. On successful call back, we will open
                //the report page and on that load, we will use the session calendar id as the parameter we pass in to load the data. 

                $.ajax({

                    type: "POST",
                    url: "WebServices/ReportService.asmx/SetCalendarItem",
                    data: "{CalendarItem:'"+ me +"'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        window.open("RV_RollCallDetails.aspx");

                    },
                    failure: function (msg) {
                        alert(msg);
                    },
                    error: function (err) {
                        alert(err);
                    }
                }) //end ajax calendar item load




            })




        })


    </script>


<div class="container">
    <asp:HiddenField ID="calitem" runat="server" />
        <div class="row">
            <div class="col-lg-12">

                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3"></div>

               <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                <div id="calendaritemList" class="list-group" style="overflow-y:scroll;height:275px">
                      
                     
           
                </div>

                   <div class="col-lg-4 col-md-4 col-sm-4 ">
                     
                   </div>
                    <div class="col-lg-3 col-md-3">
                       
                   </div>
                   <div class="col-lg-5 col-md-5 ">
                       <input type="button" id="btnDoReport" class="btn btn-primary btn-sm btn-block" value="Generate Report" />
                   
                   </div>
                  
                   
               </div>
         
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3"></div>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-12 text-center" style="padding:20px">
               <h3 id="errorMsg" style="color:#c9302c"></h3>
            </div>
        </div>

    </div>

</asp:Content>