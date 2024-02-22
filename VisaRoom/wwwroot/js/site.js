// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var counter = 1;


function Experience_AddMore(e) {
    var div = document.createElement('DIV');
    div.innerHTML = add_moreExperience("");
    document.getElementById("experience_row1").appendChild(div);
    //e.preventDefault();

}


function add_moreExperience() {
    counter++
    return `<div class="row" id="experience_row${counter}">

                    <div class="form-group">
                        <label asp-for=Experience.OrganizationName>Type Organization Name</label>
                        <input asp-for=Experience.OrganizationName name="OrganizationName${counter}" id="OrganizationName${counter}" class="form-control" placeholder="Organization Name">
                        <span asp-validation-for=Experience.OrganizationName class="text-danger"></span>
                    </div>

                    <div class="form-group">
                        <label asp-for=Experience.DesignationName>Type Designation Name</label>
                        <input asp-for=Experience.DesignationName id="DesignationName${counter}" class="form-control" placeholder="Designation Name">
                        <span asp-validation-for=Experience.DesignationName class="text-danger"></span>
                    </div>

                    <div class="form-group">
                        <label asp-for=Experience.YearsExperience>Type Years ofExperience</label>
                        <input asp-for=Experience.YearsExperience id="YearsExperience${counter}" class="form-control" placeholder="Years ofExperience">
                        <span asp-validation-for=Experience.YearsExperience class="text-danger"></span>
                    </div>

                    <div class="form-group">
                        <label asp-for=Experience.LocationName>Work Location</label>
                        <input asp-for=Experience.LocationName id="LocationName${counter}" type="text" class="form-control" placeholder="Work Location">
                        <span asp-validation-for=Experience.LocationName class="text-danger"></span>
                    </div>

                    </div>`


    //var form = document.getElementById('Candidate_Form')
    //form.insertAdjacentHTML('beforeend', newDiv);
}



