package exceptions.project;

import java.util.ArrayList;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;

public class SafeHome {

    public static void main(String[] args) {
        
        ControllerInterface ctrl1;
        ControllerInterface ctrl = new DoorLockController();
        try {
            ctrl.addTenant("1234", "Aldea");
        } catch (Exception ex) {
            Logger.getLogger(SafeHome.class.getName()).log(Level.SEVERE, null, ex);
        }
        
        try {
            ctrl.addTenant("123", "Andrei");
        } catch (Exception ex) {
            Logger.getLogger(SafeHome.class.getName()).log(Level.SEVERE, null, ex);
        }
        
        try {
            ctrl.enterPin("123");
        } catch (Exception ex) {
            Logger.getLogger(SafeHome.class.getName()).log(Level.SEVERE, null, ex);
        }
        try {
            ctrl.enterPin("1234");
        } catch (Exception ex) {
            Logger.getLogger(SafeHome.class.getName()).log(Level.SEVERE, null, ex);
        }
        try {
            ctrl.enterPin("MasterKeyValue");
        } catch (Exception ex) {
            Logger.getLogger(SafeHome.class.getName()).log(Level.SEVERE, null, ex);
        }
        
        try {
            ctrl.removeTenant("Andrei");
        } catch (Exception ex) {
            Logger.getLogger(SafeHome.class.getName()).log(Level.SEVERE, null, ex);
        }
        
        
        for(AccessLog accessLog : ctrl.getAccessLogs()){
        System.out.println(accessLog);
        }
    }
}
