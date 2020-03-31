@ModelType  NaviAnywhere.CustomerNavModel

@Html.HiddenFor(Function(m) m.CustomerNo)

@If Not String.IsNullOrEmpty(Model.CustomerNo) Then
    @Try
            If Model.ShowCustomerName AndAlso Not String.IsNullOrEmpty(Model.CustomerName) Then
                @<h2>Customer - @Model.CustomerName</h2>
            End If
     Catch
     End Try
     
     
    @<nav>
                        <ul id="menu">
                            <li>@Html.ActionLink("Details", "Details", "Customer", New With {.CustomerNo = Model.CustomerNo}, Nothing)</li>
                          @If User.IsInRole("Salesperson") OrElse User.IsInRole("Admin") OrElse User.IsInRole("Sales Manager") OrElse User.IsInRole("Customer") Then
                             @If Not User.IsInRole("Customer") Then
                                 @<li>@Html.ActionLink("Quotes", "Index", "SalesQuote", New With {.CustomerNo = Model.CustomerNo}, Nothing)</li>
                             End If
                             @<li>@Html.ActionLink("Orders", "Index", "SalesOrder", New With {.CustomerNo = Model.CustomerNo}, Nothing)</li>
                          End If
                              @If User.IsInRole("Salesperson") OrElse User.IsInRole("Admin") OrElse User.IsInRole("Sales Manager") OrElse User.IsInRole("Customer") Then
                             @<li>@Html.ActionLink("Ledgers", "Index", "CustomerLedger", New With {.CustomerNo = Model.CustomerNo}, Nothing)</li>
                          End If

                         @*   @If User.IsInRole("Service Tech") OrElse User.IsInRole("Service Manager") OrElse User.IsInRole("Admin") Then
                               @<li>@Html.ActionLink("Service Orders", "Index", "ServiceOrder", New With {.CustomerNo = Model.CustomerNo}, Nothing)</li>
                               @<li>@Html.ActionLink("Service Items", "Index", "ServiceItem", New With {.CustomerNo = Model.CustomerNo}, Nothing)</li>
                            End If*@
                         </ul>
   </nav>
End If