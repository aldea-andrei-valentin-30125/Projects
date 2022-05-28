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
public class ComissionEmployee extends Employee{
    private double grossSales;
    private double comissionSales;

    public ComissionEmployee(double grossSales, double comissionSales, String firstName, String lastName) {
        super(firstName, lastName);
        this.grossSales = grossSales;
        this.comissionSales = comissionSales;
    }
    
    
    public double getPaymentAmount(){
        return grossSales * comissionSales;
        }
}
