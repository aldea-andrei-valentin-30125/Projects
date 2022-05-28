package thread.project;

import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Aldea
 */
public class Aircraft extends Thread{
    private final String id;
    private int altitude;
    private AtcCommand command;
    private Integer seconds = 0;
    private String state;
    
    public Aircraft(String id){
        this.id = id;
    }
    
    public void receiveAtcCommand(AtcCommand command){
       if(command.getClass().equals(TakeOffCommand.class)){
        TakeOff(command);
       }
       if(command.getClass().equals(LandCommand.class)){
        this.command = command;
       }
    }
    
    public synchronized void TakeOff(AtcCommand command){
        this.altitude = command.getAltitude();
        this.notify();
        this.command = command;
    }
  
    public String getStates(){
        return this.state;
    }
    
    public String getSeconds(){
        return this.seconds.toString();
    }
    
    @Override
    public synchronized void run(){
        state = "On State";
        System.out.println("Aircraft with id: " + this.id + " is On State");
        
        try {
            this.wait();
        } catch (InterruptedException ex) {
            Logger.getLogger(Aircraft.class.getName()).log(Level.SEVERE, null, ex);
        }
        
        state = "Taxing";
        System.out.println("Aircraft with id: " + this.id + " is Taxing");
        try {
            Thread.sleep(10*1000);
        } catch (InterruptedException ex) {
            Logger.getLogger(Aircraft.class.getName()).log(Level.SEVERE, null, ex);
        }
        
        state = "Taking Off";
        System.out.println("Aircraft with id: " + this.id + " is Taking Off");
        try {
            Thread.sleep(5*1000);
        } catch (InterruptedException ex) {
            Logger.getLogger(Aircraft.class.getName()).log(Level.SEVERE, null, ex);
        }
        
        state = "Ascending";
        System.out.println("Aircraft with id: " + this.id + " is Ascending");
        try {
            Thread.sleep(10*altitude);
        } catch (InterruptedException ex) {
            Logger.getLogger(Aircraft.class.getName()).log(Level.SEVERE, null, ex);
        }
        
        state = "Cruising";
        System.out.println("Aircraft with id: " + this.id + " is Cruising");
        
        while(!command.getClass().equals(LandCommand.class)){
            try {
                Thread.sleep(1000);
            } catch (InterruptedException ex) {
                Logger.getLogger(Aircraft.class.getName()).log(Level.SEVERE, null, ex);
            }
            this.seconds ++;    
        }
        
        state = "Descending";
        System.out.println("Aircraft with id: " + this.id +" is Descending");
        try {
            Thread.sleep(10*altitude);
        } catch (InterruptedException ex) {
            Logger.getLogger(Aircraft.class.getName()).log(Level.SEVERE, null, ex);
        }
        
        state = "Landed";
        System.out.println("Aircraft with id:" + this.id + " : " + this.seconds +" has Landed");
        System.out.println("Aircraft with id:" + this.id + " : " + this.seconds + " seconds in cruising");
        
    }
    
}
