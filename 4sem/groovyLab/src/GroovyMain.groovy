class GroovyMain {
    int value
    String str
    long lng
    private def pr = "pr"

    GroovyMain(Binding binding) {
        value = binding.getProperty("value")
        str = binding.getProperty("str")
        lng = binding.getProperty("lng")
    }

    public static void main(String[] args) {
        println("Welcome,Groovy")
    }
    GroovyMain(int value,String str, long lng){
        this.value = value
        this.str = str
        this.lng = lng
    }

    Integer intFunc(){
        44 * 2
    }

    Integer testNull(Integer num){
        return num
    }

    int testNull2(Integer num){
        return num
    }

    @Override
    String toString() {
        return "$value $str $lng"
    }
}
