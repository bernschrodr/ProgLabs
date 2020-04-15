public class U0901Main {
  public static void main(String[] args) {
    Integer intArr[] = { 10, 20, 15 };
    Float floatArr[] = new Float[10];
    String stringArr[] = new String[10];
    Double doubleArr[] = new Double[10];
    Long longArr[] = new Long[2];

    int min = 10;
    int max = 100;

    longArr[0] = Long.MAX_VALUE - 1;
    longArr[1] = 1L;

    System.out.println(longArr[0]);
    System.out.println(longArr[1]);

    // U0901WorkArray<Integer> insWorkArrayInt = new
    // U0901WorkArray<Integer>(intArr);
    // U0901WorkArray<Float> insWorkArrayFloat = new
    // U0901WorkArray<Float>(floatArr);
    // U0901WorkArray<Double> insWorkArrayDouble = new
    // U0901WorkArray<Double>(doubleArr);
    U0901WorkArray<Long> insWorkArrayLong = new U0901WorkArray<Long>(longArr);
    // System.out.println(insWorkArrayFloat.sum());
    // System.out.println(insWorkArrayInt.sum());
    // System.out.println(insWorkArrayDouble.sum());
    var buf = insWorkArrayLong.sum();
    System.out.println(insWorkArrayLong.sum());

    // U0901WorkArray<String> insWorkArrayString = new U0901WorkArray<String>()
    // U0901WorkArray<String>(stringArr);

  }

}