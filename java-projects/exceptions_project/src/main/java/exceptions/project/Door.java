package exceptions.project;

import java.util.Objects;

/**
 *
 * @author Aldea
 */
public class Door {
    
    private DoorStatus status;
    
    public Door(){
       this.status = DoorStatus.CLOSE;
    }
    
    public void lockORunlockDoor(){
       if(this.status.equals(DoorStatus.OPEN)){
        status = DoorStatus.CLOSE;
       }else { status = DoorStatus.OPEN;}
    }
    
    public DoorStatus getStatus() {
        return status;
    }

    @Override
    public int hashCode() {
        int hash = 7;
        hash = 97 * hash + Objects.hashCode(this.status);
        return hash;
    }

    
    
    @Override
    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (obj == null) {
            return false;
        }
        if (getClass() != obj.getClass()) {
            return false;
        }
        final Door other = (Door) obj;
        if (this.status.toString().equals(other.status.toString())) {
            return true;
        }
        return true;
    }
    
    
    
}
