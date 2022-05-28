package IOstreams.project;

import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;

public class CarParkingAccessApp {
    public static void main(String[] args) {
        CarParkingController controller = new CarParkingController();
        List<ParkingEventRecord> logs = new ArrayList<>();
        
        Car c1 = new Car("ALD");
        Car c2 = new Car("DEI");
        Car c3 = new Car("123");
        Car c4 = new Car("532");
        Car c5 = new Car("fas");
        Car c6 = new Car("Dte");
        Car c7 = new Car("743");
        Car c8 = new Car("qwa");
        
//        controller.EnterCar(c1);
//        controller.EnterCar(c2);
//        controller.EnterCar(c3);
//        controller.EnterCar(c4);
//        controller.EnterCar(c5);
//        controller.EnterCar(c6);
//        controller.EnterCar(c7);
//        controller.EnterCar(c8);   

          System.out.println(controller.ExitCar(c1)); 
          System.out.println(controller.ExitCar(c2)); 
          System.out.println(controller.ExitCar(c3)); 
          System.out.println(controller.ExitCar(c4)); 
          System.out.println(controller.ExitCar(c5)); 
//          System.out.println(controller.ExitCar(c6)); 
//          System.out.println(controller.ExitCar(c7)); 
//          System.out.println(controller.ExitCar(c8)); 

        controller.writeLogRecord("D:\\GitRepository\\java-projects\\IOstreams_project\\docs\\CurrentparkingFolder\\logs.txt",controller.getLogs());
        controller.writeLogRecord("D:\\GitRepository\\java-projects\\IOstreams_project\\docs\\CurrentparkingFolder\\logsHistory.txt",controller.getLogsHistory());


        System.out.println("...." + "\n" + "View Current Parked Cars:");
        controller.getAllParkedCar().stream().forEach(s -> System.out.println(s.getCar().getPlateNumber() + " ,entryTime: " + s.getEnterTime() + " ,cost: " + (LocalDateTime.now().getSecond() - s.getEnterTime().getSecond())));
        System.out.println("Available Free Space: " + controller.availableFreeSpaces());
        
        System.out.println("...."+ "\n" + "View All Past Entries for a Car:");
        int totalCost = 0;
        logs = controller.getALlRecordsByCar("DEI");
        
        for(ParkingEventRecord s : logs){
            totalCost += s.getLeaveTime().getSecond() - s.getEnterTime().getSecond();
            System.out.println(s.getCar() + "," + s.getEnterTime() + ",cost: " + (s.getLeaveTime().getSecond() - s.getEnterTime().getSecond()));
        }
        System.out.println("totalCost:" + totalCost); 
        
        System.out.println("...."+ "\n" + "View All Unique Past Entries:");
        System.out.println(controller.getAllUniqueCar());
    }
}
