"use strict";
self["webpackHotUpdatetodolist"]("lottery",{

/***/ "./src/js/lottery.js":
/*!***************************!*\
  !*** ./src/js/lottery.js ***!
  \***************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _navbar_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./navbar.js */ "./src/js/navbar.js");

(0,_navbar_js__WEBPACK_IMPORTED_MODULE_0__.navbar)();
var input = document.getElementById("input");
var userTicketCell = document.createElement("td");
var winningTicketCell = document.createElement("td");
var userLotteryNumbers = [];
userTicket.appendChild(userTicketCell);
winningTicket.appendChild(winningTicketCell);
window.getNumbers = function () {
  if (input.value !== '') {
    var numbers = input.value.split(', ');
    for (var number = 0; number < numbers.length; number += 1) {
      userLotteryNumbers.push(numbers[number]);
      userTicketCell.innerHTML = userLotteryNumbers.join(", ");
    }
    if (userLotteryNumbers.length === 5) {
      var wticket = randomNumbers();
      winningTicketCell.innerHTML = wticket.join(", ");
    }
  }
};
function randomNumbers() {
  var winningTicket = [];
  for (var number = 0; number < 5; number += 1) {
    var num = Math.floor(Math.random() * 101);
    winningTicket.push(num);
  }
  return winningTicket;
}

/***/ })

},
/******/ function(__webpack_require__) { // webpackRuntimeModules
/******/ /* webpack/runtime/getFullHash */
/******/ (() => {
/******/ 	__webpack_require__.h = () => ("5d86be108967cc978d2d")
/******/ })();
/******/ 
/******/ }
);
//# sourceMappingURL=lottery.e59caa6da37be805b476.hot-update.js.map