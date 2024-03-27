import {navbar} from './navbar.js'

navbar()

const input = document.getElementById("input");
const userTicketCell = document.createElement("td");
const winningTicketCell = document.createElement("td");

const userLotteryNumbers = []

userTicket.appendChild(userTicketCell);
winningTicket.appendChild(winningTicketCell);

window.getNumbers = function(){
    if(input.value !== ''){
        var numbers = input.value.split(', ');
        for(var number = 0; number < numbers.length; number += 1){
            userLotteryNumbers.push(numbers[number]);
            userTicketCell.innerHTML = userLotteryNumbers.join(", ");
        }
        if(userLotteryNumbers.length === 5){
            let wticket = randomNumbers();
            winningTicketCell.innerHTML = wticket.join(", ");
        }
    }
}

function randomNumbers(){
    var winningTicket = []
    for(var number = 0; number < 5; number += 1){
        var num = Math.floor(Math.random() * 101)
        winningTicket.push(num);
    }
    return winningTicket;
}
