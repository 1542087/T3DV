<%-- 
    Document   : DSKhachHang
    Created on : May 30, 2017, 9:07:59 PM
    Author     : Tien Vu Khach
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Bank Management</title>

    <!-- Bootstrap -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
     <link href="css/style.css" rel="stylesheet" type="text/css">

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
    <style>
	table tr:nth-child(odd) td{
           background:#ccc;
	}
	table tr:nth-child(even) td{
				background:#FF9;
	}
    </style>
  </head>
  	<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
	<script src="http://getbootstrap.com/dist/js/bootstrap.min.js"></script>
	<script>
	$(document).ready(function(){
	$("#mytable #checkall").click(function () {
			if ($("#mytable #checkall").is(':checked')) {
				$("#mytable input[type=checkbox]").each(function () {
					$(this).prop("checked", true);
				});
	
			} else {
				$("#mytable input[type=checkbox]").each(function () {
					$(this).prop("checked", false);
				});
			}
		});
		
		$("[data-toggle=tooltip]").tooltip();
	});
    </script>
        <table id="mytable" class="table table-bordred table-hover" style="width: 850px;"> 
                 <thead style="background-color:#0C6">
                   <th><input type="checkbox" id="checkall" /></th>
                   <th>Mã Khách Hàng</th>
                   <th>Tên Khách Hàng</th>
                   <th>Giới Tính</th>
                   <th>Địa Chỉ</th>
                   <th>Số Điện Thoại</th>
                   <th>Ngày Sinh</th>
                   <th>Edit</th>
                   <th>Delete</th>
                 </thead>
    <tbody>
    
    <tr>
        <td><input type="checkbox" class="checkthis" /></td>
        <td>TK001</td>
        <td>Trần THành</td>
        <td>Nam</td>
        <td>Tphcm</td>
        <td>haz@gmail.com</td>
        <td>xxxxx</td>
        <td>
            <p data-placement="top" data-toggle="tooltip" title="Edit"><button class="btn btn-primary btn-xs" data-title="Edit" data-toggle="modal" data-target="#edit" ><span class="glyphicon glyphicon-pencil"></span></button></p>
        </td>
        <td>
            <p data-placement="top" data-toggle="tooltip" title="Delete"><button class="btn btn-danger btn-xs" data-title="Delete" data-toggle="modal" data-target="#delete" ><span class="glyphicon glyphicon-trash"></span></button></p>
        </td>
    </tr>
    
 <tr>
    <td><input type="checkbox" class="checkthis" /></td>
    <td>TK002</td>
    <td>Trần THành</td>
    <td>Nam</td>
    <td>Tphcm</td>
    <td>haz@gmail.com</td>
    <td>xxxxx</td>
    <td><p data-placement="top" data-toggle="tooltip" title="Edit"><button class="btn btn-primary btn-xs" data-title="Edit" data-toggle="modal" data-target="#edit" ><span class="glyphicon glyphicon-pencil"></span></button></p></td>
    <td><p data-placement="top" data-toggle="tooltip" title="Delete"><button class="btn btn-danger btn-xs" data-title="Delete" data-toggle="modal" data-target="#delete" ><span class="glyphicon glyphicon-trash"></span></button></p></td>
  </tr>
    
    
 <tr>
    <td><input type="checkbox" class="checkthis" /></td>
    <td>TK003</td>
    <td>Trần THành</td>
    <td>Nam</td>
    <td>Tphcm</td>
    <td>haz@gmail.com</td>
    <td>xxxxx</td>
    <td><p data-placement="top" data-toggle="tooltip" title="Edit"><button class="btn btn-primary btn-xs" data-title="Edit" data-toggle="modal" data-target="#edit" ><span class="glyphicon glyphicon-pencil"></span></button></p></td>
    <td><p data-placement="top" data-toggle="tooltip" title="Delete"><button class="btn btn-danger btn-xs" data-title="Delete" data-toggle="modal" data-target="#delete" ><span class="glyphicon glyphicon-trash"></span></button></p></td>
    </tr>
   </tbody>
            
    </table> 
   
    <jsp:include page="ThaydoiTT_KH.jsp"></jsp:include>
    <jsp:include page="Them_KH.jsp"></jsp:include>
    <jsp:include page="Xoa_KH.jsp"></jsp:include>
</html>

