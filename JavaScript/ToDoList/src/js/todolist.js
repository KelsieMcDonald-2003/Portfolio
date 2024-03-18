let todoList = [];

function addTask(task) {
    todoList.push(task);
    saveTasks();
}

function addTaskFromInput() {
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

function renderTasks() {
    const list = document.getElementById('taskList');
    list.innerHTML = '';
    for(let i = 0; i < todoList.length; i++) {
        const task = todoList[i];
        const listItem = document.createElement('li');
        listItem.textContent = task.name;
        listItem.onclick = function() { removeTaskFromList(i);};
        list.appendChild(listItem);
    }
}

loadTasks();

renderTasks();