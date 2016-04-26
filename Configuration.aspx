<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Configuration.aspx.vb" Inherits="VoteReporterNEW.Configuration" %>






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
                            <a href="default.aspx"><i class="fa fa-home"></i> Home</a>
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



    <%--                                      <asp:DropDownList ID="ddlSession"  CssClass="form-control" runat="server">
                              
                                      </asp:DropDownList>--%>
                                 <%--<span class="input-group-addon"><asp:LinkButton runat="server"><i class="fa fa-refresh"></i></asp:LinkButton></span>--%>

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

             <div class="ContentArea" style="background-color:white;">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="contentMessage" style="margin-top: 25px">
                            <h1 style="color:#2c3e50"> Vote Reporter Configuration</h1>
                            <h3 style="color:#2c3e50"><span id="lblsessioncode"></span> Session</h3>
                            <br />
                            <div class="col-lg-6 col-lg-offset-3" style="color:#2c3e50">

                                Create a new session configuration by filling in the parameters below, or optionally selecting
                                    a previously configured session from the dropdown list. 

                                                                           <br /><br />
                                       <asp:DropDownList runat="server" ID="dlCopyFromCurrentSession" CssClass="form-control">
                                        <asp:ListItem>--  --</asp:ListItem>
                                        <asp:ListItem>-- 131st General Assembly --</asp:ListItem>
                                         </asp:DropDownList>

                                 <br />
                            <asp:LinkButton ID="btnSaveAllConfigSettings" runat="server" CssClass="btn btn-lg btn-success"><i class="fa fa-save"></i> Save Settings</asp:LinkButton>
                            <br />
                            <br />
                            <asp:Label ID="lblConfigurationErrorMessage" runat="server" ForeColor="Red"></asp:Label>
                            </div>
                             
                           
                        </div>
                    </div>
                </div>
            </div>
            <!-- /.container -->


                 <div class="container">

        <div class="row">
            <div class="col-lg-12">
                <h4 style="color:#ff0000" runat="server" id="GenericErrorLabel" class="text-center"></h4>
                <br />
                <br />
                <div class="col-lg-8 col-lg-offset-2">
                    <div role="tabpanel">

                        <!-- Nav tabs -->
                        <ul class="nav nav-tabs list-inline" role="tablist">
                            <li role="presentation" class="active"><a href="#account" aria-controls="home" role="tab" data-toggle="tab"><h4>Account Settings</h4></a></li>
                            <li role="presentation"><a href="#ui" aria-controls="profile" role="tab" data-toggle="tab"><h4>User Interface</h4></a></li>
                            <li role="presentation"><a href="#rparam" aria-controls="messages" role="tab" data-toggle="tab"><h4>Report Parameters</h4></a></li>
                            <li role="presentation"><a href="#data" aria-controls="settings" role="tab" data-toggle="tab"><h4>Vote Mapping</h4></a></li>
                        </ul>

                    </div>
                </div>

                <div class="col-lg-8 col-lg-offset-2 text-left" style="margin-top:30px">
                    <!-- Tab panes -->
                    <div class="tab-content">
                        <div role="tabpanel" class="tab-pane active" id="account" style="color:#2c3e50">

                        
                            <div class="col-lg-6"><h4>Government Name</h4><asp:TextBox id="txtGovName" runat="server" cssclass="form-control" /></div>
                            <div class="col-lg-6"><h4>Legislative Body</h4><asp:TextBox id="txtLegName" runat="server" cssclass="form-control" /></div>
                            <div class="col-lg-12" style="margin-top:15px">
                                <div class="col-lg-6">
                                   
                                    <asp:Button runat="server" ID="btnSaveAccountParams" OnClick="btnSaveAccountParams_Click" CssClass="btn btn-sm btn-primary hidden" Text="Save" />
                                   </div>
                                   <div class="col-lg-6">
                                       <h4 id="AccountError"></h4>
                                   </div>
    

                            </div>
                        </div>  <!-- End Account -->
                        <div role="tabpanel" class="tab-pane" id="ui" style="color:#2c3e50">

                              <div class="col-lg-12" style="margin-top:15px"><h4>Top Navigation Links</h4></div>
                              <div class="col-lg-6"><h5>Link 1 Title</h5><input id="link1name" runat="server" class="form-control" /></div>
                              <div class="col-lg-6"><h5>Link 1 URL</h5><input id="link1url" runat="server" class="form-control" /></div>
                              <div class="col-lg-6"><h5>Link 2 Title</h5><input id="link2name" runat="server" class="form-control" /></div>
                              <div class="col-lg-6"><h5>Link 2 URL</h5><input id="link2url" runat="server" class="form-control" /></div>
                              <div class="col-lg-6"><h5>Link 3 Title</h5><input id="link3name" runat="server" class="form-control" /></div>
                              <div class="col-lg-6"><h5>Link 3 URL</h5><input id="link3url" runat="server" class="form-control" /></div>


                              <div class="col-lg-6"><h5>Legislative Seal Image</h5>
                                <img src=""  id="imagePreview2" class="img img-responsive" />
                                <asp:fileupload type="file" runat="server"  ID="imguploader2" CssClass="form-control" />

                            </div>

                            <div class="col-lg-6 hidden"><h5> Login Image</h5>
                                <img src=""  id="imagePreview1" class="img img-responsive" />
                                <asp:fileupload type="file" runat="server"  ID="imguploader1" CssClass="form-control" />

                            </div>

                           
                           
                            <script src="js/jquery.js"></script>
                            <script type="text/javascript">
                                $(document).ready(function () { //image preview code

                                    $("#<%=imguploader1.ClientID%>").change(function () {

                                        readURL1(this);
                                    })

                                    $("#<%=imguploader2.ClientID%>").change(function () {
                                        readURL2(this);
                                    })


                                    function readURL1(input) {
                                        if (input.files && input.files[0]) {
                                            var reader1 = new FileReader();

                                            reader1.onload = function (e) {

                                                $('#imagePreview1').attr('src', e.target.result);

                                            }

                                            reader1.readAsDataURL(input.files[0]);
                                        }
                                    }

                                    function readURL2(input) {
                                        if (input.files && input.files[0]) {
                                            var reader1 = new FileReader();

                                            reader1.onload = function (e) {
                                                $('#imagePreview2').attr('src', e.target.result);
                                            }

                                            reader1.readAsDataURL(input.files[0]);
                                        }
                                    }

                                    //end img preview
                                })

                            </script>


                              <div class="col-lg-12" style="margin-top:15px">
                                  <asp:Button runat="server" ID="btnSaveUIDetails" OnClick="btnSaveUIDetails_Click" CssClass="hidden btn btn-sm btn-primary" Text="Save" />
                                 </div>

                        </div>  <!-- End UI -->

                        <div role="tabpanel" class="tab-pane" id="rparam">


                    <%--     <div role="tabpanel">
                        <!-- Nav tabs -->
                            <ul class="nav nav-tabs list-inline" role="tablist">
                            <li role="presentation" class="active"><a href="#rpt_General" aria-controls="home" role="tab" data-toggle="tab"><h4>General Settings</h4></a></li>
                            <li role="presentation"><a href="#rpt_Transcript" aria-controls="profile" role="tab" data-toggle="tab"><h4>Transcript Settings</h4></a></li>
                            <li role="presentation"><a href="#rparam" aria-controls="messages" role="tab" data-toggle="tab"><h4>Report Parameters</h4></a></li>
                          
                            </ul>
                            </div>--%>

                            <div role="tabpanel" class="tab-pane" id="rpt_General" style="color:#2c3e50">
                                

                            <div class="col-lg-12" style="margin-top:15px"><h4>General Report Column Headings</h4></div>

                            <div class="col-lg-6"><h5>RCS Number</h5><input id="txtRCS" runat="server" class="form-control" /></div>
                            <div class="col-lg-6"><h5>Bill Number </h5><input id="txtBillNbr" runat="server" class="form-control" /></div>

                            <div class="col-lg-6"><h5>Motion</h5><input id="txtMotion" runat="server" class="form-control" /></div>
                            <div class="col-lg-6"><h5>Date/Time</h5><input id="txtDateTime" runat="server" class="form-control" /></div>

                             <div class="col-lg-6"><h5>Vote Totals</h5><input id="txtVoteTot" runat="server" class="form-control" /></div>
                            <div class="col-lg-6"><h5>Results</h5><input id="txtResults" runat="server" class="form-control" /></div>

                            <div class="col-lg-6"><h5>Party Totals</h5><input id="txtPartyTotals" runat="server" class="form-control" /></div>
                            <div class="col-lg-6"><h5>Outcome</h5><input id="txtOutcome" runat="server" class="form-control" /></div>

                             <div class="col-lg-6"><h5>District Name</h5><asp:RadioButton ID="rbDName" runat="server" ForeColor="#ff6600" Font-Italic="true" GroupName="District" Text="Show in report" /><input id="txtDistrictName" runat="server" class="form-control" /></div>
                            <div class="col-lg-6"><h5>District Number</h5><asp:RadioButton ID="rbDNbr" runat="server" ForeColor="#ff6600" Font-Italic="true" GroupName="District" Text="Show in report" /><input id="txtDistrictNbr" runat="server" class="form-control" /></div>

                            <div class="col-lg-6"><h5>Member Title</h5><input id="txtMember" runat="server" class="form-control" /></div>

                             <div class="col-lg-6"><h5>Motion Column Mapping</h5>  <asp:DropDownList runat="server" ID="ddlMotion1" CssClass="form-control">
                                    <asp:ListItem Value="Default">--</asp:ListItem>
                                    <asp:ListItem Value="1">CALDATAFIELD01</asp:ListItem>
                                    <asp:ListItem Value="2">CALDATAFIELD02</asp:ListItem>
                                    <asp:ListItem Value="3">CALDATAFIELD03</asp:ListItem>
                                    <asp:ListItem Value="4">CALDATAFIELD04</asp:ListItem>
                                    <asp:ListItem Value="5">CALDATAFIELD05</asp:ListItem>
                                    <asp:ListItem Value="6">CALDATAFIELD06</asp:ListItem>
                                    <asp:ListItem Value="7">CALDATAFIELD07</asp:ListItem>
                                    <asp:ListItem Value="8">CALDATAFIELD08</asp:ListItem>
                                    <asp:ListItem Value="9">CALDATAFIELD09</asp:ListItem>
                                    <asp:ListItem Value="10">CALDATAFIELD10</asp:ListItem>
                                    <asp:ListItem Value="11">CALDATAFIELD11</asp:ListItem>
                                    <asp:ListItem Value="12">CALDATAFIELD12</asp:ListItem>
                                    <asp:ListItem Value="13">CALDATAFIELD13</asp:ListItem>
                                    <asp:ListItem Value="14">CALDATAFIELD14</asp:ListItem>
                                    <asp:ListItem Value="15">CALDATAFIELD15</asp:ListItem>
                                    <asp:ListItem Value="16">CALDATAFIELD16</asp:ListItem>
                                    <asp:ListItem Value="17">CALDATAFIELD17</asp:ListItem>
                                    <asp:ListItem Value="18">CALDATAFIELD18</asp:ListItem>
                                    <asp:ListItem Value="19">CALDATAFIELD19</asp:ListItem>
                                    <asp:ListItem Value="20">CALDATAFIELD20</asp:ListItem>
                                </asp:DropDownList>  </div>

                                <div class="col-lg-6"><h5>Subject Field Mapping 1</h5>  <asp:DropDownList runat="server" ID="ddlSubjects1" CssClass="form-control">
                                    <asp:ListItem Value="Default">--</asp:ListItem>
                                    <asp:ListItem Value="1">CALDATAFIELD01</asp:ListItem>
                                    <asp:ListItem Value="2">CALDATAFIELD02</asp:ListItem>
                                    <asp:ListItem Value="3">CALDATAFIELD03</asp:ListItem>
                                    <asp:ListItem Value="4">CALDATAFIELD04</asp:ListItem>
                                    <asp:ListItem Value="5">CALDATAFIELD05</asp:ListItem>
                                    <asp:ListItem Value="6">CALDATAFIELD06</asp:ListItem>
                                    <asp:ListItem Value="7">CALDATAFIELD07</asp:ListItem>
                                    <asp:ListItem Value="8">CALDATAFIELD08</asp:ListItem>
                                    <asp:ListItem Value="9">CALDATAFIELD09</asp:ListItem>
                                    <asp:ListItem Value="10">CALDATAFIELD10</asp:ListItem>
                                    <asp:ListItem Value="11">CALDATAFIELD11</asp:ListItem>
                                    <asp:ListItem Value="12">CALDATAFIELD12</asp:ListItem>
                                    <asp:ListItem Value="13">CALDATAFIELD13</asp:ListItem>
                                    <asp:ListItem Value="14">CALDATAFIELD14</asp:ListItem>
                                    <asp:ListItem Value="15">CALDATAFIELD15</asp:ListItem>
                                    <asp:ListItem Value="16">CALDATAFIELD16</asp:ListItem>
                                    <asp:ListItem Value="17">CALDATAFIELD17</asp:ListItem>
                                    <asp:ListItem Value="18">CALDATAFIELD18</asp:ListItem>
                                    <asp:ListItem Value="19">CALDATAFIELD19</asp:ListItem>
                                    <asp:ListItem Value="20">CALDATAFIELD20</asp:ListItem>
                                </asp:DropDownList>  </div>

                                <div class="col-lg-6"><h5>Subject Field Mapping 2</h5>  <asp:DropDownList runat="server" ID="ddlSubjects2" CssClass="form-control">
                                    <asp:ListItem Value="Default">--</asp:ListItem>
                                    <asp:ListItem Value="1">CALDATAFIELD01</asp:ListItem>
                                    <asp:ListItem Value="2">CALDATAFIELD02</asp:ListItem>
                                    <asp:ListItem Value="3">CALDATAFIELD03</asp:ListItem>
                                    <asp:ListItem Value="4">CALDATAFIELD04</asp:ListItem>
                                    <asp:ListItem Value="5">CALDATAFIELD05</asp:ListItem>
                                    <asp:ListItem Value="6">CALDATAFIELD06</asp:ListItem>
                                    <asp:ListItem Value="7">CALDATAFIELD07</asp:ListItem>
                                    <asp:ListItem Value="8">CALDATAFIELD08</asp:ListItem>
                                    <asp:ListItem Value="9">CALDATAFIELD09</asp:ListItem>
                                    <asp:ListItem Value="10">CALDATAFIELD10</asp:ListItem>
                                    <asp:ListItem Value="11">CALDATAFIELD11</asp:ListItem>
                                    <asp:ListItem Value="12">CALDATAFIELD12</asp:ListItem>
                                    <asp:ListItem Value="13">CALDATAFIELD13</asp:ListItem>
                                    <asp:ListItem Value="14">CALDATAFIELD14</asp:ListItem>
                                    <asp:ListItem Value="15">CALDATAFIELD15</asp:ListItem>
                                    <asp:ListItem Value="16">CALDATAFIELD16</asp:ListItem>
                                    <asp:ListItem Value="17">CALDATAFIELD17</asp:ListItem>
                                    <asp:ListItem Value="18">CALDATAFIELD18</asp:ListItem>
                                    <asp:ListItem Value="19">CALDATAFIELD19</asp:ListItem>
                                    <asp:ListItem Value="20">CALDATAFIELD20</asp:ListItem>
                                </asp:DropDownList>  </div>
                            <br />
                            <br />
                            </div> 

                            <div role="tabpanel" class="tab-pane" id="rpt_Transcript" style="color:#2c3e50">
                                <div class="col-lg-12" style="margin-top:15px"><h4>Transcript Report Column Headings</h4></div>
                            <div class="col-lg-6"><h5>Clerk / Secretary Name</h5><input id="txtClerkName" runat="server" class="form-control" /></div>
                            <div class="col-lg-6"><h5>Clerk / Secretary Title</h5><input id="txtClerkTitle" runat="server" class="form-control" /></div>

                            <div class="col-lg-6"><h5>Presiding Officer Name</h5><input id="txtPO1Name" runat="server" class="form-control" /></div>
                            <div class="col-lg-6"><h5>Presiding Officer Title</h5><input id="txtPO1Title" runat="server"  class="form-control" /></div>

                            <div class="col-lg-6"><h5>Presiding Officer 2 Name</h5><input id="txtPO2Name" runat="server"  class="form-control" /></div>
                            <div class="col-lg-6"><h5>Presiding Officer 2 Title</h5><input id="txtPO2title" runat="server"  class="form-control" /></div>

                            </div>
                            
                            
                              <div role="tabpanel" class="tab-pane" id="rpt_VoteStats" style="color:#2c3e50">
                                  
                            <div class="col-lg-12" style="margin-top:15px"><h4>Voter Statistic Report Settings</h4></div>
                            <div class="col-lg-12">
                            <ul class="list-inline">
                                <li><asp:CheckBox ID="ckShowMbrStat" runat="server" /><span> Show Majority Stats</span></li>
                                <li><asp:CheckBox ID="ckShowPartyStat" runat="server"  /><span> Show Party Stats</span></li>
                                <li><asp:CheckBox ID="ckShowVoteTtl" runat="server"  /><span> Show Vote Totals </span></li>
                            </ul>
                            </div>

                                      <div class="col-lg-12" style="margin-top:15px"><h4>Additional Report Settings</h4></div>
                            <div class="col-lg-12">
                            <ul class="list-inline">
                                <li><asp:CheckBox ID="ckOptionalAttendance" runat="server" /><span> Show Optional Attendance Report</span></li>
                                <li><asp:CheckBox ID="ckOptionalVoterStats" runat="server"  /><span> Show Optional Voter Stats Reports</span></li>
                                <li><asp:CheckBox ID="ckOptionalPartyTotals" runat="server"  /><span> Show Optional Party Totals </span></li>
                            </ul>
                            </div>

                              </div>
                            
                               <div class="col-lg-12" style="margin-top:15px">
                                   <div class="col-lg-6">
                                      
                                       <asp:Button runat="server" OnClick="btnSaveReportData_Click" ID="btnSaveReportData" CssClass="hidden btn btn-sm btn-primary" Text="Save" />
                                   </div>
                                   <div class="col-lg-6">
                                       <h4 id="ReportError"></h4>
                                   </div>
                                   

                               </div>

                        </div>  <!-- End Param -->
                        <div role="tabpanel" class="tab-pane" id="data">


                            <div class="col-lg-12 hidden">
                                <div class="col-lg-12" style="margin-top: 15px">
                                        <h4>Vote Reporter Database</h4>
                                    </div>
                                <div class="col-lg-6">
                                    
                                    <h5>Name</h5>
                                    <input id="txtVRDBName" runat="server" class="form-control" />

                                    <h5>User ID</h5>
                                    <input id="txtVRDBUser" runat="server" class="form-control" />

                                </div>
                                <div class="col-lg-6">
                                    
                                    <h5>Server</h5>
                                    <input id="txtVRDBServer" runat="server" class="form-control" />

                                    <h5>Password</h5>
                                    <input id="txtVRDBPass"  runat="server" class="form-control" />

                                </div>
        
                            </div>
                            <div class="col-lg-12 hidden">
                                 <div class="col-lg-12" style="margin-top: 15px">
                                        <h4>XmLegislator Voting Database</h4>
                                    </div>
                                 <div class="col-lg-6">

                                   
                                    <h5>Name</h5>
                                    <input id="txtVoteDBName" runat="server" class="form-control" />

                                    <h5>User ID</h5>
                                    <input id="txtVoteDBUser" runat="server" class="form-control" />
                                </div>
                                <div class="col-lg-6">

                                    
                                    <h5>Server</h5>
                                    <input id="txtVoteDBServer" runat="server" class="form-control" />

                                    <h5>Password</h5>
                                    <input id="txtVoteDBPass"  runat="server" class="form-control" />
                                </div>

                            </div>


                            <div class="col-lg-12">
                                <div class="col-lg-12" style="margin-top:15px"><h4></h4></div>
                                <div class="col-lg-6">
                                    
                              
                               
                            </div>
                                <div class="col-lg-6">
                                    
                              
                           <%--     <asp:DropDownList runat="server" ID="ddlMotion2" CssClass="form-control">
                                    <asp:ListItem Value="Default">--</asp:ListItem>
                                    <asp:ListItem Value="CALDATAFIELD01">CALDATAFIELD01</asp:ListItem>
                                    <asp:ListItem Value="CALDATAFIELD02">CALDATAFIELD02</asp:ListItem>
                                    <asp:ListItem Value="CALDATAFIELD03">CALDATAFIELD03</asp:ListItem>
                                    <asp:ListItem Value="CALDATAFIELD04">CALDATAFIELD04</asp:ListItem>
                                    <asp:ListItem Value="CALDATAFIELD05">CALDATAFIELD05</asp:ListItem>
                                    <asp:ListItem Value="CALDATAFIELD06">CALDATAFIELD06</asp:ListItem>
                                    <asp:ListItem Value="CALDATAFIELD07">CALDATAFIELD07</asp:ListItem>
                                    <asp:ListItem Value="CALDATAFIELD08">CALDATAFIELD08</asp:ListItem>
                                    <asp:ListItem Value="CALDATAFIELD09">CALDATAFIELD09</asp:ListItem>
                                    <asp:ListItem Value="CALDATAFIELD10">CALDATAFIELD10</asp:ListItem>
                                    <asp:ListItem Value="CALDATAFIELD11">CALDATAFIELD11</asp:ListItem>
                                    <asp:ListItem Value="CALDATAFIELD12">CALDATAFIELD12</asp:ListItem>
                                    <asp:ListItem Value="CALDATAFIELD13">CALDATAFIELD13</asp:ListItem>
                                    <asp:ListItem Value="CALDATAFIELD14">CALDATAFIELD14</asp:ListItem>
                                    <asp:ListItem Value="CALDATAFIELD15">CALDATAFIELD15</asp:ListItem>
                                    <asp:ListItem Value="CALDATAFIELD16">CALDATAFIELD16</asp:ListItem>
                                    <asp:ListItem Value="CALDATAFIELD17">CALDATAFIELD17</asp:ListItem>
                                    <asp:ListItem Value="CALDATAFIELD18">CALDATAFIELD18</asp:ListItem>
                                    <asp:ListItem Value="CALDATAFIELD19">CALDATAFIELD19</asp:ListItem>
                                    <asp:ListItem Value="CALDATAFIELD20">CALDATAFIELD20</asp:ListItem>
                                </asp:DropDownList>--%>
                            </div>
                            </div>




                            <div class="col-lg-12">
                                 <div class="col-lg-12" style="margin-top:15px"><h4>Vote Type Mapping </h4></div>
                             
                             <div class="col-lg-12">



                                 <table class="table table-striped custab" style="color:#34495e">
                                     <thead>
                                         <a href="#" class="btn btn-primary btn-sm pull-right" data-toggle="modal" data-target="#myModal"><span class="glyphicon glyphicon-info-sign"></span> Need Help?</a>
                          
                                         
                                         
                                         <tr>
                                             <th>Type</th>
                                              <th>Enabled</th>
                                             <th>Custom Name</th>
                                              <th>Use</th>
                                             <th>Sort Order</th>
                                             <th class="text-center">Eligble</th>
                                            
                                         </tr>
                                     </thead>
                                     <tr>
                                         <td>Yea</td>
                                         <td class="text-center"><asp:CheckBox ID="ckYEA_Enabled" Checked="true" Enabled="false" runat="server" /></td>
                                         <td><asp:textbox cssclass="form-control" runat="server" id="txtYEA_Name" />
                                         </td>
                                         <td class="text-center"><asp:CheckBox ID="ckYEA_IsUsed" Checked="true" Enabled="false" runat="server" /></td>
                                           <td class="text-center"><asp:TextBox runat="server" type="number" id="txtYeaOrder" cssclass="form-control" /></td>
                                         <td class="text-center"><asp:CheckBox ID="ckYEA_IsEligible" Checked="true" Enabled="false" runat="server" /></td>
                                     </tr>
                                     <tr class="info">
                                         <td>Nay</td>
                                           <td class="text-center"><asp:CheckBox ID="ckNAY_Enabled" Checked="true" Enabled="false" runat="server" /></td>
                                         <td><asp:TextBox cssclass="form-control" runat="server" id="txtNAY_Name" /></td>
                                         <td class="text-center"><asp:CheckBox ID="ckNAY_IsUsed" Checked="true" Enabled="false" runat="server" /></td>
                                           <td class="text-center"><asp:TextBox runat="server" type="number" id="txtNayOrder" cssclass="form-control" /></td>
                                         <td class="text-center"><asp:CheckBox ID="ckNAY_IsEligible" Checked="true"  Enabled="false" runat="server" /></td>
                                     </tr>
                                     <tr >
                                         <td>Abstain</td>
                                         <td class="text-center"><asp:CheckBox ID="ckABS_Enabled" runat="server" /></td>
                                         <td><input class="form-control" runat="server" id="txtABS_Name" /></td>
                                          
                                         <td class="text-center"><asp:CheckBox ID="ckABS_IsUsed" runat="server" /></td>
                                           <td class="text-center"><asp:TextBox runat="server" id="txtAbstainOrder" type="number" cssclass="form-control" /></td>
                                         <td class="text-center"><asp:CheckBox ID="ckABS_IsEligible" runat="server" /></td>
                                     </tr>
                                      <tr class="info">
                                         <td>Excused</td>
                                           <td class="text-center"><asp:CheckBox ID="ckEXC_Enabled" runat="server" /></td>
                                         <td><input class="form-control" runat="server" id="txtEXC_Name" /></td>
                                          
                                         <td class="text-center"><asp:CheckBox ID="ckEXC_IsUsed" runat="server" /></td>
                                            <td class="text-center"><asp:TextBox runat="server" id="txtExcOrder" type="number" cssclass="form-control" /></td>
                                         <td class="text-center"><asp:CheckBox ID="ckEXC_IsEligible" runat="server" /></td>
                                     </tr>
                                      <tr>
                                         <td>Absent</td>
                                           <td class="text-center"><asp:CheckBox ID="ckABSENT_Enabled" runat="server" /></td>
                                         <td><asp:textBox cssclass="form-control" runat="server" id="txtABSENT_Name" /></td>
                                          
                                         <td class="text-center"><asp:CheckBox ID="ckABSENT_IsUsed" runat="server" /></td>
                                            <td class="text-center"><asp:TextBox runat="server" id="txtAbsentOrder" type="number" cssclass="form-control" /></td>
                                         <td class="text-center"><asp:CheckBox ID="ckABSENT_IsEligible" runat="server" /></td>
                                     </tr>
                                      <tr class="info">
                                         <td>Not Voting</td>
                                            <td class="text-center"><asp:CheckBox ID="ckNV_Enabled" runat="server" /></td>
                                         <td><asp:TextBox cssclass="form-control disabled" runat="server" id="txtNV_Name" /></td>
                                         
                                         <td class="text-center"><asp:CheckBox ID="ckNV_IsUsed" runat="server" /></td>
                                          <td class="text-center"><asp:TextBox runat="server" id="txtNVOrder" type="number" cssclass="form-control" /></td>
                                         <td class="text-center"><asp:CheckBox ID="ckNV_IsEnabled" runat="server" /></td>
                                        
                                     </tr>
                                 </table>

                                 

                             </div>

                            </div>

                            
                               
                   

                            <div class="col-lg-12" style="margin-top:15px">
                                <asp:Button runat="server" ID="btnSaveDataConfig" OnClick="btnSaveDataConfig_Click" CssClass="hidden btn btn-sm btn-primary" Text="Save" />
                            </div>
                            
                            <div class="col-lg-12" style="margin-top:15px"><h4 style="color:#26A65B" id="dataError"></h4></div>
                            

                        </div>  <!-- End Data -->
                    </div>

                    
                </div>

              
                
            </div>
            <!-- End main col-lg-12-->
        </div>
    </div>
    <!-- /.container -->
    <!--New User Modal -->
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="color:#34495e">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h3 class="modal-title" id="myModalLabel">Vote Value Mapping Help</h3>
                </div>
               
                <div class="col-lg-12 text-left">
                     <h4>Enabling / Disabling Vote Values</h4>
                    <p>By selecting, you are setting that vote value to be used in the reports. Keep in mind that this
                        effects member statistics in voting, and total number shown for votes cast.
                    </p>


                    <h4>Custom Naming</h4>
                    <p>This is where you can set your own naming conventions for each vote type that you want to see in a report.
                        If you leave the field blank, it will default to the text value under 'Type' column heading.
                    </p>

                    <h4>Using in Reports</h4>
                    <p>By checking 'Use', you are allowing that vote type to be viewed and categorized in all of the reports. Note
                        that 'Yes' and 'No' votes are always counted.
                    </p>

                    <h4>Sort Order</h4>
                    <p>This is where you set the order of appearance on the report from left to right. Setting a value of 1 will
                        have the specified value appear first, and if set to 6 will have the value appear last. To use sort order, you must
                        make sure that you have checked 'Use' for the vote type you wish to set.
  
                    </p>


                    <h4>Setting Eligible</h4>
                    <p>By setting a vote type as eligible, the checked vote will be used in calculating member statistics. The vote value
                        must be enabled in order to use this setting.
                    </p>
                </div>
                       
                        
     
                <div class="modal-footer">
                   
                
                    <button type="button" class="btn btn-default" data-dismiss="modal">Okay</button>
                    
                </div>
            </div>
        </div>
    </div>
    <!-- End New User Modal -->

        </div>

    </form>
