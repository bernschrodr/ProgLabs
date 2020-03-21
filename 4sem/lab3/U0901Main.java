public class U0901Main {
  public static void main(String[] args) {
    Integer intArr[] = { 10, 20, 15 };
    Float floatArr[] = new Float[10];
    String stringArr[] = new String[10];

    int min = 10;
    int max = 100;
    for (int i = 0; i < floatArr.length; i++) {
      floatArr[i] = min + (float) (Math.random() * max);
    }

    U0901WorkArray<Integer> insWorkArrayInt = new U0901WorkArray<Integer>(intArr);
    U0901WorkArray<Float> insWorkArrayFloat = new U0901WorkArray<Float>(floatArr);
    System.out.println(insWorkArrayFloat.sum());
    System.out.println(insWorkArrayInt.sum());

    // U0901WorkArray<String> insWorkArrayString = new
    // U0901WorkArray<String>(stringArr);

  }

}