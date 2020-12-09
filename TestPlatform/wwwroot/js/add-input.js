function addInput() {
    var container = document.getElementsByTagName("tbody")[0];
    var number = document.querySelectorAll("input.input_member").length;
    var input = document.createElement("input");
    var td1 = document.createElement("td");
    var td2 = document.createElement("td");
    var tr = document.createElement("tr");
    tr.className = "input_tr"
    input.type = "text";
    input.name = "Answers[" + number + "].Name";
    input.value = "Новый ответ";
    input.className = "input_member";
    var button = document.createElement("a");
    var text_button = document.createTextNode("Удалить")
    button.addEventListener("click", function () { deleteAnswer(number) });
    button.appendChild(text_button);
    td1.appendChild(input);
    td2.appendChild(button);
    tr.appendChild(td1);
    tr.appendChild(td2);
    container.appendChild(tr);
}

function deleteAnswer(index) {
    var number = document.querySelectorAll("input.input_member").length;
    var element = document.getElementsByTagName("tr")[index];
    element.parentNode.removeChild(element);
    for (let i = 0; i < number-1; i++) {
        element = document.querySelectorAll("input.input_member")[i];
        element.setAttribute("name", "Answers[" + i + "].Name");
    }
    
}