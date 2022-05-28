/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package exercise3;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.List;


public class Sensor implements Comparator1{
    
    private Sensor_Type type;
    private String id;
    private List<SensorReading> sensorReadingList = new ArrayList<>();

    public Sensor(Sensor_Type type, String id) {
        this.type = type;
        this.id = id;
    }
    
    public boolean addSensorReading(SensorReading sensorReading){
        if(sensorReading != null){
            sensorReadingList.add(sensorReading);
            return true; 
        }else return false;
    }
    
    public List<SensorReading> getSensorReadingSortedByDateAndTime (){
        Comparator<SensorReading> compareByDataAndTime = (SensorReading a, SensorReading b) ->a.compareTo(b);
        Collections.sort(sensorReadingList,compareByDataAndTime); 
        return sensorReadingList;
    }
    
    public List<SensorReading> getSensorReadingSortedByValue (){
        Comparator<SensorReading> compareByValue = (SensorReading a, SensorReading b) -> this.compare(a, b);
        Collections.sort(sensorReadingList,compareByValue);
        return sensorReadingList;
    }

    public Sensor_Type getType() {
        return type;
    }

    public void setType(Sensor_Type type) {
        this.type = type;
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    
    @Override
    public int compare(SensorReading a, SensorReading b) {
        return (int)(a.getValue() - b.getValue());
    }

    @Override
    public String toString() {
        return "Sensor{" + "type=" + type + ", id=" + id + ", sensorReadingList=" + sensorReadingList + '}';
    }

}
