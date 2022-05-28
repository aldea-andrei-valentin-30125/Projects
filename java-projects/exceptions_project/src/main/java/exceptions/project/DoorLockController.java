package exceptions.project;

import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class DoorLockController implements ControllerInterface{
    
    private Map<Tenant,AccessKey> validAccess = new HashMap<>();
    private List<AccessLog> accessLogList = new ArrayList<>();
    private Door door = new Door();
    private int numberOfTryes = 0;
    private Tenant master_tenant = new Tenant(MASTER_TENANT_NAME);
    private AccessKey master_key = new AccessKey(MASTER_KEY);

    @Override
    public DoorStatus enterPin(String pin) throws Exception {
        AccessKey key = new AccessKey(pin);
        if(pin.equals(MASTER_KEY)){
            numberOfTryes = 0;
            door.lockORunlockDoor();
            AccessLog accessLog = new AccessLog(master_tenant,LocalDateTime.now(),"enterPin",door.getStatus(),"-");
            accessLogList.add(accessLog); 
            return door.getStatus();
       }
        if(numberOfTryes < 2){
            if(validAccess.containsValue(key)){
                numberOfTryes = 0;
                door.lockORunlockDoor();
                AccessLog accessLog = new AccessLog(master_tenant,LocalDateTime.now(),"enterPin",door.getStatus(),"-");
                accessLogList.add(accessLog);
                return door.getStatus();
            }else{    
                numberOfTryes++;
                AccessLog accessLog = new AccessLog(master_tenant,LocalDateTime.now(),"enterPin",door.getStatus(),"InvalidPin");
                accessLogList.add(accessLog);
                throw new InvalidPinException();
            }
        }else{throw new TooManyAttemptsException();}
    }

    @Override
    public void addTenant(String pin, String name) throws Exception {
        Tenant tenant = new Tenant(name);
        AccessKey key = new AccessKey(pin);
               
            if(validAccess.containsKey(tenant)){
                AccessLog accessLog = new AccessLog(tenant,LocalDateTime.now(),"addTenant",door.getStatus(),"TenantAlreadyExists");
                accessLogList.add(accessLog); 
                throw new TenantAlreadyExistsException(); 
            }else{
                validAccess.putIfAbsent(tenant, key);
                AccessLog accessLog = new AccessLog(tenant,LocalDateTime.now(),"addTenant",door.getStatus(),"-");
                accessLogList.add(accessLog);
                }   
    }

    @Override
    public void removeTenant(String name) throws Exception {   
        Tenant tenant = new Tenant(name);
        
        if(validAccess.containsKey(tenant)){
            validAccess.remove(tenant);
            AccessLog accessLog = new AccessLog(tenant,LocalDateTime.now(),"removeTenant",door.getStatus(),"-");
            accessLogList.add(accessLog);
        }else{
            AccessLog accessLog = new AccessLog(tenant,LocalDateTime.now(),"removeTenant",door.getStatus(),"TenantNotFound");
            accessLogList.add(accessLog);
           throw new TenantNotFoundException();
        }
    }

    @Override
    public List<AccessLog> getAccessLogs() {
        return accessLogList;
    }

    @Override
    public String getStatus() {
        return door.getStatus().toString();
    }

}
