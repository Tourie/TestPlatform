function addInput() {
    var container = document.getElementById("dynamic_form");
    var number = document.querySelectorAll("input.input_member").length;
    var input = document.createElement("input");
    var td = document.createElement("td");
    var tr = document.createElement("tr");
    input.type = "text";
    input.name = "Answers[" + number + "].Name";
    input.value = "Новый ответ";
    input.className = "input_member";
    td.appendChild(input);
    tr.appendChild(td);
    container.appendChild(tr);
}