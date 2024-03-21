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
    var li = document.createElement("td");
    li.innerHTML = inputBox.value;
    listContainer.appendChild(li);
    var span = document.createElement("span");
    li.appendChild(span);
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
/******/ 	__webpack_require__.h = () => ("b4b54a40c17257fcd4a6")
/******/ })();
/******/ 
/******/ }
);
//# sourceMappingURL=todolist.cd833f721a0eb7868af3.hot-update.js.map