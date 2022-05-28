package exceptions.project;

import java.util.Objects;

public class Tenant {
    
    private String name;

    public Tenant(String name) {
        this.name = name;
    }

    public String getName() {
        return name;
    }
    


    @Override
    public int hashCode() {
        int hash = 3;
        hash = 97 * hash + Objects.hashCode(this.name);
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
        final Tenant other = (Tenant) obj;
        if (!Objects.equals(this.name, other.name)) {
            return false;
        }
        return true;
    }

 
}
