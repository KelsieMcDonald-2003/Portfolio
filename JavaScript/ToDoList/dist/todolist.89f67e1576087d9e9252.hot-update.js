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
function addTaskFromInput() {
  var input = document.getElementById('taskInput');
  addTask({
    name: input.value,
    done: false
  });
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
    listItem.onclick = function () {
      removeTaskFromList(i);
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
/******/ 	__webpack_require__.h = () => ("dfd91e619c5e3eb62800")
/******/ })();
/******/ 
/******/ }
);
//# sourceMappingURL=todolist.89f67e1576087d9e9252.hot-update.js.map