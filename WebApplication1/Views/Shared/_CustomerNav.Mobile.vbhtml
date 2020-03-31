@ModelType  NaviAnywhere.CustomerNavModel


@If Not String.IsNullOrEmpty(Model.CustomerNo) Then
    @Try
            If Model.ShowCustomerName AndAlso Not String.IsNullOrEmpty(Model.CustomerName) Then
                @<h2>Customer - @Model.CustomerName</h2>
            End If
     Catch
     End Try
     
     
    @<nav>
                  @code
                      Html.Kendo.MobileLayout.Name("NaviAnywhere").Header("Header") _
                          .Header(Sub() _
                            Html.Kendo.MobileNavBar.Name("navbar") _
                                   .Content(Sub(navbar)
                        @<text> 
                           @(Html.Kendo.MobileButton _
                                 .Align(MobileButtonAlign.Left) _
                                 .HtmlAttributes(New With {.style = "background-color: green; color: white;"}) _
                                 .Url("Details", "Customer", New With {.CustomerNo = Model.CustomerNo}) _
                                 .Text("Details")) 
                          @(Html.Kendo.MobileButton _
                                .Align(MobileButtonAlign.Left) _
                                .HtmlAttributes(New With {.style = "background-color: green; color: white;"}) _
                                .Url("Index", "SalesOrder", New With {.CustomerNo = Model.CustomerNo}) _
                                .Text("Sales Orders"))
                         @If User.IsInRole("Service Tech") OrElse User.IsInRole("Service Manager") OrElse User.IsInRole("Admin") Then
                                                           @(Html.Kendo.MobileButton _
                                                               .Align(MobileButtonAlign.Left) _
                                                               .HtmlAttributes(New With {.style = "background-color: green; color: white;"}) _
                                                               .Url("Index", "ServiceOrder", New With {.CustomerNo = Model.CustomerNo}) _
                                                               .Text("Service Orders"))
                                                End If
                        @If User.IsInRole("Service Tech") OrElse User.IsInRole("Service Manager") OrElse User.IsInRole("Admin") Then
                                                           @(Html.Kendo.MobileButton _
                                                                 .Align(MobileButtonAlign.Left) _
                                                                 .HtmlAttributes(New With {.style = "background-color: green; color: white;"}) _
                                                                 .Url("Index", "ServiceItem", New With {.CustomerNo = Model.CustomerNo}) _
                                                                 .Text("Service Items"))
                                                End If
                       </text> 
                                            End Sub).Render()).Render()
                                   
     End Code

   </nav>
   End If                                                   