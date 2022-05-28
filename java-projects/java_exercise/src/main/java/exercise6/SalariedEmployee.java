/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package exercise6;

/**
 *
 * @author Aldea
 */
public class SalariedEmployee extends Employee {
    private double weeklySalary;

    public SalariedEmployee(double weeklySalary, String firstName, String lastName) {
        super(firstName, lastName);
        this.weeklySalary = weeklySalary;
    }
    
    
    public double getPaymentAmount(){
        return weeklySalary;
        }
}
