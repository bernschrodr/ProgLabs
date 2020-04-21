package sync;

public class U1901Bank {
    int intTo;
    int intFrom = 220;

    synchronized public void calc(int intTransaction, long lngTimeout) {
        System.out.println("before " + "To:" + intTo + " From:" + intFrom + " " + Thread.currentThread().getName());
        intFrom -= intTransaction;
        try {
            Thread.sleep(lngTimeout);
        } catch (Exception e) {
        }
        intTo += intTransaction;
        System.out.println("after " + "To:" + intTo + " From:   " + intFrom + " " + Thread.currentThread().getName());
    }
}
