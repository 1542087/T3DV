<%String name=(String)session.getAttribute("username");

if(name==null)
{
    response.sendRedirect("index.jsp");
}

else
{
if(name.equals("admin"))
	{
		response.sendRedirect("register.jsp");
	}
%>
<link type="text/css" rel="stylesheet" href="../css/style.css"/>
<div id="container">
<jsp:include page="home-header.jsp"></jsp:include>

<div id="content-container">
<div id="content">
	<center>
	<marquee><h2 style="color: red;"><i>- Welcome <%=name%> -</i></h2></marquee><br/><br/>
	&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
	<img alt="home"  src="images/icon.jpg" width="550" height="400px"/>
	</center>
</div>

<div id="aside">
<p>Bank online.
</p>
</div>
</div>

<jsp:include page="footer.jsp"></jsp:include>
</div>
<%}%>