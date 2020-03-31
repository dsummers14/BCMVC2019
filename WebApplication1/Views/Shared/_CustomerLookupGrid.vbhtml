@Code
    
    Html.Kendo.Grid(Of NaviAnywhere.NavODataService.Customer) _
        .Name("CustomerLookupGrid") _
        .ToolBar(Sub(t) t.Template("<input class='k-textbox' id='customerSearchbox'/>&nbsp;<button id='customerSearchbutton'>Search</>")) _
        .Columns(Sub(c)
                         c.Bound(Function(s) s.No)
                         c.Bound(Function(s) s.Name)
                 End Sub) _
     .DataSource(Sub(d)
                         d.Ajax _
                          .ServerOperation(True) _
                          .PageSize(20) _
                          .Model(Sub(m)
                                         m.Id(Function(s) s.No)
                                         m.Field(Function(s) s.Name).Editable(False)
                                 End Sub) _
                          .Read(Function(r) r.Action("Customer_Read", "Customer").Data("customerAddSearch"))
                 End Sub) _
     .Pageable() _
     .Filterable() _
     .Sortable() _
     .Events(Sub(e) e.Change("onCustomerLookupSelect")) _
     .Selectable(Sub(s) s.Mode(GridSelectionMode.Single)) _
     .Render()
    
End Code

<script type="text/javascript">

    jQuery(function () { jQuery("#customerSearchbutton").kendoButton({}); });

    function customerAddSearch() {
        return { SearchText: $('#customerSearchbox').val() };
    }

    $('#customerSearchbutton').click(function () {
        $('#CustomerLookupGrid').data('kendoGrid').dataSource.read();
    });
 
</script>    