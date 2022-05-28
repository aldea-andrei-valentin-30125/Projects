
package exercise4;

public class ATM {
    
    private Card card;
    private Account acc;
    private Bank bank = new Bank();
    
    public boolean insertCard(Card card,String pin){
        if (card.getPin().equals(pin)){
            this.card = card;
            this.acc = bank.getAccount(this.card.getCardID());
            //System.out.println(this.bank);
            return true;
        }else return false; 
    }
    
    public void WithdrawMoney(double amount){
        if (this.card != null){
            Transaction t = new WithdrawMoney(amount,acc);
            System.out.println(bank.executeTransaction(t));
        }
    }
    
    public void CheckMoney(){
        if (this.card != null){
            Transaction t = new CheckMoney(acc);
            System.out.println(bank.executeTransaction(t));
        }
    }
    
    public void ChangePIN(String oldPin,String newPin){
        if (this.card != null){
            Transaction t = new ChangePIN(oldPin,newPin,acc);
            System.out.println(bank.executeTransaction(t));
        }
    }
    
    public void removeCard(){
        this.card = null;
        this.acc = null;
    }

    public Card getCard() {
        return card;
    }

    public Account getAcc() {
        return acc;
    }

    public Bank getBank() {
        return bank;
    }
      
    
}
