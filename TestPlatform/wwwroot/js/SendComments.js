"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/comments").build();
document.getElementById("send").disabled = true;
connection.start().then(AddToGroup);
document.getElementById("send").addEventListener("click", SendComment);
connection.on("Send", AddComment);

function AddComment(userName, content, publishDate) {
    var timeOffset = new Date().getTimezoneOffset();
    var options = { year: 'numeric', month: 'numeric', day: 'numeric', hour: 'numeric', minute: 'numeric', second: 'numeric', hour12: false };
    var date = new Date(publishDate - timeOffset).toLocaleString('ru-RU', options).replace(",", "");

    var comments = document.getElementById("comments")
    comments.insertAdjacentHTML("beforeend",
        '<div class="box">' +
        '<a href=""><h4>' + userName + '</h4 ></a > ' +
        '<p>' + content + '</p >' +
        '<p>' + date + '</p >' +
        '</div >'
    )
}

function AddToGroup() {
    document.getElementById("send").disabled = false;
    var postId = document.getElementById("articleId").value;
    connection.invoke("AddToGroup", postId)
}

function SendComment(event) {
    var articleId = document.getElementById("articleId").value;
    var content = document.getElementById("content").value;
    if (document.getElementById("content").value != "") {
        document.getElementById("content").value = "";
        connection.invoke("SendComment", articleId, content)
        event.preventDefault();
    }
}