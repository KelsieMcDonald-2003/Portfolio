self["webpackHotUpdatetodolist"]("todolist",{

/***/ "./src/js/todolist.js":
/*!****************************!*\
  !*** ./src/js/todolist.js ***!
  \****************************/
/***/ (() => {

var todoList = [];
function addTask(task) {
  todoList.push(task);
  saveTasks();
}
window.addTaskFromInput = function () {
  var input = document.getElementById('taskInput');
  addTask({
    name: input.value,
    done: false
  });
  input.value = '';
  renderTasks();
};
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
  var storedTasks = localStorage.getItem('todoList');
  if (storedTasks) {
    todoList = JSON.parse(storedTasks);
  }
}
function renderTasks() {
  var list = document.getElementById('taskList');
  list.innerHTML = '';
  var _loop = function _loop(i) {
    var task = todoList[i];
    var listItem = document.createElement('li');
    listItem.textContent = task.name;

    // Create a delete button
    var deleteButton = document.createElement('button');
    deleteButton.textContent = 'x';
    deleteButton.onclick = function (event) {
      // Prevent the list item from being clicked
      event.stopPropagation();
      removeTaskFromList(i);
    };

    // Append the delete button to the list item
    listItem.appendChild(deleteButton);

    // Change the onclick event of the list item
    listItem.onclick = function () {
      toggleDone(i);
    };
    list.appendChild(listItem);
  };
  for (var i = 0; i < todoList.length; i++) {
    _loop(i);
  }
}
loadTasks();
renderTasks();

/***/ })

},
/******/ function(__webpack_require__) { // webpackRuntimeModules
/******/ /* webpack/runtime/getFullHash */
/******/ (() => {
/******/ 	__webpack_require__.h = () => ("ca6fdb818bcb29a95e60")
/******/ })();
/******/ 
/******/ }
);
//# sourceMappingURL=todolist.c33fb49f6fc4c76c5353.hot-update.js.map