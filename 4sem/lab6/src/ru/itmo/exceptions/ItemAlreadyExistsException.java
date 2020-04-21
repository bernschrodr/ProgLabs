package ru.itmo.exceptions;

public class ItemAlreadyExistsException extends Exception {
    public ItemAlreadyExistsException(Throwable e) {
        initCause(e);
    }
}
