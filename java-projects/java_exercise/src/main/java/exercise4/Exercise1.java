package exercise4;


public class Exercise1 {

    public static void main(String[] args) {
        //instantiati obiect
        //Teste
//        String s;
//        Bank b = new Bank();
//        Account a;
//        a = b.getAccount("1");
//        System.out.println(a);
//        System.out.println("..........");
//        
//        Transaction t = new WithdrawMoney(100,a);
//        s = b.executeTransaction(t);
//        System.out.println(s);
            
        Card card = new Card("1","1111");
        ATM atm = new ATM();
        atm.insertCard(card,"1111");
        atm.CheckMoney();
        atm.WithdrawMoney(100);
        atm.ChangePIN("1111","1234");
        atm.removeCard();
             
    }
}
