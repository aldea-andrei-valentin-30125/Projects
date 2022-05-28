package exercise3;

import java.time.LocalDateTime;
import java.time.Month;

public class Exercise3 {

    public static void main(String[] args) {
        Sensor_Type type1 = Sensor_Type.TEMPERATURE;
        Sensor_Type type2 = Sensor_Type.HUMIDITY;
        Sensor_Type type3 = Sensor_Type.PRESSURE;
 
        SensorReading sensor1 = new SensorReading(103,LocalDateTime.of(2012, Month.MARCH, 22, 8, 34));
        SensorReading sensor2 = new SensorReading(112,LocalDateTime.of(2013, Month.APRIL, 2, 12, 4));
        SensorReading sensor3 = new SensorReading(421,LocalDateTime.of(2011, Month.FEBRUARY, 13, 1, 52));
        SensorReading sensor4 = new SensorReading(123,LocalDateTime.of(2012, Month.JULY, 15, 14, 21));
        
        Sensor sensor = new Sensor(type1,"123");
        
        sensor.addSensorReading(sensor1);
        sensor.addSensorReading(sensor2);
        sensor.addSensorReading(sensor3);
        sensor.addSensorReading(sensor4);
            System.out.println("Sorted by DataAndTime:");
            System.out.println(sensor.getSensorReadingSortedByDateAndTime());
            System.out.println("Sorted by Value:");
            System.out.println(sensor.getSensorReadingSortedByValue());
        
        System.out.println("\n Sensor Cluster Test:");
            
        SensorCluster sensorCluster = new SensorCluster();
        
        sensorCluster.addSensor("134", type1);
        sensorCluster.addSensor("134", type2);
        sensorCluster.addSensor("231", type2);
        sensorCluster.addSensor("214", type3);
            
        sensorCluster.writeSensorReading("231", 100, LocalDateTime.now());
        sensorCluster.writeSensorReading("134", 200, LocalDateTime.now());
        sensorCluster.writeSensorReading("134", 240, LocalDateTime.now());
        sensorCluster.writeSensorReading("214", 142, LocalDateTime.now());
            System.out.println(sensorCluster);
        sensorCluster.getSensorById("134");
       
    
    }
}
