public class Main {
    public static void main(String[] args) {
        System.out.println("Starting project");

        for (char c = 'a'; c <= 'z'; c++) {
            System.out.println(c);
        }

        long begin = new java.util.Date().getTime();
        for (long i = 0; i <= 100_000_000; i++) {
        }
        long end = new java.util.Date().getTime();
        System.out.println("time: " + (end - begin));

        begin = new java.util.Date().getTime();
        for (int i = 0; i <= 100_000_000; i++) {
        }
        end = new java.util.Date().getTime();
        System.out.println("time: " + (end - begin));
    }
}
