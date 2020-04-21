package ru.billing.stocklist;

/**
 * GenericItem
 */
public class GenericItem {

    private int ID; // ID товара
    private String name; // Наименование товара
    private float price; // Цена товара
    private ItemCategory category = ItemCategory.GENERAL;
    private GenericItem analog;
    private PriceCategory priceCategory;

    static int currentID = 1;

    public GenericItem(String name, float price, ItemCategory category) {
        this.name = name;
        this.price = price;
        setPriceCategory(price);
        this.category = category;
        this.ID = GenericItem.currentID++;
    }

    public GenericItem(String name, float price, GenericItem analog) {
        this.name = name;
        this.price = price;
        setPriceCategory(price);
        this.analog = analog;
        this.ID = GenericItem.currentID++;
    }

    public GenericItem() {
        this.ID = GenericItem.currentID++;
    }

    public void printAll() {

        System.out.printf("ID: %d , Name: %s , price:%5.2f , category:%s \n", ID, name, price, category);
    }

    @Override
    public String toString() {

        String str = String.format("ID: %d , Name: %s , price:%5.2f , category:%s \n", ID, name, price, category);
        return str;
    }

    private void setPriceCategory(float price){
        if (price < 100) {
            priceCategory = PriceCategory.CHEAP;
        } else {
            priceCategory = PriceCategory.EXPENSIVE;
        }
    }

    public PriceCategory getPriceCategory() {
        return priceCategory;
    }

    public GenericItem getAnalog() {
        return analog;
    }

    public void setAnalog(GenericItem analog) {
        this.analog = analog;
    }

    public ItemCategory getCategory() {
        return category;
    }

    public void setCategory(ItemCategory category) {
        this.category = category;
    }

    public int getID() {
        return ID;
    }

    public void setID(int ID) {
        this.ID = ID;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public float getPrice() {
        return price;
    }

    public void setPrice(float price) {
        this.price = price;
        setPriceCategory(price);
    }

}