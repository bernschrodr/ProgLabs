class GroovyMain {
    int value
    String str
    long lng
    private def pr = "pr"

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
