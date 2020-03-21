import java.util.Date;

/**
 * FoodItem
 */
public class FoodItem extends GenericItem {

    Date dateOfIncome;
    short expires;

    public FoodItem(String name, float price, FoodItem analog, Date date, short expires) {
        super(name, price, analog);
        dateOfIncome = date;
        this.expires = expires;
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
    void printAll() {
        super.printAll();
        System.out.printf("Date: %tD, expires: %d\n", dateOfIncome, expires);
    }
}