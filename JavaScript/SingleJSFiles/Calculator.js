function chooseCalculator(){
    console.log("Welcome to a calculator program! Choose one of the following options: \n 1. Addition \n 2. Subtraction \n 3. Multiplication \n 4. Division");
    option = parseInt(prompt("Enter the number of your choice:"));
    organizeOption(option);
  }
  
  function organizeOption(unum){
    if(unum == 1){
      addition()
    } else if(unum == 2){
      subtraction()
    } else if(unum == 3){
      multiplication()
    } else if(unum == 4){
      division()
    } else{
      alert("Invalid option. Enter 1 for addition, 2 for subtraction, 3 for multiplication, or 4 for division");
      chooseCalculator()
    }
  }
  
  function addition() {
    var totalAddition = prompt("Enter how many numbers you would like to add:");
    var sum = 0;
    for(var number = 0; number < totalAddition; number += 1){
      var num = parseInt(prompt("Enter a number:"));
      sum += num;
    }
    console.log("The answer is: " + sum);
    askAgain()
  }
  
  function subtraction() {
    var totalSubtraction = prompt("Enter how many numbers you would like to subtract:");
    sum = 0;
    for(number = 0; number < totalSubtraction; number += 1){
      num = parseInt(prompt("Enter a number:"));
      sum -= num;
    }
    console.log("The answer is: " + sum);
    askAgain()
  }
  
  function multiplication() {
    var totalMultiplication = prompt("Enter how many numbers you would like to multiply:");
    sum = parseInt(prompt("Enter a number:"));
    for(number = 1; number < totalMultiplication; number += 1){
      num = parseInt(prompt("Enter a number:"));
      sum *= num;
    }
    console.log("The answer is: " + sum)
    askAgain()
  }
  
  function division() {
    var totalDivision = prompt("Enter how many numbers you would like to divide:");
    sum = parseInt(prompt("Enter a number:"));
    for(number = 1; number < totalDivision; number += 1){
      num = parseInt(prompt("Enter a number:"));
      sum /= num;
    }
    console.log("The answer is: " + sum);
    askAgain()
  }
  
  function askAgain(){
    ask = prompt("Would you like to use the calculator again?");
    if(ask.toUpperCase == "YES" || ask.toUpperCase == "Y"){
      option = parseInt("The options are: \n 1. Addition \n 2. Subtraction \n 3. Multiplication \n 4. Division \n Enter the number of your choice:")
      organizeOption(option);
    } else if(ask.toUpperCase == "NO" || ask.toUpperCase == "N"){
      alert("Have a nice day!");
    } else{
      alert("Invalid option. Enter yes/y to use another calculator or enter no/n to quit");
      ask;
    }
  }
  
  chooseCalculator()