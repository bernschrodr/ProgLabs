import static java.util.Calendar.MONTH
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

Date february = new Date(2015,2,28)
Date january = new Date(2015,1,31)

def result = new Date(february.getTime() - january.getTime())
def prevMonth = result[MONTH] - 1
result.set(month :prevMonth)
def nextMonth = result[MONTH] + 1
result.set(month :nextMonth)
result.next()

println(result)

/// 3

def closureDivide = {
    a, b -> a / b
}

def closureMinus = {
    a, b -> a - b
}

def closureBoth = {
    a, b, c -> closureMinus(closureDivide(a, b), c)
}

println(closureBoth(1,4,5))