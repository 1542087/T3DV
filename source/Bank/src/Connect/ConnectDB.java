package Connect;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

import javax.swing.JOptionPane;

import Control.Account;

public class ConnectDB {
	static Connection conn = null;
	static ResultSet rs = null;
	public static String ConnectDatabase(String user, String pass) throws SQLException
	 {
		 String sql = "select * from Account where usern = ? and passw = ?";
		 try {
			 Class.forName("sun.jdbc.odbc.JdbcOdbcDriver");
			 String url = "jdbc:odbc:BankingManagement"; 
		     conn = DriverManager.getConnection(url,"",""); 
		     PreparedStatement ps = conn.prepareStatement(sql);
		     ps.setString(1, user);
		     ps.setString(2, pass);
		     if(rs.next())
		    	 return "welcom.jsp";
		     else
		    	 return "index.jsp";
		} catch (ClassNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
			 return "error.jsp";
		}

	 }
}
