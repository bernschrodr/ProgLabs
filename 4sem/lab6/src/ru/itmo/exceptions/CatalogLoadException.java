package ru.itmo.exceptions;

public class CatalogLoadException extends RuntimeException {
    public CatalogLoadException(Throwable e){
        initCause(e);
    }
}
