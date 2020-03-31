@ModelType NaviAnywhere.EmailModel

<div class="k-content">
       <table>
              <tr>
                  <td>Email To:</td>
                  <td>@Html.TextBoxFor(Function(m) m.EmailTo)</td>
              </tr>
             <tr>
                  <td>Email From:</td>
                  <td>@Html.TextBox("EmailFrom",NaviAnywhere.CommonCode.UserEmail(User.Identity.Name))</td>
              </tr>
               <tr>
                  <td>Subject:</td>
                  <td>@Html.TextBoxFor(Function(m) m.Subject)</td>
              </tr>
               <tr>
                  <td>Body:</td>
                  <td>@Html.Kendo.EditorFor(Function(m) m.EmailBody).Encode(True).HtmlAttributes(New With {.style = "width: 500px;"})</td>
                  <td></td>
                  <td></td>
              </tr>
             </table>
    <p>
          @Html.Kendo.Button().Content("Send").Name("SendEmail").HtmlAttributes(New With {.onClick = "onSendEmailClick();"})
    </p>
</div>

<script type="text/javascript">
  
    function onEmailClick(e) {
        var wnd = $("#EmailWindow").data("kendoWindow");
        //Fix for editor not working on mobile
        $('#EmailBody').data("kendoEditor").refresh();
        wnd.center().open();
       };

    function onSendEmailClick(e) {
        var wnd = $("#EmailWindow").data("kendoWindow");
        var actionUrl = "@(Url.Action("SendDocumentEmail", "Email"))";
        var EmailTo = $("#EmailTo").val();
        var EmailFrom = $("#EmailFrom").val();
        var Subject = $("#Subject").val();
        var Body = $("#EmailBody").data("kendoEditor").value();
        var DocumentType = $("#DocumentType").val();
        var DocumentNo = $("#DocumentNo").val();
          
        $.ajax({
            url: actionUrl,
            cache: false,
            type: "GET",
            contentType: "application/json; charset=utf-8",
            data: {
                EmailTo: EmailTo,
                EmailFrom: EmailFrom,
                Subject: Subject,
                Body: Body,
                DocumentType: DocumentType,
                DocumentNo: DocumentNo},
            dataType: "json",
            error: function () { alert("error"); }
            })
        wnd.close();
   };

</script>  