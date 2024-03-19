import '../css/todolist.css'

let todoList = [];

function addTask(task) {
    todoList.push(task);
    saveTasks();
}

window.addTaskFromInput = function() {
    const input = document.getElementById('taskInput');
    addTask({ name : input.value, done: false});
    input.value = '';
    renderTasks();
}

function removeTask(index) {
    todoList.splice(index, 1);
    saveTasks();
}

function removeTaskFromList(index) {
    removeTask(index);
    renderTasks();
}

function saveTasks() {
    localStorage.setItem('todoList', JSON.stringify(todoList));
}

function loadTasks() {
    const storedTasks = localStorage.getItem('todoList');
    if(storedTasks) {
        todoList = JSON.parse(storedTasks);
    }
}

function toggleDone(index) {
    todoList[index].done = !todoList[index].done;
    saveTasks();
    renderTasks();
}


function renderTasks() {
    const list = document.getElementById('taskList');
    list.innerHTML = '';
    for(let i = 0; i < todoList.length; i++) {
        const task = todoList[i];
        const listItem = document.createElement('li');
        listItem.textContent = task.name;

        // Create a delete button
        const deleteButton = document.createElement('button');
        deleteButton.textContent = 'x';
        deleteButton.onclick = function(event) {
            // Prevent the list item from being clicked
            event.stopPropagation();
            removeTaskFromList(i);
        };

        // Append the delete button to the list item
        listItem.appendChild(deleteButton);

        // Change the onclick event of the list item
        listItem.onclick = function() { toggleDone(i); };

        list.appendChild(listItem);
    }
}


loadTasks();

renderTasks();