<%@ Page Language="vb" MasterPageFile="~/Content.Master" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="VoteReporterNEW._Default" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content runat="server" ContentPlaceHolderID="PageTitle">Vote Reporter</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="PageSubTitle"></asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">

    <script src="js/jquery.js" type="text/javascript"></script>
    <script>
        $(document).ready(function () {

            if ($("#<%=lnkMemberAttendance.ClientID%>").hasClass("hide")) {

                $("#<%=iAtt.ClientID%>").addClass("hide");
            }
            
            
            if ($("#<%=lnkRCSum.ClientID%>").hasClass("hide")) {

                $("#<%=ircsum.ClientID%>").addClass("hide");
            }

            if ($("#<%=lnkRCTrans.ClientID%>").hasClass("hide")) {

                $("#<%=irctrans.ClientID%>").addClass("hide");
            }

            if ($("#<%=lnkVoterComp.ClientID%>").hasClass("hide")) {

                $("#<%=ivcomp.ClientID%>").addClass("hide");
            }

            if ($("#<%=lnkVoterDetails.ClientID%>").hasClass("hide")) {

                $("#<%=ivdet.ClientID%>").addClass("hide");
            }

            if ($("#<%=lnkVoterStats.ClientID%>").hasClass("hide")) {

                $("#<%=ivstats.ClientID%>").addClass("hide");
            }



        })
    </script>


     <div class="container">
         
                <div class="row">
                    
                        <h2 class="section-heading">Reports</h2>
                    <ul class="list-inline text-center">

                                 
                            <li>
                                <h4>
                                    <asp:HyperLink runat="server" ID="lnkVoterDetails" NavigateUrl="~/VoterDetails.aspx">
                                        <i id="ivdet" style="color: #FFA274" runat="server" class="fa fa-user fa-3x"></i>
                                        <br />
                                        <%=_VoterDetails %>
                                    </asp:HyperLink></h4>
                            </li>

                        <li>
                            <h4>
                                <asp:HyperLink runat="server" ID="lnkVoterStats" NavigateUrl="~/VoterStatistics.aspx">
                                    <i id="ivstats" style="color: #326779" runat="server" class="fa fa-area-chart fa-3x"></i>
                                    <br />
                                    <%=_VoterStats %>
                                </asp:HyperLink></h4>
                        </li>


                        <li>

                            <h4>
                                <asp:HyperLink runat="server" ID="lnkVoterComp" NavigateUrl="~/VoterComparison.aspx">
                                    <i id="ivcomp" style="color: #4F92BF" runat="server" class="fa fa-pie-chart fa-3x"></i>
                                    <br />
                                    <%=_VoterComparison%>
                                </asp:HyperLink></h4>
                        </li>



                        <li>
                            <h4>
                                <asp:HyperLink runat="server" ID="lnkMemberAttendance" NavigateUrl="~/VoterAttendance.aspx">
                                    <i runat="server" id="iAtt" style="color: #7AC292" class="fa fa-check fa-3x"></i>
                                    <br />
                                    <%=_MemberAttendance%>
                                </asp:HyperLink></h4>
                        </li>




                        <li>
                            <h4>
                                <asp:HyperLink runat="server" ID="lnkRCSum" NavigateUrl="~/RollCallSummary.aspx">
                                    <i id="ircsum" style="color: #7089AD" runat="server" class="fa fa-gavel fa-3x"></i>
                                    <br />
                                    <%=_RCSummary %>
                                </asp:HyperLink></h4>
                        </li>

                        <%--               <li> <i id="ircdet" runat="server" class="fa fa-tasks fa-3x"></i>
                           <br />
                              <asp:HyperLink runat="server" ID="lnkRCDet"  NavigateUrl="~/RollCallDetails.aspx"><%=_RCDetails%></asp:HyperLink></li>--%>

                        <li>
                            <h4>
                                <asp:HyperLink runat="server" ID="lnkRCTrans" NavigateUrl="~/RollCallTranscripts.aspx">
                                    <i id="irctrans" style="color: #DB6B71" runat="server" class="fa fa-calendar-o fa-3x"></i>
                                    <br />
                                    <%=_RCTranscript%>
                                </asp:HyperLink></h4>
                        </li>

                    </ul>


                    <div runat="server" id="adminSection">

                        <br />
                        <h2 class="section-heading">Administration
                        </h2>
                        <ul class="list-inline text-center">
                            <li>
                                <h4><a href="UserManagementEditor.aspx">
                                    <i style="color: #5C5956" class="fa fa-users fa-3x"></i>
                                    <br />
                                    User Management</a></h4>
                            </li>

                            <li>
                                <h4><a href="ReportManagementEditor.aspx">
                                    <i style="color: #5C5956" class="fa fa-file fa-3x"></i>
                                    <br />
                                    Report Management</a></h4>
                            </li>

                            <li>
                                <h4><a href="Configuration.aspx">
                                    <i style="color: #5C5956" class="fa fa-wrench fa-3x"></i>
                                    <br />
                                    Configuration</a></h4>
                            </li>
                        </ul>

                    </div>


                </div>

            </div>
            <!-- /.container -->

</asp:Content>