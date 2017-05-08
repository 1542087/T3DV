<%@ page contentType="text/html; charset=iso-8859-1" language="java" import="java.sql.*" errorPage="" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title>Bank Management</title>
<link type="text/css" rel="stylesheet" href="../css/style.css"/>
<script type="text/JavaScript">
</script>
</head>

<body>
<div id="container">
    <%String name=(String)session.getAttribute("username");
    session.setAttribute("contact_status","null");    			      					      			
    %>
<jsp:include page="header.jsp"></jsp:include>

<div id="content-container">
<div id="content">

	<marquee>
		<h2 style="color: red;">
			<i>
	            <%
	            if(name==null)
	            {%>
	                - Welcome T3DV Bank -
	            <%}
	            else
	            {%>
	            	- Welcome <%=name%> -
	            <%}%>
	         </i>
	   </h2>
	</marquee>
		<br/><br/>
		<center><img src="../images/icon.jpg" width="550" height="400px"/></center>
	</div>
	<div id="aside">
	    <%
	    if(name==null)
	    {%>
		<jsp:include page="login.jsp"></jsp:include>
	    <%}
	    else
	      {%>
	        <p>null</p>
	    <%}%>
	</div>
</div>
<jsp:include page="footer.jsp"></jsp:include>

</div>
</body>

</html>
