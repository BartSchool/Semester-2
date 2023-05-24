function submitForm(id) {
    console.log(id);
    var form = document.getElementById(id);
    form.submit();
}

function SetOption(string, i) {
    var selectElement = document.getElementById("score-" + i);
    var selectedOption = string;

    for (var i = 0; i < selectElement.options.length; i++) {
        if (selectElement.options[i].value === selectedOption) {
            selectElement.options[i].selected = true;
            break;
        }
    }
}