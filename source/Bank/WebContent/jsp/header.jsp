<%String name=(String)session.getAttribute("username");%>
<div id="header">
<h1 align="center" colspan="2" scope="col" style="background-color:#2175bc; width:100%"; font-size: 30px">
	T3DV Bank
</h1>

</div>

	<div id="navigation">
		<ul>
                    
			<li><a href="index.jsp">Home</a></li>
						<%
                        if(name!=null)
                        {%>
                        <li> <a href="home.jsp">My Account</a></li>
                        <%}%>
                        
                       	
                        
			<li><a href="about.jsp">About</a></li>
			<li><a href="contact.jsp">Contact</a></li>
                        <%
                        if(name!=null)
                        {%>
                        <li> <a href="logout.jsp">Logout</a></li>
                        <%}%>
		</ul>
    
        
</div>
