package exceptions.project;

import java.util.Objects;

/**
 *
 * @author Aldea
 */
public class AccessKey {
    
    private String key;
 
    public AccessKey(String key){
        this.key = key;
    }

    @Override
    public int hashCode() {
        int hash = 3;
        hash = 59 * hash + Objects.hashCode(this.key);
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
        final AccessKey other = (AccessKey) obj;
        if (!Objects.equals(this.key, other.key)) {
            return false;
        }
        return true;
    }


}
