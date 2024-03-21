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
    var li = document.createElement("li");
    li.innerHTML = inputBox.value;
    listContainer.appendChild(li);
    var span = document.createElement("span");
    li.appendChild(span);
    saveData();
  }
  inputBox.value = "";
};
listContainer.addEventListener("click", function (e) {
  if (e.target.tagName === 'LI') {
    e.target.classList.toggle("checked");
  } else if (e.target.tagName === "SPAN") {
    e.target.parentElement.remove();
    saveData();
  }
}, false);
function saveData() {
  localStorage.setItem("data", listContainer.innerHTML);
}
function showTask() {
  listContainer.innerHTML = localStorage.getItem("data");
}

/***/ })

},
/******/ function(__webpack_require__) { // webpackRuntimeModules
/******/ /* webpack/runtime/getFullHash */
/******/ (() => {
/******/ 	__webpack_require__.h = () => ("e988b4879526b2afb710")
/******/ })();
/******/ 
/******/ }
);
//# sourceMappingURL=todolist.e8b99451801adfd46c2c.hot-update.js.map