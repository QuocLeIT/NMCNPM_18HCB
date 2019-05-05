<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="QLGym._Default" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="description" content="">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <!-- The above 4 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <!-- Title -->
    <title>Gym Login</title>

    <!-- Favicon -->
    <link rel="icon" href="/Content/img/core-img/favicon.ico">

    <!-- Core Stylesheet -->
    <link rel="stylesheet" href="/Content/style.css">
    <style>
        body {
            background-color: #ecf0f5;
        }

        .cls-content .cls-content-sm, .cls-content .cls-content-lg {
            width: 70%;
            min-width: 270px;
            margin: 0 auto;
            position: relative;
            background-color: transparent;
            border: 0;
            box-shadow: none;
        }
    </style>
</head>

<body>
    <form runat="server">
        <div id="container" class="cls-container">

            <!-- BACKGROUND IMAGE -->
            <!--===================================================-->
            <div id="bg-overlay"></div>


            <!-- LOGIN FORM -->
            <!--===================================================-->
            <div class="cls-content">
                <div class="cls-content-sm panel">
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-12">
                                <div class="contact-form-area">
                                    <div class="row" style="height: 200px"></div>
                                    <div class="row">
                                        <div class="col-4"></div>
                                        <div class="col-4 text-center" style="padding-bottom: 50px">
                                            <h5>Quản lý phòng Gym</h5>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-4"></div>
                                        <div class="col-4 text-center">
                                            <%--<input type="text" class="form-control" id="username" placeholder="Username">--%>
                                            <asp:TextBox runat="server" ID="txtUsername" CssClass="form-control" placeholder="Username"></asp:TextBox>
                                        </div>
                                        <div class="col-4"></div>
                                        <div class="col-4"></div>
                                        <div class="col-4 text-center">
                                            <%--<input type="password" class="form-control" id="password" placeholder="Password">--%>
                                            <asp:TextBox runat="server" ID ="txtPassword" CssClass="form-control" type="password" placeholder="Password"></asp:TextBox>
                                        </div>
                                        <div class="col-12 text-center">
                                            <%--<button class="btn delicious-btn mt-30" type="submit" onclick="Login()">Log in</button>--%>
                                            <asp:Button runat="server" ID="btnLogin" CssClass="btn delicious-btn mt-30" OnClick="btnLogin_Click" Text="Login" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script src="js/jquery/jquery-2.2.4.min.js"></script>
    <!-- Popper js -->
    <script src="js/bootstrap/popper.min.js"></script>
    <!-- Bootstrap js -->
    <script src="js/bootstrap/bootstrap.min.js"></script>
    <!-- All Plugins js -->
    <script src="js/plugins/plugins.js"></script>
    <!-- Active js -->
    <script src="js/active.js"></script>
   <%-- <script>
        function Login() {
            window.location.href = "index.html";
        }
    </script>--%>
</body>

</html>
