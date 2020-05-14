import groovy.lang.Binding
import sun.misc.Unsafe

def firstclass = new GroovyMain(10, "HI", 455L)
println(firstclass)

def binding = new Binding()
binding.setVariable("value", 100)
binding.setVariable("str", "LLL")
binding.setVariable("lng", 222L)
def secclass = new GroovyMain(binding)

String str = ""
println(str instanceof Integer)

println(firstclass.intFunc())

//Part2
println(firstclass.testNull(null))
//println(firstclass.testNull2(null))

def dec1 = new BigDecimal(10)
def dec2 = new BigDecimal(10)

println(System.identityHashCode(dec2) == System.identityHashCode(dec1))

println(dec1.equals(dec2))
println("add: ${dec1.add(dec2)}")
println("+: ${dec1 + dec2}")
println("divide: ${dec1.divide(dec2)}")
println("/: ${dec1 / dec2}")
println("multiply: ${dec1.multiply(dec2)}")
println("*: ${dec1 * dec2}")

def variable = "f"
println(variable)
variable = 10
println(variable.getClass().getName())

Date february = new Date(1423353600L)
Date january = new Date(1422662400L)

Date result = february - january