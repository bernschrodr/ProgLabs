package ru.billing.stocklist;

public class Pair<K,V> {
    public K k;
    public V v;

    public Pair(K firstValue, V secondValue){
        k = firstValue;
        v = secondValue;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        Pair pair2 = (Pair) o;

        if (k != null ? !k.equals(pair2.k) : pair2.k != null) return false;
        if (v != null ? !v.equals(pair2.v) : pair2.v != null) return false;

        return true;
    }

    @Override
    public int hashCode() {
        int hash = 5;
        hash = hash + (this.k != null ? this.k.hashCode() : 0);
        hash = hash + (this.v != null ? this.v.hashCode() : 0);
        return hash;
    }

    public K getKey() {
        return k;
    }

    public V getValue() {
        return v;
    }
}
