package ru.itmo.exceptions;

public class NegativeQuantityException extends Exception {
    public NegativeQuantityException(String message){
        super(message);
    }
}
