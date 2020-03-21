import java.util.Date;

/**
 * Main
 */
public class Main {

    public static void main(String[] args) {
        GenericItem milkItem = new GenericItem();
        milkItem.ID = 1;
        milkItem.name = "milk";
        milkItem.price = (float) 52.13;

        GenericItem waterItem = new GenericItem();
        waterItem.ID = 2;
        waterItem.name = "water";
        waterItem.price = (float) 31;

        GenericItem meatItem = new GenericItem();
        meatItem.ID = 3;
        meatItem.name = "meat";
        meatItem.price = (float) 300;

        milkItem.printAll();
        waterItem.printAll();
        meatItem.printAll();

        FoodItem chipsItem = new FoodItem();
        chipsItem.ID = 4;
        chipsItem.name = "chips";
        chipsItem.price = (float) 49.9;
        chipsItem.expires = 80;
        chipsItem.dateOfIncome = new Date();

        TechnicalItem iphoneItem = new TechnicalItem();
        iphoneItem.ID = 5;
        iphoneItem.name = "Iphone";
        iphoneItem.price = 75000;
        iphoneItem.warrantyTime = 365;

        GenericItem[] arrayItems = { iphoneItem, chipsItem };

        for (GenericItem genericItem : arrayItems) {
            genericItem.printAll();
        }

        String line = "Конфеты ’Маска’;45;120";
        String[] item_fld = line.split(";");
        String name = item_fld[0];
        float price = Float.parseFloat(item_fld[1]);
        short expires = Short.parseShort(item_fld[2]);
        FoodItem food = new FoodItem(name, price, expires);
        food.printAll();
    }
}