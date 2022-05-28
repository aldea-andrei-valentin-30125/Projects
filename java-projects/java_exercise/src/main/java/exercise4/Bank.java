
package exercise4;

import java.util.ArrayList;
import java.util.List;


public class Bank {

    private List<Account> accountList;
    private List<Card> cardList;
    //private Transaction t;
    
    public Bank() {
        accountList = new ArrayList<>();
        cardList = new ArrayList<>();
        cardList.add(new Card("1","1111"));
        cardList.add(new Card("2","2222"));
        cardList.add(new Card("3","3333"));
        cardList.add(new Card("4","4444"));
        
        accountList.add(new Account("Aldea Andrei1",1204,cardList.get(0)));
        accountList.add(new Account("Aldea Andrei2",1634,cardList.get(1)));
        accountList.add(new Account("Aldea Andrei3",2504,cardList.get(2)));
        accountList.add(new Account("Aldea Andrei4",5214,cardList.get(3)));
       
    }
    
    public String executeTransaction(Transaction t){
        String ret;
        ret = t.execute();
        return ret;
    }
    
    public Account getAccount(String cardID){
        Card er = new Card("err","err");
        Account err = new Account("error",0,er);
        int i = 0;
        for(Card card : cardList){
            if(card.getCardID().equals(cardID)){
                err = accountList.get(i);} 
            i++;
        }
        return err;
    }

    @Override
    public String toString() {
        return "Bank{" + "accountList=" + accountList + ", cardList=" + cardList + '}';
    }

}
