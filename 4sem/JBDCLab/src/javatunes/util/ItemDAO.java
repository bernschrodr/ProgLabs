package javatunes.util;

import java.math.BigDecimal;
import java.sql.*;
import java.util.Collection;
import java.util.ArrayList;

public class ItemDAO {
    // connection to the database (assumed to be open)
    private Connection m_conn = null;

    //// PreparedStatement Lab ////
    //-- declare the PreparedStatement for searchByKeyword --//
    PreparedStatement pstmtSearchByKey = null;
    //// Update Lab ////
    //-- declare the PreparedStatement for create --//
    PreparedStatement pstmtCreate = null;

    static ArrayList<Integer> blockedIds = new ArrayList<Integer>();

    // constructor
    public ItemDAO(Connection conn) throws SQLException {
        // store the connection
        m_conn = conn;

        //// PreparedStatement Lab ////
        //-- define the ?-SQL for searchByKeyword --//
        String sqlSearchByKey = "SELECT * FROM GUEST.ITEM WHERE TITLE LIKE ?";

        //-- prepare the ?-SQL with the DBMS and initialize the PreparedStatement --//
        pstmtSearchByKey = m_conn.prepareStatement(sqlSearchByKey);

        //// Update Lab ////
        //-- define the ?-SQL for create --//
        String sqlCreate = "INSERT INTO GUEST.ITEM (TITLE, ARTIST, RELEASEDATE, LISTPRICE, PRICE, VERSION) VALUES (?, ?, ?, ?, ?, ?)";

        //-- prepare the ?-SQL with the DBMS and initialize the PreparedStatement --//
        pstmtCreate = m_conn.prepareStatement(sqlCreate);
    }


    //// DAO Lab ////
    public MusicItem searchById(Long id)
            throws SQLException {
        // declare return value
        MusicItem result = null;

        // declare JDBC objects
        Statement stmt = null;

        //-- build the SQL statement --//
        String sql = "SELECT * FROM GUEST.ITEM WHERE ITEM_ID = " + id.toString();

        try {
            //-- initialize the Statement object --//
            stmt = m_conn.createStatement();

            //-- execute the SQL statement, get a ResultSet back --//
            ResultSet rs = stmt.executeQuery(sql);

            //-- if ID found, extract data from the ResultSet and initialize the ItemValue return value --//
            //-- if ID not found, the return value remains null --//
            rs.next();
            if (rs.getRow() != 0) {
                result = new MusicItem(rs.getLong(1), rs.getString(2), rs.getString(3),
                        rs.getDate(4), rs.getBigDecimal(5), rs.getBigDecimal(6));
            }

        } finally {
            //-- close the Statement - this closes its ResultSet --//
            stmt.close();
        }

        // return the value object
        return result;
    }

    //// PreparedStaement Lab ////
    public Collection<MusicItem> searchByKeyword(String keyword)
            throws SQLException {
        // create storage for the results
        Collection<MusicItem> result = new ArrayList<MusicItem>();

        // create the %keyword% wildcard syntax used in SQL LIKE operator
        String likeKeyword = "%" + keyword + "%";

        //-- set the ? parameters on the PreparedStatement --//
        pstmtSearchByKey.setString(1, likeKeyword);

        //-- execute the PreparedStatement, get a ResultSet back --//
        ResultSet rs = pstmtSearchByKey.executeQuery();

        //-- iterate through the ResultSet, extracting data from each row and creating an ItemValue from it --//
        //-- add the ItemValue to the Collection via Collection's add method --//
        while (rs.next()) {
            result.add(new MusicItem(rs.getLong(1), rs.getString(2), rs.getString(3),
                    rs.getDate(4), rs.getBigDecimal(5), rs.getBigDecimal(6)));
        }

        // return the Collection
        return result;
    }


    //// Update Lab ////
    public void create(MusicItem item)
            throws SQLException {
        // Use the following releaseDate value in the  prepared statement for setDate
        java.sql.Date releaseDate = new java.sql.Date(item.getReleaseDate().getTime());
        //-- set the ? parameters on the PreparedStatement --//
        pstmtCreate.setString(1, item.getTitle());
        pstmtCreate.setString(2, item.getArtist());
        pstmtCreate.setDate(3, releaseDate);
        pstmtCreate.setBigDecimal(4, item.getListPrice());
        pstmtCreate.setBigDecimal(5, item.getPrice());
        pstmtCreate.setInt(6, 1);

        //-- execute the PreparedStatement - ignore the update count --//
        System.out.println(pstmtCreate.executeUpdate());
        m_conn.commit();
    }

    public void swap(int idFirst, int idSecond) throws SQLException {

        PreparedStatement statement = null;

        if (blockedIds.contains(idFirst) && blockedIds.contains(idSecond)) {
            for (var i = 0; i < 30; i++) {
                try {
                    Thread.sleep(1000);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
            }
        }

        blockedIds.add(idFirst);
        blockedIds.add(idSecond);


        m_conn.setAutoCommit(false);

        int buf = 0;
        if(idFirst < idSecond){
            buf = idSecond;
            idSecond = idFirst;
            idFirst = buf;
        }

        String firstId = "SELECT PRICE FROM GUEST.ITEM WHERE ITEM_ID = ?";
        String secondId = "SELECT PRICE FROM GUEST.ITEM WHERE ITEM_ID = ?";
        ResultSet rsFirstId;
        ResultSet rsSecondId;

        statement = m_conn.prepareStatement(firstId);
        statement.setInt(1, idFirst);
        rsFirstId = statement.executeQuery();
        rsFirstId.next();
        BigDecimal firstPrice = rsFirstId.getBigDecimal(1);

        statement = m_conn.prepareStatement(secondId);
        statement.setInt(1, idSecond);
        rsSecondId = statement.executeQuery();
        rsSecondId.next();
        BigDecimal secondPrice = rsSecondId.getBigDecimal(1);

        String finalSql = "UPDATE GUEST.ITEM SET PRICE = CASE" + " WHEN ITEM_ID = ? THEN " + secondPrice +
                " WHEN ITEM_ID = ? THEN " + firstPrice +
                " END" +
                " WHERE ITEM_ID IN (? , ?)";

        statement = m_conn.prepareStatement(finalSql);
        statement.setInt(1, idFirst);
        statement.setInt(2, idSecond);
        statement.setInt(3, idFirst);
        statement.setInt(4, idSecond);
        statement.executeUpdate();

        m_conn.commit();
        m_conn.setAutoCommit(true);

        blockedIds.removeIf(it -> it.intValue() == idFirst || it.intValue() == idSecond);

    }

    //// PreparedStatement and Update Labs ////
    public void close() {

        try {
            //// PreparedStatement Lab ////
            //-- close the PreparedStatement for searchByKeyword --//
            pstmtSearchByKey.close();

            //// Update Lab ////
            //-- close the PreparedStatement for create --//
            pstmtCreate.close();
        } catch (SQLException e) {
            JDBCUtilities.printSQLException(e);
        }
    }
}