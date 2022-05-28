package exercise4;


public class WithdrawMoney extends Transaction{
    
    private double amount;

    public WithdrawMoney(double amount, Account acc) {
        super(acc);
        this.amount = amount;
    }
    
    
     @Override
    public String execute(){
        if(amount < super.getAcc().getBalance()){
            super.getAcc().setBalance(super.getAcc().getBalance() - amount);
            return super.getAcc().getBalance() + " money left in your account";
        }
        else return "You don`t have enaugh money"; 
    }
    
}
