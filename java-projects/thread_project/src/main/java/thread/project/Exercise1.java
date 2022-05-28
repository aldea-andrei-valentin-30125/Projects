package thread.project;
import java.util.Scanner;

public class Exercise1 {
    
    
    public static void main(String[] args) {
        int cmd;
        Scanner read = new Scanner(System.in);
        
        //TEST
        System.out.println("Test");
        Aircraft a1 = new Aircraft("1234");
        AtcCommand c1 = new TakeOffCommand(1);
        AtcCommand c2 = new LandCommand();
        a1.start();
        do{
            cmd = read.nextInt();
            if(cmd == 1){
                a1.receiveAtcCommand(c1);
            }
            if(cmd == 2){
                a1.receiveAtcCommand(c2);
            }
  
        }while(cmd != 0);

    }
}
