package exercise4;

public abstract class Transaction {
    
    public Account acc;
    
    public Transaction(Account acc){
        this.acc = acc;
    }
    abstract String execute();

    public Account getAcc() {
        return acc;
    }
    
    
        
}
