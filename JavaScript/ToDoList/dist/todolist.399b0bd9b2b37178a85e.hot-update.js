"use strict";
self["webpackHotUpdatetodolist"]("todolist",{

/***/ "./src/js/todolist.js":
/*!****************************!*\
  !*** ./src/js/todolist.js ***!
  \****************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _css_todolist_css__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../css/todolist.css */ "./src/css/todolist.css");

var inputBox = document.getElementById("taskInput");
var listContainer = document.getElementById("taskList");
window.addTaskFromInput = function () {
  if (inputBox.value === '') {
    return;
  } else {
    var row = document.createElement("tr");
    var taskCell = document.createElement("td");
    taskCell.innerHTML = inputBox.value;
    row.appendChild(taskCell);
    var deleteCell = document.createElement("td");
    var deleteButton = document.createElement("button");
    deleteButton.innerHTML = "Delete";
    deleteButton.onclick = function () {
      this.parentElement.parentElement.remove();
      saveData();
    };
    deleteCell.appendChild(deleteButton);
    row.appendChild(deleteCell);
    listContainer.appendChild(row);
    saveData();
  }
  inputBox.value = "";
};
listContainer.addEventListener("click", function (e) {
  if (e.target.tagName === 'TD') {
    e.target.classList.toggle("checked");
    saveData();
  } else if (e.target.tagName === "SPAN") {
    e.target.parentElement.remove();
    saveData();
  }
}, false);
function saveData() {
  if (typeof Storage !== "undefined") {
    localStorage.setItem("data", listContainer.innerHTML);
  } else {
    console.log('Sorry, your browser does not support Web Storage...');
  }
}
function showTask() {
  if (typeof Storage !== "undefined") {
    var data = localStorage.getItem("data");
    if (data) {
      listContainer.innerHTML = data;
    }
  } else {
    console.log('Sorry, your browser does not support Web Storage...');
  }
}
showTask();

/***/ })

},
/******/ function(__webpack_require__) { // webpackRuntimeModules
/******/ /* webpack/runtime/getFullHash */
/******/ (() => {
/******/ 	__webpack_require__.h = () => ("d7377bffee9a2dabcc13")
/******/ })();
/******/ 
/******/ }
);
//# sourceMappingURL=todolist.399b0bd9b2b37178a85e.hot-update.js.map