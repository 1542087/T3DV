
<center>
<form name="f2" action="loginBean.jsp" onsubmit="return check();" autocomplete="on"><br>
 	<table border="0" cellpadding="2" cellspacing="2" style="border:#000000 solid 2px; padding:5px; width: 391px">

	   <tr>
              <th colspan="3" bgcolor="#000000" scope="col"><font color="#FFFFFF">Customer Login</font></th>
              </tr>
	   <tr>
              <td width="24%">Username:</td>
              <td width="48%"><label>
              <input name="username" type="text" id="username" style="width: 233px; "/>
              </label></td>
     	</tr>
	    <tr>
              <td>Password:</td>
              <td><label>
                <input name="password" type="password" id="password" style="width: 231px; "/>
              </label></td>
        </tr>
        <tr>
              <td colspan="2"><label>
                
                    <div align="center">
                      <input name="Submit" type="submit" value="Login" />
                      <input name="Submit" type="reset" value="Login" />
                    </div>
                  </label></td>
       	</tr>
        <tr>
              <td colspan="3">Do you want to create a account? <a href="register.jsp">Click Here</a> </td>
        </tr>
	</table>
</form></center>