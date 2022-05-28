
package exercise7;

import java.util.Scanner;

public final class Singleton {
    private static volatile Singleton instance;
    private int credit;
    private Product[] a = new Product[5];

    private Singleton() {
    this.credit = 0;
        a[0] = new Product(123,"mere");
        a[1] = new Product(121,"pere");
        a[2] = new Product(323,"apa");
        a[3] = new Product(223,"lamai");
        a[4] = new Product(321,"ciocolata");
    }
    
    public void displayProducts(){
        for(int i= 0;i < 5;i++){
            System.out.println(a[i].toString());
        }
        System.out.println("");
    }
    
    public void insertCredit(int credit){
        this.credit += credit;
    }
    
    public void displayCredit(){
        System.out.println("Credit = " + this.credit + "\n");
    }
    
    public String selectProduct(int id){
        String ret = "error";
        for(int i= 0;i < 5;i++){
            if(a[i].id == id){
                ret  = a[i].name;
            }
        }
        return ret;
    }
    
    private void display(){
        System.out.println("Press 1 for : display product \n" +
                           "Press 2 for : insert credit \n" + 
                           "Press 3 for : display credit \n" + 
                           "Press 4 for : select product \n" + 
                           "Press 5 for : exit \n");  
        }        
    
    public void userMenu(){

        int op;
        int credit;
        int ok = 0;
        Scanner read = new Scanner(System.in);
        
    while(ok == 0)
    {
        display();
        op = read.nextInt();
        switch(op) {
            case 1: displayProducts();  
            break;
            case 2: {
                System.out.println("insert credit");
                credit = read.nextInt();
                insertCredit(credit);   
            }           
            break;
            case 3: displayCredit();
            break;
            case 4: {
                System.out.println("insert id");
                credit = read.nextInt();
                System.out.println(selectProduct(credit)+"\n");
            }
            break;
            case 5: ok = 1;
            break;
        }  
    }
    }
   
    public static Singleton getInstance() {
        if (instance == null) {
            synchronized (Singleton.class) {
                if (instance == null) {
                    instance = new Singleton();
                }
            }
        }
        return instance;
    }
}