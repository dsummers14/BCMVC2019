
@Html.Hidden("ItemNo")

@Code
    Html.Kendo.Grid(Of NaviAnywhere.ItemAvailabilityResult) _
        .Name("ItemAvailabilityGrid") _
        .Columns(Sub(c)
                         c.Bound(Function(s) s.LocationCode)
                         c.Bound(Function(s) s.LocationName)
                         c.Bound(Function(s) s.QtyOnHand)
                         c.Bound(Function(s) s.QtyOnSaleOrder)
                         c.Bound(Function(s) s.QtyOnHand).ClientTemplate("#=QtyOnHand - QtyOnSaleOrder#").Title("Availability")
                 End Sub) _
     .DataSource(Sub(d)
                         d.Ajax _
                          .ServerOperation(True) _
                         .Model(Sub(m)
                                        m.Field(Function(s) s.LocationCode).Editable(False)
                                        m.Field(Function(s) s.LocationName).Editable(False)
                                        m.Field(Function(s) s.QtyOnHand).Editable(False)
                                        m.Field(Function(s) s.QtyOnSaleOrder).Editable(False)
                                        
                                End Sub) _
                        .Read(Function(r) r.Action("Item_Read", "ItemAvailability").Data("getItemNo"))
                        
                 End Sub) _
     .Filterable() _
     .Sortable() _
    .Render()
    
End Code

<script type="text/javascript">

    function getItemNo() {
        return {ItemNo: $('#ItemNo').val()};
    }
  

    function onClickInventory(ItemNo) {
        var wnd = $("#ItemAvailabilityWindow").data("kendoWindow");
        var Grid = $("#ItemAvailabilityGrid").data("kendoGrid");

        wnd.title("Item Availability - " + ItemNo)
        $('#ItemNo').val(ItemNo);
        Grid.dataSource.read();
        wnd.center().open();
    }

</script>    