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
     <script src="js/newscript.js"></script>    
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
 <body>
     <div id="adv-search" style="margin-bottom: 40px">
          <form id="nlk-search-form" method="get" action="" target="_self">
            <div class="input-group">
              <input input id="nlk-search-str" name="s" type="text" maxlength="100"
                        class="form-control input-lg" placeholder="Mã Khách Hàng" required>
              <div class="input-group-btn">
                  <div class="btn-group"> 
                      <button type="button" class="btn btn-primary btn-lg" id="nlk-search-submit">
                          <span class="glyphicon glyphicon-search" style="height: 24px"></span>
                      </button> 
                      <button type="button" class="btn btn-default btn-lg dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><span class="caret"></span></button>
                        <ul class="dropdown-menu nlk-dropdown"> 
                            <li><a role="button" class="nlk-search-type" data-value="Mã Khách Hàng" data-action="/" data-param="s" data-target="_self">Mã Khách Hàng</a></li> 
                            <li><a role="button" class="nlk-search-type" data-value="Tên Khách Hàng" data-action="" data-param="q" data-target="_self">Tên Khách Hàng</a></li>
                        </ul>                            
                  </div>
              </div>

            </div>
          </form> 
        </div>   
         <div class="text-center" style="font-size: 20px; color:red; font-weight: bold; margin-left: 60px; margin-bottom: 20px">
            Danh Sách Khách Hàng
        </div>
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
            <p data-placement="top" data-toggle="tooltip" title="Edit">
                <div class="dropdown">
                    <button class="btn btn-primary dropdown-toggle" type="button" data-toggle="dropdown">
                    <span class="glyphicon glyphicon-pencil"></span>
                    </button>
                    <ul class="dropdown-menu">
                      <li><a href="#">1</a></li>
                      <li><a href="#">2</a></li>
                      <li><a href="#">3</a></li>
                    </ul>
                </div>
            </p>
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
    <td><p data-placement="top" data-toggle="tooltip" title="Edit">
                <div class="dropdown">
                    <button class="btn btn-primary dropdown-toggle" type="button" data-toggle="dropdown">
                    <span class="glyphicon glyphicon-pencil"></span>
                    </button>
                    <ul class="dropdown-menu">
                      <li><a href="#">1</a></li>
                      <li><a href="#">2</a></li>
                      <li><a href="#">3</a></li>
                    </ul>
                </div>
            </p></td>
    <td><p data-placement="top" data-toggle="tooltip" title="Delete"><button class="btn btn-danger btn-xs" data-title="Delete" data-toggle="modal" data-target="#delete" ><span class="glyphicon glyphicon-trash"></span></button></p></td>
  </tr>
    
   </tbody>
            
    </table> 
   
        <!-- phan trang -->
        <div class="row">
					<div class="col-md-12">
						<ul class="pagination pagination-sm pull-left">
							<li class="disabled"><a href="javascript:void(0)">«</a></li>
							<li class="active"><a href="javascript:void(0)">1 <span class="sr-only">(current)</span></a></li>
							<li><a href="#">2</a></li>
							<li><a href="#">3</a></li>
							<li><a href="#">4</a></li>
							<li><a href="#">5</a></li>
							<li><a href="javascript:void(0)">»</a></li>
						</ul>
					</div>
	</div>
        
    <jsp:include page="ThaydoiTT_KH.jsp"></jsp:include>
   
    <jsp:include page="Xoa_KH.jsp"></jsp:include>
    
 </body>
</html>

