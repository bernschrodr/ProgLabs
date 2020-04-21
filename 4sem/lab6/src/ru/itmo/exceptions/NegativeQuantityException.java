package ru.itmo.exceptions;

public class NegativeQuantityException extends Exception {
    public NegativeQuantityException(Throwable e){
        initCause(e);
    }
}
