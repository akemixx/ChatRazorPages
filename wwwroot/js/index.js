const connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
connection.start()
    .catch(function (error) {
        return console.error(error.toString());
    });

// sending data to server 
document.getElementById("sendButton").addEventListener("click", (e) => {
    const text = document.getElementById("Text").value;
    if (text == "") {
        document.getElementsByClassName("field-validation-valid")[0].innerHTML = "You cannot send an empty message.";
    }
    else {
        connection.invoke("SendMessageToAll", text)
            .catch(function (error) {
                return console.error(error.toString());
            });
        document.getElementById("Text").value = "";
    }
});

 // getting server response
connection.on("ReceiveMessage", function (text, sender, time) {
    const div = document.createElement("div");
    div.style = "border: 1px solid #808080";
    div.innerHTML = `<div style='font-size:smaller'><b>${sender}</b> at ${time} </div>` +
        `<div style='font-size:larger'> ${text} </div>`;
    document.getElementById("bottom").before(div);
});