var employee = document.getElementById("ESSN");
var projectsArea = document.getElementById("projectsArea");
var projectInput = document.getElementById("projectNum");
var HourArea = document.getElementById("HourArea");
var inputHour = document.getElementById("Hours");



employee.addEventListener("change", async () => {

    
    var projectsResult = await fetch("http://localhost:5/worksOnProject/EditEmployeeHour_emp/" + employee.value);
    projectList = await projectsResult.text();
    console.log(projectList);

    projectsArea.innerHTML = projectList;
    projectInput = document.getElementById("projectNum");
    if (projectInput.value) {
        var hourResult = await fetch("http://localhost:5174/worksOnProject/EditEmployeeHour_emp_proj/" + employee.value + "?projectNum=" + projectInput.value);
        hour = await hourResult.text();
        console.log(hour);
        HourArea.innerHTML = hour;
    }

    projectInput.addEventListener("change", async () => {

        console.log(projectInput);
        var hourResult = await fetch("http://localhost:5174/worksOnProject/EditEmployeeHour_emp_proj/" + employee.value + "?projectNum=" + projectInput.value);
        hour = await hourResult.text();
        console.log(hour);
        HourArea.innerHTML = hour;
     
        console.log(projectInput);

    });

});


