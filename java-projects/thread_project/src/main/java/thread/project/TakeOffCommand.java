
package thread.project;

/**
 *
 * @author Aldea
 */
public class TakeOffCommand extends AtcCommand {
    private int altitude;

    public TakeOffCommand(int altitude) {
        this.altitude = altitude;
    }

    public int getAltitude() {
        return altitude;
    }
    
}
