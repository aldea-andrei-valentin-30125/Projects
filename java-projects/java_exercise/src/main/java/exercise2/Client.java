package exercise2;

public class Client {
    public static void main(String[] args) throws InterruptedException{
        Humidity humidity = new Humidity();
        Temperature temperature = new Temperature();
        Pressure pressure= new Pressure();
        
        Controller controller = new Controller();
        
        temperature.register(controller);
        humidity.register(controller);
        pressure.register(controller);
        
        temperature.readSensor();
        pressure.readSensor();
        humidity.readSensor();
        
        Thread.sleep(5000);
        
        humidity.readSensor();
        temperature.readSensor();
        pressure.readSensor();
        
    }
}

