@{
    
    Layout = "~/Views/Shared/indexBack.cshtml";
}
    <div class="card-columns">


        @foreach (var item in ViewBag.Title)
        {


            <!-- Example Social Card-->
            <div class="card mb-3">
                
                    <img class="card-img-top img-fluid w-100" style="width:50px;height:200px"  src=@Url.Content("~/Content/Upload/"+item.urlImage) >
               
                <div class="card-body">
                    <h6 class="card-title mb-1">@item.nameFirstname</h6>
                    <p class="card-text small">
                        @item.email
                         <a href="#">#kickflip</a>
                        <a href="#">#holdmybeer</a>
                        <a href="#">#igotthis</a>
                    </p>
                </div>
                <hr class="my-0">
                <div class="card-body py-2 small">
                    <a class="mr-3 d-inline-block" href="#">
                        <i class="fa fa-fw fa-thumbs-up"></i>@item.dateCreation
                    </a>
                    <a class="mr-3 d-inline-block" href="#">
                        <i class="fa fa-fw fa-comment"></i>@Html.ActionLink("Edit", "Edit", new { id = item.id })


                    </a>
                    <a class="d-inline-block" href="#">
                        <i class="fa fa-fw fa-share"></i>@Html.ActionLink("Delete", "Delete", new { id = item.id }, new { @class = "button btn-mini red" })


                    </a>
                </div>
                <div class="card-footer small text-muted">@item.dateCreation</div>
            </div>
            <!-- Example Social Card-->

          
        }
    </div>



@Html.ActionLink("Create", "Create", new { @class = "button btn-mini red" })
