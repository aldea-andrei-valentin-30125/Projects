package exercise2;

import java.util.ArrayList;
import java.util.List;

public class Observable {

   private List<Observer> observers = new ArrayList<Observer>();
 
   public void changeState(Observable o,Object event) {
      notifyAllObservers(o, event);
   }
 
   public void register(Observer observer) {
      observers.add(observer);		
   }
 
   private void notifyAllObservers(Observable o,Object event) {
      for (Observer observer : observers) {
         observer.update(o , event);
      }
   } 	
}

         

