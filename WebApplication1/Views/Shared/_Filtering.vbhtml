@Modeltype NaviAnywhere.FilteringModel

@Using Html.BeginForm()
  @<fieldset class="filtering">

    @Html.HiddenFor(Function(model) model.CustomerNav.CustomerNo)
    @Html.HiddenFor(Function(model) model.CustomerNav.CustomerName)
 

      <legend>Filter Product Results</legend>
      <div>
         <b>Filtering:</b>
            @Html.DropDownListFor(Function(Model)Model.Filter , Model.FilterList, "")
            @Html.TextBoxFor(Function(model) model.Value)     
       <input type="submit" value="Filter" />
      </div>
   </fieldset>
 End Using