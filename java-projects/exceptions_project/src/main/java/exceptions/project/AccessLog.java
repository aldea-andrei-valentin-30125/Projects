package exceptions.project;

import java.time.LocalDateTime;

/**
 *
 * @author Aldea
 */
public class AccessLog {
    private Tenant tenantName;
    private LocalDateTime dateTime;
    private String operation;
    private DoorStatus doorStatus;
    private String errorMessage;

    public AccessLog(Tenant tenantName, LocalDateTime dateTime, String operation, DoorStatus doorStatus, String errorMessage) {
        this.tenantName = tenantName;
        this.dateTime = dateTime;
        this.operation = operation;
        this.doorStatus = doorStatus;
        this.errorMessage = errorMessage;
    }

    @Override
    public String toString() {
        return "AccessLog{" + "tenantName=" + tenantName.getName() + ", dateTime=" + dateTime + ", operation=" + operation + ", doorStatus=" + doorStatus + ", errorMessage=" + errorMessage + '}';
    }

}
