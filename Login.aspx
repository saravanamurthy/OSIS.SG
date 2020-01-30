<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="LMSNamespace.Login" %>

<!DOCTYPE html>

<html lang="en">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" type="image/png" sizes="16x16" href="Images/lms-logo.png">
    <title>OSIS - Online Security Integrated System</title>
    <link href="assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <link href="css/custom.css" rel="stylesheet">
    <link href="css/style.css" rel="stylesheet">
    <link href="css/colors/green.css" id="theme" rel="stylesheet">
    <!--[if lt IE 9]>
    <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js" integrity="sha256-16cdPddA6VdVInumRGo6IbivbERE8p7CQR3HzTBuELA=" crossorigin="anonymous"></script>
    <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js" integrity="sha256-16cdPddA6VdVInumRGo6IbivbERE8p7CQR3HzTBuELA=" crossorigin="anonymous"></script>
<![endif]-->

    <style>
        .login-register {
            background: #ddd;
        }
        #BtnLogin {
            background: none;
            border: none;
            color: #fff;
            width: 100%;
            cursor: pointer;
        }
            #BtnLogin.active, #BtnLogin:focus {
                background: none;
                border: none;
                color: #fff;
            }
        input[type="text"], input[type="password"] {
            text-indent: 15px !important;
        }
        .border-style {
            -webkit-box-shadow: 0px 2px 3px 0px rgba(0,0,0,0.36);
            -moz-box-shadow: 0px 2px 3px 0px rgba(0,0,0,0.36);
            box-shadow: 0px 2px 3px 0px rgba(0,0,0,0.36);
        }
        .form-control {
            min-height: 30px !important;
            font-size: 1rem !important;
        }
        .form-group {
            margin-bottom: 25px !important;
        }
        .btn-lg {
            padding: .75rem 1.5rem !important;
            font-size: 1.25rem !important;
        }
    </style>
    <script type="text/javascript">
        function disableBackButton() {
            window.history.forward();
        }
        setTimeout("disableBackButton()", 0);
    </script>
