def main():
    phrase = input("Would you like to use a calculator? (Yes/No): ")
    if(phrase.upper() == "YES" or phrase.upper() == "Y"):
        calculator = input("What type of calculator are you in need of? Addition, Subtraction, Multiplication, Division, Floor Division, Modulus, Exponential: ")
        if(calculator.upper() == "ADDITION"):
            addition()
        elif(calculator.upper() == "SUBTRACTION"):
            subtraction()
        elif(calculator.upper() == "MULTIPLICATION"):
            multiplication()
        elif(calculator.upper() == "DIVISION"):
            division()
        elif(calculator.upper() == "FLOOR DIVISION"):
            floordivision()
        elif(calculator.upper() == "MODULUS"):
            modulus()
        elif(calculator.upper() == "EXPONENTIAL"):
            exponential()
        else:
            print("Invalid input. Please try again")
            main()
    elif(calculator.upper() == "NO" or calculator.upper() == "N"):
        print("Have a nice day!", end="")
    else:
        print("Invalid input. Please try again.")
        main()
    
def addition():
    phrase = int(input("Enter how many numbers you need to add together: "))
    for calculation in range(phrase):
        number = int(input("Enter a number: "))
        number += number
    returnResult(number)

def subtraction():
    phrase = int(input("Enter how many numbers you would like to subtract: "))
    result = int(input("Enter the first number: "))
    for calculation in range(phrase - 1):
        number = int(input("Enter a number: "))
        result -= number
    returnResult(result)

def multiplication():
    phrase = int(input("Enter how numbers you would like to multiply: "))
    result = int(input("Enter the first number: "))
    for calculation in range(phrase - 1):
        number = int(input("Enter a number: "))
        result *= number
    returnResult(result)

def division():
    phrase = int(input("Enter how many numbers you would like to divide by: "))
    result = int(input("Enter the first number: "))
    for calculation in range(phrase - 1):
        number = int(input("Enter a number: "))
        result /= number
    returnResult(result)

def floordivision():
    phrase = int(input("Enter how many numbers you would like to floor divide by: "))
    result = int(input("Enter the first number: "))
    for calculation in range(phrase - 1):
        number = int(input("Enter a number: "))
        result //= number
    returnResult(result)
    
def modulus():
    phrase = int(input("Enter how many numbers you would like to modulus by: "))
    result = int(input("Enter the first number: "))
    for calculation in range(phrase - 1):
        number = int(input("Enter a number: "))
        result %= number
    returnResult(result)

def exponential():
    phrase = int(input("Enter how many numbers you would like to exponential by: "))
    result = int(input("Enter the first number: "))
    for calculation in range(phrase - 1):
        number = int(input("Enter a number: "))
        result **= number
    returnResult(result)

def returnResult(calculation):
     print(calculation)
     main()

if __name__ == '__main__':
    main()