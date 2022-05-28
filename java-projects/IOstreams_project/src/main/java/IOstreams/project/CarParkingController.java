package IOstreams.project;

import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.io.Serializable;
import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.logging.Level;
import java.util.logging.Logger;
import static java.util.stream.Collectors.toList;
import lombok.AccessLevel;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

public class CarParkingController {
    private CarParking carParking = new CarParking(100);
    private List<ParkingEventRecord> logs;
    private List<ParkingEventRecord> historyLogs;
    
    public CarParkingController(){
        this.readLogRecord("D:\\GitRepository\\java-projects\\IOstreams_project\\docs\\CurrentparkingFolder\\logs.txt");
        //logs = new ArrayList<>();
        //historyLogs = new ArrayList<>();
        this.readLogRecordHistory("D:\\GitRepository\\java-projects\\IOstreams_project\\docs\\CurrentparkingFolder\\logsHistory.txt");
    }
    
    public boolean EnterCar(Car c){
        if(carParking.getEmptyParkingSpots() > 0 && !carParking.hasCar(c)){
            carParking.addCar(c);
            logs.add(new ParkingEventRecord(c,LocalDateTime.now()));
            return true;
        }
        return false;
    }

    public int ExitCar(Car c){
        LocalDateTime enterTime;
        LocalDateTime leaveTime;
        int cost = 0;
            for(ParkingEventRecord log : logs){
                if(c.getPlateNumber().equals(log.getCar().getPlateNumber())){
                    enterTime = log.getEnterTime();
                    leaveTime = LocalDateTime.now();
                    log.setLeaveTime(leaveTime);
                    cost = leaveTime.getSecond() -  enterTime.getSecond();
                    historyLogs.add(log);
                    logs.remove(log);
                    carParking.removeCar(c);
                    return cost;
                }
            }       
        return 0;
    }
   
    public List<ParkingEventRecord> getAllParkedCar(){
        return logs;
    }

    public List<ParkingEventRecord> getALlRecordsByCar(String plateNumber){
        return historyLogs.stream().filter(t -> t.getCar().getPlateNumber().equals(plateNumber)).collect(toList());
    }
    
    public Map<Car,Integer> getAllUniqueCar(){
        Map<Car,Integer> map = new HashMap<>();
        for(ParkingEventRecord log : historyLogs){
            if(map.containsKey(log.getCar())){
                map.replace(log.getCar(),map.get(log.getCar()) + 1);
            }else { map.put(log.getCar(),1);}    
        }
        return map;
    }
     
    public void writeLogRecord(String path,List<ParkingEventRecord> loga) {
        ObjectOutputStream o;
        try {
            o = new ObjectOutputStream(new FileOutputStream(path));
            o.writeObject(loga);
        } catch (IOException ex) {
            Logger.getLogger(CarParkingController.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    
    public List<ParkingEventRecord> getLogs(){
        return logs;
    }
    
    public List<ParkingEventRecord> getLogsHistory(){
        return historyLogs;
    }
    
    public int availableFreeSpaces(){
        return carParking.getEmptyParkingSpots();
    }
    
    public void readLogRecord(String path){
        ObjectInputStream in;
        try {
            in = new ObjectInputStream(new FileInputStream(path));
            logs = (List<ParkingEventRecord>)in.readObject();
            for(ParkingEventRecord log : logs){
                carParking.addCar(log.getCar());
            }  
        } catch (IOException ex) {
            Logger.getLogger(CarParkingController.class.getName()).log(Level.SEVERE, null, ex);
        } catch (ClassNotFoundException ex) {
            Logger.getLogger(CarParkingController.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    
    public void readLogRecordHistory(String path){
        ObjectInputStream in;
        try {
            in = new ObjectInputStream(new FileInputStream(path));
            historyLogs = (List<ParkingEventRecord>)in.readObject(); 
        } catch (IOException ex) {
            Logger.getLogger(CarParkingController.class.getName()).log(Level.SEVERE, null, ex);
        } catch (ClassNotFoundException ex) {
            Logger.getLogger(CarParkingController.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
}
  

@NoArgsConstructor(access = AccessLevel.PUBLIC)    
class ParkingEventRecord implements Serializable{
    @Getter @Setter
    private Car car;
    
    @Getter @Setter
    private LocalDateTime enterTime;
    
    @Getter @Setter
    private LocalDateTime leaveTime;
    
    public ParkingEventRecord(Car c,LocalDateTime d){
        this.car = c;
        this.enterTime = d;
        this.leaveTime = null;
    }
}


