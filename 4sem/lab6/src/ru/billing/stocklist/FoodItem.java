package ru.billing.stocklist;

import java.util.Date;

public class FoodItem extends GenericItem {

    private Date dateOfIncome;
    private short expires;

    public FoodItem(String name, float price, FoodItem analog, Date date, short expires) {
        super(name, price, analog);
        dateOfIncome = date;
        this.expires = expires;
        setCategory(ItemCategory.FOOD);
    }

    public FoodItem(String name, float price, short expires) {
        this(name, price, null, null, expires);
    }

    public FoodItem(String name) {
        this(name, (float) 0, null, null, (short) 360);
    }

    public FoodItem() {
        super();
    }

    @Override
    public void printAll() {
        super.printAll();
        System.out.printf("Date: %tD, expires: %d\n", dateOfIncome, expires);
    }

    @Override
    public String toString() {
        String str = String.format("Date: %tD, expires: %d\n", dateOfIncome, expires);
        return super.toString() + str;
    }

    public Date getDateOfIncome() {
        return dateOfIncome;
    }

    public void setDateOfIncome(Date dateOfIncome) {
        this.dateOfIncome = dateOfIncome;
    }

    public short getExpires() {
        return expires;
    }

    public void setExpires(short expires) {
        this.expires = expires;
    }
}