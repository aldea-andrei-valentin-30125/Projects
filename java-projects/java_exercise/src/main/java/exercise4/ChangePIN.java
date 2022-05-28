
package exercise4;


public class ChangePIN extends Transaction {
    
    private String oldPin;
    private String newPin;

    public ChangePIN(String oldPin, String newPin, Account acc) {
        super(acc);
        this.oldPin = oldPin;
        this.newPin = newPin;
    }
    
   
    @Override
    public String execute(){
        if (super.getAcc().getC().getPin() == oldPin){
            super.getAcc().getC().setPin(newPin);
        }
        return "PIN change";
    }
    
}
