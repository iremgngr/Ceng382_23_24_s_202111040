var down = document.getElementById("GFG_DOWN");

// Create a break line element
var br = document.createElement("br").cloneNode();

function demo() {
    var form = document.createElement("form");
    form.setAttribute("method", "post");
    form.setAttribute("action", ""); // Action boş bırakıldı

    var FN = document.createElement("input");
    FN.setAttribute("type", "text");
    FN.setAttribute("name", "FullName");
    FN.placeholder = "Full Name"; // placeholder attribute'ü bu şekilde set edilebilir

    var DOB = document.createElement("input");
    DOB.type = "text";
    DOB.name = "dob";
    DOB.placeholder = "DOB"; // placeholder attribute'ü bu şekilde set edilebilir

    // create a submit button
    var s = document.createElement("input");
    s.type = "submit";
    s.value = "Submit";

    // Append the full name input to the form
    form.appendChild(FN);

    // Inserting a line break
    form.appendChild(br.cloneNode());

    // Append the DOB to the form
    form.appendChild(DOB);
    form.appendChild(br.cloneNode());

    // Append the submit button to the form
    form.appendChild(s);

    document.body.appendChild(form);
}


function demo2() {

    var div2 = document.getElementById("plans");
    // plans elementi varsa, görünmez yap
    div2.style.display = div2.style.display === "none" ? "block" : "none";

    var button = document.getElementById('button2');
    var buttonText = button.innerHTML;

    if (buttonText === "Hide Plans") {
        button.innerHTML = "Show Plans";
    }

    else {
        button.innerHTML = "Hide Plans"
    }


}