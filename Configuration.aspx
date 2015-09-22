<%@ Page Language="vb" MasterPageFile="~/Content.Master" AutoEventWireup="false" CodeBehind="Configuration.aspx.vb" Inherits="VoteReporterNEW.Configuration" %>


<asp:Content runat="server" ContentPlaceHolderID="PageTitle">Configuration</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="PageSubTitle"></asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">

   

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
                            <li role="presentation"><a href="#data" aria-controls="settings" role="tab" data-toggle="tab"><h4>Data Control</h4></a></li>
                        </ul>

                    </div>
                </div>

                <div class="col-lg-8 col-lg-offset-2 text-left" style="margin-top:30px">
                    <!-- Tab panes -->
                    <div class="tab-content">
                        <div role="tabpanel" class="tab-pane active" id="account">

                        
                            <div class="col-lg-6"><h4>Government Name</h4><input id="txtGovName" runat="server" class="form-control" /></div>
                            <div class="col-lg-6"><h4>Legislative Body</h4><input id="txtLegName" runat="server" class="form-control" /></div>
                            <div class="col-lg-12" style="margin-top:15px">
                                <div class="col-lg-6">
                                      
                                    <asp:Button runat="server" ID="btnSaveAccountParams" OnClick="btnSaveAccountParams_Click" CssClass="btn btn-sm btn-primary" Text="Save" />
                                   </div>
                                   <div class="col-lg-6">
                                       <h4 id="AccountError"></h4>
                                   </div>
    

                            </div>
                        </div>  <!-- End Account -->
                        <div role="tabpanel" class="tab-pane" id="ui">

                              <div class="col-lg-12" style="margin-top:15px"><h4>Top Navigation Links</h4></div>
                              <div class="col-lg-6"><h5>Link 1 Title</h5><input id="link1name" runat="server" class="form-control" /></div>
                              <div class="col-lg-6"><h5>Link 1 URL</h5><input id="link1url" runat="server" class="form-control" /></div>
                              <div class="col-lg-6"><h5>Link 2 Title</h5><input id="link2name" runat="server" class="form-control" /></div>
                              <div class="col-lg-6"><h5>Link 2 URL</h5><input id="link2url" runat="server" class="form-control" /></div>
                              <div class="col-lg-6"><h5>Link 3 Title</h5><input id="link3name" runat="server" class="form-control" /></div>
                              <div class="col-lg-6"><h5>Link 3 URL</h5><input id="link3url" runat="server" class="form-control" /></div>

                            <div class="col-lg-6"><h5> Login Image</h5>
                                <img src=""  id="imagePreview1" class="img img-responsive" />
                                <asp:fileupload type="file" runat="server"  ID="imguploader1" CssClass="form-control" />

                            </div>

                             <div class="col-lg-6"><h5>Legislative Seal Image</h5>
                                <img src=""  id="imagePreview2" class="img img-responsive" />
                                <asp:fileupload type="file" runat="server"  ID="imguploader2" CssClass="form-control" />

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
                                  <asp:Button runat="server" ID="btnSaveUIDetails" OnClick="btnSaveUIDetails_Click" CssClass="btn btn-sm btn-primary" Text="Save" />
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

                            <div role="tabpanel" class="tab-pane" id="rpt_General">
                                

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

                            <div role="tabpanel" class="tab-pane" id="rpt_Transcript">
                                <div class="col-lg-12" style="margin-top:15px"><h4>Transcript Report Column Headings</h4></div>
                            <div class="col-lg-6"><h5>Clerk / Secretary Name</h5><input id="txtClerkName" runat="server" class="form-control" /></div>
                            <div class="col-lg-6"><h5>Clerk / Secretary Title</h5><input id="txtClerkTitle" runat="server" class="form-control" /></div>

                            <div class="col-lg-6"><h5>Presiding Officer Name</h5><input id="txtPO1Name" runat="server" class="form-control" /></div>
                            <div class="col-lg-6"><h5>Presiding Officer Title</h5><input id="txtPO1Title" runat="server"  class="form-control" /></div>

                            <div class="col-lg-6"><h5>Presiding Officer 2 Name</h5><input id="txtPO2Name" runat="server"  class="form-control" /></div>
                            <div class="col-lg-6"><h5>Presiding Officer 2 Title</h5><input id="txtPO2title" runat="server"  class="form-control" /></div>

                            </div>
                            
                            
                              <div role="tabpanel" class="tab-pane" id="rpt_VoteStats">
                                  
                            <div class="col-lg-12" style="margin-top:15px"><h4>Voter Statistic Report Settings</h4></div>
                            <div class="col-lg-12">
                            <ul class="list-inline">
                                <li><asp:CheckBox ID="ckShowMbrStat" runat="server" /><span> Show Majority Stats</span></li>
                                <li><asp:CheckBox ID="ckShowPartyStat" runat="server"  /><span> Show Party Stats</span></li>
                                <li><asp:CheckBox ID="ckShowVoteTtl" runat="server"  /><span> Show Vote Totals </span></li>
                            </ul>
                            </div>

                              </div>
                            

                       



                            <%-- <div class="col-lg-12" style="margin-top:15px"><h4>Voter Statistics Columns</h4></div>

                            <table class="table table-striped custab">
                                     <thead>
                 
                                         <tr style="color:#0c4378">
                                             <th>Column</th>
                                             <th>Use</th>
                                             <th>Custom Name</th>
                                             <th>Sort Order</th>
                                            
                                            
                                         </tr>
                                     </thead>
                                     <tr>
                                         <td>Member</td>
                                         <td class="text-center"><asp:CheckBox ID="ckUseMember"   runat="server" /></td>
                                         <td><input class="form-control" runat="server" id="txtVSMember" /></td>
                                         <td class="text-center"><input class="form-control" type="number" runat="server" id="txtVSMemberSO" /></td>
                                     </tr>

                                    <tr>
                                         <td>District</td>
                                         <td class="text-center"><asp:CheckBox ID="ckUseDistrict"   runat="server" /></td>
                                         <td><input class="form-control" runat="server" id="txtVSDistrict" /></td>
                                         <td class="text-center"><input class="form-control" type="number" runat="server" id="VSDistrictSO" /></td>
                                     </tr>

                                 <tr>
                                         <td>Total Votes</td>
                                         <td class="text-center"><asp:CheckBox ID="ckUseTotVotes"   runat="server" /></td>
                                         <td><input class="form-control" runat="server" id="txtVSTotalVotes" /></td>
                                         <td class="text-center"><input class="form-control" type="number" runat="server" id="txtTotalVoteSO" /></td>
                                     </tr>
                                   
                                <tr>
                                         <td>Total Eligible Votes</td>
                                         <td class="text-center"><asp:CheckBox ID="ckUseTotElig"   runat="server" /></td>
                                         <td><input class="form-control" runat="server" id="txtVSTotElig" /></td>
                                         <td class="text-center"><input class="form-control" type="number" runat="server" id="VSTotEligSO" /></td>
                                     </tr>

                                <tr>
                                         <td>Member Votes</td>
                                         <td class="text-center"><asp:CheckBox ID="ckUseMbrVotes"   runat="server" /></td>
                                         <td><input class="form-control" runat="server" id="txtMbrVotes" /></td>
                                         <td class="text-center"><input class="form-control" type="number" runat="server" id="MbrVotesSO" /></td>
                                     </tr>

                                   <tr>
                                         <td>Member Votes Percentage</td>
                                         <td class="text-center"><asp:CheckBox ID="ckUseMbrVotesPercent"   runat="server" /></td>
                                         <td><input class="form-control" runat="server" id="txtMbrVotePercent" /></td>
                                         <td class="text-center"><input class="form-control" type="number" runat="server" id="MbrVotePercentSO" /></td>
                                     </tr>

                                <tr>
                                         <td>W/ Majority</td>
                                         <td class="text-center"><asp:CheckBox ID="ckUseWMaj"   runat="server" /></td>
                                         <td><input class="form-control" runat="server" id="txtWMaj" /></td>
                                         <td class="text-center"><input class="form-control" type="number" runat="server" id="WMajSO" /></td>
                                     </tr>

                                <tr>
                                         <td>W/ Majority Percentage</td>
                                         <td class="text-center"><asp:CheckBox ID="ckUseMajPercent"   runat="server" /></td>
                                         <td><input class="form-control" runat="server" id="txtMajPercent" /></td>
                                         <td class="text-center"><input class="form-control" type="number" runat="server" id="MajPercentSO" /></td>
                                     </tr>

                                <tr>
                                         <td>Againts Majority</td>
                                         <td class="text-center"><asp:CheckBox ID="ckUseAgaints"   runat="server" /></td>
                                         <td><input class="form-control" runat="server" id="txtAgaintsMaj" /></td>
                                         <td class="text-center"><input class="form-control" type="number" runat="server" id="AgaintsMajSO" /></td>
                                     </tr>
                                    
                                <tr>
                                         <td>Againts Majority Percentage</td>
                                         <td class="text-center"><asp:CheckBox ID="ckUseAgaintsPercent"   runat="server" /></td>
                                         <td><input class="form-control" runat="server" id="txtAgaintsPercent" /></td>
                                         <td class="text-center"><input class="form-control" type="number" runat="server" id="AgaintsPercentSO" /></td>
                                     </tr>
                                      
                                <tr>
                                         <td>W/ Party</td>
                                         <td class="text-center"><asp:CheckBox ID="ckUseWithParty"   runat="server" /></td>
                                         <td><input class="form-control" runat="server" id="txtWithParty" /></td>
                                         <td class="text-center"><input class="form-control" type="number" runat="server" id="txtWithPartySO" /></td>
                                     </tr>  

                                <tr>
                                         <td>W/ Party Percentage</td>
                                         <td class="text-center"><asp:CheckBox ID="ckUseWithPartyPercent"   runat="server" /></td>
                                         <td><input class="form-control" runat="server" id="txtWPartyPercent" /></td>
                                         <td class="text-center"><input class="form-control" type="number" runat="server" id="WPartyPercentSO" /></td>
                                     </tr>

                                    <tr>
                                         <td>Againts Party</td>
                                         <td class="text-center"><asp:CheckBox ID="ckUseAgaintsParty"   runat="server" /></td>
                                         <td><input class="form-control" runat="server" id="txtAgaintsParty" /></td>
                                         <td class="text-center"><input class="form-control" type="number" runat="server" id="AgstPartySO" /></td>
                                     </tr>

                                <tr>
                                         <td>Againts Party Percentage</td>
                                         <td class="text-center"><asp:CheckBox ID="ckUseAgaintsPartyPercent"   runat="server" /></td>
                                         <td><input class="form-control" runat="server" id="txtAgaintsPArtyPercent" /></td>
                                         <td class="text-center"><input class="form-control" type="number" runat="server" id="AgstPartyPercentSO" /></td>
                                     </tr>

                               
                                     
                                 </table>--%>




                               <div class="col-lg-12" style="margin-top:15px">
                                   <div class="col-lg-6">
                                      
                                       <asp:Button runat="server" OnClick="btnSaveReportData_Click" ID="btnSaveReportData" CssClass="btn btn-sm btn-primary" Text="Save" />
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



                                 <table class="table table-striped custab">
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
                                         <td><input class="form-control" runat="server" id="txtYEA_Name" /></td>
                                         <td class="text-center"><asp:CheckBox ID="ckYEA_IsUsed" Checked="true" Enabled="false" runat="server" /></td>
                                           <td class="text-center"><input runat="server" type="number" id="txtYeaOrder" class="form-control" /></td>
                                         <td class="text-center"><asp:CheckBox ID="ckYEA_IsEligible" Checked="true" Enabled="false" runat="server" /></td>
                                     </tr>
                                     <tr class="info">
                                         <td>Nay</td>
                                           <td class="text-center"><asp:CheckBox ID="ckNAY_Enabled" Checked="true" Enabled="false" runat="server" /></td>
                                         <td><input class="form-control" runat="server" id="txtNAY_Name" /></td>
                                         <td class="text-center"><asp:CheckBox ID="ckNAY_IsUsed" Checked="true" Enabled="false" runat="server" /></td>
                                           <td class="text-center"><input runat="server" type="number" id="txtNayOrder" class="form-control" /></td>
                                         <td class="text-center"><asp:CheckBox ID="ckNAY_IsEligible" Checked="true"  Enabled="false" runat="server" /></td>
                                     </tr>
                                     <tr >
                                         <td>Abstain</td>
                                         <td class="text-center"><asp:CheckBox ID="ckABS_Enabled" runat="server" /></td>
                                         <td><input class="form-control" runat="server" id="txtABS_Name" /></td>
                                          
                                         <td class="text-center"><asp:CheckBox ID="ckABS_IsUsed" runat="server" /></td>
                                           <td class="text-center"><input runat="server" id="txtAbstainOrder" type="number" class="form-control" /></td>
                                         <td class="text-center"><asp:CheckBox ID="ckABS_IsEligible" runat="server" /></td>
                                     </tr>
                                      <tr class="info">
                                         <td>Excused</td>
                                           <td class="text-center"><asp:CheckBox ID="ckEXC_Enabled" runat="server" /></td>
                                         <td><input class="form-control" runat="server" id="txtEXC_Name" /></td>
                                          
                                         <td class="text-center"><asp:CheckBox ID="ckEXC_IsUsed" runat="server" /></td>
                                            <td class="text-center"><input runat="server" id="txtExcOrder" type="number" class="form-control" /></td>
                                         <td class="text-center"><asp:CheckBox ID="ckEXC_IsEligible" runat="server" /></td>
                                     </tr>
                                      <tr>
                                         <td>Absent</td>
                                           <td class="text-center"><asp:CheckBox ID="ckABSENT_Enabled" runat="server" /></td>
                                         <td><input class="form-control" runat="server" id="txtABSENT_Name" /></td>
                                          
                                         <td class="text-center"><asp:CheckBox ID="ckABSENT_IsUsed" runat="server" /></td>
                                            <td class="text-center"><input runat="server" id="txtAbsentOrder" type="number" class="form-control" /></td>
                                         <td class="text-center"><asp:CheckBox ID="ckABSENT_IsEligible" runat="server" /></td>
                                     </tr>
                                      <tr class="info">
                                         <td>Not Voting</td>
                                            <td class="text-center"><asp:CheckBox ID="ckNV_Enabled" runat="server" /></td>
                                         <td><input class="form-control disabled" runat="server" id="txtNV_Name" /></td>
                                         
                                         <td class="text-center"><asp:CheckBox ID="ckNV_IsUsed" runat="server" /></td>
                                          <td class="text-center"><input runat="server" id="txtNVOrder" type="number" class="form-control" /></td>
                                         <td class="text-center"><asp:CheckBox ID="ckNV_IsEnabled" runat="server" /></td>
                                        
                                     </tr>
                                 </table>

                                 <script src="js/jquery.js"></script>
                                 <script>
                                     $(document).ready(function () {
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


                                     })
                                 </script>

                             </div>

                            </div>

                            
                               
                   

                            <div class="col-lg-12" style="margin-top:15px">
                                <asp:Button runat="server" ID="btnSaveDataConfig" OnClick="btnSaveDataConfig_Click" CssClass="btn btn-sm btn-primary" Text="Save" />
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

     <script src="js/jquery.js"></script>

    
    <script type="text/javascript">


  
        $(document).ready(function () {

            //Reset all error message values 
            //$("#dataError").text("");
            //$("#ReportError").text("");
            //$("#AccountError").text("");


            //$("#btnSaveAccountSettings").click(function () {

            //    var gov = $("#txtGovName").val();
            //    var leg = $("#txtLegName").val();

            //    //Update Data Config Parameters
            //    $.ajax({

            //        type: "POST",
            //        url: "WebServices/VRConfigurationService.asmx/SetAccountSettings",
            //        data: "{GovName:'" + gov + "',LegBodyName:'" + leg + "'}",
            //        contentType: "application/json; charset=utf-8",
            //        dataType: "json",
            //        success: function (data) {
            //            var result = data.d;

            //            if (result == true) {
            //                $("#AccountError").css("color", "#26A65B");
            //                $("#AccountError").text("Saved Successfully!");
            //            } else {
            //                $("#AccountError").css("color", "#E74C3C");
            //                $("#AccountError").text("Something went wrong while attempting to save changes. Please check error log for further details.");
            //            }

            //        },
            //        failure: function (msg) {
            //            alert(msg);
            //        },
            //        error: function (err) {
            //            alert(err);
            //        }
            //    }) //end ajax 
            //})




            ////Save Account Settings
            //$("#btnSaveDataSettings").click(function () {

            //    var VRDBName = $("#txtVRDBName").val();
            //    var VRDBCon = $("#txtVRDBCon").val();
            //    var VoteDBName = $("#txtVoteDBName").val();
            //    var VoteDBCon = $("#txtVoteDBName").val();

            //    //Update Data Config Parameters
            //    $.ajax({

            //        type: "POST",
            //        url: "WebServices/VRConfigurationService.asmx/SetDataParameters",
            //        data: "{VRDBName:'" + VRDBName + "',VRDBCon:'" + VRDBCon + "',VoteDBName:'" + VoteDBName + "',VoteDBCon:'" + VoteDBCon + "'}",
            //        contentType: "application/json; charset=utf-8",
            //        dataType: "json",
            //        success: function (data) {
            //            var result = data.d;

            //            if (result == 1) {
            //                $("#dataError").css("color", "#26A65B");
            //                $("#dataError").text("Saved Successfully!");
            //            } else {
            //                $("#dataError").css("color", "#E74C3C");
            //                $("#dataError").text("Something went wrong while attempting to save changes. Please check error log for further details.");
            //            }

            //        },
            //        failure: function (msg) {
            //            alert(msg);
            //        },
            //        error: function (err) {
            //            alert(err);
            //        }
            //    }) //end ajax 

            //})




            //$("#btnSaveReportParams").click(function () {

            //    var RCS = $("#txtRCS").val();
            //    var BillNbr = $("#txtBillNbr").val();
            //    var Motion = $("#txtMotion").val();
            //    var DateTime = $("#txtDateTime").val();
            //    var VoteTot = $("#txtVoteTot").val();
            //    var Results = $("#txtResults").val();
            //    var PartyTot = $("#txtPartyTotals").val();
            //    var Outcome = $("#txtOutcome").val();
            //    var Member = $("#txtMember").val();
            //    var DistrictName = $("#txtDistrictName").val();
            //    var DistrictNumber = $("#txtDistrictNbr").val();

            //    var PresName1 = $("#txtPO1Name").val();
            //    var PresTitle1 = $("#txtPO1Title").val();
            //    var PresName2 = $("#txtPO2Name").val();
            //    var PresTitle2 = $("#txtPO2title").val();
            //    var ClerkName = $("#txtClerkName").val();
            //    var ClerkTitle = $("#txtClerkTitle").val();

            //    //Update Report Parameters
            //    $.ajax({

            //        type: "POST",
            //        url: "WebServices/VRConfigurationService.asmx/SetReportParameters",
            //        data: "{RCS:'" + RCS + "',BillNbr:'" + BillNbr + "',Motion:'" + Motion + "',DateTime:'" + DateTime + "',VoteTotals:'" + VoteTot
            //                + "',Results:'" + Results + "',PartyTotals:'" + PartyTot + "',Outcome:'" + Outcome + "',Member:'" + Member + "',DistrictName:'" + DistrictName
            //                + "',DistrictNumber:'" + DistrictNumber + "',PresName1:'" + PresName1 + "',PresTitle1:'" + PresTitle1 + "',PresName2:'" + PresName2 + "',PresTitle2:'" + PresTitle2
            //                + "',ClerkName:'" + ClerkName + "',ClerkTitle:'" + ClerkTitle + "'}",


            //        contentType: "application/json; charset=utf-8",
            //        dataType: "json",
            //        success: function (data) {
            //            var result = data.d;

            //            if (result == true) {
            //                $("#ReportError").css("color", "#26A65B");
            //                $("#ReportError").text("Saved Successfully!");
            //            } else {
            //                $("#ReportError").css("color", "#E74C3C");
            //                $("#ReportError").text("Something went wrong while attempting to save changes. Please check error log for further details.");
            //            }
                        
            //            window.location.reload(true);

            //        },
            //        failure: function (msg) {
            //            alert(msg);
            //        },
            //        error: function (err) {
            //            alert(err);
            //        }
            //    }) //end ajax 
            //}) //end report param function


           


          
          



        }) // end doc ready
    </script>
    <!--New User Modal -->
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
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
</asp:Content>

