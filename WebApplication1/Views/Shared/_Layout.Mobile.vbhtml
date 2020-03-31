<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
     <meta charset="utf-8" />
      <meta name="viewport" content="width=device-width" />
        <title>@ViewData("Title") - NaviAnywhere</title>
        <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
     
       @Styles.Render("~/Content/Themes/start/AwesomeMvc.css")
        @Styles.Render("~/Content/Themes/start/Site.css")
        @Styles.Render("~/Content/css")
        @Styles.Render("~/Resources/controls.css")
        @Styles.Render("~/Content/web/css")
       @Styles.Render("~/Content/shared/css")
       
        @Scripts.Render("~/bundles/modernizr")
        @Scripts.Render("~/bundles/jquery")
        @Scripts.Render("~/bundles/jqueryui")
        @Scripts.Render("~/bundles/kendo-mobile")
        @Scripts.Render("~/Scripts/AwesomeMvc.js")
 
    @RenderSection("HeadContent", false)   
</head>
<body>
 @code
     Dim isMobileDevice = Regex.IsMatch(Request.UserAgent, "(blackberry|bb1\\w?;|playbook|meego;\\s*nokia|android|silk|iphone|ipad|ipod|windows phone|Mobile.*Firefox)", RegexOptions.IgnoreCase)

 End Code
    

<header>
 @If Request.IsAuthenticated Then
    @<text>
        @Using Html.BeginForm("LogOff", "Account", FormMethod.Post, New With {.id = "logoutForm"})
            @Html.AntiForgeryToken()
            @<a href="javascript:document.getElementById('logoutForm').submit()"></a>
        End Using
    </text>
End If

 @code
                     Html.Kendo.MobileLayout.Name("NaviAnywhere").Header("Header") _
                     .Header(Sub() _
                     Html.Kendo.MobileNavBar.Name("navbar") _
                     .Content(Sub(navbar)
                        @<text> 
                           @(Html.Kendo.MobileButton _
                           .Align(MobileButtonAlign.Left) _
                           .HtmlAttributes(New With {.style = "background-color: blue; color: white;"}) _
                           .Url("Index", "Home") _
                           .Text("Home")) 
                         @(Html.Kendo.MobileButton _
                           .Align(MobileButtonAlign.Left) _
                           .HtmlAttributes(New With {.style = "background-color: blue; color: white;"}) _
                           .Url("Index", "Customer") _
                           .Text("Customers")) 
                         @(Html.Kendo.MobileButton _
                           .Align(MobileButtonAlign.Left) _
                           .HtmlAttributes(New With {.style = "background-color: blue; color: white;"}) _
                           .Url("Index", "Item") _
                           .Text("Items")) 
                         @(Html.Kendo.MobileButton _
                           .Align(MobileButtonAlign.Left) _
                           .HtmlAttributes(New With {.style = "background-color: blue; color: white;"}) _
                           .Url("Index", "SalesOrder") _
                           .Text("Orders"))
                     @If Request.IsAuthenticated Then
                                                           @(Html.Kendo.MobileButton _
                                                                 .Align(MobileButtonAlign.Left) _
                                                                 .HtmlAttributes(New With {.style = "background-color: blue; color: white;"}) _
                                                                 .Url("javascript:document.getElementById('logoutForm').submit()") _
                                                                 .Text("Logout"))
                                  End If 
                        </text> End Sub).Render()).Render()
                                   
     End Code

                            
                                                                                                                           
                                                                            

<!-- Html.Kendo.MobileBackButton.Align(MobileButtonAlign.Left).HtmlAttributes(New With {.class = "nav-button"}).Text("Orders").Url("Index","SalesOrder") -->

     @RenderBody()    


</header>
    
    
  <footer>
       <div class="content-wrapper">
          <div class="float-left">
               <p>&copy; @DateTime.Now.Year - iCepts Technology Group, Inc.</p>
                </div>
            </div>
  </footer>

        @RenderSection("scripts", False)
       @RenderSection("featured", False)
</body>
</html>
