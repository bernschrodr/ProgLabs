package ru.itmo.exceptions;

public class CatalogLoadException extends Exception {
    public CatalogLoadException(Throwable e){
        initCause(e);
    }
}
