@Code
    
    Html.Kendo.Grid(Of NaviAnywhere.NavODataService.ShipToAddress) _
        .Name("ShipToLookupGrid") _
        .ToolBar(Sub(t) t.Template("<input class='k-textbox' id='shiptoSearchbox'/>&nbsp;<button id='shiptoSearchbutton'>Search</>")) _
        .Columns(Sub(c)
                         c.Bound(Function(s) s.Code)
                         c.Bound(Function(s) s.Name)
                         c.Bound(Function(s) s.Name_2)
                         c.Bound(Function(s) s.Address)
                         c.Bound(Function(s) s.Address_2)
                         c.Bound(Function(s) s.City)
                         c.Bound(Function(s) s.Country_Region_Code)
                         c.Bound(Function(s) s.Post_Code)
                         c.Bound(Function(s) s.Contact)
                         c.Bound(Function(s) s.Phone_No)
                 End Sub) _
     .DataSource(Sub(d)
                         d.Ajax _
                          .ServerOperation(True) _
                          .PageSize(20) _
                          .Model(Sub(m)
                                         m.Id(Function(s) s.Code)
                                         m.Field(Function(s) s.Name).Editable(False)
                                         m.Field(Function(s) s.Name_2).Editable(False)
                                         m.Field(Function(s) s.Address).Editable(False)
                                         m.Field(Function(s) s.Address_2).Editable(False)
                                         m.Field(Function(s) s.City).Editable(False)
                                         m.Field(Function(s) s.Country_Region_Code).Editable(False)
                                         m.Field(Function(s) s.Post_Code).Editable(False)
                                         m.Field(Function(s) s.Contact).Editable(False)
                                         m.Field(Function(s) s.Phone_No).Editable(False)
                                         m.Field(Function(s) s.Location_Code).Editable(False)
                                 End Sub) _
                          .Read(Function(r) r.Action("ShipToAddress_Read", "ShipToAddress").Data("shiptoAddressAddSearch"))
                 End Sub) _
     .Pageable() _
     .Filterable() _
     .Sortable() _
     .Events(Sub(e) e.Change("onShipToLookupSelect")) _
     .Selectable(Sub(s) s.Mode(GridSelectionMode.Single)) _
     .Render()
    
End Code

<script type="text/javascript">

    jQuery(function () { jQuery("#shiptoSearchbutton").kendoButton({}); });

    function shiptoAddressAddSearch() {
        return { SearchText: $('#shiptoSearchbox').val(),
                 CustomerNo: $('#SelltoCustomerNo').val()
        };
    }

    $('#shiptoSearchbutton').click(function () {
        $('#ShipToLookupGrid').data('kendoGrid').dataSource.read();
    });
 
</script>    