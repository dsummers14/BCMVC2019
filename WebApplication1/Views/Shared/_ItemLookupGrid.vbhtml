
@Code
    
    Html.Kendo.Grid(Of NaviAnywhere.NavODataService.Item) _
        .Name("ItemsGrid") _
        .ToolBar(Sub(t) t.Template("<input class='k-textbox' id='searchbox'/>&nbsp;<button id='searchbutton'>Search</>")) _
        .Columns(Sub(c)
                         c.Command(Function(l) l.Custom("Add").Click("ItemLookupAdd"))
                         c.Bound(Function(s) s.No)
                         c.Bound(Function(s) s.Description)
                         c.Bound(Function(s) s.Unit_Cost).Format("{0:c}").Visible(User.IsInRole("Salesperson") OrElse User.IsInRole("Admin") OrElse User.IsInRole("Sales Manager"))
                         c.Bound(Function(s) s.Availability).ClientTemplate(Html.ActionLink("#=Availability#", "Drilldown", Nothing, New With {.onClick = "onClickInventory('#=No#'); return false;"}).ToHtmlString)
                 End Sub) _
     .DataSource(Sub(d)
                         d.Ajax _
                          .ServerOperation(True) _
                          .PageSize(20) _
                         .Model(Sub(m)
                                        m.Id(Function(s) s.No)
                                        m.Field(Function(s) s.Description).Editable(False)
                                        m.Field(Function(s) s.Availability).Editable(False)
                                        m.Field(Function(s) s.Unit_Cost).Editable(False)
                                        
                                End Sub) _
                        .Read(Function(r) r.Action("Item_Read", "Item").Data("addSearch"))
                        
                 End Sub) _
     .Pageable() _
     .Filterable() _
     .Sortable() _
    .Render()
 
    '    .Selectable(Sub(s) s.Mode(GridSelectionMode.Single)) _
    '    .Events(Sub(e) e.Change("onItemLookupSelectItem")) _
 
    
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
 
    jQuery(function () { jQuery("#searchbutton").kendoButton({}); });

    function addSearch() {
        return { SearchText: $('#searchbox').val() };
    }

    $('#searchbutton').click(function () {
        $('#ItemsGrid').data('kendoGrid').dataSource.read();
    });
     
</script>    