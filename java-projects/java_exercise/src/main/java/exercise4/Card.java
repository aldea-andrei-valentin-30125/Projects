
package exercise4;


public class Card {
    private String cardID;
    private String pin;
    
    public Card(String cardID,String pin){
        this.cardID = cardID;
        this.pin = pin;
    }

    public String getCardID() {
        return cardID;
    }

    public String getPin() {
        return pin;
    }

    public void setPin(String pin) {
        this.pin = pin;
    }
    
    
    
}
