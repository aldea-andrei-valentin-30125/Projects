package IOstreams.project;

import java.util.ArrayList;
import java.util.List;

public class CarParking {
    List <ParkingSpot> parkingSpots;
    
    public CarParking(int numberOfParkingSpots){
        parkingSpots = new ArrayList<>();
        for(int i = 0;i < numberOfParkingSpots; i++){
            parkingSpots.add(new ParkingSpot());
        }
    }
    
    public int getEmptyParkingSpots(){
        int numberOfEmptySpots = 0;
        for (ParkingSpot spot : parkingSpots) {
            if (spot.isFree()){
                numberOfEmptySpots ++;
            }
        }
        return numberOfEmptySpots;
    }
    
    public void addCar(Car c){
       for (ParkingSpot spot : parkingSpots) {
           if (spot.isFree()){
               spot.putCar(c);
               return;
           }
       }
    }
      
    public boolean hasCar(Car c){
        for (ParkingSpot spot : parkingSpots) {
            if(c.equals(spot.getCarOnThisSpot())){
                return true;
            }
        }
        return false;
    }
    
    public void removeCar(Car c){
        for (ParkingSpot spot : parkingSpots) {
            if(c.equals(spot.getCarOnThisSpot())){
                spot.setFree();
            }
        }
    }
}

class ParkingSpot{
    private Car carOnThisSpot;

    public Car getCarOnThisSpot() {
        return carOnThisSpot;
    }
    
    public void putCar(Car c){
        this.carOnThisSpot = c;
    }
    
    public void setFree(){
        this.carOnThisSpot = null;
    }
    
    public boolean isFree(){
        return this.carOnThisSpot == null;
    }  
}