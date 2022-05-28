/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package exercise3;

import java.time.LocalDateTime;

public class SensorReading implements Comparable{
    
    private double value;
    private LocalDateTime dataAndTime;
   
    public SensorReading(double value, LocalDateTime dataAndTime) {
        this.value = value;
        this.dataAndTime = dataAndTime;
    }

    public double getValue() {
        return value;
    }

    public void setValue(double value) {
        this.value = value;
    }

    public LocalDateTime getDataAndTime() {
        return dataAndTime;
    }

    public void setDataAndTime(LocalDateTime dataAndTime) {
        this.dataAndTime = dataAndTime;
    }

    @Override
    public String toString() {
        return "SensorReading{" + "value=" + value + ", dataAndTime=" + dataAndTime + '}';
    }

    @Override
    public int compareTo(SensorReading o) {
        return this.dataAndTime.compareTo(o.getDataAndTime());
    }

   
}
