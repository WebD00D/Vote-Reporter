<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Content.Master" CodeBehind="ReportManagementEditor.aspx.vb" Inherits="VoteReporterNEW.ReportManagementEditor" %>

<asp:Content runat="server" ContentPlaceHolderID="PageTitle">Report Management</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="PageSubTitle"></asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">

    <script src="js/jquery.js"></script>
    <script>
        $(document).ready(function () {

            $("#name").attr("disabled", "disabled");
            $("#<%=ddlAccessLevel.ClientID%>").attr("disabled", "disabled");
            $("#<%=ddlUseReport.ClientID%>").attr("disabled", "disabled");
            
            //load report types 
            $.ajax({

                type: "POST",
                url: "WebServices/ReportManagementService.asmx/LoadReportTypes",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {

                    //take data and append as list item parameters to be selected by user
                    var result = data.d;
                    $("#reportTypes").empty();
                    $.each(result, function (index, item) {

                        var content = "<a href='#' id='" + item.ID + "' data-rtype='" + item.ID + "'   data-type='" + item.Type + "' data-selected='0'  data-isUsed='" + item.IsUsed + "'  data-name='" + item.Name + "' data-access=" + item.MinAccess + " class='list-group-item reportz'>" + item.Name + "</a>";
                        $(content).hide().appendTo("#reportTypes").fadeIn();
                    })

                },
                failure: function (msg) {
                    alert(msg);
                },
                error: function (err) {
                    alert(err);
                }
            }) //end ajax 

            
            $("#btnEdit").click(function () {
                $("#name").removeAttr("disabled");
                $("#<%=ddlAccessLevel.ClientID%>").removeAttr("disabled");
                $("#<%=ddlUseReport.ClientID%>").removeAttr("disabled");
            })


            var SelectedOne;
       

            $("#reportTypes").delegate(".reportz", "click", function (e) {

              
                if ($(this).data("selected") == 1) {

                    $(this).removeClass('active');
                    $(this).data("selected", 0);

                    $("#name").val("");
                    $("#type").val("");
                    $("#<%=ddlAccessLevel.ClientID%>").val("Default");
                    $("#<%=ddlUseReport.ClientID%>").val("Default");
               
                    


                } else {

                    $(".reportz").removeClass('active');
                    $(this).addClass('active');
                    $(this).data("selected", 1);

                    var dataUSED = ($(this).attr('data-IsUsed'));

                    

                    if (dataUSED == 0) {
                        $("#<%=ddlUseReport.ClientID%>").val("0");
                    } else
                    {
                        $("#<%=ddlUseReport.ClientID%>").val("1");
                    }
                  
                  <%--  switch (dataUSED) {

                        case 1:
                            // Is used
                            $("#<%=ddlUseReport.ClientID%>").val("1");
                            break;
                        case 2:
                            //Hide
                            $("#<%=ddlUseReport.ClientID%>").val("0");
                            break;
                    }
                  --%>

             

                    switch ($(this).data("access")) {

                        case 1:
                            //Admin
                            $("#<%=ddlAccessLevel.ClientID%>").val("1");
                            break;
                        case 2:
                            //Standard
                            $("#<%=ddlAccessLevel.ClientID%>").val("2");
                            break;
                        case 3:
                            //Public 
                            $("#<%=ddlAccessLevel.ClientID%>").val("3");
                            break;
                   
                    }

                  
                  
                    

                    $("#name").val($(this).data("name"));
                    $("#type").val($(this).data("type"));
                    SelectedOne = $(this).data("rtype");
                  

                }

            })


            $("#btnSaveChanges").click(function () {
              
                var newName = $("#name").val();
                var access = $("#<%=ddlAccessLevel.ClientID%> option:selected").val();
                var UseReport = $("#<%=ddlUseReport.ClientID%>").val();
                
              
                

                if ($("#<%=ddlAccessLevel.ClientID%> option:selected").val() == "Default" || $.trim(newName) == "") {
                    alert("Please make sure you have selected a report and all fields are filled out completely.");
                    return;
                }


                $.ajax({

                    type: "POST",
                    url: "WebServices/ReportManagementService.asmx/EditReportDetails",
                    data: "{Name:'" + newName + "',AccessLevel:'" + access + "',ID:'" + SelectedOne + "',UseReport:'"+ UseReport  +"'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        location.reload(true);

                    },
                    failure: function (msg) {
                        alert(msg);
                    },
                    error: function (err) {
                        alert(err);
                    }
                }) //end ajax 

                




            })








        })
    </script>


     <div class="container">

                <div class="row">
                    <div class="col-lg-12">
                   
                        <div class="col-lg-4 col-lg-offset-1">
                            <div id="reportTypes" class="list-group">
                              
                            </div>
                        </div>


                    <div class="col-lg-6">

                        <div class="col-lg-6">
                               <h4>Name</h4>
                            <input class="form-control" id="name" placeholder="Report Name" />
                         
                        </div>
                         <div class="col-lg-6">
                              <h4>Type</h4>
                              <input class="form-control" id="type" disabled="disabled" placeholder="Report Type" />
                        </div>
                      

                      <div class="col-lg-6">
                                <h4>Minimum Access Level</h4>
                         <asp:DropDownList ID="ddlAccessLevel"  CssClass="form-control" runat="server">
                        
                      </asp:DropDownList>
                       
                          <br />
                          <ul class="list-inline">

                              <li> <input type="button" value="Edit" class="btn btn-sm btn-danger" id="btnEdit"></li>
                               <li> <input type="button" value="Save Changes" id="btnSaveChanges" class="btn btn-sm btn-primary"></li>
                              <li><h4 runat="server" id="successMsg" style="color:#0fa34d"></h4></li>
                          </ul>
                         
                      </div>

                    <div class="col-lg-6">
                        <h4>Use Report</h4>
                        <asp:DropDownList ID="ddlUseReport" CssClass="form-control" runat="server">
                            <asp:ListItem Value="Default">---</asp:ListItem>
                            <asp:ListItem Value="1">Yes</asp:ListItem>
                            <asp:ListItem Value="0">No</asp:ListItem>
                        </asp:DropDownList>

                    </div>
                      

                  
                    </div>


                     
                    
                    </div>
                    
                </div>

            </div>
            <!-- /.container -->

</asp:Content>
