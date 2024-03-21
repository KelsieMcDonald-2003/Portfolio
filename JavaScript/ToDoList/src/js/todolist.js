import '../css/todolist.css'

const inputBox = document.getElementById("taskInput");
const listContainer = document.getElementById("taskList");

window.addTaskFromInput = function(){
    if(inputBox.value === ''){
        return;
    }
    else{
        let row = document.createElement("tr");
        let taskCell = document.createElement("td");
        taskCell.innerHTML = inputBox.value;
        row.appendChild(taskCell);

        let deleteCell = document.createElement("td");
        let deleteButton = document.createElement("button");
        deleteButton.innerHTML = "Delete";
        deleteButton.onclick = function() {
            this.parentElement.parentElement.remove();
            saveData();
        };
        deleteCell.appendChild(deleteButton);
        row.appendChild(deleteCell);

        listContainer.appendChild(row);
        saveData();
    }
    inputBox.value = "";
}


listContainer.addEventListener("click", function(e){
    if(e.target.tagName === 'TD'){
        e.target.classList.toggle("checked");
        saveData()
    }
    else if(e.target.tagName === "SPAN"){
        e.target.parentElement.remove();
        saveData()
    }
}, false);

function saveData(){
    if (typeof(Storage) !== "undefined") {
        localStorage.setItem("data", listContainer.innerHTML);
    } else {
        console.log('Sorry, your browser does not support Web Storage...');
    }
}

function showTask(){
    if (typeof(Storage) !== "undefined") {
        let data = localStorage.getItem("data");
        if (data) {
            listContainer.innerHTML = data;
        }
    } else {
        console.log('Sorry, your browser does not support Web Storage...');
    }
}

showTask()