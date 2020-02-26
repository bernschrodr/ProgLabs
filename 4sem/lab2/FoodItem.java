import java.util.Date;

/**
 * FoodItem
 */
public class FoodItem extends GenericItem {

    Date dateOfIncome;
    short expires;

    @Override
    void printAll() {
        super.printAll();
        System.out.printf("Date: %tD, expires: %d\n", dateOfIncome, expires);
    }
}