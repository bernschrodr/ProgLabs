package javatunes.util;
import java.math.BigDecimal;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.Collection;
import java.util.Date;

public class ItemDAOMain {
    public static void main(String[] args) throws SQLException {
        MusicItem mi;
        Connection conn = null;

        conn = DriverManager.getConnection("jdbc:derby://localhost:1527/JavaTunesDB");
        System.out.println(conn.getTransactionIsolation());
        conn.setTransactionIsolation(4);
        System.out.println(conn.getTransactionIsolation());

        ItemDAO itemDAO = new ItemDAO(conn);
        mi = itemDAO.searchById(1L);
        System.out.println(mi.toString());

        try {
            mi = itemDAO.searchById(100L);
            System.out.println(mi.toString());
        }catch (Throwable e){
            System.out.println("Not Found");
        }

        Collection<MusicItem> cmi = itemDAO.searchByKeyword("Ray");
        System.out.println(cmi.toString());

/*
        MusicItem mi1 = new MusicItem(1L, "Middle Of The Summer", "Playboi Carti", new Date(120, 3, 2),
                BigDecimal.valueOf(90.0), BigDecimal.valueOf(50.0));
        itemDAO.create(mi1);*/

        cmi = itemDAO.searchByKeyword("Middle");
        System.out.println(cmi.toString());

//        String deleteSql = "DELETE FROM GUEST.ITEM WHERE TITLE = \'Middle\'";
//        Statement stmt = conn.createStatement();
//        stmt.executeUpdate(deleteSql);

        cmi = itemDAO.searchByKeyword("of");
        System.out.println(cmi.toString());

        System.out.println("BEFORE: ");
        System.out.println(itemDAO.searchById(1L));
        System.out.println(itemDAO.searchById(2L));
        itemDAO.swap(1,2);
        System.out.println("AFTER: ");
        System.out.println(itemDAO.searchById(1L));
        System.out.println(itemDAO.searchById(2L));
    }
}