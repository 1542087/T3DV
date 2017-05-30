<%-- 
    Document   : main
    Created on : May 30, 2017, 9:05:03 PM
    Author     : Tien Vu Khach
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
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
    body{
		background-color: #FF9;
        }
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
<body style="background-color: #d9edf7">
<div class="container">
<div class="col-md-3 col-md-offset-10"><b>Xin chào User @@@  </b> | 
<a href="#" style="font-size:18px">Logout</a>
</div>
	<!-- header-->
<div class="row" style="margin-top:20px">
      <div class="col-md-12 panel-default">
       <!-- icon danh sach khach hang-->
          <div class="col-md-2 col-md-offset-1">
              <button name="themKH" id="themKH" type="button" class="btn btn-info btn-circle btn-xl"  style="padding:0px">
                  <img src="Images/custom_list.jpg" width="60px" height="60px" class="img-circle text-center"/>
              </button>
          	<span class="text-center"><br />Khách Hàng</span>
          </div> <!-- icon danh sach khach hang-->
          <!-- icon them khach hang-->
          <div class="col-md-3 col-md-offset-0">
              <button type="button" class="btn btn-info btn-circle btn-xl" data-title="Add" data-toggle="modal" data-target="#add" style="padding:0px; margin-left:20px">
                <img src="Images/customer_add.jpg" width="60px" height="60px" class="img-circle text-center"/>
              </button>
          	<span class="text-center"><br>Thêm Khách Hàng</span>
          </div> <!-- icon them khach hang-->
      </div>
 </div><!-- header-->
 <div class="row col-md-9"><!-- row content-->
    <!-- content-->
      <div class="col-md-9 col-sm-9 col-lg-9 col-md-offset-0 panel-default">

            <jsp:include page="DSKhachHang.jsp"></jsp:include>

      </div> <!-- content-->
 </div> <!-- row content-->
 <div class="row"><!-- row right-->
   <!-- right-->
   <div class="col-md-3 panel-default panel" style="width: 20%; 
        padding-top: 20px; padding-bottom: 20px; float: right ">
    	<div class="row">
            <div class="col-md-offset-3">
                  <button type="button" class="btn btn-info btn-squre" style="padding:0px">
                    <img src="Images/chuyentien.jpg" width="80px" height="80px" class="img-circle text-center"/>
                  </button><br />
               <b style="padding-left:20px">Chuyển Tiền</b>
              </div> <!-- icon chuyen tien-->
          
        </div>
        <!-- icon rut tien-->
        <div class="row" style="margin-top:20px">
            <div class="col-md-offset-3">
                  <button type="button" class="btn btn-info btn-squre" style="padding:0px">
                    <img src="Images/ruttien.jpg" width="80px" height="80px" class="img-circle text-center"/>
                  </button><br />
                <b style="padding-left:20px">Rút Tiền</b>
              </div> <!-- icon rut tien-->
          
        </div> <!-- icon so tiet kiem-->
        <div class="row" style="margin-top:20px">
            <div class="col-md-offset-3">
                  <button type="button" class="btn btn-info btn-squre" style="padding:0px">
                    <img src="Images/sotietkiem.jpg" width="80px" height="80px" class="img-circle text-center"/>
                  </button><br />
                <b style="padding-left:20px">Sổ Tiết Kiệm</b>
              </div> <!--  icon so tiet kiem-->
          
        </div>
        
    </div><!-- right-->
 </div>    <!-- row right-->
 <div class="clearfix"></div>
 <div class="row"><!-- footer-->
        <div class="col-md-12 panel-default heighfooter">
            Ngân Hàng T3DV - Chi nhánh TPHCM
            Design by @T3DV
        </div>
 </div><!-- footer-->

</body>
</html>