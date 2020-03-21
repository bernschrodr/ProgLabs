/**
 * GenericItem
 */
public class GenericItem {

    public int ID; // ID товара
    public String name; // Наименование товара
    public float price; // Цена товара
    ItemCategory category = ItemCategory.GENERAL;
    GenericItem analog;
    static int currentID;

    public GenericItem(String name, float price, ItemCategory category) {
        this.name = name;
        this.price = price;
        this.category = category;
        this.ID = GenericItem.currentID++;
    }

    public GenericItem(String name, float price, GenericItem analog) {
        this.name = name;
        this.price = price;
        this.analog = analog;
        this.ID = GenericItem.currentID++;
    }

    public GenericItem() {
        this.ID = GenericItem.currentID++;
    }

    void printAll() {

        System.out.printf("ID: %d , Name: %s , price:%5.2f , category:%s \n", ID, name, price, category);
    }

}