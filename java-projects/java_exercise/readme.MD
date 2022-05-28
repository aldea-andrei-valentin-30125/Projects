**Exercise 1**

- In exercise1 is presented a basic implementation of Observer design pattern.

**Exercise 2**

A system is composed of 1 controller and 3 sensor types (TEMPERATURE, HUMIDITY, PRESSURE). Each sensor has a void readSensor() method which, when executed will randomly generate a value. Controller is registered as observer for the 3 sensors. Each time a sensor change it's value controller is notified and will print sensor value and sensor type.

- 1. Implement a Java program based on the above description.
- 2. Test the functionality in main() method. From main readValue() method will be called for each sensor to test Observer pattern is working.

**Exercise 3**

![Exercise 3 image](docs/ex3.jpg)

Given the UML class diagram above, implement the corresponding Java program.

- 1.Create Java class based on the diagram above.
	* _SensorReading should should implement Comparable<SensorReading> for comparing by date and time
	* _Sensor should use Comparator<SensorReading> for comparing SensorReading by value
- 2.Demonstrate the functionality of application in Exercise1 class main method.
 	* _Use SensorsCluster.addSensor to add few sensors. NOTE: The method should return an instance to the newly created Sensor object or null if a sensor with given id already exists
	* _Use SensorsCluster.writeSensorReading to add some readings for previously added sensors. This method should search for sensor by sensorId and use the sensor addSensorReading() to add a new value. Method will return false if sensor cannot be found
	* _Use SensorsCluster.getSensorById to obtain a reference for a previously added sensor and display sorted readings by the 2 provided criterias

**Exercise 4**

![Exercise 4 image](docs/ex4.jpg)

Given the UML class diagram above, implement the corresponding Java program.

- 1.Create Java class based on the diagram above.
	* _insertCard() method from ATM will compare received pin with the pin stored in card. If 2 pins match the card will be stored as attribute and will be used for executing transactions.
	* _removeCard() method will invalidate a previously inserted card by making the attribute null.
- 2.Demonstrate the functionality of application in Exercise1 class main method.
	* _Create minimal unit tests for testing the behavior of the programm.


**Exercise 5**
- Polymorphism

## Exercise 6 
![Exercise 6 image](docs/ex6.jpg)

Given the UML class diagram above, implement the corresponding Java program.

Note: Constructors are not represented in the diagram above, but you will need to add all necessary constructors to be able to initialise all attributes. 

1. Create Java classes based on the diagram above. 
    * method getPaymentAmount() will return 0.0 in base class Employee.
2. Instantiate and test created classes in the provided Exercise 6 main method. 
    1. create 1 object of each derived type and display payment amount.
    2. create a vector of 6 objects of type Employee, add 2 object of each type and calculate total payment.

**Exercise 7**
- Singleton

**Exercise 8**

- Write a program which display the geometric mean of the primes number from [a,b] where a,b->[1,200] a<b, a and b are read from keyboard. Also display the number of prime numbers which have the sum of digits an even number.



