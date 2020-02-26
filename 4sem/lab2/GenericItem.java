/**
 * GenericItem
 */
public class GenericItem {

    public int ID; // ID товара
    public String name; // Наименование товара
    public float price; // Цена товара
    ItemCategory category = ItemCategory.GENERAL;

    void printAll() {
        
        System.out.printf("ID: %d , Name: %s , price:%5.2f , category:%s \n", ID, name, price,category);
    }

}