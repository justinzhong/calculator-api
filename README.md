# Calculator API

A calculator API that performs the following arithmetic operations: +, -, *, /

## Test

Open Visual Studio solution and go to Test Explorer, click 'Run All'.

## Run

```DOS
cd Calculator.Api
dotnet run
```

## Examples

Adding the number 13 and 17 yields 30 (HTTP OK 200)

https://localhost:5001/api/calculator/add?left=13&right=17

Adding the number 79228162514264337593543950335 and 1 yields "ArithmeticOverflow" (HTTP Bad Request 400)

https://localhost:5001/api/calculator/add?left=79228162514264337593543950335&right=1

Divide the number 22 and 7 yields 3.1428571428571428571428571429

https://localhost:5001/api/calculator/divide?left=22&right=7

Divide the number 22 and 0 yields "DivideByZero" (HTTP Bad Request 400)

https://localhost:5001/api/calculator/divide?divide=22&right=0