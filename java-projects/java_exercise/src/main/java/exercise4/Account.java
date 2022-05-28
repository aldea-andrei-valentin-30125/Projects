
package exercise4;

public class Account {
    private String owner;
    private double balance;
    private Card c;

    public Account(String owner, double balance, Card c) {
        this.owner = owner;
        this.balance = balance;
        this.c = c;
    }

    @Override
    public String toString() {
        return "Account{" + "owner=" + owner + ", balance=" + balance + ", c=" + c + '}';
    }

    public String getOwner() {
        return owner;
    }

    public double getBalance() {
        return balance;
    }

    public Card getC() {
        return c;
    }

    public void setBalance(double balance) {
        this.balance = balance;
    }
    
    
    
    
    
}
