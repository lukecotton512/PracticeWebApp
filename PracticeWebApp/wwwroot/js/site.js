// site.js
// Luke Cotton
// Site JavaScript code.

// Loads a table from a JSON file via AJAX.
function loadTable() {
    $.getJSON("/Ajax/Tasks", function(taskListData) {
        $.each(taskListData, function (index, item) {
            addItem(item);
        });
    });
}

// Adds one item to the table.
function addItem(item) {
    console.log(item);
    $("#tasklisttable").append("<tr>" + 
                                    "<td class=\"itemname\">" + item.taskName + "</td>" + 
                                    "<td class=\"itemdate\">" + item.dateAssigned + "</td>" +
                                    "<td class=\"itemassigned\">" + item.assignedTo + "</td>" +
                                "</tr>");
                                
}

// Send a new item to the server.
function sendItem(item) {
    var modelItem = {TaskId: 0, TaskName: item.taskName, DateAssigned: item.dateAssigned, AssignedTo: item.assignedTo};
    console.log(modelItem);
    $.ajax("/Ajax/Create", {
        method: "POST",
        dataType: "json",
        data: modelItem
    }).done(function(data) {
        console.log(data);
    });
}

// Inserts a new item from the form.
function insertItem() {
    // Get out item and print it out.
    var item = { taskName: $("#taskName").val(), dateAssigned: $("#taskDate").val(), assignedTo: $("#assignedTo").val()};
    console.log(item);
    addItem(item);
    sendItem(item);
}

// Load our table and setup the onclick listener for the button.
$(document).ready(function () {
    // Load the table.
    loadTable();
    // Setup onclick listener for our submit button.
    $("#submitbutton").click(function (event) {
        insertItem();
    })
})