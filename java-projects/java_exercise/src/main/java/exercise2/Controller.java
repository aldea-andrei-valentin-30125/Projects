package exercise2;


public class Controller implements Observer {

    @Override
    public void update(Observable o, Object event) {
        System.out.println("Sensor type: " + o.getClass().getSimpleName() +", value: " + event);          
    }   

}
