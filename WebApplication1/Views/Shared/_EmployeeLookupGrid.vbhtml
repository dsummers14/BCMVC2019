@Code
    
    Html.Kendo.Grid(Of NaviAnywhere.NavODataService.Employee) _
        .Name("EmployeeLookupGrid") _
        .ToolBar(Sub(t) t.Template("<input class='k-textbox' id='employeeSearchbox'/>&nbsp;<button id='employeeSearchbutton'>Search</>")) _
        .Columns(Sub(c)
                         c.Bound(Function(s) s.No)
                         c.Bound(Function(s) s.Search_Name)
                 End Sub) _
     .DataSource(Sub(d)
                         d.Ajax _
                          .ServerOperation(True) _
                          .PageSize(20) _
                          .Model(Sub(m)
                                         m.Id(Function(s) s.No)
                                         m.Field(Function(s) s.Search_Name).Editable(False)
                                 End Sub) _
                          .Read(Function(r) r.Action("Employee_Read", "Employee").Data("employeeAddSearch"))
                 End Sub) _
     .Pageable() _
     .Filterable() _
     .Sortable() _
     .Events(Sub(e) e.Change("onEmployeeLookupSelect")) _
     .Selectable(Sub(s) s.Mode(GridSelectionMode.Single)) _
     .Render()
    
End Code

<script type="text/javascript">

    jQuery(function () { jQuery("#employeeSearchbutton").kendoButton({}); });

    function employeeAddSearch() {
        return { SearchText: $('#employeeSearchbox').val() };
    }

    $('#employeeSearchbutton').click(function () {
        $('#EmployeeLookupGrid').data('kendoGrid').dataSource.read();
    });
 
</script>    