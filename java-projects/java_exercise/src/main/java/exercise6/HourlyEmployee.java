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
public class HourlyEmployee extends Employee{
    private double wage;
    private double hours;

    public HourlyEmployee(double wage, double hours, String firstName, String lastName) {
        super(firstName, lastName);
        this.wage = wage;
        this.hours = hours;
    }
    
    
    public double getPaymentAmount(){
        return wage * hours;
        }
}
