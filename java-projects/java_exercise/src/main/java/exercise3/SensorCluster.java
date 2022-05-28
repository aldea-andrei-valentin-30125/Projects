/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package exercise3;

import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;


public class SensorCluster {
    
    private List<Sensor> sensorList = new ArrayList<>();
    
    public Sensor addSensor(String sensorID,Sensor_Type type){
        Sensor ret = null;
        boolean state = false;
        if(sensorList.isEmpty()){
            Sensor sensorFirst = new Sensor(type, sensorID);
            sensorList.add(sensorFirst);
            ret = sensorFirst;
        }
        else{
            for(Sensor sensor : sensorList){
                if(!sensorID.equals(sensor.getId())){
                    state = true;
                }     
            }
            if(state){
                    Sensor sensorAdd = new Sensor(type, sensorID);
                    sensorList.add(sensorAdd);
                    ret = sensorAdd;
                }
        }
        return ret; 
    }
    
    public boolean writeSensorReading(String sensorID,double value,LocalDateTime dateTime){
        boolean ret = false;
        for(Sensor sensor : sensorList){
            if(sensor.getId().equals(sensorID)){
                SensorReading sensorReading = new SensorReading(value, dateTime);
                sensor.addSensorReading(sensorReading);
                ret = true;
            }
        }
        return ret;
    }
    
    public Sensor getSensorById(String sensorID){
        Sensor ret = null;
        for(Sensor sensor : sensorList){
            if(sensor.getId().equals(sensorID)){
                ret = sensor;
                System.out.println("Sorted by DataAndTime:");
                System.out.println(sensor.getSensorReadingSortedByDateAndTime());
                System.out.println("Sorted by Value:");
                System.out.println(sensor.getSensorReadingSortedByValue());
                
            }
        }
        return ret;
    }
    
    public int ListSize(){
        return sensorList.size();
    }
            
    @Override
    public String toString() {
        return "SensorCluster{" + "sensorList=" + sensorList + '}';
    }
    
    
    
}
