package exercise4;


public class CheckMoney extends Transaction{

    public CheckMoney(Account acc) {
        super(acc);
    }
    
     @Override
    public String execute(){
        return "You have: " + super.getAcc().getBalance();
    }
    
}
