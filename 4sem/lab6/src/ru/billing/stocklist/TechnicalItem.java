package ru.billing.stocklist;

/**
 * TechnicalItem
 */
public class TechnicalItem extends GenericItem {

    private short warrantyTime;

    @Override
    public void printAll() {
        super.printAll();
        System.out.printf("Warranty Time: %d\n", warrantyTime);
    }

    @Override
    public String toString() {
        String str = String.format("Warranty Time: %d\n", warrantyTime);
        return super.toString() + str;
    }

    public short getWarrantyTime() {
        return warrantyTime;
    }

    public void setWarrantyTime(short warrantyTime) {
        this.warrantyTime = warrantyTime;
    }
}