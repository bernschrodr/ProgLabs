/**
 * TechnicalItem
 */
public class TechnicalItem extends GenericItem {

    short warrantyTime;

    @Override
    void printAll(){
        super.printAll();
        System.out.printf("Warranty Time: %d\n",warrantyTime);
    }
}