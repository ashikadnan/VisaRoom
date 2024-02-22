var counters = 1;
function qualificationAddMore(e) {
    var div = document.createElement('DIV');
    div.innerHTML = add_moreQualification("");
    document.getElementById("qualification_row1").appendChild(div);

}


function add_moreQualification() {
    counters++
    return `<div class="row" id="qualification_row${counters}">



                        <div class="form-group" style="margin-bottom:7px; margin-top:10px">
                            <label asp-for=Qualification.InstituteName>Institute Name</label>
                            <input asp-for=Qualification.InstituteName id="InstituteName${counters}" class="form-control" type="text" placeholder="Institute Name">
                            <span asp-validation-for=Qualification.InstituteName class="text-danger"></span>
                        </div>


                        <div class="form-group" style="margin-bottom:7px">
                            <label asp-for=Qualification.DegreeName>Degree Name</label>
                            <input asp-for=Qualification.DegreeName id="DegreeName${counters}" class="form-control" type="text" placeholder="Degree Name">
                            <span asp-validation-for=Qualification.DegreeName class="text-danger"></span>
                        </div>

                        <div class="form-group" style="margin-bottom:7px">
                            <label asp-for=Qualification.DurationYear>Duration Year</label>
                            <input asp-for=Qualification.DurationYear id="DurationYear${counters}" class="form-control" type="text" placeholder="Duration Year">
                            <span asp-validation-for=Qualification.DurationYear class="text-danger"></span>
                        </div>



                        <div class="form-group" style="margin-bottom:7px">
                            <label asp-for=Qualification.PassingYear>Passing Year</label>
                            <input asp-for=Qualification.PassingYear id="PassingYear${counters}" class="form-control" type="text" placeholder="Passing Year">
                            <span asp-validation-for=Qualification.PassingYear  class="text-danger"></span>
                        </div>
                    </div>`


    //var form = document.getElementById('Candidate_Form')
    //form.insertAdjacentHTML('beforeend', newDiv);
}


//function delete_row(id) {
    //document.getElementById('experience_row' + id).remove()
//}

/*function submit_form() {
    var productData = []
    for (var i = 1; i <= counter; i++) {
        var product_row = document.getElementById('product_row' + i)
        if (product_row) {
            var product_name = document.getElementById('name' + i).value
            var price = document.getElementById('price' + i).value
            var data = {
                name: product_name,
                price: price
            }
            productData.push(data)
        }
    }

    axios.post('/dynamicinput/submitform.php', {
        productData: productData
    }).then(resp => {
        window.location.reload()
    })
}*/