/*
My JavaScript Eloquent JavaScript Textbook Chapter 2 Programs
*/

//Looping a Triangle:
var line = "#";
for(line; line.length < 8; line += "#"){
    console.log(line);
}

//FizzBuzz:
var fizz = "Fizz";
var buzz = "Buzz";
var fizzBuzz = "FizzBuzz";
var num = 1;
for(num; num < 101; num += 1){
    if(num % 3 == 0 && num % 5 == 0){
        console.log(num + " " + fizzBuzz);
    } else if(num % 3 == 0){
        console.log(num + " " + fizz);
    } else if(num % 5 == 0){
        console.log(num + " " + buzz);
    } else{
        console.log(num);
    }
}

//Chess Board:
var board = "";
for (var y = 0; y < 8; y++) {
  for (var x = 0; x < 8; x++) {
    if ((x + y) % 2 == 0) {
      board += " ";
    } else {
      board += "#";
    }
  }
  board += "\n";
}
console.log(board);