</head>
<body class="login">

    <div class="preloader">
        <svg class="circular" viewBox="25 25 50 50">
            <circle class="path" cx="50" cy="50" r="20" fill="none" stroke-width="2" stroke-miterlimit="10" />
        </svg>
    </div>
    <form id="form1" runat="server">
        <section id="wrapper">
            <div class="login-register" style="background-image: url(../assets/images/background/login-register00.jpg); padding: 5% 0;">
                <div class="mob-logocenter" style="margin: 0 auto; width: 200px; margin-top: 40px;">
                    <img src="Images/img-logo-main.png" alt="homepage" class="light-logo mob-mainlogo" style="width: 200px;" />
                </div>
                <div class="login-box card" style="margin-top: 15px; width: 350px;">
                    <div class="card-body border-style" method="get">
                        <div class="form-material">
                            <h3 class="box-title mb-3" style="text-align: center;">Sign In</h3>
                            <div class="form-group ">
                                <div class="col-xs-12">
                                    <asp:TextBox ID="TxtCompanyCode" runat="server" placeholder="Company Code" class="form-control  form-control-line" MaxLength="30"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="TxtCompanyCode" ForeColor="Red"
                                        SetFocusOnError="true" Display="Dynamic" ErrorMessage="Please enter company code"
                                        ValidationGroup="Save" Style="font-size: 12px" />
                                    <asp:HiddenField runat="server" ID="HdntokenID" />
                                </div>
                            </div>
                            <div class="form-group ">
                                <div class="col-xs-12">
                                    <asp:TextBox ID="TxtUserId" runat="server" placeholder="Username" class="form-control  form-control-line" MaxLength="30"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="TxtUserId" ForeColor="Red"
                                        SetFocusOnError="true" Display="Dynamic" ErrorMessage="Please enter username"
                                        ValidationGroup="Save" Style="font-size: 12px" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-xs-12">
                                    <asp:TextBox ID="TxtPassword" TextMode="Password" runat="server" placeholder="Password" class="form-control" MaxLength="20"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="TxtPassword" ForeColor="Red"
                                        SetFocusOnError="true" Display="Dynamic" ErrorMessage="Please enter password"
                                        ValidationGroup="Save" Style="font-size: 12px" />
                                </div>
                            </div>
                            <div class="form-group text-center m-t-20" style="margin-bottom: 10px !important">
                                <div class="col-xs-12">
                                    <asp:Button ID="BtnLogin" runat="server" OnClick="BtnLogin_Click" ValidationGroup="Save" Text="LOG IN" CssClass="btn btn-info btn-lg btn-block text-uppercase waves-effect waves-light" />
                                </div>
                            </div>
                            <div class="form-group m-b-0" style="margin-bottom: 10px !important">
                                <div class="col-sm-12 text-center">
                                    <asp:Label ID="lblStatus" runat="server" ForeColor="Red"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <footer class="footer" style="padding: 10px 15px;">© 2018 Online Security Integrated System powered by Awnsys Technologies Pte Ltd. </footer>

        </section>
        <div id="token" style="display: none">
            <asp:HiddenField ID="lbltoken" runat="server"></asp:HiddenField>
        </div>
        <div id="msg" style="display: none"></div>
        <div id="notis" style="display: none"></div>
        <div id="err" style="display: none"></div>

    </form>

    <script src="https://www.gstatic.com/firebasejs/6.4.2/firebase-app.js"></script>
    <script src="firebase-messaging.js"></script>
    <script>
        MsgElem = document.getElementById("msg");
        TokenElem = document.getElementById("lbltoken");
        NotisElem = document.getElementById("notis");
        ErrElem = document.getElementById("err");
        var config = {
            apiKey: "AIzaSyAQmrwirG_czyxQz1bP2ctSX2k4iH7HeOI",
            authDomain: "osiscloudweb.firebaseapp.com",
            databaseURL: "https://osiscloudweb.firebaseio.com",
            projectId: "osiscloudweb",
            storageBucket: "osiscloudweb.appspot.com",
            messagingSenderId: "680693147973",
            appId: "1:680693147973:web:80ab726c66c70956"
        };
        firebase.initializeApp(config);

        if ('serviceWorker' in navigator) {
            navigator.serviceWorker.register('firebase-messaging-sw.js')
            .then(function (registration) {
                console.log('Registration successful, scope is:', registration.scope);
            }).catch(function (err) {
                console.log('Service worker registration failed, error:', err);
            });
        }

        var messaging = firebase.messaging();
        messaging
            .requestPermission()
            .then(function () {
                MsgElem.innerHTML = "Notification permission granted."
                console.log("Notification permission granted.");
                return messaging.getToken()
            })
            .then(function (token) {
                TokenElem.innerHTML = token;
                //alert(token);
                document.getElementById('<%=HdntokenID.ClientID%>').value = token;
            })
            .catch(function (err) {
                ErrElem.innerHTML = ErrElem.innerHTML + "; " + err
                console.log("Unable to get permission to notify.", err);
            });

            messaging.onMessage(function (payload) {
                console.log("Message received. ", payload);
                NotisElem.innerHTML = NotisElem.innerHTML + JSON.stringify(payload)
            });
    </script>
    <script src="assets/plugins/jquery/jquery.min.js"></script>
    <script src="assets/plugins/bootstrap/js/popper.min.js"></script>
    <script src="assets/plugins/bootstrap/js/bootstrap.min.js"></script>
    <script src="js/jquery.slimscroll.js"></script>
    <script src="js/waves.js"></script>
    <script src="js/sidebarmenu.js"></script>
    <script src="assets/plugins/sticky-kit-master/dist/sticky-kit.min.js"></script>
    <script src="js/custom.min.js"></script>
    <script src="assets/plugins/styleswitcher/jQuery.style.switcher.js"></script>
</body>
</html>
