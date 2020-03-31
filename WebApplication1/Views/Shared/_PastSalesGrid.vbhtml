@code
    Html.Kendo.Grid(Of NaviAnywhere.NavODataService.SalesInvoiceLine) _
        .Name("PastSalesGrid") _
         .Columns(Sub(c)
                          c.Command(Function(l) l.Custom("Add").Click("PastSalesAdd"))
                          c.Bound(Function(l) l.No)
                          c.Bound(Function(l) l.Description)
                          c.Bound(Function(l) l.Quantity)
                          c.Bound(Function(l) l.Unit_Price).Format("{0:c}").ClientFooterTemplate("<div>Total:</div>")
                          c.Bound(Function(l) l.Amount).Format("{0:c}").ClientFooterTemplate("<div>#= kendo.toString(sum, 'C') #</div>")
                          c.Bound(Function(l) l.Posting_Date).Format("{0:MM/dd/yy}")
                          c.Bound(Function(l) l.Availability).ClientTemplate(Html.ActionLink("#=Availability#", "Drilldown", Nothing, New With {.onClick = "onClickInventory('#=No#'); return false;"}).ToHtmlString)
                  End Sub) _
         .DataSource(Sub(d)
                             d.Ajax _
                              .ServerOperation(True) _
                              .PageSize(20) _
                              .Sort(Sub(s) s.Add("Posting_Date").Descending()) _
                             .Model(Sub(m)
                                            m.Field(Function(l) l.No).Editable(False)
                                            m.Field(Function(l) l.Description).Editable(False)
                                            m.Field(Function(l) l.Quantity).Editable(False)
                                            m.Field(Function(l) l.Unit_Price).Editable(False)
                                            m.Field(Function(l) l.Amount).Editable(False)
                                            m.Field(Function(l) l.Posting_Date).Editable(False)
                                            m.Field(Function(l) l.Availability).Editable(False)
                                    End Sub) _
                              .Aggregates(Sub(Aggregate)
                                                  Aggregate.Add(Function(p) p.Amount).Sum()
                                          End Sub) _
                              .Read(Function(r) r.Action("PastSalesLines_Read", "SalesInvoice", New With {.CustomerNo = Model.SelltoCustomerNo}))
                         
                     End Sub) _
   .Pageable() _
   .Filterable() _
   .Sortable() _
    .Render()
    
    '   .Events(Sub(e) e.Change("onPastSalesSelectItem")) _
    '  .Selectable(Sub(s) s.Mode(GridSelectionMode.Single)) _
   
    
End Code


@code
Html.Kendo.Window() _
 .Name("ItemAvailabilityWindow") _
 .Title("Item Availability") _
 .Visible(False) _
 .Content(Function(ct)
                          @<div>
                             @Html.Partial("_ItemAvailabilityGrid")
                          </div>     
          End Function) _
.Render()
     
 end code   




<script type="text/javascript">

   
</script>
