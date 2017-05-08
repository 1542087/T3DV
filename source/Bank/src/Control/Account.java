package Control;

import java.sql.SQLException;

import Connect.ConnectDB;

public class Account {
	private String username;
	private String password;
	public Account(String username, String password) {
		this.username = username;
		this.password = password;
	}
	public String getUsername() {
		return username;
	}
	public void setUsername(String username) {
		this.username = username;
	}
	public String getPassword() {
		return password;
	}
	public void setPassword(String password) {
		this.password = password;
	}
	public void validate()
    {
		try {
			ConnectDB.ConnectDatabase(username, password);
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
    }
	
}
