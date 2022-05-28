package exercise6;

public class Exercise6 {
    public static void main(String[] arg){
        
        ComissionEmployee angajatul1 = new ComissionEmployee(12054.34,0.21,"Andrei","Aldea");
        HourlyEmployee angajatul2 = new HourlyEmployee(12.24,165,"Medeea","Rachita");
        SalariedEmployee angajatul3 = new SalariedEmployee(1532.43,"Valentin","Popescu");
        
        System.out.println(angajatul1.getPaymentAmount());
        System.out.println(angajatul2.getPaymentAmount());
        System.out.println(angajatul3.getPaymentAmount());
        System.out.println("..............");
        
        Employee[] angajati = new Employee[6];
        angajati[0] = new ComissionEmployee(12054.34,0.21,"Andrei","Aldea");
        angajati[1] = new ComissionEmployee(3245.65,0.18,"Ghita","Oltean");
        angajati[2] = new HourlyEmployee(12.24,165,"Medeea","Rachita");
        angajati[3] = new HourlyEmployee(10.154,185,"Marcel","Hulpus");
        angajati[4] = new SalariedEmployee(2087.43,"Valentin","Popescu");
        angajati[5] = new SalariedEmployee(1287.43,"Ion","Popescu");
        
        double salary = 0.0;
        
        for(int i = 0;i < 6;i++){
        salary = salary + angajati[i].getPaymentAmount();
        System.out.println(angajati[i].getPaymentAmount());
        }
        System.out.println("Total salary = " + salary);
        } 
}
