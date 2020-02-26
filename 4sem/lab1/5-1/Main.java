public class Main {
    public static void main(String[] args) {
        System.out.println("Starting project");

        int[] mas = {12,43,12,-65,778,123,32,76};
        int buffer = Integer.MIN_VALUE;
        for(int i=0; i < mas.length; i++){
            if(buffer < mas[i]){
                buffer = mas[i];
            };
        }
        System.out.println("Max value: " + buffer);

    }
}
