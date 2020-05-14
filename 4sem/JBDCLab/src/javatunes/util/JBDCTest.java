package javatunes.util;

import java.sql.Connection;
import java.sql.DatabaseMetaData;
import java.sql.DriverManager;
import java.sql.SQLException;

public class JBDCTest {
    public static void main(String[] args) throws ClassNotFoundException, SQLException {
        Connection con = null;
        Class.forName("org.apache.derby.jdbc.ClientDriver");
        con = DriverManager.getConnection("jdbc:derby://localhost:1527/JavaTunesDB");
        DatabaseMetaData dbmd = con.getMetaData();
        System.out.println(dbmd.getDriverName());
        System.out.println(dbmd.getUserName());
        con.close();

    }
}
