<%-- 
    Document   : ThaydoiTT_KH
    Created on : May 30, 2017, 10:33:27 PM
    Author     : Tien Vu Khach
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE   >
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Bank Management</title>
<link href="css/bootstrap.min.css" rel="stylesheet">
</head>
<body>
    <form accept-charset="ISO-8859-1" action="ThaydoiTT_KH">
<div class="modal fade" id="edit" tabindex="-1" role="dialog" aria-labelledby="edit" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true"><span class="glyphicon glyphicon-remove" aria-hidden="true"></span></button>
        <h4 class="modal-title custom_align" id="Heading">Thêm Thông Tin Khách Hàng</h4>
        </div>
          <div class="modal-body">
        <div class="form-group">
            <b>Mã Khách Hàng</b>
            <input class="form-control " type="text" placeholder="Mã Khách Hàng" id="maKH" name="maKH">
        </div>
            <b>Tên Khách Hàng</b>
            <div class="form-group">
            <input class="form-control " type="text" placeholder="Tên Khách Hàng" id="tenKH" name="tenKH">
        </div>
            <b>Giới Tính</b>
            <div class="form-group">
                <select class="form-control">
                    <option>Nam</option>
                    <option>Nữ</option>
                </select>
            </div>
        <b>Ngày Sinh</b>
        <div class="control-group">
                <div class="controls input-append date form_date" data-date="" data-date-format="dd MM yyyy" data-link-field="dtp_input2" data-link-format="yyyy-mm-dd">
                    <input size="16" type="text" value="" readonly>
                    <span class="add-on"><i class="icon-remove"></i></span>
                    <span class="add-on"><i class="icon-th"></i></span>
                </div>
                    <input type="hidden" id="dtp_input2" value="" /><br/>
        </div>
            <b>Địa Chỉ</b>
        <div class="form-group">
            <textarea rows="2" class="form-control" placeholder=" Địa Chỉ" id="diaChi" name="diaChi" ></textarea>
        </div>
        
        <b>Số Điện Thoại</b>
        <div class="form-group">
        <input class="form-control " type="text" placeholder="Số Điện Thoại" id="soDT" name="soDT">
        </div>

        </div>
        
          <div class="modal-footer ">
        <button type="button" class="btn btn-warning btn-lg" style="width: 100%;"><span class="glyphicon glyphicon-pencil"></span> Update</button>
      </div>
      </div>
    <!-- /.modal-content --> 
  </div>
      <!-- /.modal-dialog --> 
  </div>
</form>   
    
        <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="js/bootstrap.min.js"></script>
</body>
</html>