</body>
</html>

    

 <script src="js/jquery.js"></script>
 <script src="js/bootstrap.min.js"></script>
 <script type="text/javascript">

     $(document).ready(function () {


         // -----------------BASE PAGE FUNCTIONS START ------------------//


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
                         var optiontag = "<option id=" + item.sessionID + " value=" + item.sessionID + ">" + item.legislatureName + "</option>";
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



         // -----------------BASE PAGE FUNCTIONS START ------------------//




            //get current session settings.
            $.ajax({ //first call to set nav bar links and titles
                type: "POST",
                url: "Engine.asmx/GetBaseVoteReporterData",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var result = data.d;
                    $.each(result, function (index, item) {
                      
                        $("#<%=txtGovName.ClientID%>").val(item.governmentName);
                        $("#<%=txtLegName.ClientID%>").val(item.legislatureName);

                        $("#<%=link1name.ClientID%>").val(item.link1Name);
                        $("#<%=link2name.ClientID%>").val(item.link2Name);
                        $("#<%=link3name.ClientID%>").val(item.link3Name);

                        $("#<%=link1url.ClientID%>").val(item.link1URL);
                        $("#<%=link2url.ClientID%>").val(item.link2URL);
                        $("#<%=link3url.ClientID%>").val(item.link3URL);

                        $("#<%=txtRCS.ClientID%>").val(item.rcsNbrTitle);
                        $("#<%=txtBillNbr.ClientID%>").val(item.billNbrTitle);
                        $("#<%=txtMotion.ClientID%>").val(item.motionTitle);
                        $("#<%=txtDateTime.ClientID%>").val(item.dateTimeTitle);
                        $("#<%=txtVoteTot.ClientID%>").val(item.voteTotalTitle);
                        $("#<%=txtResults.ClientID%>").val(item.resultsTitle);
                        $("#<%=txtOutcome.ClientID%>").val(item.outcomeTitle);
                        $("#<%=txtPartyTotals.ClientID%>").val(item.partyTotalsTitle);
                        $("#<%=txtMember.ClientID%>").val(item.memberTitle);
                        $("#<%=txtDistrictName.ClientID%>").val(item.districtNameTitle);
                        $("#<%=txtDistrictNbr.ClientID%>").val(item.districtNbrTitle);

                        $("#<%=txtPO1Name.ClientID%>").val(item.presidingOfficer1Name);
                        $("#<%=txtPO1Title.ClientID%>").val(item.presidingOfficer1Title);
                        $("#<%=txtPO2Name.ClientID%>").val(item.presidingOfficer2Name);
                        $("#<%=txtPO2title.ClientID%>").val(item.presidingOfficer2Title);
                        $("#<%=txtClerkName.ClientID%>").val(item.clerkSecretaryName);
                        $("#<%=txtClerkTitle.ClientID%>").val(item.clerkSecretaryTitle);
                        
                        $("#<%=rbDName.ClientID%>").prop("checked", item.showDistrictName);
                        $("#<%=rbDNbr.ClientID%>").prop("checked", item.showDistrictNbr);
                        $("#<%=ckShowMbrStat.ClientID%>").prop("checked", item.showMajorityStats);
                        $("#<%=ckShowPartyStat.ClientID%>").prop("checked", item.showPartyStats);
                        $("#<%=ckShowVoteTtl.ClientID%>").prop("checked", item.showVotingStats);
                        $("#<%=ckOptionalAttendance.ClientID%>").prop("checked", item.showOptionalAttendance);
                        $("#<%=ckOptionalVoterStats.ClientID%>").prop("checked", item.showOptionalStats);
                        $("#<%=ckOptionalPartyTotals.ClientID%>").prop("checked", item.showOptionalPartyTotals);

                        $("#<%=ddlMotion1.ClientID%>").val(item.motionDataField);
                        $("#<%=ddlSubjects1.ClientID%>").val(item.subjectDataField1);
                        $("#<%=ddlSubjects2.ClientID%>").val(item.subjectDataField2);
                      
                        $("#<%=ckYEA_Enabled.ClientID%>").prop("checked",item.yeaEnabled);
                        $("#<%=txtYEA_Name.ClientID%>").val(item.yeaNamesAs);
                        $("#<%=ckYEA_IsUsed.ClientID%>").prop("checked",item.yeaIsUsed);
                        $("#<%=ckYEA_IsEligible.ClientID%>").prop("checked",item.yeaIsEligible);
                        $("#<%=txtYeaOrder.ClientID%>").val(item.yeaHeaderOrder)
                        
                        $("#<%=ckNAY_Enabled.ClientID%>").prop("checked", item.nayEnabled);
                        $("#<%=txtNAY_Name.ClientID%>").val(item.nayNamesAs);
                        $("#<%=ckNAY_IsUsed.ClientID%>").prop("checked", item.nayIsUsed);
                        $("#<%=ckNAY_IsEligible.ClientID%>").prop("checked", item.nayIsEligible);
                        $("#<%=txtNayOrder.ClientID%>").val(item.nayHeaderOrder)

                        $("#<%=ckABS_Enabled.ClientID%>").prop("checked", item.abstainEnabled);
                        $("#<%=txtABS_Name.ClientID%>").val(item.abstainNamesAs);
                        $("#<%=ckABS_IsUsed.ClientID%>").prop("checked", item.abstainIsUsed);
                        $("#<%=ckABS_IsEligible.ClientID%>").prop("checked", item.abstainIsEligible);
                        $("#<%=txtAbstainOrder.ClientID%>").val(item.abstainHeaderOrder)
                       
                        $("#<%=ckEXC_Enabled.ClientID%>").prop("checked", item.excusedEnabled);
                        $("#<%=txtEXC_Name.ClientID%>").val(item.excusedNamesAs);
                        $("#<%=ckEXC_IsUsed.ClientID%>").prop("checked", item.excusedIsUsed);
                        $("#<%=ckEXC_IsEligible.ClientID%>").prop("checked", item.excusedIsEligible);
                        $("#<%=txtExcOrder.ClientID%>").val(item.excusedHeaderOrder)
                       
                        $("#<%=ckABSENT_Enabled.ClientID%>").prop("checked", item.absentEnabled);
                        $("#<%=txtABSENT_Name.ClientID%>").val(item.absentNamesAs);
                        $("#<%=ckABSENT_IsUsed.ClientID%>").prop("checked", item.absentIsUsed);
                        $("#<%=ckABSENT_IsEligible.ClientID%>").prop("checked", item.absentIsEligible);
                        $("#<%=txtAbsentOrder.ClientID%>").val(item.absentHeaderOrder)

                        $("#<%=ckNV_Enabled.ClientID%>").prop("checked", item.notVotingEnabled);
                        $("#<%=txtNV_Name.ClientID%>").val(item.notVotingNamesAs);
                        $("#<%=ckNV_IsUsed.ClientID%>").prop("checked", item.notVotingIsUsed);
                        $("#<%=ckNV_IsEnabled.ClientID%>").prop("checked", item.notVotingIsEligible);
                        $("#<%=txtNVOrder.ClientID%>").val(item.notVotingHeaderOrder)


                    })
                }
            })


         






         //Not Voting
         $("#<%=ckNV_Enabled.ClientID%>").change(function () {

             if ($(this).is(':checked')) {

                 $("#<%=txtNV_Name.ClientID%>").removeAttr("disabled");
                 $("#<%=ckNV_IsUsed.ClientID%>").removeAttr("disabled");
                 $("#<%=ckNV_IsEnabled.ClientID%>").removeAttr("disabled");

             } else {

                 $("#<%=txtNV_Name.ClientID%>").attr("disabled", "disabled");
                 $("#<%=ckNV_IsUsed.ClientID%>").prop('checked', false);
                 $("#<%=ckNV_IsUsed.ClientID%>").attr("disabled", "disabled");
                 $("#<%=ckNV_IsEnabled.ClientID%>").prop('checked', false);
                 $("#<%=ckNV_IsEnabled.ClientID%>").attr("disabled", "disabled");
             }

         }) //end Not Voting Enabled

         //Absent 
         $("#<%=ckABSENT_Enabled.ClientID%>").change(function () {

             if ($(this).is(':checked')) {
                 $("#<%=txtABSENT_Name.ClientID%>").removeAttr("disabled");
                 $("#<%=ckABSENT_IsUsed.ClientID%>").removeAttr("disabled");
                 $("#<%=ckABSENT_IsEligible.ClientID%>").removeAttr("disabled");

             } else {
                 $("#<%=txtABSENT_Name.ClientID%>").attr("disabled", "disabled");
                 $("#<%=ckABSENT_IsUsed.ClientID%>").prop('checked', false);
                 $("#<%=ckABSENT_IsUsed.ClientID%>").attr("disabled", "disabled");
                 $("#<%=ckABSENT_IsEligible.ClientID%>").prop('checked', false);
                 $("#<%=ckABSENT_IsEligible.ClientID%>").attr("disabled", "disabled");
             }


         }) // end Absent

         //Excused
         $("#<%=ckEXC_Enabled.ClientID%>").change(function () {

             if ($(this).is(':checked')) {
                 $("#<%=txtEXC_Name.ClientID%>").removeAttr("disabled");
                 $("#<%=ckEXC_IsUsed.ClientID%>").removeAttr("disabled");
                 $("#<%=ckEXC_IsEligible.ClientID%>").removeAttr("disabled");

             } else {
                 $("#<%=txtEXC_Name.ClientID%>").attr("disabled", "disabled");
                 $("#<%=ckEXC_IsUsed.ClientID%>").prop('checked', false);
                 $("#<%=ckEXC_IsUsed.ClientID%>").attr("disabled", "disabled");
                 $("#<%=ckEXC_IsEligible.ClientID%>").prop('checked', false);
                 $("#<%=ckEXC_IsEligible.ClientID%>").attr("disabled", "disabled");
             }


         }) // End Excused


         //Abstain
         $("#<%=ckABS_Enabled.ClientID%>").change(function () {

             if ($(this).is(':checked')) {
                 $("#<%=txtABS_Name.ClientID%>").removeAttr("disabled");
                 $("#<%=ckABS_IsUsed.ClientID%>").removeAttr("disabled");
                 $("#<%=ckABS_IsEligible.ClientID%>").removeAttr("disabled");

             } else {
                 $("#<%=txtABS_Name.ClientID%>").attr("disabled", "disabled");
                 $("#<%=ckABS_IsUsed.ClientID%>").prop('checked', false);
                 $("#<%=ckABS_IsUsed.ClientID%>").attr("disabled", "disabled");
                 $("#<%=ckABS_IsEligible.ClientID%>").prop('checked', false);
                 $("#<%=ckABS_IsEligible.ClientID%>").attr("disabled", "disabled");
             }

         }) // End Abstain



        }) // end doc ready
    </script>



