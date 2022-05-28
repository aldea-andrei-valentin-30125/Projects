package exceptions.project;

import java.util.List;

public interface ControllerInterface {
 
    String MASTER_KEY = "MasterKeyValue";

    String MASTER_TENANT_NAME = "MasterTenant";

    /**
     * Lock / unlock door based on <param>pin</param> input
     * If pin is wrong, {@link InvalidPinException} exception will be thrown
     * If 3 consecutive entered pins are wrong, {@link TooManyAttemptsException} exception will be thrown
     * If {@link ControllerInterface#MASTER_KEY} is used as input value, number of retries will be reset to 0 and door will be locked / unlocked based on its current state
     *
     * @param pin - pin value
     * @return current {@link DoorStatus} status
     * @throws Exception
     */
    DoorStatus enterPin(String pin) throws Exception;


    void addTenant(String pin, String name) throws Exception;


    void removeTenant(String name) throws Exception;
    
    String getStatus();
    
    
    List<AccessLog> getAccessLogs();
}
